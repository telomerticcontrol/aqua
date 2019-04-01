using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infragistics.Windows.TilePanel;
using Infragistics.Guidance.Aqua.Client.Collections;
using Microsoft.LiveFX.ResourceModel;
using Microsoft.LiveFX.Client;
using Infragistics.Guidance.Aqua.Model.Collections;
using Infragistics.Guidance.Aqua.DataClient.Commands;
using Infragistics.Guidance.Aqua.Model.Framework;
using Infragistics.Guidance.Aqua.Model;
using System.Windows;

namespace Infragistics.Guidance.Aqua.Client.ViewModel
{
    public class DiagnosisSupportViewModel: ViewModelBase
    {
        public DiagnosisSupportViewModel(MainWindowViewModel owner)
        {
            mainWindowViewModel = owner;
            mainWindowViewModel.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(mainWindowViewModel_PropertyChanged);
            this.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(DiagnosisSupportViewModel_PropertyChanged);

			this.ChatText = "Enter Chat Text";
        }
        
        #region Fields

        private MainWindowViewModel mainWindowViewModel;
        private LiveOperatingEnvironment liveOperatingEnvironment;
        private WorkspaceItemState workSpaceItemState;
        private DiagnosisLibraryItemCollection libraryItems;
        private DiagnosisLibraryItemCollection imageLibraryItems;
        private DiagnosisLibraryItemCollection xpsLibraryItems;
        private LiveContactsCollection liveContacts;
        private LiveContactsViewModelCollection liveContactsVM;
        private ChatResponseCollection chatResponses;
		private LiveContactViewModel selectedContact;
		private string chatText = string.Empty;
        private string response;
        private string chatRole;

		#endregion
        #region Properties
        public LiveContactsViewModelCollection LiveContacts
        {
            get
            {
                if (this.liveContacts != null)
                {
                    if (liveContactsVM != null)
                    {
                        return liveContactsVM;
                    }
                    else 
                    {
                        liveContactsVM = new LiveContactsViewModelCollection();
                        foreach (Contact contact in liveContacts)
                        {
                            liveContactsVM.Add(new LiveContactViewModel(contact, this.mainWindowViewModel.LiveAuthenticationToken, this.liveOperatingEnvironment));
                        }
                    }
                    
                }
                return null;
            }
            set
            {
                this.liveContactsVM = value;
                OnPropertyChanged("LiveContacts");
            }
        }
        public Visibility ChatDisclaimerVisibility
        {
            get
            {
                if (this.liveContacts == null)
                {
                    return Visibility.Visible;
                }
                return Visibility.Collapsed;
            }
        }

        public WorkspaceItemState WorkSpaceItemState
        {
            get { return this.workSpaceItemState; }
            set
            {
                this.workSpaceItemState = value;
                OnPropertyChanged("WorkSpaceItemState");
            }
        }
        public Visibility NormalStateVisibility
        {
            get
            {
                if (this.WorkSpaceItemState != WorkspaceItemState.Maximized)
                {
                    return Visibility.Visible;
                }
                return Visibility.Collapsed;
            }
        }

        public Visibility MaximizedStateVisibility
        {
            get
            {
                if (this.WorkSpaceItemState == WorkspaceItemState.Maximized)
                {
                    return Visibility.Visible;
                }
                return Visibility.Collapsed;
            }
        }
        public DiagnosisLibraryItemCollection LibraryItems
        {
            get { return this.libraryItems; }
            set
            {
                this.libraryItems = value;
                OnPropertyChanged("LibraryItems");
            }
        }

        public DiagnosisLibraryItemCollection ImageLibraryItems
        {
            get { return this.imageLibraryItems; }
        }

        public DiagnosisLibraryItemCollection XpsLibraryItems
        {
            get { return this.xpsLibraryItems; }
        }
        public string Response
        {
            get { return this.response;}
            set { this.response = value ;}
        }
        public string LoginName
        {
            get { return this.mainWindowViewModel.LoginName; }
        }
        public ChatResponseCollection ChatResponses
        {
            get { return this.chatResponses; }
            set { this.chatResponses = value; }
        }

		public LiveContactViewModel SelectedContact
		{
			get { return this.selectedContact; }
			set 
				{
				
					this.selectedContact = value;
					OnPropertyChanged("SelectedContact");
					OnPropertyChanged("ChatLog");
				}
		}

		public string ChatText
		{
			get
			{
				return chatText;
			}
			set
			{
				this.chatText = value;
				OnPropertyChanged("ChatText");
			}
		}

		public string ChatLog
        {
            get 
			{
				string chatLog = string.Empty;

				if (this.SelectedContact != null)
				{
					chatLog = this.SelectedContact.ChatlogHistory;
				}

				return chatLog;
			}

        }

        #endregion
        #region Methods
        private LiveContactsCollection GetAllContacts(LiveOperatingEnvironment liveOperatingEnvironment)
        {
            if (liveOperatingEnvironment != null)
            {
                if (!liveOperatingEnvironment.Contacts.IsLoaded)
                {
                    liveOperatingEnvironment.Contacts.Load();
                }
                LiveContactsCollection contacts = new LiveContactsCollection(liveOperatingEnvironment.Contacts.Entries);
                return contacts;
            }
            return new LiveContactsCollection();
        }
        private void GetImageLibraryItems()
        {
            var imageLibraryItems = (from item in this.libraryItems where item.ContentType == "png" select item);
            this.imageLibraryItems = new DiagnosisLibraryItemCollection(imageLibraryItems);
        }

        private void GetXpsLibraryItems()
        {
            var xpsLibraryItems = (from item in this.libraryItems where item.ContentType == "xps" select item);
            this.xpsLibraryItems = new DiagnosisLibraryItemCollection(xpsLibraryItems);
        }

        public void GetChatResponses()
        {

			if (!string.IsNullOrEmpty(this.ChatText))
			{
				string contactRole = string.Empty;

				if (this.SelectedContact != null && this.SelectedContact.Profession != null)
				{
					contactRole = this.SelectedContact.Profession;
				}
				else
				{
					contactRole = "Default";
				}

				CommandCriteria criteria = new CommandCriteria();
				criteria.Add("Role", contactRole);
				this.chatRole = criteria["Role"].ToString();

				GetChatResponseCommand chatResponse = new GetChatResponseCommand();
				chatResponse.Execute(ChatResponseCommand_Complete, criteria);
			}
        }

        #endregion
        #region Event Handlers
        void DiagnosisSupportViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "WorkSpaceItemState")
            {
                OnPropertyChanged("NormalStateVisibility");
                OnPropertyChanged("MaximizedStateVisibility");
            }
        }

        void mainWindowViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
           
            if (e.PropertyName == "LiveOperatingEnvironment")
            {
                this.liveOperatingEnvironment = mainWindowViewModel.LiveOperatingEnvironment;
                this.liveContacts = GetAllContacts(this.liveOperatingEnvironment);
                OnPropertyChanged("LiveContacts");
                OnPropertyChanged("ChatDisclaimerVisibility");
            }
            if (e.PropertyName == "LibraryItems")
            {
                this.libraryItems = mainWindowViewModel.LibraryItems;
                GetImageLibraryItems();
                GetXpsLibraryItems();
                OnPropertyChanged("ImageLibraryItems");
                OnPropertyChanged("XpsLibraryItems");
            }
        }
        private void ChatResponseCommand_Complete(ChatResponseCollection responses)
        {
            this.chatResponses = responses;
            this.response = responses.GetResponseByRole(this.chatRole);
			
			if (this.SelectedContact != null)
			{
				string userText = this.chatText;
				this.ChatText = string.Empty;

				ChatMessage message = new ChatMessage { UserName = this.LoginName, UserText = userText, MessageTime = DateTime.Now, ResponseText = response };
				this.SelectedContact.AddChatResponse(message);
				OnPropertyChanged("ChatLog");
			}

            //OnPropertyChanged("Response");
        }
        #endregion

    }
}
