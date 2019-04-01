using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Infragistics.Guidance.Aqua.Model.Framework
{
	public abstract class BaseModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;

		public virtual void OnPropertyChanged(string propertyName)
		{
			PropertyChangedEventHandler handler = this.PropertyChanged;
			if (handler != null)
			{
				handler(this, new PropertyChangedEventArgs(propertyName));
			}
        }
        #endregion
        #region Methods
        protected void RegisterNotification<T>(CommandDispatcher<T> commandDispatcher, string field)
		{
			commandDispatcher.Dispatcher = new NotifyDispatcher { Receiver = this, Field = field };
        }
        #endregion
    }
}
