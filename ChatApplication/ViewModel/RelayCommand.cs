﻿using System;
using System.Windows.Input;

namespace ChatApplication
{
    /// <summary>
    /// A basic command that runs an Action
    /// </summary>
    class RelayCommand : ICommand
    {

        #region Private Members
        /// <summary>
        /// Action to run
        /// </summary>
        private Action mAction;
        #endregion

        #region Public Events
        /// <summary>
        /// The event thats fired when the <see cref="CanExecute(object?)"/> value has changed
        /// </summary>
        public event EventHandler? CanExecuteChanged = (sender, e) => { };
        #endregion

        #region Constructor
        /// <summary>
        /// Default Constructor
        /// </summary>
        public RelayCommand(Action action)
        {
            mAction = action;
        }

        #endregion

        #region Command Methods

        /// <summary>
        /// A relay command can always execute
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object? parameter) { return true; }

        /// <summary>
        /// Executes the commands Action
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object? parameter)
        {
            mAction();
        }
        #endregion
    }
}
