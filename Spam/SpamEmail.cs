using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Spam
{
    public partial class SpamEmail : Form
    {
        public SpamEmail()
        {
            InitializeComponent();

            smtp.Credentials = new NetworkCredential(senderEmail, appPassword);
            smtp.EnableSsl = true;
        }

        private readonly string senderEmail = "email";
        private readonly string appPassword = "appPassword";

        SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);

        private void таблицаBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.таблицаBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.databaseDataSet1);
        }

        private void SpamEmail_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "databaseDataSet.Таблица". При необходимости она может быть перемещена или удалена.
            this.таблицаTableAdapter.Fill(this.databaseDataSet1.Таблица);

        }

        private void ShareMsgToEmail(string email, int code)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(senderEmail);
                mail.To.Add(email);
                mail.Subject = "Знижка для нових клієнтів";
                mail.IsBodyHtml = true;
                mail.Body = GetEmailBody(code.ToString());

                smtp.Send(mail);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка: " + ex.Message);
            }
        }

        private bool UserMeetsRequirements(string sexOfSelectedUser, float ageOfSelectedUser, float incomeOfSelectedUser)
        {
            bool SexMeetsRequirements = true;
            bool AgeMeetsRequirements = true;
            bool IncomeMeetsRequirements = true;

            if (chlbFilterOptions.GetItemChecked(0)) // стать
            {
                SexMeetsRequirements = tbSexToCompare.Text == sexOfSelectedUser;
            }

            if (chlbFilterOptions.GetItemChecked(1)) // вік
            {
                if (tbAgeToCompare.Text == "") tbAgeToCompare.Text = "0";
                float ageToCompare = Convert.ToInt32(tbAgeToCompare.Text);

                switch (cbTypeAgeComparison.Text)
                {
                    case ">":
                        AgeMeetsRequirements = ageOfSelectedUser > ageToCompare;
                        break;
                    case "<":
                        AgeMeetsRequirements = ageOfSelectedUser < ageToCompare;
                        break;
                    case "=":
                        AgeMeetsRequirements = ageOfSelectedUser == ageToCompare;
                        break;
                    default:
                        AgeMeetsRequirements = false;
                        break;
                }
            }

            if (chlbFilterOptions.GetItemChecked(2)) // середній дохід
            {
                if (tbIncomeToCompare.Text == "") tbIncomeToCompare.Text = "0";
                float incomeToCompare = Convert.ToInt32(tbIncomeToCompare.Text);

                switch (cbTypeIncomeComparison.Text)
                {
                    case ">":
                        IncomeMeetsRequirements = incomeOfSelectedUser > incomeToCompare;
                        break;
                    case "<":
                        IncomeMeetsRequirements = incomeOfSelectedUser < incomeToCompare;
                        break;
                    case "=":
                        IncomeMeetsRequirements = incomeOfSelectedUser == incomeToCompare;
                        break;
                    default:
                        IncomeMeetsRequirements = false;
                        break;
                }
            }

            return (SexMeetsRequirements && AgeMeetsRequirements && IncomeMeetsRequirements);
        }

        private void btnLoadFromTxtFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    richtbMessage.Text = File.ReadAllText(openFileDialog1.FileName, Encoding.UTF8);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnShareToSelected_Click(object sender, EventArgs e)
        {
            int code = таблицаBindingSource.Position;
            code++;

            DataRow selectedUser = databaseDataSet1.Таблица.Rows[таблицаBindingSource.Position];
            string email = selectedUser["е-mail"].ToString();

            string sex = selectedUser["Стать"].ToString();
            float age = Convert.ToInt32(selectedUser["Вік"]);
            float income = Convert.ToInt32(selectedUser["Середній дохід"]);

            if (UserMeetsRequirements(sex, age, income))
            {
                ShareMsgToEmail(email, code);
            }
        }

        private void btnShareToAll_Click(object sender, EventArgs e)
        {
            int initialPosition = таблицаBindingSource.Position;

            for (int i = 0; i < databaseDataSet1.Таблица.Rows.Count; ++i)
            {
                таблицаBindingSource.Position = i;
                btnShareToSelected_Click(sender, e);
            }

            таблицаBindingSource.Position = initialPosition;
        }

        static string GetEmailBody(string code)
        {
            return $@"
<!DOCTYPE html PUBLIC ""-//W3C//DTD XHTML 1.0 Transitional//EN"" ""http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"">
<html dir=""ltr"" xmlns=""http://www.w3.org/1999/xhtml"" xmlns:o=""urn:schemas-microsoft-com:office:office"" lang=""uk"">
 <head>
  <meta charset=""UTF-8"">
  <meta content=""width=device-width, initial-scale=1"" name=""viewport"">
  <meta name=""x-apple-disable-message-reformatting"">
  <meta http-equiv=""X-UA-Compatible"" content=""IE=edge"">
  <meta content=""telephone=no"" name=""format-detection"">
  <title>Новый шаблон 2025-04-01</title><!--[if (mso 16)]>
    <style type=""text/css"">
    a {{text-decoration: none;}}
    </style>
    <![endif]--><!--[if gte mso 9]><style>sup {{ font-size: 100% !important; }}</style><![endif]--><!--[if gte mso 9]>
<noscript>
         <xml>
           <o:OfficeDocumentSettings>
           <o:AllowPNG></o:AllowPNG>
           <o:PixelsPerInch>96</o:PixelsPerInch>
           </o:OfficeDocumentSettings>
         </xml>
      </noscript>
<![endif]--><!--[if mso]><xml>
    <w:WordDocument xmlns:w=""urn:schemas-microsoft-com:office:word"">
      <w:DontUseAdvancedTypographyReadingMail/>
    </w:WordDocument>
    </xml><![endif]-->
  <style type=""text/css"">
.rollover:hover .rollover-first {{
  max-height:0px!important;
  display:none!important;
}}
.rollover:hover .rollover-second {{
  max-height:none!important;
  display:block!important;
}}
.rollover span {{
  font-size:0px;
}}
u + .body img ~ div div {{
  display:none;
}}
#outlook a {{
  padding:0;
}}
span.MsoHyperlink,
span.MsoHyperlinkFollowed {{
  color:inherit;
  mso-style-priority:99;
}}
a.es-button {{
  mso-style-priority:100!important;
  text-decoration:none!important;
}}
a[x-apple-data-detectors],
#MessageViewBody a {{
  color:inherit!important;
  text-decoration:none!important;
  font-size:inherit!important;
  font-family:inherit!important;
  font-weight:inherit!important;
  line-height:inherit!important;
}}
.es-desk-hidden {{
  display:none;
  float:left;
  overflow:hidden;
  width:0;
  max-height:0;
  line-height:0;
  mso-hide:all;
}}
@media only screen and (max-width:600px) {{.es-m-p0r {{ padding-right:0px!important }} .es-m-p20b {{ padding-bottom:20px!important }} .es-p-default {{ }} *[class=""gmail-fix""] {{ display:none!important }} p, a {{ line-height:150%!important }} h1, h1 a {{ line-height:120%!important }} h2, h2 a {{ line-height:120%!important }} h3, h3 a {{ line-height:120%!important }} h4, h4 a {{ line-height:120%!important }} h5, h5 a {{ line-height:120%!important }} h6, h6 a {{ line-height:120%!important }} .es-header-body p {{ }} .es-content-body p {{ }} .es-footer-body p {{ }} .es-infoblock p {{ }} h1 {{ font-size:30px!important; text-align:center; line-height:120%!important }} h2 {{ font-size:26px!important; text-align:center; line-height:120%!important }} h3 {{ font-size:20px!important; text-align:center; line-height:120%!important }} h4 {{ font-size:24px!important; text-align:left }} h5 {{ font-size:20px!important; text-align:left }} h6 {{ font-size:16px!important; text-align:left }} .es-header-body h1 a, .es-content-body h1 a, .es-footer-body h1 a {{ font-size:30px!important }} .es-header-body h2 a, .es-content-body h2 a, .es-footer-body h2 a {{ font-size:26px!important }} .es-header-body h3 a, .es-content-body h3 a, .es-footer-body h3 a {{ font-size:20px!important }} .es-header-body h4 a, .es-content-body h4 a, .es-footer-body h4 a {{ font-size:24px!important }} .es-header-body h5 a, .es-content-body h5 a, .es-footer-body h5 a {{ font-size:20px!important }} .es-header-body h6 a, .es-content-body h6 a, .es-footer-body h6 a {{ font-size:16px!important }} .es-menu td a {{ font-size:16px!important }} .es-header-body p, .es-header-body a {{ font-size:16px!important }} .es-content-body p, .es-content-body a {{ font-size:16px!important }} .es-footer-body p, .es-footer-body a {{ font-size:16px!important }} .es-infoblock p, .es-infoblock a {{ font-size:12px!important }} .es-m-txt-c, .es-m-txt-c h1, .es-m-txt-c h2, .es-m-txt-c h3, .es-m-txt-c h4, .es-m-txt-c h5, .es-m-txt-c h6 {{ text-align:center!important }} .es-m-txt-r, .es-m-txt-r h1, .es-m-txt-r h2, .es-m-txt-r h3, .es-m-txt-r h4, .es-m-txt-r h5, .es-m-txt-r h6 {{ text-align:right!important }} .es-m-txt-j, .es-m-txt-j h1, .es-m-txt-j h2, .es-m-txt-j h3, .es-m-txt-j h4, .es-m-txt-j h5, .es-m-txt-j h6 {{ text-align:justify!important }} .es-m-txt-l, .es-m-txt-l h1, .es-m-txt-l h2, .es-m-txt-l h3, .es-m-txt-l h4, .es-m-txt-l h5, .es-m-txt-l h6 {{ text-align:left!important }} .es-m-txt-r img, .es-m-txt-c img, .es-m-txt-l img {{ display:inline!important }} .es-m-txt-r .rollover:hover .rollover-second, .es-m-txt-c .rollover:hover .rollover-second, .es-m-txt-l .rollover:hover .rollover-second {{ display:inline!important }} .es-m-txt-r .rollover span, .es-m-txt-c .rollover span, .es-m-txt-l .rollover span {{ line-height:0!important; font-size:0!important; display:block }} .es-spacer {{ display:inline-table }} a.es-button, button.es-button {{ font-size:20px!important; padding:10px 0px 10px 0px!important; line-height:120%!important }} a.es-button, button.es-button, .es-button-border {{ display:inline-block!important }} .es-m-fw, .es-m-fw.es-fw, .es-m-fw .es-button {{ display:block!important }} .es-m-il, .es-m-il .es-button, .es-social, .es-social td, .es-menu {{ display:inline-block!important }} .es-adaptive table, .es-left, .es-right {{ width:100%!important }} .es-content table, .es-header table, .es-footer table, .es-content, .es-footer, .es-header {{ width:100%!important; max-width:600px!important }} .adapt-img {{ width:100%!important; height:auto!important }} .es-mobile-hidden, .es-hidden {{ display:none!important }} .es-desk-hidden {{ width:auto!important; overflow:visible!important; float:none!important; max-height:inherit!important; line-height:inherit!important }} tr.es-desk-hidden {{ display:table-row!important }} table.es-desk-hidden {{ display:table!important }} td.es-desk-menu-hidden {{ display:table-cell!important }} .es-menu td {{ width:1%!important }} table.es-table-not-adapt, .esd-block-html table {{ width:auto!important }} .h-auto {{ height:auto!important }} .es-text-1048 .es-text-mobile-size-18, .es-text-1048 .es-text-mobile-size-18 * {{ font-size:18px!important; line-height:150%!important }} .es-text-8735 .es-text-mobile-size-18, .es-text-8735 .es-text-mobile-size-18 * {{ font-size:18px!important; line-height:150%!important }} .es-text-3539 .es-text-mobile-size-48, .es-text-3539 .es-text-mobile-size-48 * {{ font-size:48px!important; line-height:150%!important }} .es-text-4453 .es-text-mobile-size-28, .es-text-4453 .es-text-mobile-size-28 * {{ font-size:28px!important; line-height:150%!important }} }}
@media screen and (max-width:384px) {{.mail-message-content {{ width:414px!important }} }}
</style>
 </head>
 <body class=""body"" style=""width:100%;height:100%;-webkit-text-size-adjust:100%;-ms-text-size-adjust:100%;padding:0;Margin:0"">
  <div dir=""ltr"" class=""es-wrapper-color"" lang=""uk"" style=""background-color:#F6F6F6""><!--[if gte mso 9]>
			<v:background xmlns:v=""urn:schemas-microsoft-com:vml"" fill=""t"">
				<v:fill type=""tile"" color=""#f6f6f6""></v:fill>
			</v:background>
		<![endif]-->
   <table width=""100%"" cellspacing=""0"" cellpadding=""0"" class=""es-wrapper"" role=""none"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;padding:0;Margin:0;width:100%;height:100%;background-repeat:repeat;background-position:center top;background-color:#F6F6F6"">
     <tr style=""border-collapse:collapse"">
      <td valign=""top"" style=""padding:0;Margin:0"">
       <table cellpadding=""0"" cellspacing=""0"" align=""center"" class=""es-header"" role=""none"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;width:100%;table-layout:fixed !important;background-color:transparent;background-repeat:repeat;background-position:center top"">
         <tr style=""border-collapse:collapse"">
          <td align=""center"" style=""padding:0;Margin:0"">
           <table cellspacing=""0"" cellpadding=""0"" bgcolor=""#ffffff"" align=""center"" class=""es-header-body"" role=""none"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;background-color:#FFFFFF;width:600px"">
             <tr style=""border-collapse:collapse"">
              <td align=""left"" bgcolor=""#000000"" style=""padding:0;Margin:0;background-color:#000000"">
               <table width=""100%"" cellspacing=""0"" cellpadding=""0"" role=""none"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px"">
                 <tr style=""border-collapse:collapse"">
                  <td valign=""top"" align=""center"" style=""padding:0;Margin:0;width:600px"">
                   <table width=""100%"" cellspacing=""0"" cellpadding=""0"" role=""presentation"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px"">
                     <tr style=""border-collapse:collapse"">
                      <td align=""center"" style=""padding:0;Margin:0;padding-top:5px;font-size:0""><img src=""https://i.imgur.com/i7u29G2.png"" alt=""logo"" title=""logo"" width=""189"" class=""adapt-img"" style=""display:block;font-size:14px;border:0;outline:none;text-decoration:none""></td>
                     </tr>
                   </table></td>
                 </tr>
               </table></td>
             </tr>
           </table></td>
         </tr>
       </table>
       <table cellspacing=""0"" cellpadding=""0"" align=""center"" class=""es-content"" role=""none"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;width:100%;table-layout:fixed !important"">
         <tr style=""border-collapse:collapse""></tr>
       </table>
       <table cellspacing=""0"" cellpadding=""0"" align=""center"" class=""es-content"" role=""none"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;width:100%;table-layout:fixed !important"">
         <tr style=""border-collapse:collapse"">
          <td align=""center"" style=""padding:0;Margin:0"">
           <table cellspacing=""0"" cellpadding=""0"" bgcolor=""#333333"" align=""center"" class=""es-content-body"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;background-color:#333333;width:600px"" role=""none"">
             <tr style=""border-collapse:collapse"">
              <td align=""left"" style=""Margin:0;padding-top:20px;padding-right:20px;padding-bottom:10px;padding-left:20px"">
               <table width=""100%"" cellspacing=""0"" cellpadding=""0"" role=""none"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px"">
                 <tr style=""border-collapse:collapse"">
                  <td valign=""top"" align=""center"" style=""padding:0;Margin:0;width:560px"">
                   <table width=""100%"" cellspacing=""0"" cellpadding=""0"" role=""presentation"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px"">
                     <tr style=""border-collapse:collapse"">
                      <td align=""center"" class=""es-text-4453"" style=""padding:0;Margin:0;padding-right:20px;padding-bottom:10px;padding-left:20px""><p class=""es-text-mobile-size-28"" style=""Margin:0;mso-line-height-rule:exactly;font-family:Arial, sans-serif;line-height:42px;letter-spacing:0;color:#ffffff;font-size:28px""><strong>Вигравайте знижку до 50%!!!</strong></p></td>
                     </tr>
                     <tr style=""border-collapse:collapse"">
                      <td align=""center"" class=""es-text-1048"" style=""padding:0;Margin:0""><p class=""es-text-mobile-size-18"" style=""Margin:0;mso-line-height-rule:exactly;font-family:Arial, sans-serif;line-height:27px;letter-spacing:0;color:#ffffff;font-size:18px"">🔥 ВІТАЄМО! ВИ ВИГРАЛИ СПЕЦІАЛЬНИЙ ПРОМОКОДКОД НА ВИГІДНІ ПОКУПКИ! 🔥 <br> <br>🎉 Ваш виграш чекає на вас! <br>Отримайте ексклюзивний промокод на знижки у таких категоріях:</p></td>
                     </tr>
                   </table></td>
                 </tr>
               </table></td>
             </tr>
             <tr style=""border-collapse:collapse"">
              <td align=""left"" style=""Margin:0;padding-top:20px;padding-right:20px;padding-bottom:10px;padding-left:20px""><!--[if mso]><table style=""width:560px"" cellpadding=""0"" cellspacing=""0""><tr><td style=""width:194px"" valign=""top""><![endif]-->
               <table cellspacing=""0"" cellpadding=""0"" align=""left"" class=""es-left"" role=""none"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;float:left"">
                 <tr style=""border-collapse:collapse"">
                  <td align=""center"" class=""es-m-p0r es-m-p20b"" style=""padding:0;Margin:0;width:174px"">
                   <table width=""100%"" cellspacing=""0"" cellpadding=""0"" role=""presentation"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px"">
                     <tr style=""border-collapse:collapse"">
                      <td align=""center"" style=""padding:0;Margin:0;font-size:0""><img src=""https://fkumuhi.stripocdn.email/content/guids/CABINET_607759159e18219d6dcb5dfeda428654/images/791513673456785.jpg"" alt=""Shaving &amp; Beard"" title=""Shaving &amp; Beard"" width=""174"" class=""adapt-img"" style=""display:block;font-size:14px;border:0;outline:none;text-decoration:none""></td>
                     </tr>
                   </table></td>
                  <td class=""es-hidden"" style=""padding:0;Margin:0;width:20px""></td>
                 </tr>
               </table><!--[if mso]></td><td style=""width:173px"" valign=""top""><![endif]-->
               <table cellspacing=""0"" cellpadding=""0"" align=""left"" class=""es-left"" role=""none"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;float:left"">
                 <tr style=""border-collapse:collapse"">
                  <td align=""center"" style=""padding:0;Margin:0;width:173px"">
                   <table width=""100%"" cellspacing=""0"" cellpadding=""0"" role=""presentation"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px"">
                     <tr style=""border-collapse:collapse"">
                      <td align=""center"" style=""Margin:0;padding-right:20px;padding-left:20px;padding-top:40px;padding-bottom:5px;font-size:0"">
                       <table width=""100%"" height=""100%"" cellspacing=""0"" cellpadding=""0"" border=""0"" role=""presentation"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px"">
                         <tr style=""border-collapse:collapse"">
                          <td style=""padding:0;Margin:0;border-bottom:1px solid #333333;background:#00000000 none repeat scroll 0% 0%;height:0px;width:100%;margin:0px""></td>
                         </tr>
                       </table></td>
                     </tr>
                   </table></td>
                 </tr>
                 <tr style=""border-collapse:collapse"">
                  <td align=""center"" class=""es-m-p20b"" style=""padding:0;Margin:0;width:173px"">
                   <table width=""100%"" cellspacing=""0"" cellpadding=""0"" bgcolor=""#f3eaeb"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;background-color:#F3EAEB"" role=""presentation"">
                     <tr style=""border-collapse:collapse"">
                      <td esdev-links-color=""#333333"" align=""center"" bgcolor=""#000000"" style=""Margin:0;padding-top:20px;padding-right:20px;padding-left:20px;padding-bottom:20px""><p style=""Margin:0;mso-line-height-rule:exactly;font-family:Arial, sans-serif;line-height:32px;letter-spacing:0;color:#333333;font-size:14px""><a target=""_blank"" href="""" style=""mso-line-height-rule:exactly;text-decoration:none;font-family:'times new roman', times, baskerville, georgia, serif;font-size:16px;color:#ffffff"">Perfumery</a></p><p style=""Margin:0;mso-line-height-rule:exactly;font-family:Arial, sans-serif;line-height:32px;letter-spacing:0;color:#333333;font-size:14px""><a target=""_blank"" href="""" style=""mso-line-height-rule:exactly;text-decoration:none;font-family:'times new roman', times, baskerville, georgia, serif;font-size:16px;color:#ffffff"">Shaving & Beard</a></p><p style=""Margin:0;mso-line-height-rule:exactly;font-family:Arial, sans-serif;line-height:32px;letter-spacing:0;color:#333333;font-size:14px""><a target=""_blank"" href="""" style=""mso-line-height-rule:exactly;text-decoration:none;font-family:'times new roman', times, baskerville, georgia, serif;font-size:16px;color:#ffffff"">Body care</a></p></td>
                     </tr>
                   </table></td>
                 </tr>
               </table><!--[if mso]></td><td style=""width:20px""></td><td style=""width:173px"" valign=""top""><![endif]-->
               <table cellspacing=""0"" cellpadding=""0"" align=""right"" class=""es-right"" role=""none"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;float:right"">
                 <tr style=""border-collapse:collapse"">
                  <td align=""center"" style=""padding:0;Margin:0;width:173px"">
                   <table width=""100%"" cellspacing=""0"" cellpadding=""0"" role=""presentation"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px"">
                     <tr style=""border-collapse:collapse"">
                      <td align=""center"" style=""padding:0;Margin:0;font-size:0""><img src=""https://fkumuhi.stripocdn.email/content/guids/CABINET_607759159e18219d6dcb5dfeda428654/images/2041513672921884.jpg"" alt=""Man"" title=""Man"" width=""173"" class=""adapt-img"" style=""display:block;font-size:14px;border:0;outline:none;text-decoration:none""></td>
                     </tr>
                   </table></td>
                 </tr>
               </table><!--[if mso]></td></tr></table><![endif]--></td>
             </tr>
             <tr style=""border-collapse:collapse"">
              <td align=""left"" style=""Margin:0;padding-right:20px;padding-bottom:10px;padding-left:20px;padding-top:10px""><!--[if mso]><table style=""width:560px"" cellpadding=""0"" cellspacing=""0""><tr><td style=""width:194px""><![endif]-->
               <table cellspacing=""0"" cellpadding=""0"" align=""left"" class=""es-left"" role=""none"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;float:left"">
                 <tr style=""border-collapse:collapse"">
                  <td align=""center"" style=""padding:0;Margin:0;width:174px"">
                   <table width=""100%"" cellspacing=""0"" cellpadding=""0"" role=""presentation"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px"">
                     <tr style=""border-collapse:collapse"">
                      <td align=""center"" style=""padding:0;Margin:0;padding-top:20px;padding-right:20px;padding-left:20px;font-size:0"">
                       <table width=""100%"" height=""100%"" cellspacing=""0"" cellpadding=""0"" border=""0"" role=""presentation"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px"">
                         <tr style=""border-collapse:collapse"">
                          <td style=""padding:0;Margin:0;border-bottom:1px solid #000000;background:#00000000 none repeat scroll 0% 0%;height:0px;width:100%;margin:0px""></td>
                         </tr>
                       </table></td>
                     </tr>
                   </table></td>
                  <td class=""es-hidden"" style=""padding:0;Margin:0;width:20px""></td>
                 </tr>
                 <tr style=""border-collapse:collapse"">
                  <td align=""center"" class=""es-m-p0r es-m-p20b"" style=""padding:0;Margin:0;width:174px"">
                   <table width=""100%"" cellspacing=""0"" cellpadding=""0"" bgcolor=""#f3eaeb"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;background-color:#F3EAEB"" role=""presentation"">
                     <tr style=""border-collapse:collapse"">
                      <td esdev-links-color=""#333333"" align=""center"" bgcolor=""#000000"" style=""Margin:0;padding-top:20px;padding-right:20px;padding-left:20px;padding-bottom:20px""><p style=""Margin:0;mso-line-height-rule:exactly;font-family:Arial, sans-serif;line-height:32px;letter-spacing:0;color:#333333;font-size:14px""><a target=""_blank"" href="""" style=""mso-line-height-rule:exactly;text-decoration:none;font-family:'times new roman', times, baskerville, georgia, serif;font-size:16px;color:#ffffff"">Perfumery</a></p><p style=""Margin:0;mso-line-height-rule:exactly;font-family:Arial, sans-serif;line-height:32px;letter-spacing:0;color:#333333;font-size:14px""><a target=""_blank"" href="""" style=""mso-line-height-rule:exactly;text-decoration:none;font-family:'times new roman', times, baskerville, georgia, serif;font-size:16px;color:#ffffff"">Make-up</a></p><p style=""Margin:0;mso-line-height-rule:exactly;font-family:Arial, sans-serif;line-height:32px;letter-spacing:0;color:#333333;font-size:14px""><a target=""_blank"" href="""" style=""mso-line-height-rule:exactly;text-decoration:none;font-family:'times new roman', times, baskerville, georgia, serif;font-size:16px;color:#ffffff"">Body care</a></p><p style=""Margin:0;mso-line-height-rule:exactly;font-family:Arial, sans-serif;line-height:32px;letter-spacing:0;color:#333333;font-size:14px""><a target=""_blank"" href="""" style=""mso-line-height-rule:exactly;text-decoration:none;font-family:'times new roman', times, baskerville, georgia, serif;font-size:16px;color:#ffffff"">Hair care</a></p><p style=""Margin:0;mso-line-height-rule:exactly;font-family:Arial, sans-serif;line-height:32px;letter-spacing:0;color:#333333;font-size:14px""><a target=""_blank"" href="""" style=""mso-line-height-rule:exactly;text-decoration:none;font-family:'times new roman', times, baskerville, georgia, serif;font-size:16px;color:#ffffff"">Styling tools</a></p></td>
                     </tr>
                   </table></td>
                  <td class=""es-hidden"" style=""padding:0;Margin:0;width:20px""></td>
                 </tr>
               </table><!--[if mso]></td><td style=""width:173px""><![endif]-->
               <table cellspacing=""0"" cellpadding=""0"" align=""left"" class=""es-left"" role=""none"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;float:left"">
                 <tr style=""border-collapse:collapse"">
                  <td align=""center"" class=""es-m-p20b"" style=""padding:0;Margin:0;width:173px"">
                   <table width=""100%"" cellspacing=""0"" cellpadding=""0"" role=""presentation"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px"">
                     <tr style=""border-collapse:collapse"">
                      <td align=""center"" style=""padding:0;Margin:0;padding-top:5px;font-size:0""><img src=""https://fkumuhi.stripocdn.email/content/guids/CABINET_607759159e18219d6dcb5dfeda428654/images/87241513673668797.jpg"" alt=""Woman"" title=""Woman"" width=""173"" class=""adapt-img"" style=""display:block;font-size:14px;border:0;outline:none;text-decoration:none""></td>
                     </tr>
                   </table></td>
                 </tr>
               </table><!--[if mso]></td><td style=""width:20px""></td><td style=""width:173px""><![endif]-->
               <table cellspacing=""0"" cellpadding=""0"" align=""right"" class=""es-right"" role=""none"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;float:right"">
                 <tr style=""border-collapse:collapse"">
                  <td align=""center"" style=""padding:0;Margin:0;width:173px"">
                   <table width=""100%"" cellspacing=""0"" cellpadding=""0"" role=""presentation"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px"">
                     <tr style=""border-collapse:collapse"">
                      <td align=""center"" style=""padding:0;Margin:0;padding-top:20px;font-size:0""><img src=""https://fkumuhi.stripocdn.email/content/guids/CABINET_607759159e18219d6dcb5dfeda428654/images/20291513674063004.jpg"" alt=""Body care"" title=""Body care"" width=""173"" class=""adapt-img"" style=""display:block;font-size:14px;border:0;outline:none;text-decoration:none""></td>
                     </tr>
                   </table></td>
                 </tr>
               </table><!--[if mso]></td></tr></table><![endif]--></td>
             </tr>
             <tr style=""border-collapse:collapse"">
              <td align=""left"" style=""Margin:0;padding-right:20px;padding-left:20px;padding-bottom:20px;padding-top:10px""><!--[if mso]><table style=""width:560px"" cellpadding=""0"" cellspacing=""0""><tr><td style=""width:194px""><![endif]-->
               <table cellspacing=""0"" cellpadding=""0"" align=""left"" class=""es-left"" role=""none"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;float:left"">
                 <tr style=""border-collapse:collapse"">
                  <td align=""center"" style=""padding:0;Margin:0;width:174px"">
                   <table width=""100%"" cellspacing=""0"" cellpadding=""0"" role=""presentation"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px"">
                     <tr style=""border-collapse:collapse"">
                      <td align=""center"" style=""padding:0;Margin:0;font-size:0""><img src=""https://fkumuhi.stripocdn.email/content/guids/CABINET_607759159e18219d6dcb5dfeda428654/images/35111513674496689.jpg"" alt=""Body care"" title=""Body care"" width=""174"" class=""adapt-img"" style=""display:block;font-size:14px;border:0;outline:none;text-decoration:none""></td>
                     </tr>
                   </table></td>
                  <td class=""es-hidden"" style=""padding:0;Margin:0;width:20px""></td>
                 </tr>
               </table><!--[if mso]></td><td style=""width:173px""><![endif]-->
               <table cellspacing=""0"" cellpadding=""0"" align=""left"" class=""es-left"" role=""none"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;float:left"">
                 <tr style=""border-collapse:collapse"">
                  <td align=""center"" class=""es-m-p20b"" style=""padding:0;Margin:0;width:173px"">
                   <table width=""100%"" cellspacing=""0"" cellpadding=""0"" role=""presentation"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px"">
                     <tr style=""border-collapse:collapse"">
                      <td align=""center"" style=""padding:0;Margin:0;padding-top:15px;font-size:0""><img src=""https://fkumuhi.stripocdn.email/content/guids/CABINET_607759159e18219d6dcb5dfeda428654/images/32711513674327122.jpg"" alt=""Make-up"" title=""Make-up"" width=""173"" class=""adapt-img"" style=""display:block;font-size:14px;border:0;outline:none;text-decoration:none""></td>
                     </tr>
                   </table></td>
                 </tr>
               </table><!--[if mso]></td><td style=""width:20px""></td><td style=""width:173px""><![endif]-->
               <table cellspacing=""0"" cellpadding=""0"" align=""right"" class=""es-right"" role=""none"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;float:right"">
                 <tr style=""border-collapse:collapse"">
                  <td align=""center"" style=""padding:0;Margin:0;width:173px"">
                   <table width=""100%"" cellspacing=""0"" cellpadding=""0"" role=""presentation"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px"">
                     <tr style=""border-collapse:collapse"">
                      <td align=""center"" style=""padding:0;Margin:0;padding-top:15px;font-size:0""><img src=""https://fkumuhi.stripocdn.email/content/guids/CABINET_607759159e18219d6dcb5dfeda428654/images/92081513674344019.jpg"" alt=""Make-up"" title=""Make-up"" width=""173"" class=""adapt-img"" style=""display:block;font-size:14px;border:0;outline:none;text-decoration:none""></td>
                     </tr>
                   </table></td>
                 </tr>
               </table><!--[if mso]></td></tr></table><![endif]--></td>
             </tr>
             <tr style=""border-collapse:collapse"">
              <td align=""left"" style=""padding:0;Margin:0;padding-top:20px;padding-right:20px;padding-left:20px"">
               <table width=""100%"" cellpadding=""0"" cellspacing=""0"" role=""none"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px"">
                 <tr style=""border-collapse:collapse"">
                  <td align=""left"" style=""padding:0;Margin:0;width:560px"">
                   <table width=""100%"" role=""presentation"" cellpadding=""0"" cellspacing=""0"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px"">
                     <tr style=""border-collapse:collapse"">
                      <td align=""center"" style=""padding:0;Margin:0""><h2 style=""Margin:0;font-family:'times new roman', times, baskerville, georgia, serif;mso-line-height-rule:exactly;letter-spacing:0;font-size:24px;font-style:normal;font-weight:normal;line-height:28.8px;color:#ffffff""><strong>💬 Вводьте ваш код у чат бот, щоб дізнатися яку саме знижку ви отримали!!!</strong></h2></td>
                     </tr>
                   </table></td>
                 </tr>
               </table></td>
             </tr>
             <tr style=""border-collapse:collapse"">
              <td align=""left"" style=""padding:0;Margin:0;padding-top:20px;padding-right:20px;padding-left:20px"">
               <table width=""100%"" cellpadding=""0"" cellspacing=""0"" role=""none"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px"">
                 <tr style=""border-collapse:collapse"">
                  <td align=""left"" style=""padding:0;Margin:0;padding-right:55px;padding-left:55px;border-radius:12px;overflow:hidden;width:450px"">
                   <table cellpadding=""0"" cellspacing=""0"" width=""100%"" role=""presentation"" bgcolor=""#333333"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:separate;border-spacing:0px;background-color:#333333;border-top:9px solid #ffffff;border-right:9px solid #ffffff;border-bottom:9px solid #ffffff;border-left:9px solid #ffffff;border-radius:12px"">
                     <tr style=""border-collapse:collapse"">
                      <td align=""center"" bgcolor=""#d6d5d5"" class=""es-text-3539"" style=""padding:0;Margin:0;padding-top:60px;padding-bottom:40px""><h1 class=""es-text-mobile-size-48"" style=""Margin:0;font-family:'times new roman', times, baskerville, georgia, serif;mso-line-height-rule:exactly;letter-spacing:0;font-size:48px;font-style:normal;font-weight:normal;line-height:57.6px;color:#333333;text-align:center"">{code}</h1><p style=""Margin:0;mso-line-height-rule:exactly;font-family:Arial, sans-serif;line-height:21px;letter-spacing:0;color:#333333;font-size:14px""><br></p></td>
                     </tr>
                   </table></td>
                 </tr>
               </table></td>
             </tr>
             <tr style=""border-collapse:collapse"">
              <td align=""left"" style=""padding:0;Margin:0;padding-top:20px;padding-right:20px;padding-left:20px"">
               <table width=""100%"" cellpadding=""0"" cellspacing=""0"" role=""none"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px"">
                 <tr style=""border-collapse:collapse"">
                  <td align=""left"" style=""padding:0;Margin:0;width:560px"">
                   <table cellpadding=""0"" cellspacing=""0"" width=""100%"" role=""presentation"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px"">
                     <tr style=""border-collapse:collapse"">
                      <td align=""center"" style=""padding:0;Margin:0;padding-bottom:10px""><span class=""es-button-border"" style=""border-style:solid;border-color:#ffffff;background:#2aa6e8;border-width:3px;display:inline-block;border-radius:28px;width:auto"">
    <a href=""https://t.me/WatsonPlus_bot"" target=""_blank"" class=""es-button"" style=""mso-style-priority:100 !important;text-decoration:none !important;mso-line-height-rule:exactly;font-family:'lucida sans unicode', 'lucida grande', sans-serif;font-size:18px;color:#ffffff;padding:15px 35px 10px 10px;display:inline-block;background:#2aa6e8;border-radius:28px;font-weight:bold;font-style:normal;line-height:21.6px;width:auto;text-align:center;letter-spacing:0;mso-padding-alt:0;mso-border-alt:10px solid #2aa6e8"">
        <img width=""30"" align=""absmiddle"" src=""https://www.iconsdb.com/icons/preview/white/telegram-xxl.png"" alt=""icon"" referrerpolicy=""no-referrer"" style=""display:inline-block;font-size:14px;border:0;outline:none;text-decoration:none;vertical-align:middle;margin-right:10px"">Отримати Знижку
    </a>
</span></td>
                     </tr>
                   </table></td>
                 </tr>
               </table></td>
             </tr>
             <tr style=""border-collapse:collapse"">
              <td align=""left"" style=""padding:0;Margin:0;padding-top:20px;padding-right:20px;padding-left:20px"">
               <table cellspacing=""0"" width=""100%"" cellpadding=""0"" role=""none"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px"">
                 <tr style=""border-collapse:collapse"">
                  <td align=""left"" style=""padding:0;Margin:0;width:560px"">
                   <table width=""100%"" role=""presentation"" cellpadding=""0"" cellspacing=""0"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px"">
                     <tr style=""border-collapse:collapse"">
                      <td align=""left"" class=""es-text-8735"" style=""padding:0;Margin:0;padding-bottom:15px""><p class=""es-text-mobile-size-18"" style=""Margin:0;mso-line-height-rule:exactly;font-family:Arial, sans-serif;line-height:27px;letter-spacing:0;color:#ffffff;font-size:18px;text-align:center""><strong>⏰ Акція діє лише 24 години&nbsp;– не зволікайте!</strong></p><p class=""es-text-mobile-size-18"" style=""Margin:0;mso-line-height-rule:exactly;font-family:Arial, sans-serif;line-height:27px;letter-spacing:0;color:#ffffff;font-size:18px;text-align:center""><strong>🚀&nbsp;Не прогавте свій шанс купити вигідно!&nbsp;🚀</strong></p></td>
                     </tr>
                   </table></td>
                 </tr>
               </table></td>
             </tr>
           </table></td>
         </tr>
       </table>
       <table cellpadding=""0"" cellspacing=""0"" align=""center"" class=""es-footer"" role=""none"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;width:100%;table-layout:fixed !important;background-color:transparent;background-repeat:repeat;background-position:center top"">
         <tr style=""border-collapse:collapse"">
          <td align=""center"" style=""padding:0;Margin:0"">
           <table cellspacing=""0"" cellpadding=""0"" align=""center"" bgcolor=""#000000"" class=""es-footer-body"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;background-color:#000000;width:600px"" role=""none"">
             <tr style=""border-collapse:collapse"">
              <td align=""left"" style=""Margin:0;padding-top:20px;padding-right:20px;padding-left:20px;padding-bottom:20px""><!--[if mso]><table style=""width:560px"" cellpadding=""0"" cellspacing=""0""><tr><td style=""width:194px""><![endif]-->
               <table cellspacing=""0"" cellpadding=""0"" align=""left"" class=""es-left"" role=""none"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;float:left"">
                 <tr style=""border-collapse:collapse"">
                  <td align=""center"" class=""es-m-p0r es-m-p20b"" style=""padding:0;Margin:0;width:174px"">
                   <table width=""100%"" cellspacing=""0"" cellpadding=""0"" role=""presentation"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px"">
                     <tr style=""border-collapse:collapse"">
                      <td align=""left"" style=""padding:0;Margin:0""><p style=""Margin:0;mso-line-height-rule:exactly;font-family:Arial, sans-serif;line-height:21px;letter-spacing:0;color:#FFFFFF;font-size:14px""><span style=""font-family:'lucida sans unicode', 'lucida grande', sans-serif""><strong style=""line-height:150%"">Menu</strong></span></p></td>
                     </tr>
                     <tr style=""border-collapse:collapse"">
                      <td align=""left"" style=""padding:0;Margin:0""><p style=""Margin:0;mso-line-height-rule:exactly;font-family:Arial, sans-serif;line-height:21px;letter-spacing:0;color:#ffffff;font-size:14px""><a target=""_blank"" href="""" style=""mso-line-height-rule:exactly;text-decoration:none;font-family:Arial, sans-serif;font-size:14px;color:#8C8788""></a><a target=""_blank"" href=""https://viewstripo.email"" style=""mso-line-height-rule:exactly;text-decoration:none;font-family:Arial, sans-serif;font-size:14px;color:#8C8788"">Makeup</a></p><p style=""Margin:0;mso-line-height-rule:exactly;font-family:Arial, sans-serif;line-height:21px;letter-spacing:0;color:#8C8788;font-size:14px""><a target=""_blank"" href=""https://viewstripo.email"" style=""mso-line-height-rule:exactly;text-decoration:none;font-family:Arial, sans-serif;font-size:14px;color:#8C8788"">Fragrance</a></p><p style=""Margin:0;mso-line-height-rule:exactly;font-family:Arial, sans-serif;line-height:21px;letter-spacing:0;color:#8C8788;font-size:14px""><a target=""_blank"" href=""https://viewstripo.email"" style=""mso-line-height-rule:exactly;text-decoration:none;font-family:Arial, sans-serif;font-size:14px;color:#8C8788"">Solutions</a></p><p style=""Margin:0;mso-line-height-rule:exactly;font-family:Arial, sans-serif;line-height:21px;letter-spacing:0;color:#8C8788;font-size:14px""><a target=""_blank"" href=""https://viewstripo.email"" style=""mso-line-height-rule:exactly;text-decoration:none;font-family:Arial, sans-serif;font-size:14px;color:#8C8788"">Sale</a></p></td>
                     </tr>
                   </table></td>
                  <td class=""es-hidden"" style=""padding:0;Margin:0;width:20px""></td>
                 </tr>
               </table><!--[if mso]></td><td style=""width:173px""><![endif]-->
               <table cellspacing=""0"" cellpadding=""0"" align=""left"" class=""es-left"" role=""none"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;float:left"">
                 <tr style=""border-collapse:collapse"">
                  <td align=""center"" class=""es-m-p20b"" style=""padding:0;Margin:0;width:173px"">
                   <table width=""100%"" cellspacing=""0"" cellpadding=""0"" role=""presentation"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px"">
                     <tr style=""border-collapse:collapse"">
                      <td align=""left"" style=""padding:0;Margin:0""><p style=""Margin:0;mso-line-height-rule:exactly;font-family:Arial, sans-serif;line-height:21px;letter-spacing:0;color:#FFFFFF;font-size:14px""><span style=""font-family:'lucida sans unicode', 'lucida grande', sans-serif""><strong style=""line-height:150%"">Services</strong></span><br></p></td>
                     </tr>
                     <tr style=""border-collapse:collapse"">
                      <td align=""left"" style=""padding:0;Margin:0""><p style=""Margin:0;mso-line-height-rule:exactly;font-family:Arial, sans-serif;line-height:21px;letter-spacing:0;color:#8C8788;font-size:14px""><a target=""_blank"" href=""https://viewstripo.email"" style=""mso-line-height-rule:exactly;text-decoration:none;font-family:Arial, sans-serif;font-size:14px;color:#8C8788"">Privacy Policy</a></p><p style=""Margin:0;mso-line-height-rule:exactly;font-family:Arial, sans-serif;line-height:21px;letter-spacing:0;color:#8C8788;font-size:14px""><a target=""_blank"" href=""https://viewstripo.email"" style=""mso-line-height-rule:exactly;text-decoration:none;font-family:Arial, sans-serif;font-size:14px;color:#8C8788"">Terms & Conditions</a></p><p style=""Margin:0;mso-line-height-rule:exactly;font-family:Arial, sans-serif;line-height:21px;letter-spacing:0;color:#8C8788;font-size:14px""><a target=""_blank"" href=""https://viewstripo.email"" style=""mso-line-height-rule:exactly;text-decoration:none;font-family:Arial, sans-serif;font-size:14px;color:#8C8788"">Payment</a></p></td>
                     </tr>
                   </table></td>
                 </tr>
               </table><!--[if mso]></td><td style=""width:20px""></td><td style=""width:173px""><![endif]-->
               <table cellspacing=""0"" cellpadding=""0"" align=""right"" class=""es-right"" role=""none"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;float:right"">
                 <tr style=""border-collapse:collapse"">
                  <td align=""center"" style=""padding:0;Margin:0;width:173px"">
                   <table width=""100%"" cellspacing=""0"" cellpadding=""0"" role=""presentation"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px"">
                     <tr style=""border-collapse:collapse"">
                      <td align=""left"" style=""padding:0;Margin:0""><p style=""Margin:0;mso-line-height-rule:exactly;font-family:Arial, sans-serif;line-height:21px;letter-spacing:0;color:#FFFFFF;font-size:14px""><span style=""font-family:'lucida sans unicode', 'lucida grande', sans-serif""><strong style=""line-height:150%"">Get in Touch</strong></span><br></p></td>
                     </tr>
                     <tr style=""border-collapse:collapse"">
                      <td align=""left"" style=""padding:0;Margin:0""><p style=""Margin:0;mso-line-height-rule:exactly;font-family:Arial, sans-serif;line-height:21px;letter-spacing:0;color:#8C8788;font-size:14px""><a target=""_blank"" href=""tel:123456789"" style=""mso-line-height-rule:exactly;text-decoration:none;font-family:Arial, sans-serif;font-size:14px;color:#8C8788"">123456789</a></p><p style=""Margin:0;mso-line-height-rule:exactly;font-family:Arial, sans-serif;line-height:21px;letter-spacing:0;color:#8C8788;font-size:14px""><a target=""_blank"" href=""mailto:watson.plus.deals@gmail.com"" style=""mso-line-height-rule:exactly;text-decoration:none;font-family:Arial, sans-serif;font-size:14px;color:#8C8788"">Email@</a></p></td>
                     </tr>
                     <tr style=""border-collapse:collapse"">
                      <td align=""left"" style=""padding:0;Margin:0;padding-top:15px;font-size:0"">
                       <table cellspacing=""0"" cellpadding=""0"" class=""es-table-not-adapt es-social"" role=""presentation"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px"">
                         <tr style=""border-collapse:collapse"">
                          <td valign=""top"" align=""center"" style=""padding:0;Margin:0;padding-right:10px""><img title=""X"" src=""https://fkumuhi.stripocdn.email/content/assets/img/social-icons/circle-black/x-circle-black.png"" alt=""X"" width=""24"" height=""24"" style=""display:block;font-size:14px;border:0;outline:none;text-decoration:none""></td>
                          <td valign=""top"" align=""center"" style=""padding:0;Margin:0;padding-right:10px""><img title=""Facebook"" src=""https://fkumuhi.stripocdn.email/content/assets/img/social-icons/circle-black/facebook-circle-black.png"" alt=""Fb"" width=""24"" height=""24"" style=""display:block;font-size:14px;border:0;outline:none;text-decoration:none""></td>
                          <td valign=""top"" align=""center"" style=""padding:0;Margin:0;padding-right:10px""><img title=""Youtube"" src=""https://fkumuhi.stripocdn.email/content/assets/img/social-icons/circle-black/youtube-circle-black.png"" alt=""Yt"" width=""24"" height=""24"" style=""display:block;font-size:14px;border:0;outline:none;text-decoration:none""></td>
                         </tr>
                       </table></td>
                     </tr>
                   </table></td>
                 </tr>
               </table><!--[if mso]></td></tr></table><![endif]--></td>
             </tr>
           </table></td>
         </tr>
       </table>
       <table cellspacing=""0"" cellpadding=""0"" align=""center"" class=""es-content"" role=""none"" style=""mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;width:100%;table-layout:fixed !important"">
       </table></td>
     </tr>
   </table>
  </div>
 </body>
</html>";
        }
    }
}
