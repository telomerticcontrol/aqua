using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infragistics.Guidance.Aqua.Model.Framework
{
	public class CommandCriteria : Dictionary<string, object>
	{
		public CommandCriteria()
		{
        }

        #region Fields
        private static CommandCriteria emptyCommand;
        #endregion
        #region Properties
        public static CommandCriteria EmptyCommand
		{
			get
			{
				if (CommandCriteria.emptyCommand == null)
				{
					CommandCriteria.emptyCommand = new CommandCriteria();

				}

				return CommandCriteria.emptyCommand;
			}
        }
        #endregion
        #region Methods
        public bool IsValidKey(string key)
		{
			return this.ContainsKey(key);
		}

		public string GetValue(string key)
		{
			string result = string.Empty;

			if (this.IsValidKey(key))
			{
				result = this[key].ToString();
			}

			return result;
		}

		public int GetIntValue(string key)
		{
			int result = 0;

			if (this.IsValidKey(key))
			{
				int.TryParse(this[key].ToString(), out result);
			}

			return result;
        }
        #endregion
    }
}
