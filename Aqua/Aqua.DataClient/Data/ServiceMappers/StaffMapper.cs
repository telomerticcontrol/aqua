using System.Collections.Generic;
using System.Linq;
using Infragistics.Guidance.Aqua.DataClient.Common;
using Infragistics.Guidance.Aqua.Model;
using Infragistics.Guidance.Aqua.Model.Collections;
using SR = Infragistics.Guidance.Aqua.DataClient.MedicalService;

namespace Infragistics.Guidance.Aqua.DataClient.Data.ServiceMappers
{
	public class StaffMapper : BaseDataMapper<Staff, SR.Staff>
	{
		
		#region Public Methods

		/// <summary>
		/// Maps an item and returns it in a collection
		/// </summary>
		/// <param name="source">Source Class</param>
		/// <returns>Collection of Mapped items</returns>
		/// <remarks>This method is used to wrap a single entity into a collection</remarks>
		public HospitalStaffCollection MapToCollection(SR.Staff source)
		{
			HospitalStaffCollection staff = new HospitalStaffCollection();

			if (source != null)
			{
				staff.Add(this.Map(source));
			}
			return staff;
		}

		#endregion
		
		#region Overridden Methods
		
		/// <summary>
		/// Handles mapping a single model item
		/// </summary>
		/// <param name="source">Object(s) returned from the data source</param>
		/// <returns>Mapped Model Object(s)</returns>
		public override Staff Map(SR.Staff source)
		{
			return new Staff
			{
				ID = source.ID,
				FirstName = source.FirstName,
				LastName = source.LastName,
				MiddleName = source.MiddleName,
				Speciality = source.Speciality,
				StaffType = this.GetStaffType(source),
				Suffix = source.Suffix,
				Title = source.Title
			};
		}


		#endregion
		
		#region Private Methods

		/// <summary>
		/// Get a staff type
		/// </summary>
		/// <param name="source">Source Class</param>
		/// <returns>Mapped Staff Type</returns>
		private StaffType GetStaffType(SR.Staff source)
		{
			StaffType staffType = new StaffType();
			if (source.StaffType != null)
			{
				staffType.ID = source.StaffType.ID;
				staffType.Name = source.StaffType.Name;
			}
			return staffType;
		}

		#endregion
		
	}
}
