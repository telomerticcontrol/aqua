using System.Linq;
using Infragistics.Guidance.Aqua.DataClient.Common;
using Infragistics.Guidance.Aqua.DataClient.Data.EntityMappers;
using Infragistics.Guidance.Aqua.Model;
using Infragistics.Guidance.Aqua.Model.Framework;
using EF = Infragistics.Guidance.Aqua.DataCommon.EntityData;

namespace Infragistics.Guidance.Aqua.DataClient.Data.EntityRepositories
{

	public class ComplaintRepositoryEF : BaseRepository<Complaint, EF.Admittance>
	{

		public ComplaintRepositoryEF()
		{
			this.dataContext = new EntityContext();
		}
        
		#region Overridden Methods

		/// <summary>
		/// Data Context
		/// </summary>
		/// <returns></returns>
		private EntityContext dataContext;
		protected override IDataContext DataContext
		{
			get { return this.dataContext; }
		}
        
		/// <summary>
		/// Get the ADO.NET DS Context for getting a collection of items.
		/// </summary>
		/// <param name="criteria">Command Criteria</param>
		/// <returns>Queryable Context for ADO.NET DS</returns>
		protected override IQueryable<EF.Admittance> GetCollectionQuery(CommandCriteria criteria)
		{
			int admittanceId = criteria.GetIntValue("AdmittanceId");
			return this.dataContext.DataSource.Admittance.Include("Complaints").Where(d => d.ID == admittanceId);
		}
        
		/// <summary>
		/// Select an item from the data source
		/// </summary>
		/// <param name="criteria">Criteria for querying the data source</param>
		/// <returns>Retrieved Item</returns>
		public override Complaint Select(CommandCriteria criteria)
		{

			Complaint result = new Complaint();
            
			EF.Admittance admittance = this.GetItem(criteria);

			if (admittance != null)
			{
				if (admittance.Complaints.Count > 0)
				{
					result = new ComplaintMapperEF().Map(admittance.Complaints.First());
				}
			}

			return result;
		}
        
		#endregion

	}
}
