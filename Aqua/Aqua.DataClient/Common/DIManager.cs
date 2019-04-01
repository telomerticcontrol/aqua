using System.Configuration;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace Infragistics.Guidance.Aqua.DataClient.Common
{
	public class DIManager
	{
		private static DIManager manager;

		private IUnityContainer repositoryContainer;

		private DIManager()
		{
			this.InitializeContainer();
		}

		public static DIManager Current
		{
		
			get
			{
				if (DIManager.manager == null)
				{
					DIManager.manager = new DIManager();
				}

				return DIManager.manager;
			}
		}

		private void InitializeContainer()
		{
			this.repositoryContainer = new UnityContainer();

			UnityConfigurationSection section = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
			section.Containers.Default.Configure(this.repositoryContainer);
		}

		public T Get<T>()
		{
			return this.repositoryContainer.Resolve<T>();
		}

		public T Get<T>(string name)
		{
			return this.repositoryContainer.Resolve<T>(name);
		}
	}
}
