using Infragistics.Guidance.Aqua.DataClient.Common;
using Infragistics.Guidance.Aqua.Model;
using Infragistics.Guidance.Aqua.Model.Collections;
using Infragistics.Guidance.Aqua.Model.Framework;

namespace Infragistics.Guidance.Aqua.DataClient.Commands
{
	public class GetMedicationsCommand : BaseDataCommand<MedicationsCollection>
	{

		#region Overridden Methods
		
		/// <summary>
		/// Logic for the Medications Command
		/// </summary>
		/// <param name="criteria">Criteria for the command</param>
		/// <returns>Result from executing the command</returns>
		protected override object ProcessCommand(CommandCriteria criteria)
		{
			IRepository<Med> repository = DIManager.Current.Get<IRepository<Med>>("MedicationRepository");
			return new MedicationsCollection(repository.SelectCollection(criteria));
		}
		
		#endregion
		
	}
}
