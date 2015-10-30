using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace RssReader
{
    public class NewsSender
    {
        private SmtpClient smtpClient;

        private string password;
        private string senderAddress;
        private string smtpAddress = "smtp.gmail.com";
        private int smtpPort = 587;

        private string[] recipientAddresses = new string[0];

        public string[] RecipientAddresses
        {
            get { return (string[])recipientAddresses.Clone(); }
            set { recipientAddresses = (string[])value.Clone(); }
        }

        public NewsSender(string address, string password)
        {
            this.senderAddress = address;
            this.password = password;
            this.recipientAddresses = new string[0];

            smtpClient = new SmtpClient(smtpAddress, smtpPort);
            smtpClient.Credentials = new NetworkCredential(address, password);
            smtpClient.EnableSsl = true;
        }

        public void SendNewsItem(FeedItem item)
        {
            SendNewsItem(item, recipientAddresses);
        }

        public void SendNewsItem(FeedItem item, string[] addresses)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));
            if (addresses == null)
                throw new ArgumentNullException(nameof(addresses));
            if (addresses.Length < 1)
                return;

            var message = new MailMessage();
            message.From = new MailAddress(senderAddress);
            foreach (var address in addresses)
            {
                message.To.Add(new MailAddress(address));
            }
            message.Subject = item.Title;
            message.Body = item.Summary;
            message.IsBodyHtml = true;

            smtpClient.Send(message);
        }

        public void SendNewsItems(FeedItem[] items)
        {
            SendNewsItems(items, recipientAddresses);
        }

        public void SendNewsItems(FeedItem[] items, string[] addresses)
        {
            if (items == null)
                throw new ArgumentNullException(nameof(items));

            foreach (var item in items)
                SendNewsItem(item, addresses);
        }
    }
}
