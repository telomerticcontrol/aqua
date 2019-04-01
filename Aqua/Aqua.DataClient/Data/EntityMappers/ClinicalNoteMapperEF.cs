using Infragistics.Guidance.Aqua.DataClient.Common;
using Infragistics.Guidance.Aqua.Model;
using SR = Infragistics.Guidance.Aqua.DataCommon.EntityData;

namespace Infragistics.Guidance.Aqua.DataClient.Data.EntityMappers
{
	public class ClinicalNoteMapperEF : BaseDataMapper<ClinicalNote, SR.ClinicalNote>
	{
		#region Overridden Methods

		/// <summary>
		/// Handles mapping a single model item
		/// </summary>
		/// <param name="source">Object(s) returned from the data source</param>
		/// <returns>Mapped Model Object(s)</returns>
		public override ClinicalNote Map(SR.ClinicalNote source)
		{
			return new ClinicalNote
			{
				ID = source.ID,
				Note = source.Note,
				Timestamp = source.Timestamp.GetValueOrDefault(),
				ClinicalNoteType = new ClinicalNoteType
						{
							ID = source.ClinicalNoteTypeID.GetValueOrDefault(),
							Name = string.Empty
						}
			};
		}

		#endregion
	}
}
