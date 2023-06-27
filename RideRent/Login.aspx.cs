using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RideRent
{
    public partial class Login : System.Web.UI.Page
    {
        private string connectionString = "Data Source=lab000000\\SQLEXPRESS;Initial Catalog=ST10091187_Therideyourentdatabse;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string name = txtName.Value;
            string email = txtEmail.Value;

            if (ValidateCredentials(name, email))
            {
                // Credentials are valid, set session variable or cookie to indicate login success
                Session["InspectorLoggedIn"] = true;

                // Redirect to the protected page 
                Response.Redirect("Navigation.aspx");
            }
            else
            {
                // Credentials are invalid, display an error message
                lblError.Text = "Invalid name or email. Please try again.";
            }
        }

        private bool ValidateCredentials(string name, string email)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM ST10091187_Inspector WHERE Name = @Name AND Email = @Email";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Email", email);

                    connection.Open();
                    int count = Convert.ToInt32(command.ExecuteScalar());
                    return count > 0;
                }
            }
        }
    }
}