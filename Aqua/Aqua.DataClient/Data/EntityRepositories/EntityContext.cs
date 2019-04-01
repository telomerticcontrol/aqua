using System.Collections.Generic;
using System.Configuration;
using System.Data.Objects;
using System.Linq;
using Infragistics.Guidance.Aqua.DataClient.Common;
using Infragistics.Guidance.Aqua.DataCommon.EntityData;

namespace Infragistics.Guidance.Aqua.DataClient.Data.EntityRepositories
{
	public class EntityContext : IDataContext
	{

		/// <summary>
		/// URI for the ADO.NET Data Services
		/// </summary>
		private string dataSeviceUri = string.Empty;

		private MedicalDataEntities medicalDataEntities;
        
		public EntityContext()
		{
			this.medicalDataEntities = new MedicalDataEntities();
		}

		public MedicalDataEntities DataSource
		{
			get { return this.medicalDataEntities; }
		}

		/// <summary>
		/// Read the ADO.NET Data Services server URI app setting 
		/// </summary>
		private void GetDataServiceUri()
		{
			this.dataSeviceUri = ConfigurationManager.AppSettings["DataServicesUri"];
		}
        
		/// <summary>
		/// Select a colleciton of items from the data source
		/// </summary>
		/// <returns>Collection of Item</returns>
		public IEnumerable<TQuery> ExecuteQuery<TQuery>(IQueryable<TQuery> query)
		{
			ObjectQuery<TQuery> service = query as ObjectQuery<TQuery>;
			return service.Execute(MergeOption.NoTracking);
		}

	}
}