using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    internal class DataBall : IDataBall, INotifyPropertyChanged
    {
        private double _xPosition { get; set; }
        private double _yPosition { get; set; }
        private int _weight { get; }
        private double _xSpeed { get; set; }
        private double _ySpeed { get; set; }

        private bool _movedBall { get; set; }
        private SemaphoreSlim _semaphore = new SemaphoreSlim(1);
        private List<Task> _tasks;
        internal DataBall(double xPosition, double yPosition, int weight, double xSpeed = 0.0, double ySpeed = 0.0)
        {
            _xPosition = xPosition;
            _yPosition = yPosition;
            _xSpeed = xSpeed;
            _ySpeed = ySpeed;
            _weight = weight;
            Task.Run(StartMoving);
            _movedBall = false;
        }

        private void MoveBall()
        {
            XPosition += XSpeed;
            YPosition += YSpeed;
        }

        private async void StartMoving()
        {
            while (true)
            {
                //if (!_movedBall)
                //{
                //    await this._semaphore.WaitAsync();
                //    MoveBall();
                //    _semaphore.Release();
                //    await Task.Delay(10);
                //}


                // druga wersja
                lock (this)
                {
                    MoveBall();
                }
                await Task.Delay(10);

            }
        }

        public override void StopMoving()
        {
            bool isAllTasksCompleted = false;
           

            while (!isAllTasksCompleted)
            {
                isAllTasksCompleted = true;
                foreach (Task task in _tasks)
                {
                    if (!task.IsCompleted)
                    {
                        isAllTasksCompleted = false;
                        break;
                    }
                }
            }

            foreach (Task task in _tasks)
            {
                try
                {
                    task.Dispose();
                }
                catch (Exception ex) { }
            }
            _tasks.Clear();
        }


        // Properties 

        public override double XPosition
        {
            get => _xPosition;
            set
            {
                if (_xPosition != value)
                {
                    _xPosition = value;
                    RaisePropertyChanged(() => XPosition);
                }
            }
        }

        public override double YPosition
        {
            get => _yPosition;
            set
            {
                if (_yPosition != value)
                {
                    _yPosition = value;
                    RaisePropertyChanged(() => YPosition);
                }
            }
        }

        public override int Weight
        {
            get => _weight;
        }


        public override double XSpeed
        {
            get => _xSpeed;
            set
            {
                if (_xSpeed != value)
                {
                    _xSpeed = value;               
                }
            }
        }
        public override double YSpeed
        {
            get => _ySpeed;
            set
            {
                if (_ySpeed != value)
                {
                    _ySpeed = value;
                }
            }
        }

        public override event PropertyChangedEventHandler? PropertyChanged;
        private void RaisePropertyChanged<T>(Expression<Func<T>> propertyExpression)
        {
            if (propertyExpression.Body is MemberExpression memberExpression)
            {
                string propertyName = memberExpression.Member.Name;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}

