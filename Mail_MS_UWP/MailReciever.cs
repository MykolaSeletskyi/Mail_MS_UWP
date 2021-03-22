using MailKit;
using MailKit.Net.Imap;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Mail_MS_UWP.Model
{
   public class MailReciever
    {
        ImapClient imapClient = new ImapClient();
        public MailReciever()
        {
            imapClient.Connect("imap.gmail.com", 993, true);
            imapClient.Authenticate("temp.seletskyi.mykola@gmail.com", "rMtb2JEX8xmcgSKxCB7aZPDyzyVhbM2RzV");
        }
        public IList<IMailFolder> GetFolders()
        {
            return imapClient.GetFolders(imapClient.PersonalNamespaces[0]).Skip(2).ToList();
        }
        public IList<MimeMessage> GetMessages(IMailFolder folder)
        {
            folder.Open(FolderAccess.ReadOnly);
            List<MimeMessage> mimeMessages = new List<MimeMessage>(folder.Count);
            for (int i = 0; i < folder.Count; i++)
            {
                mimeMessages.Add(folder.GetMessage(i));
            }
            return mimeMessages;
        }
    }
}
