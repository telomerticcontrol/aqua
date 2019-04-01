using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using Infragistics.Guidance.Aqua.DataClient.Misc;
using System.Collections;
using System.Text.RegularExpressions;

namespace Infragistics.Guidance.Aqua.Model.Collections
{
    public class ChatResponseCollection:ObservableCollection<ChatResponse>
    {
        public ChatResponseCollection(IEnumerable<ChatResponse> source)
            : base(source)
        { }
        public ChatResponseCollection()
            : base()
        { }

        #region Methods
        public string GetResponseByRole(string Role)
        {
            ChatRoleType chatRoleType = GetChatRole(Role);
            
            int ChatRoleID = (int)chatRoleType +1;
            var responses = from chatResponse in this.Items where chatResponse.ChatRole.ID == ChatRoleID select chatResponse;                          
            
            if (chatRoleType == ChatRoleType.Default)
            {
                return responses.First().Response;
            }
            Random r = new Random();
            ChatResponseCollection chatResponses = new ChatResponseCollection(responses);
            return chatResponses[r.Next(0, 4)].Response;
        }
        private ChatRoleType GetChatRole(string strRole)
        {
           
            foreach (ChatRoleType crt in Enum.GetValues(typeof(ChatRoleType)))
            {                
                if (crt.ToString().Contains(Regex.Replace(strRole, @"\s", "")))
                {
                    return crt;
                }
            }
            return ChatRoleType.Default;
        }
        #endregion
    }
}
