using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace EmailSend
{
    class Program
    {
        static void Main(string[] args)
        {

            #region 寄件者個人資訊
            //string userName = UserName;
            string userName = "寄件者名稱";
            //string sendAddress = abcdefgh@gmail.com;
            string sendAddress = "寄件者Email";
            //string pwd = "a1b2c3d4";
            string pwd = "寄件者密碼";
            MailAddress MailFrom = new MailAddress(sendAddress, userName, Encoding.UTF8);
            #endregion

            #region 收件者Email
            List<string> MailTos = new List<string>();
            MailTos.Add("收件者Email_1");
            MailTos.Add("收件者Email_2");
            #endregion

            #region 副本Email
            List<string> MailCcs = new List<string>();
            MailCcs.Add("副本Email_1");
            MailCcs.Add("副本Email_2");
            #endregion

            #region 附件路徑
            List<string> attachmentPath = new List<string>();
            //attachmentPath.Add(@"C:\aaa.jpg");
            attachmentPath.Add("附件路徑_1");
            attachmentPath.Add("附件路徑_2");
            #endregion

            #region 寄信主機Server及Port號
            #region 其他常用電子郵件SMTP主機及Port號
            // outlook.com || smtp.live.com port:25
            // yahoo.com.tw || smtp.mail.yahoo.com.tw port:465
            #endregion
            string smtpServer = "smtp.gmail.com";
            int smtpPort = 587;
            #endregion

            #region 信件主旨&內文
            string subject = "實作C#寄信";
            string body = @"你好<br>
                            我正在實作C#寄信<br>
                            我是內文<br>
                            <h1>BYE</h1>" + DateTime.Now;
            #endregion

            #region MailMessage
            MailMessage mms = new MailMessage();
            
            //寄件人資訊
            mms.From = MailFrom;
            //收件者信箱
            mms.To.Add(string.Join(",", MailTos));
            //副本信箱
            mms.CC.Add(string.Join(",", MailCcs));
            //密件副本
            mms.Bcc.Add(string.Join(",", MailTos));
            //主旨
            mms.Subject = subject;
            //主旨編碼方式
            mms.SubjectEncoding = Encoding.UTF8;
            //內容
            mms.Body = body;
            //內容編碼方式
            mms.BodyEncoding = Encoding.UTF8;
            //是否採用HTML格式
            mms.IsBodyHtml = true;
            //信件重要程度
            mms.Priority = MailPriority.Normal;
            //附件
            foreach (var item in attachmentPath)
            {
                Attachment attachment = new Attachment(item);
                mms.Attachments.Add(attachment);
            }
            #endregion

            #region SMTP SERVER
            //設定發送信件的伺服器
            SmtpClient smtpClient = new SmtpClient(smtpServer, smtpPort);
            //填寫信箱帳號密碼
            smtpClient.Credentials = new System.Net.NetworkCredential(sendAddress, pwd);
            //是否使用SSL協定傳輸
            smtpClient.EnableSsl = true;
            //傳送信件
            smtpClient.Send(mms);
            #endregion
        }
    }
}
