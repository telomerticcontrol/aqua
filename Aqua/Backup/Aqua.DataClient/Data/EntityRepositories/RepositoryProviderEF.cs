using Infragistics.Guidance.Aqua.DataClient.Common;

namespace Infragistics.Guidance.Aqua.DataClient.Data.EntityRepositories
{
	/// <summary>
	/// ADO.NET Entity Framework Repository Provider for the change patient command.
	/// Because of the complexity of the change patient command we saw better 
	/// performance with this approach then using DI to load all repositories.
	/// </summary>
	public class RepositoryProviderEF : IRepositoryProvider
	{
		public RepositoryProviderEF()
		{

		}

		public IRepository<T> GetRepository<T>(string alias)
		{

			IRepository<T> result = null;

			switch (alias)
			{
				case "AdmittanceRepository":
					result = new PatientAdmittancesRepositoryEF() as IRepository<T>;
					break;
				case "AlleryRepository":
					result = new AllergyRepositoryEF() as IRepository<T>;
					break;
				case "OrderRepository":
					result = new OrderRepositoryEF() as IRepository<T>;
					break;
				case "TestRepository":
					result = new TestRepositoryEF() as IRepository<T>;
					break;
				case "VitalRepository":
					result = new VitalRepositoryEF() as IRepository<T>;
					break;
				case "ClinicalNoteRepository":
					result = new ClinicalNoteRepositoryEF() as IRepository<T>;
					break;
			}

			return result;

		}

	}
}