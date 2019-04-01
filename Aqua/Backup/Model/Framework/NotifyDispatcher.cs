using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infragistics.Guidance.Aqua.Model.Framework
{
	public class NotifyDispatcher
	{
		public NotifyDispatcher()
		{
        }

        #region Properties
        public BaseModel Receiver { get; set; }
		public string Field { get; set; }
        #endregion
        #region Methods
        public void Notify()
		{
			if (this.Receiver != null && this.Field != null)
			{
				this.Receiver.OnPropertyChanged(this.Field);
			}
        }
        #endregion

    }
}
