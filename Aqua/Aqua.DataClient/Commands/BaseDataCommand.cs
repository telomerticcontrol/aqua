using System;
using System.ComponentModel;
using System.Configuration;
using Infragistics.Guidance.Aqua.Model.Framework;

namespace Infragistics.Guidance.Aqua.DataClient.Commands
{
	/// <summary>
	/// Base Command Class Used for Retreaving Data for the application
	/// </summary>
	/// <typeparam name="T">The main model class returned from the command</typeparam>
	/// <remarks>Based on RunCommandsAsync app config setting the command will use a background worker thread.</remarks>
	public abstract class BaseDataCommand<T> : IDataCommand<T>
	{
		#region Fields

		// Method called when the command is completed
		private Action<T> callback;

		// Should the command uses a background worked thread
		private bool runsCommandsAsyc = true; 

		#endregion

		#region Constructors

		/// <summary>
		/// Base class constructor
		/// </summary>
		public BaseDataCommand()
		{
			this.CheckAsyncAppSetting();
		}

		#endregion

		#region Public Methods

		/// <summary>
		/// Processor Method for executing a command
		/// </summary>
		/// <param name="callback">Callback Method</param>
		/// <param name="criteria">Criteria for the Command</param>
		/// <remarks>This method will happen AYSNC when the RunAsync App setting is true.</remarks>
		public void Execute(Action<T> callback, CommandCriteria criteria)
		{
			this.callback = callback;

			if (this.runsCommandsAsyc)
			{
				this.RunAsyncProcess(criteria);
			}
			else
			{
				this.RunSyncCommand(criteria);
			}

		}

		#endregion

		#region Private Methods

		/// <summary>
		/// Read the app setting to detemine if the command runs in ASYNC mode.
		/// </summary>
		private void CheckAsyncAppSetting()
		{
			string configSetting = ConfigurationManager.AppSettings["RunCommandsAsync"];
			if (configSetting != null)
			{
				bool.TryParse(configSetting, out this.runsCommandsAsyc);
			}
		}

		/// <summary>
		/// Use a Background worker thread to ASYNC execute the command.
		/// </summary>
		/// <param name="criteria">Criteria for the command</param>
		private void RunAsyncProcess(CommandCriteria criteria)
		{
			BackgroundWorker worker = new BackgroundWorker();
			worker.DoWork += new DoWorkEventHandler(worker_DoWork);
			worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
			worker.RunWorkerAsync(criteria);
		}

		/// <summary>
		/// Background worker thread callback method
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			this.Notify((T)e.Result);
		}

		/// <summary>
		/// Main processing logic - Executes Asynchronosly
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void worker_DoWork(object sender, DoWorkEventArgs e)
		{
			CommandCriteria criteria = e.Argument as CommandCriteria;
			e.Result = this.ProcessCommand(criteria);
		}

		/// <summary>
		/// Main processing logic - Executes Synchronously
		/// </summary>
		/// <param name="criteria"></param>
		private void RunSyncCommand(CommandCriteria criteria)
		{
			this.Notify((T)this.ProcessCommand(criteria));
		}

		/// <summary>
		/// Notify the command caller that the command is done executing.
		/// </summary>
		/// <param name="result">Result to return to the caller</param>
		private void Notify(T result)
		{
			if (this.callback != null)
			{
				this.callback.Invoke(result);
			}
		}
		
		#endregion
		
		#region Abstract Methods

		/// <summary>
		/// Abstract processing method. Each command overrides and performs its own logic.
		/// </summary>
		/// <param name="criteria">Criteria for the command</param>
		/// <returns>Result from executing the command</returns>
		protected abstract object ProcessCommand(CommandCriteria criteria);

		#endregion
		
	}
}
