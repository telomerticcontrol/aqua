using System.Linq;
using Infragistics.Guidance.Aqua.DataClient.Common;
using Infragistics.Guidance.Aqua.DataClient.Data.ServiceMappers;
using Infragistics.Guidance.Aqua.Model;
using Infragistics.Guidance.Aqua.Model.Framework;
using SR = Infragistics.Guidance.Aqua.DataClient.MedicalService;

namespace Infragistics.Guidance.Aqua.DataClient.Data.ServiceRepositories
{

	public class ComplaintRepository : BaseRepository<Complaint, SR.Admittance>
	{

		public ComplaintRepository()
		{
			this.dataContext = new DSContext();
		}

		#region Overridden Methods

		/// <summary>
		/// Data Context
		/// </summary>
		/// <returns></returns>
		private DSContext dataContext;
		protected override IDataContext DataContext
		{
			get { return this.dataContext; }
		}

		/// <summary>
		/// Get the ADO.NET DS Context for getting a collection of items.
		/// </summary>
		/// <param name="criteria">Command Criteria</param>
		/// <returns>Queryable Context for ADO.NET DS</returns>
		protected override IQueryable<SR.Admittance> GetCollectionQuery(CommandCriteria criteria)
		{
			int admittanceId = criteria.GetIntValue("AdmittanceId");
			return this.dataContext.DataSource.Admittance.Expand("Complaints").Where(d => d.ID == admittanceId);
		}

		/// <summary>
		/// Select an item from the data source
		/// </summary>
		/// <param name="criteria">Criteria for querying the data source</param>
		/// <returns>Retrieved Item</returns>
		public override Complaint Select(CommandCriteria criteria)
		{

			Complaint result = new Complaint();

			SR.Admittance admittance = this.GetItem(criteria);

			if (admittance != null)
			{
				if (admittance.Complaints.Count > 0)
				{
					result = new ComplaintMapper().Map(admittance.Complaints.First());
				}
			}

			return result;
		}

		#endregion

	}
}
