using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.LiveFX.Client;
using Microsoft.LiveFX.ResourceModel;
using System.IO;
using System.Net;
using System.Windows.Media.Imaging;
using System.Collections;
using Infragistics.Guidance.Aqua.Model;

namespace Infragistics.Guidance.Aqua.Client.ViewModel
{
    public class LiveContactViewModel: ViewModelBase
    {
        public LiveContactViewModel(Contact contact, string token, LiveOperatingEnvironment liveOperatingEnvironment)
        {
            this.contact = contact;
            this.liveAuthenticationToken = token;
            this.liveOperatingEnvironment = liveOperatingEnvironment;
            GetProfile(this.contact);
            DownloadProfileImage();
        }
        
        #region Fields
        private Contact contact;
        private string liveAuthenticationToken;
        private BitmapImage profileImage;
        private GeneralProfile generalProfile;
        private LiveOperatingEnvironment liveOperatingEnvironment;
		private string chatLogHistory = string.Empty;
		
        #endregion
		
        #region Properties

		public string ChatlogHistory
		{
			get { return this.chatLogHistory; }
		}

        public string Name
        {
            get { return contact.Resource.FormattedName; }
        }
        public string Profession
        {
            get { return contact.Resource.Profession; }
        }

        public GeneralProfile GeneralProfile
        {
            get { return this.generalProfile; }
        }
        public BitmapImage ProfileImage
        {
            get
            {
                if (this.profileImage == null)
                {
                    DownloadProfileImage();
                }
                return this.profileImage;
            }
        }
        #endregion
        #region Methods

		public void AddChatResponse(ChatMessage message)
		{
			this.chatLogHistory = this.chatLogHistory + message.GetChatMessage(this.DoesChatHistoryExist(), this.Name);
		}

		public void ClearChatHistory()
		{
			this.chatLogHistory = string.Empty;
		}

		private bool DoesChatHistoryExist()
		{
			return !string.IsNullOrEmpty(this.chatLogHistory);
		}
		
        private void GetProfile(Contact contact)
        {
            contact.Load();

            var profiles = from profile in contact.Profiles.Entries where profile.Resource.Title == "GeneralProfile" select profile;
            if (profiles.ToList().Count > 0)
            {
                Profile tmp = profiles.First();
                this.generalProfile = tmp.Resource.ProfileInfo as GeneralProfile;
            }

        }


        private void DownloadProfileImage()
        {
            if (generalProfile != null && this.liveOperatingEnvironment != null)
            {
                if (generalProfile.ThumbnailImageLink == null)
                {
                    this.profileImage = new BitmapImage();
                }
                else
                {
                    string ImagePath = System.IO.Path.Combine(this.liveOperatingEnvironment.BaseUri.ToString(), generalProfile.ThumbnailImageLink.ToString());
                    System.Net.WebClient client = new WebClient();
                    client.Headers.Add("Content-Type", "application/atom+xml");
                    client.Headers.Add("Authorization", this.liveAuthenticationToken);
                    byte[] ImageBytes = client.DownloadData(ImagePath);
                    this.profileImage = new BitmapImage();
                    this.profileImage.BeginInit();
                    MemoryStream ms = new MemoryStream(ImageBytes);
                    this.profileImage.StreamSource = ms;
                    this.profileImage.EndInit();
                    ms.Close();
                    ms.Dispose();
                }
               
            }

        }
        #endregion
       
    }
}
