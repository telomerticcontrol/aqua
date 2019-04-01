using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infragistics.Guidance.Aqua.Model.Framework
{
	public interface IDataCommand<T>
    {
        #region Methods
        void Execute(Action<T> callback, CommandCriteria criteria);
        #endregion
    }
}
