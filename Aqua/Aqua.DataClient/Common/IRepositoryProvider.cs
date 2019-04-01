
namespace Infragistics.Guidance.Aqua.DataClient.Common
{
	/// <summary>
	/// This is used to abstract away multi repositories. Because of the complexity of the change patient
	/// command we saw better performance with this approach then using DI to load all repositories.
	/// </summary>
	public interface IRepositoryProvider
	{
		IRepository<T> GetRepository<T>(string alias);
	}
}