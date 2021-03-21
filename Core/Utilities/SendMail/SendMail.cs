using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Core.Utilities.SendMail
{
    public static class SendMail 
    {
        public static bool Send(string GMailHesabi, string GMailHesapSifresi, string GMailUnvan, string AMailHesabi, string MailKonu, string MailIcerik, string Pop3Host, int Pop3Port)
        {
            try
            {
                ICredentials cred = new NetworkCredential(GMailHesabi, GMailHesapSifresi);
                // mail göndermek için oturum açtık

                using (MailMessage mail = new MailMessage())// yeni mail oluşturduk
                {
                    mail.From = new MailAddress(GMailHesabi, GMailUnvan); // maili gönderecek hesabı belirttik
                    mail.To.Add(AMailHesabi); // mail gönderilecek adres
                    mail.Subject = MailKonu; // mailin konusu
                    mail.Body = MailIcerik; // mailin içeriği
                    // göndereceğimiz maili hazırladık.

                    using (SmtpClient smtp = new SmtpClient(Pop3Host, Pop3Port)) // smtp servere bağlandık
                    {
                        smtp.UseDefaultCredentials = false; // varsayılan girişi kullanmadık
                        smtp.EnableSsl = true; // ssl kullanımına izin verdik
                        smtp.Credentials = (NetworkCredential)cred; // server üzerindeki oturumumuzu yukarıda belirttiğimiz NetworkCredential üzerinden sağladık.
                        smtp.Send(mail); // mailimizi gönderdik.
                                         // smtp yani Simple Mail Transfer Protocol üzerinden maili gönderiyoruz.
                                         
                    }
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
