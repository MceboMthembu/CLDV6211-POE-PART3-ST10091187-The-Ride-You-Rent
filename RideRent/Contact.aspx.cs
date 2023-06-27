using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace RideRent
{
    public partial class Contact : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblStatus.Visible = false;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string name = txtName.Value;
            string email = txtEmail.Value;
            string message = txtMessage.Value;

            try
            {
                // Create and configure the email message
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(email);
                mail.To.Add("info@therideyourent.com");
                mail.Subject = "Contact Form Submission";
                mail.Body = $"Name: {name}<br>Email: {email}<br>Message: {message}";
                mail.IsBodyHtml = true;

                // Create and configure the SMTP client
                SmtpClient smtpClient = new SmtpClient("your-smtp-server");
                smtpClient.Send(mail);

                // Display success message
                lblStatus.Text = "Your message has been sent successfully.";
                lblStatus.CssClass = "text-success";
            }
            catch (Exception ex)
            {
                // Display error message
                lblStatus.Text = "An error occurred while sending the message. Please try again later.";
                lblStatus.CssClass = "text-danger";
                // You can also log the error for further analysis
            }

            lblStatus.Visible = true;
            ClearForm();
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        private void ClearForm()
        {
            txtName.Value = string.Empty;
            txtEmail.Value = string.Empty;
            txtMessage.Value = string.Empty;
        }
    }
}