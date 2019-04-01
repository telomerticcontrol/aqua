﻿using System.Collections.Generic;
using System.Linq;
using Infragistics.Guidance.Aqua.DataClient.Common;
using Infragistics.Guidance.Aqua.DataClient.Data.ServiceMappers;
using Infragistics.Guidance.Aqua.Model;
using Infragistics.Guidance.Aqua.Model.Framework;
using SR = Infragistics.Guidance.Aqua.DataClient.MedicalService;

namespace Infragistics.Guidance.Aqua.DataClient.Data.ServiceRepositories
{

	public class ClinicalNoteRepository : BaseRepository<ClinicalNote, SR.Admittance>
	{

		public ClinicalNoteRepository()
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
			return this.dataContext.DataSource.Admittance.Expand("ClinicalNotes").Where(d => d.ID == admittanceId);
		}

		/// <summary>
		/// Select a colleciton of items from the data source
		/// </summary>
		/// <param name="criteria">Criteria for querying the data source</param>
		/// <returns>Collection of Item</returns>
		public override IEnumerable<ClinicalNote> SelectCollection(CommandCriteria criteria)
		{
			IEnumerable<ClinicalNote> result = null;

			SR.Admittance admittance = this.GetItemCollection(criteria).SingleOrDefault();
			if (admittance != null)
			{
				result = new ClinicalNoteMapper().MapCollection(admittance.ClinicalNotes);
			}

			return result;

		}

		#endregion
	}
}
