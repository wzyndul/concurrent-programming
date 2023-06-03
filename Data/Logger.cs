using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Data
{
    internal class Logger : LoggerAbstract
    {
        private readonly string _pathToFile;
        private Task? LoggerTask;
        private readonly ConcurrentQueue<JObject> BallQueue = new();
        private readonly Mutex queueMutex = new();
        private readonly JArray DataArray;
        private readonly Mutex fileMutex = new();

        public Logger()
        {
            string PathToSave = Path.GetTempPath();
            _pathToFile = PathToSave + "ballsLogs.json";

            //If file doesnt exists create new one.
            if (File.Exists(_pathToFile))
            {
                try
                {
                    string input = File.ReadAllText(_pathToFile);
                    DataArray = JArray.Parse(input);
                    return;
                }
                catch (JsonReaderException)
                {
                    DataArray = new();
                }
            }

            DataArray = new();
            File.Create(_pathToFile);
        }

        public override void AddLogToSave(IDataBall ball)
        {
            queueMutex.WaitOne();
            try
            {
                JObject itemToAdd = JObject.FromObject(ball);
                itemToAdd["Time"] = DateTime.Now.ToString("HH:mm:ss");
                BallQueue.Enqueue(itemToAdd);

                if (LoggerTask == null || LoggerTask.IsCompleted)
                {
                    LoggerTask = Task.Factory.StartNew(this.LogToFile);
                }
            }
            finally
            {
                queueMutex.ReleaseMutex();
            }
        }

        private async Task LogToFile()
        {
            //Append logs until queue empty
            while (BallQueue.TryDequeue(out JObject ball))
            {
                DataArray.Add(ball);
            }

            // Convert data to string and save it
            string output = JsonConvert.SerializeObject(DataArray);

            fileMutex.WaitOne();
            try
            {
                File.WriteAllText(_pathToFile, output);
            }
            finally
            {
                fileMutex.ReleaseMutex();
            }
        }

        ~Logger()
        {
            fileMutex.WaitOne();
            fileMutex.ReleaseMutex();
        }
    }
}
