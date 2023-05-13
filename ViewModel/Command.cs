﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace ViewModel
{
    public class Command : ICommand
    {
        private readonly Action _execute;
        private readonly Func<bool>? _canExecute;

        public Command(Action execute, Func<bool>? canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public bool CanExecute(object? parameter)
        {
            if (_canExecute == null)
                return true;
            return _canExecute();
        }

        public void Execute(object? parameter)
        {
            _execute();
        }

        public event EventHandler? CanExecuteChanged;

        internal void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}