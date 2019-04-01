using Infragistics.Guidance.Aqua.DataClient.Common;
using Infragistics.Guidance.Aqua.Model;
using SR = Infragistics.Guidance.Aqua.DataClient.MedicalService;

namespace Infragistics.Guidance.Aqua.DataClient.Data.ServiceMappers
{
	public class TestMapper : BaseDataMapper<Test, SR.Test>
	{

		#region Overridden Methods

		/// <summary>
		/// Handles mapping a single model item
		/// </summary>
		/// <param name="source">Object(s) returned from the data source</param>
		/// <returns>Mapped Model Object(s)</returns>
		public override Test Map(SR.Test source)
		{
            return new Test
            {
                Result = source.Result,
                
                BodyRegion = new BodyRegion
                    {
                        ID = source.BodyRegion.ID,
                        Name = source.BodyRegion.Name
                    },
                TestType = this.GetTestType(source.TestType),
                Timestamp = source.Timestamp.GetValueOrDefault()
            };
		}

		#endregion
		
		#region Private Methods

		/// <summary>
		/// Get a test type
		/// </summary>
		/// <param name="source">Source Class</param>
		/// <returns>Mapped Staff Type</returns>
		private TestType GetTestType(SR.TestType source)
		{
			TestType testType = null;

			if (source != null)
			{
				testType = new TestType
				{
					ID = source.ID,
					Name = source.Name,
					ResultType = source.ResultType,
					TestCategory = new TestCategory
					{
						ID = source.TestCategory.ID,
						Name = source.TestCategory.Name,
					}
				};
			}
			return testType;
		}

		#endregion

	}
}
