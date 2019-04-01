using Infragistics.Guidance.Aqua.DataClient.Common;
using Infragistics.Guidance.Aqua.Model;
using Infragistics.Guidance.Aqua.Model.Collections;
using Infragistics.Guidance.Aqua.Model.Framework;

namespace Infragistics.Guidance.Aqua.DataClient.Commands
{
	public class GetAdmittanceCommand : BaseDataCommand<AdmittanceCollection>
	{

		#region Overridden Methods

		/// <summary>
		/// Logic for the Get Admittance Command
		/// </summary>
		/// <param name="criteria">Criteria for the command</param>
		/// <returns>Result from executing the command</returns>
		protected override object ProcessCommand(CommandCriteria criteria)
		{
			IRepository<Admittance> repository = DIManager.Current.Get<IRepository<Admittance>>("AdmittanceRepository");
			return new AdmittanceCollection(repository.SelectCollection(criteria));
		}

		#endregion
	}
}
