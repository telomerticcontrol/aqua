using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.LiveFX.Client;
using Microsoft.LiveFX.ResourceModel;
using System.Net;
using Infragistics.Guidance.Aqua.Client.ViewModel;
using Infragistics.Guidance.Aqua.Client.Properties;
using System.Collections.ObjectModel;
using Infragistics.Guidance.Aqua.Client.Collections;
using System.Security.Cryptography;
using System.IO;
using System.Net.Sockets;


namespace Infragistics.Guidance.Aqua.Client.View
{
    /// <summary>
    /// Interaction logic for LiveLoginView.xaml
    /// </summary>
    public partial class LiveLoginView : UserControl
    {
        MainWindowViewModel mainWindowViewModel;     
        LiveOperatingEnvironment liveOperatingEnvironment;
        
        public LiveLoginView()
        {
            InitializeComponent();          
            liveOperatingEnvironment = new LiveOperatingEnvironment();
            CheckForStoredInfo();
            
        }
        private void CheckForStoredInfo()
        {
            string StoredUserName = Settings.Default.StoredUserName;
            string StoredPassword = Decrypt(Settings.Default.StoredPassword);

            if (!string.IsNullOrEmpty(StoredUserName))
            {
                txtUserName.Text = StoredUserName;
                cbRememberMe.IsChecked = true;
            }
            else
            {
                cbRememberMe.IsChecked = false;
            }
            if (!string.IsNullOrEmpty(StoredPassword))
            {
                txtPassword.Password = StoredPassword;
                cbRememberPass.IsChecked = true;
            }
            else
            {
                cbRememberPass.IsChecked = false;
            }
        }
        private void SaveStoredInfo()
        {
            if (cbRememberMe.IsChecked ?? false)
            {
               
                Settings.Default.StoredUserName = txtUserName.Text;
            }
            else
            {
                Settings.Default.StoredUserName = string.Empty;
            }
            if (cbRememberPass.IsChecked ?? false)
            {
                Settings.Default.StoredPassword = Encrypt(txtPassword.Password);
            }
            else
            {
                Settings.Default.StoredPassword = string.Empty;
            }
            Settings.Default.Save();
        }

        public static string Decrypt(string TextToBeDecrypted)
        {
            RijndaelManaged RijndaelCipher = new RijndaelManaged();
            string Password = "CSC";
            string DecryptedData;
            try
            {
                byte[] EncryptedData = Convert.FromBase64String(TextToBeDecrypted);
                byte[] Salt = Encoding.ASCII.GetBytes(Password.Length.ToString());
                //Making of the key for decryption            
                PasswordDeriveBytes SecretKey = new PasswordDeriveBytes(Password, Salt);
                //Creates a symmetric Rijndael decryptor object.            
                ICryptoTransform Decryptor = RijndaelCipher.CreateDecryptor(SecretKey.GetBytes(32), SecretKey.GetBytes(16));
                MemoryStream memoryStream = new MemoryStream(EncryptedData);
                //Defines the cryptographics stream for decryption.THe stream contains decrpted data            
                CryptoStream cryptoStream = new CryptoStream(memoryStream, Decryptor, CryptoStreamMode.Read);
                byte[] PlainText = new byte[EncryptedData.Length];
                int DecryptedCount = cryptoStream.Read(PlainText, 0, PlainText.Length);
                memoryStream.Close();
                cryptoStream.Close();
                //Converting to string            
                DecryptedData = Encoding.Unicode.GetString(PlainText, 0, DecryptedCount);
            }
            catch
            {
                DecryptedData = TextToBeDecrypted;
            }
            return DecryptedData;
        }

        public static string Encrypt(string TextToBeEncrypted)
        {
            RijndaelManaged RijndaelCipher = new RijndaelManaged();
            string Password = "CSC";
            byte[] PlainText = System.Text.Encoding.Unicode.GetBytes(TextToBeEncrypted);
            byte[] Salt = Encoding.ASCII.GetBytes(Password.Length.ToString());
            PasswordDeriveBytes SecretKey = new PasswordDeriveBytes(Password, Salt);
            //Creates a symmetric encryptor object.         
            ICryptoTransform Encryptor = RijndaelCipher.CreateEncryptor(SecretKey.GetBytes(32), SecretKey.GetBytes(16));
            MemoryStream memoryStream = new MemoryStream();
            //Defines a stream that links data streams to cryptographic transformations        
            CryptoStream cryptoStream = new CryptoStream(memoryStream, Encryptor, CryptoStreamMode.Write);
            cryptoStream.Write(PlainText, 0, PlainText.Length);
            //Writes the final state and clears the buffer        
            cryptoStream.FlushFinalBlock();
            byte[] CipherBytes = memoryStream.ToArray();
            memoryStream.Close();
            cryptoStream.Close();
            string EncryptedData = Convert.ToBase64String(CipherBytes);
            return EncryptedData;
        }   

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            // Change Cursor
		   this.Cursor = Cursors.Wait;

		   this.mainWindowViewModel = this.DataContext as MainWindowViewModel;
            SaveStoredInfo();
            
            string userName = this.txtUserName.Text;

            if (string.IsNullOrEmpty(userName))
            {
                return;
            }
            string passWord = this.txtPassword.Password;
            if (string.IsNullOrEmpty(passWord))
            {
                return;
            }

            this.mainWindowViewModel.LoginToLive(userName, passWord);
            
        
        }
       
    }
}
