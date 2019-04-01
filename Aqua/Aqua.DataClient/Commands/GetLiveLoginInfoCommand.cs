using Aqua.Security;
using Infragistics.Guidance.Aqua.Model;
using Infragistics.Guidance.Aqua.Model.Framework;

namespace Infragistics.Guidance.Aqua.DataClient.Commands
{
    public class GetLiveLoginInfoCommand:BaseDataCommand<LiveStatus>
    {

		protected override object ProcessCommand(CommandCriteria criteria)
		{
			SecurityServices authenticateService = new SecurityServices();
			LiveStatus loginStatus = authenticateService.AuthenticateUser(criteria);

			return loginStatus;
		}

    }
    #region Live Login Code
    /*
    The code below is the code used to log into Live.  We needed to obscure the UserName and Password to 
     * prevent someone from changing the credentials so we placed the code in an assembly.  
    public LiveStatus AuthenticateUser(CommandCriteria criteria)
        {

            try
            {
                liveStatus = new LiveStatus();
                this.liveOperatingEnvironment = new LiveOperatingEnvironment();
                LiveItemAccessOptions accessOptions = new LiveItemAccessOptions(true);
                string uri = ConfigurationManager.AppSettings["LiveUri"].ToString();
                token = new NetworkCredential("UserName", "Password", uri).GetWindowsLiveAuthenticationToken();

                Uri theUri = new Uri(uri);
                liveOperatingEnvironment.Connect(token, AuthenticationTokenType.UserToken, theUri, accessOptions);

                liveStatus.Token = token;
                liveStatus.LiveOperatingEnvironment = this.liveOperatingEnvironment;
            }
            catch (Exception ex)
            {
                liveStatus.HasLoginErrors = true;
                liveStatus.LoginErrorMessage = ex.Message;
            }

            return liveStatus;
        }
     */
    #endregion
    
}
