using System.Collections.Generic;
using System.Linq;
using Infragistics.Guidance.Aqua.DataClient.Common;
using Infragistics.Guidance.Aqua.DataClient.Data.EntityMappers;
using Infragistics.Guidance.Aqua.Model;
using Infragistics.Guidance.Aqua.Model.Framework;
using EF = Infragistics.Guidance.Aqua.DataCommon.EntityData;

namespace Infragistics.Guidance.Aqua.DataClient.Data.EntityRepositories
{
	class ChatResponsesRepositoryEF : BaseRepository<ChatResponse, EF.ChatResponses>
    {

		public ChatResponsesRepositoryEF()
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
		protected override IQueryable<EF.ChatResponses> GetCollectionQuery(CommandCriteria criteria)
		{
			return this.dataContext.DataSource.ChatResponses.Include("ChatRole");
		}

		/// <summary>
		/// Select a colleciton of items from the data source
		/// </summary>
		/// <param name="criteria">Criteria for querying the data source</param>
		/// <returns>Collection of Item</returns>
		public override IEnumerable<ChatResponse> SelectCollection(CommandCriteria criteria)
		{
			return new ChatResponseMapperEF().MapCollection(this.GetItemCollection(criteria));
		}


		#endregion

	}
}
