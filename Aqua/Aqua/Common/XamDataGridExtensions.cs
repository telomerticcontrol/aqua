using Infragistics.Windows.DataPresenter;

namespace Infragistics.Guidance.Aqua.Client.Common
{
	public static class XamDataGridExtensions
	{
		public static Record GetActiveRecord(this XamDataGrid  control)
		{
			Record activeRecord = null;

			if (control.Records != null && control.Records.Count > 0)
			{
				activeRecord = control.Records[0];
			}

			return activeRecord;
		}
	}

}
