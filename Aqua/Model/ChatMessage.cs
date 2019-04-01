using System;

namespace Infragistics.Guidance.Aqua.Model
{
	public class ChatMessage
	{

		public ChatMessage()
		{
		}

		public string UserName { get; set; }
		public string UserText { get; set; }
		public DateTime MessageTime { get; set; }
		public string ResponseText { get; set; }

		public string GetChatMessage(bool append, string responseUser)
		{
			string newLine = string.Empty;

			if (append)
			{
				newLine = "\n";
			}
					
			string userMessage = newLine + string.Format("\n {0} ({1}) \n {2}", this.UserName, this.FormatDate(this.MessageTime), this.UserText);
			string responseMessage = string.Format("\n\n {0} ({1}) \n {2}", responseUser, this.FormatDate(DateTime.Now), this.ResponseText);

			return userMessage + responseMessage;
		}

		private string FormatDate(DateTime dateToFormat)
		{
			return dateToFormat.ToShortDateString() + " " + dateToFormat.ToShortTimeString();
		}

	}
}
