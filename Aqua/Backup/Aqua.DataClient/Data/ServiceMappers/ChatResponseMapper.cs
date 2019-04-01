using Infragistics.Guidance.Aqua.DataClient.Common;
using Infragistics.Guidance.Aqua.Model;
using Infragistics.Guidance.Aqua.Model.Framework;
using SR = Infragistics.Guidance.Aqua.DataClient.MedicalService;

namespace Infragistics.Guidance.Aqua.DataClient.Data.ServiceMappers
{
    class ChatResponseMapper: BaseDataMapper<ChatResponse, SR.ChatResponses>
    {
        public override ChatResponse Map(SR.ChatResponses source)
        {
            CommandCriteria chatResponseCriteria = new CommandCriteria();
            //chatResponseCriteria.Add("AdmittanceId", source.ID.ToString());

            return new ChatResponse()
            {
                ID = source.ID,
                Response = source.Response,
                ChatRole = new ChatRole() 
                {
                    ID = source.ChatRole.ID,
                    Name= source.ChatRole.Name
                }
            };

        }
    }
}
