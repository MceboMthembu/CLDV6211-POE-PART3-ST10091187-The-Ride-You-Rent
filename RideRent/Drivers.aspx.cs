using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RideRent
{
    public partial class Drivers : System.Web.UI.Page
    {
        private string connectionString = "Data Source=lab000000\\SQLEXPRESS;Initial Catalog=ST10091187_Therideyourentdatabse;Integrated Security=True";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDriverGrid();
            }
        }

        protected void InsertDriver(object sender, EventArgs e)
        {
            string name = NameTextBox.Text;
            string address = AddressTextBox.Text;
            string email = EmailTextBox.Text;
            string mobile = MobileTextBox.Text;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO ST10091187_Driver (Name, Address, Email, Mobile) VALUES (@Name, @Address, @Email, @Mobile)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Address", address);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Mobile", mobile);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

            ClearDriverForm();
            BindDriverGrid();
        }

        protected void DriverGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            DriverGridView.EditIndex = e.NewEditIndex;
            BindDriverGrid();
        }

        protected void DriverGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = DriverGridView.Rows[e.RowIndex];
            string driverId = DriverGridView.DataKeys[e.RowIndex].Value.ToString();
            string name = ((TextBox)row.FindControl("NameTextBox")).Text;
            string address = ((TextBox)row.FindControl("AddressTextBox")).Text;
            string email = ((TextBox)row.FindControl("EmailTextBox")).Text;
            string mobile = ((TextBox)row.FindControl("MobileTextBox")).Text;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE ST10091187_Driver SET Name = @Name, Address = @Address, Email = @Email, Mobile = @Mobile WHERE DriverId = @DriverId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Address", address);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Mobile", mobile);
                    command.Parameters.AddWithValue("@DriverId", driverId);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

            DriverGridView.EditIndex = -1;
            BindDriverGrid();
        }

        protected void DriverGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            DriverGridView.EditIndex = -1;
            BindDriverGrid();
        }

        protected void DriverGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string name = DriverGridView.DataKeys[e.RowIndex].Value.ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM ST10091187_Driver WHERE Name = @Name";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", name);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

            BindDriverGrid();
        }

        private void DeleteDriver(string driverId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM ST10091187_Driver WHERE DriverId = @DriverId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@DriverId", driverId);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        private void BindDriverGrid()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM ST10091187_Driver";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        DriverGridView.DataSource = dt;
                        DriverGridView.DataBind();
                    }
                }
            }
        }

        private void ClearDriverForm()
        {
            NameTextBox.Text = string.Empty;
            AddressTextBox.Text = string.Empty;
            EmailTextBox.Text = string.Empty;
            MobileTextBox.Text = string.Empty;
        }
    }
}