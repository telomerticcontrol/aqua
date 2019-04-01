using System.Collections.Generic;
using System.Linq;
using Infragistics.Guidance.Aqua.DataClient.Common;
using Infragistics.Guidance.Aqua.DataClient.Data.ServiceMappers;
using Infragistics.Guidance.Aqua.Model;
using Infragistics.Guidance.Aqua.Model.Framework;
using SR = Infragistics.Guidance.Aqua.DataClient.MedicalService;

namespace Infragistics.Guidance.Aqua.DataClient.Data.ServiceRepositories
{

	public class PatientAdmittancesRepository : BaseRepository<Admittance, SR.Patient>
	{

		public PatientAdmittancesRepository()
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
		protected override IQueryable<SR.Patient> GetCollectionQuery(CommandCriteria criteria)
		{
			int patientId = criteria.GetIntValue("PatientId");
			return this.dataContext.DataSource.Patient.Expand("Admittances").Where(d => d.ID == patientId);
		}

		/// <summary>
		/// Select a colleciton of items from the data source
		/// </summary>
		/// <param name="criteria">Criteria for querying the data source</param>
		/// <returns>Collection of Item</returns>
		public override IEnumerable<Admittance> SelectCollection(CommandCriteria criteria)
		{

			IEnumerable<Admittance> result = null;

			SR.Patient patient = this.GetItemCollection(criteria).SingleOrDefault();
			if (patient != null)
			{
				result = new AdmittanceMapper().MapCollection(patient.Admittances);
			}

			return result;
		}

		#endregion

	}
}
