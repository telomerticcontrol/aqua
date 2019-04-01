using System.Linq;
using Infragistics.Guidance.Aqua.DataClient.Common;
using Infragistics.Guidance.Aqua.Model;
using SR = Infragistics.Guidance.Aqua.DataCommon.EntityData;

namespace Infragistics.Guidance.Aqua.DataClient.Data.EntityMappers
{
	public class ComplaintMapperEF : BaseDataMapper<Complaint, SR.Complaint>
	{
		#region Overridden Methods

		/// <summary>
		/// Maps an item and returns it in a collection
		/// </summary>
		/// <param name="source">Source Class</param>
		/// <returns>Collection of Mapped items</returns>
		/// <remarks>This method is used to wrap a single entity into a collection</remarks>
		public Complaint MapToCollection(System.Data.Objects.DataClasses.EntityCollection<SR.Complaint> source)
		{
			Complaint complaint = null;

			if (source.Count > 0)
			{
				complaint = this.Map(source.First());
			}

			return complaint;
		}

		#endregion

		#region Overridden Methods
		
		/// <summary>
		/// Handles mapping a single model item
		/// </summary>
		/// <param name="source">Object(s) returned from the data source</param>
		/// <returns>Mapped Model Object(s)</returns>
		public override Complaint Map(SR.Complaint source)
		{
			return new Complaint
			{
				PatientComplaint = source.ComplaintTypeID,
			};
		}

		#endregion
	}
}
