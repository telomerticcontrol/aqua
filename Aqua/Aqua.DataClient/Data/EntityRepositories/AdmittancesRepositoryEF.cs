using System;
using System.Collections.Generic;
using System.Linq;
using Infragistics.Guidance.Aqua.DataClient.Common;
using Infragistics.Guidance.Aqua.DataClient.Data.EntityMappers;
using Infragistics.Guidance.Aqua.Model;
using Infragistics.Guidance.Aqua.Model.Framework;
using EF = Infragistics.Guidance.Aqua.DataCommon.EntityData;

namespace Infragistics.Guidance.Aqua.DataClient.Data.EntityRepositories
{

	public class AdmittancesRepositoryEF : BaseRepository<Admittance, EF.Admittance>
	{
        
		public AdmittancesRepositoryEF()
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
			return this.dataContext.DataSource.Admittance.Include(
				"Patient").Include("Complaints").Include("Staff").Include("Tests").Where(
				d => d.TimestampIn >= new DateTime(2009, 6, 25) && d.TimestampIn < new DateTime(2009, 6, 26));
		}

		/// <summary>
		/// Select a colleciton of items from the data source
		/// </summary>
		/// <param name="criteria">Criteria for querying the data source</param>
		/// <returns>Collection of Item</returns>
		public override IEnumerable<Admittance> SelectCollection(CommandCriteria criteria)
		{
			return new AdmittanceMapperEF().MapCollection(this.GetItemCollection(criteria));
		}
        
		#endregion
	}
}
