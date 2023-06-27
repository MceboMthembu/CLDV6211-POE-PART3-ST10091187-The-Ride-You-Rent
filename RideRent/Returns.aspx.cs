using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;

namespace RideRent
{
    public partial class Returns : System.Web.UI.Page
    {
        private string connectionString = "Data Source=lab000000\\SQLEXPRESS;Initial Catalog=ST10091187_Therideyourentdatabse;Integrated Security=True";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindReturnData();
            }
        }

        protected void BindReturnData()
        {
            string query = "SELECT * FROM ST10091187_Return";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        ReturnGridView.DataSource = dataTable;
                        ReturnGridView.DataBind();
                    }
                }
            }
        }

        protected void CreateReturn(object sender, EventArgs e)
        {
            string carNo = CarNoTextBox.Text;
            string inspector = InspectorTextBox.Text;
            string driver = DriverTextBox.Text;
            DateTime returnDate = Convert.ToDateTime(ReturnDateTextBox.Text);
            int elapsedDays = Convert.ToInt32(ElapsedDaysTextBox.Text);
            int fine = Convert.ToInt32(FineTextBox.Text);

            string formattedReturnDate = returnDate.ToString("yyyy-MM-dd");

            string query = "INSERT INTO ST10091187_Return (CarNo, Inspector, Driver, ReturnDate, ElapsedDate, Fine) VALUES (@CarNo, @Inspector, @Driver, @ReturnDate, @ElapsedDays, @Fine)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CarNo", carNo);
                    command.Parameters.AddWithValue("@Inspector", inspector);
                    command.Parameters.AddWithValue("@Driver", driver);
                    command.Parameters.AddWithValue("@ReturnDate", returnDate);
                    command.Parameters.AddWithValue("@ElapsedDays", elapsedDays);
                    command.Parameters.AddWithValue("@Fine", fine);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

            ClearReturnForm();
            BindReturnData();
        }

        protected void ReturnGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string carNo = ReturnGridView.DataKeys[e.RowIndex].Value.ToString();
            string query = "DELETE FROM ST10091187_Return WHERE CarNo = @CarNo";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CarNo", carNo);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

            BindReturnData();
        }

        protected void ClearReturnForm()
        {
            CarNoTextBox.Text = "";
            InspectorTextBox.Text = "";
            DriverTextBox.Text = "";
            ReturnDateTextBox.Text = "";
            ElapsedDaysTextBox.Text = "";
            FineTextBox.Text = "";
        }
    }
}