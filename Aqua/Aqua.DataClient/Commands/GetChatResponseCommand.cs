using Infragistics.Guidance.Aqua.DataClient.Common;
using Infragistics.Guidance.Aqua.Model;
using Infragistics.Guidance.Aqua.Model.Collections;

namespace Infragistics.Guidance.Aqua.DataClient.Commands
{
    public class GetChatResponseCommand: BaseDataCommand<ChatResponseCollection>
    {
        //private string[] responsesArray = {"BrainSurgeon response","Pharmacist response","Internal Medicine response","OrthoPedic Surgeon response", "Cardiologist response", "Radiologist Response" };
        protected override object ProcessCommand(Infragistics.Guidance.Aqua.Model.Framework.CommandCriteria criteria)
        {
			IRepository<ChatResponse> repository = DIManager.Current.Get<IRepository<ChatResponse>>("ChatResponseRepository");
        	return new ChatResponseCollection(repository.SelectCollection(criteria));

        }
        
    }
}
