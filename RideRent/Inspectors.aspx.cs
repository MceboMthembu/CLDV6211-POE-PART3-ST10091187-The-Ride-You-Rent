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
    public partial class Inspectors : System.Web.UI.Page
    {
        private string connectionString = "Data Source=lab000000\\SQLEXPRESS;Initial Catalog=ST10091187_Therideyourentdatabse;Integrated Security=True";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindInspectorGrid();
            }
        }

        protected void InsertInspector(object sender, EventArgs e)
        {
            string inspectorNo = InspectorNoTextBox.Text;
            string name = NameTextBox.Text;
            string email = EmailTextBox.Text;
            string mobile = MobileTextBox.Text;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO ST10091187_Inspector (InspectorNo, Name, Email, Mobile) VALUES (@InspectorNo, @Name, @Email, @Mobile)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@InspectorNo", inspectorNo);
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Mobile", mobile);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

            ClearInspectorForm();
            BindInspectorGrid();
        }

        protected void InspectorGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            InspectorGridView.EditIndex = e.NewEditIndex;
            BindInspectorGrid();
        }

        protected void InspectorGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = InspectorGridView.Rows[e.RowIndex];
            string inspectorNo = ((TextBox)row.FindControl("InspectorNoTextBox")).Text;
            string name = ((TextBox)row.FindControl("NameTextBox")).Text;
            string email = ((TextBox)row.FindControl("EmailTextBox")).Text;
            string mobile = ((TextBox)row.FindControl("MobileTextBox")).Text;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE ST10091187_Inspector SET Name = @Name, Email = @Email, Mobile = @Mobile WHERE InspectorNo = @InspectorNo";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Mobile", mobile);
                    command.Parameters.AddWithValue("@InspectorNo", inspectorNo);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

            InspectorGridView.EditIndex = -1;
            BindInspectorGrid();
        }

        protected void InspectorGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            InspectorGridView.EditIndex = -1;
            BindInspectorGrid();
        }

        protected void InspectorGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string inspectorNo = InspectorGridView.DataKeys[e.RowIndex].Value.ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM ST10091187_Inspector WHERE InspectorNo = @InspectorNo";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@InspectorNo", inspectorNo);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

            BindInspectorGrid();
        }
        private void BindInspectorGrid()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM ST10091187_Inspector";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        InspectorGridView.DataSource = dt;
                        InspectorGridView.DataBind();
                    }
                }
            }
        }

        private void ClearInspectorForm()
        {
            InspectorNoTextBox.Text = string.Empty;
            NameTextBox.Text = string.Empty;
            EmailTextBox.Text = string.Empty;
            MobileTextBox.Text = string.Empty;
        }
    }
}