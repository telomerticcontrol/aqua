using Infragistics.Guidance.Aqua.DataClient.Common;

namespace Infragistics.Guidance.Aqua.DataClient.Data.ServiceRepositories
{
	/// <summary>
	/// ADO.NET Data Service Repository Provider for the change patient command.
	/// Because of the complexity of the change patient command we saw better 
	/// performance with this approach then using DI to load all repositories.
	/// </summary>
	public class RepositoryProviderDS : IRepositoryProvider
	{

		public RepositoryProviderDS()
		{

		}

		public IRepository<T> GetRepository<T>(string alias)
		{

			IRepository<T> result = null;

			switch (alias)
			{
				case "AdmittanceRepository":
					result = new PatientAdmittancesRepository() as IRepository<T>;
					break;
				case "AlleryRepository":
					result = new AllergyRepository() as IRepository<T>;
					break;
				case "OrderRepository":
					result = new OrderRepository() as IRepository<T>;
					break;
				case "TestRepository":
					result = new TestRepository() as IRepository<T>;
					break;
				case "VitalRepository":
					result = new VitalRepository() as IRepository<T>;
					break;
				case "ClinicalNoteRepository":
					result = new ClinicalNoteRepository() as IRepository<T>;
					break;
			}

			return result;

		}

	}
}