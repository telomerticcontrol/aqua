using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Threading;

namespace Infragistics.Guidance.Aqua.Model.Framework
{
	public class CommandDispatcher<T> : INotifyPropertyChanged
    {
        public CommandDispatcher(T value)
        {
            this.value = value;
        }

        public CommandDispatcher(IDataCommand<T> command)
            : this(command, new CommandCriteria())
        {
        }

        public CommandDispatcher(IDataCommand<T> command, CommandCriteria criteria)
        {
            this.command = command;
            this.criteria = criteria;
            this.value = default(T);
        }

        #region Fields
        private T value = default(T);
		private IDataCommand<T> command;
		private CommandCriteria criteria;
		private bool isExecuting = false;
        #endregion
        #region Properties
        public T Value
        {

            get
            {

                if (this.command != null && !this.isExecuting)
                {
                    this.isExecuting = true;
                    this.command.Execute(Command_Completed, this.criteria);
                }

                return this.value;
            }
        }
        public NotifyDispatcher Dispatcher { get; set; }
        #endregion
        #region Methods
        public static CommandDispatcher<T> Source<T>(IDataCommand<T> command)
        {
            return new CommandDispatcher<T>(command, new CommandCriteria());
        }

        public static CommandDispatcher<T> Source<T>(IDataCommand<T> command, CommandCriteria criteria)
        {
            return new CommandDispatcher<T>(command, criteria);
        }
        private void Command_Completed(T value)
        {
            this.command = null;
            this.value = value;
            this.OnPropertyChanged("Value");

            if (this.Dispatcher != null)
            {
                this.Dispatcher.Notify();
            }
        }
        #endregion
        #region INotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged(string propertyName)
		{
			PropertyChangedEventHandler handler = this.PropertyChanged;
			if (handler != null)
			{
				handler(this, new PropertyChangedEventArgs(propertyName));
			}
        }
        #endregion
    }

}
