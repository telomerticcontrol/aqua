using System.Collections.Generic;
using System.Linq;
using Infragistics.Guidance.Aqua.DataClient.Common;
using Infragistics.Guidance.Aqua.DataClient.Data.EntityMappers;
using Infragistics.Guidance.Aqua.Model;
using Infragistics.Guidance.Aqua.Model.Framework;
using EF = Infragistics.Guidance.Aqua.DataCommon.EntityData;

namespace Infragistics.Guidance.Aqua.DataClient.Data.EntityRepositories
{

	public class AllergyRepositoryEF : BaseRepository<PatientAllergy, EF.Patient>
	{

		public AllergyRepositoryEF()
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
		protected override IQueryable<EF.Patient> GetCollectionQuery(CommandCriteria criteria)
		{
			int patientId = criteria.GetIntValue("PatientId");

			return this.dataContext.DataSource.Patient.Include("PatientAllergies.Allergy").Where(d => d.ID == patientId);
		}
        
		/// <summary>
		/// Select a colleciton of items from the data source
		/// </summary>
		/// <param name="criteria">Criteria for querying the data source</param>
		/// <returns>Collection of Item</returns>
		public override IEnumerable<PatientAllergy> SelectCollection(CommandCriteria criteria)
		{
			IEnumerable<PatientAllergy> result = null;

			EF.Patient patient =  this.GetItemCollection(criteria).SingleOrDefault();
			if (patient != null)
			{
				result = new AllergyMapperEF().MapCollection(patient.PatientAllergies);
			}

			return result;
		}

		#endregion
        
	}
}
