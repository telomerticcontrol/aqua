using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Services.Client;
using System.Linq;
using Infragistics.Guidance.Aqua.DataClient.Common;
using Infragistics.Guidance.Aqua.DataClient.MedicalService;

namespace Infragistics.Guidance.Aqua.DataClient.Data.ServiceRepositories
{
	public class DSContext : IDataContext
	{

		#region Fields

		/// <summary>
		/// URI for the ADO.NET Data Services
		/// </summary>
		private string dataSeviceUri = string.Empty;

		#endregion

		private MedicalDataEntities medicalDataEntities;

		public DSContext()
		{
			this.InitializeDataService();
		}

		public MedicalDataEntities DataSource
		{
			get { return this.medicalDataEntities; }
		}

		/// <summary>
		/// Initialize ADO.NET Data Services Context;
		/// </summary>
		private void InitializeDataService()
		{
			string dataSeviceUri = ConfigurationManager.AppSettings["DataServicesUri"];
			this.medicalDataEntities = new MedicalDataEntities(new Uri(dataSeviceUri));
		}
        
		/// <summary>
		/// Select a colleciton of items from the data source
		/// </summary>
		/// <returns>Collection of Item</returns>
		public IEnumerable<TQuery> ExecuteQuery<TQuery>(IQueryable<TQuery> query)
		{
			DataServiceQuery<TQuery> service = query as DataServiceQuery<TQuery>;
			return service.Execute();
		}

	}
}