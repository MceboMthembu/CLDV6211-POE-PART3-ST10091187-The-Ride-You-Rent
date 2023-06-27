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
    public partial class Rentals : System.Web.UI.Page
    {
        private string connectionString = "Data Source=lab000000\\SQLEXPRESS;Initial Catalog=ST10091187_Therideyourentdatabse;Integrated Security=True";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindRentalGrid();
            }
        }

        protected void CreateRental(object sender, EventArgs e)
        {
            string carNo = CarNoTextBox.Text;
            string inspector = InspectorTextBox.Text;
            string driver = DriverTextBox.Text;
            int rentalFee = Convert.ToInt32(RentalFeeTextBox.Text);
            DateTime startDate = Convert.ToDateTime(StartDateTextBox.Text);
            DateTime endDate = Convert.ToDateTime(EndDateTextBox.Text);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("INSERT INTO ST10091187_Rentals__ (CarNo, Inspector, Driver, RentalFee, StartDate, EndDate) VALUES (@CarNo, @Inspector, @Driver, @RentalFee, @StartDate, @EndDate)", connection))
                {
                    command.Parameters.AddWithValue("@CarNo", carNo);
                    command.Parameters.AddWithValue("@Inspector", inspector);
                    command.Parameters.AddWithValue("@Driver", driver);
                    command.Parameters.AddWithValue("@RentalFee", rentalFee);
                    command.Parameters.AddWithValue("@StartDate", startDate);
                    command.Parameters.AddWithValue("@EndDate", endDate);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

            BindRentalGrid();
            ClearRentalForm();
        }

        protected void RentalGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            RentalGridView.EditIndex = e.NewEditIndex;
            BindRentalGrid();
        }

        protected void RentalGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            // Get the row index and other updated values
            int rowIndex = e.RowIndex;
            string carNo = RentalGridView.DataKeys[rowIndex].Values["CarNo"].ToString();
            // Get other updated values

            // Get the return date and elapsed days
            DateTime returnDate = DateTime.Parse((RentalGridView.Rows[rowIndex].FindControl("ReturnDateTextBox") as TextBox).Text);
            int elapsedDays = Convert.ToInt32((RentalGridView.Rows[rowIndex].FindControl("ElapsedDaysTextBox") as TextBox).Text);

            // Calculate the penalty fee
            int penaltyFee = CalculatePenaltyFee(returnDate, elapsedDays);

            // Update the penalty fee in the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Update the penalty fee using an appropriate UPDATE statement
                // For example:
                string updateQuery = "UPDATE ST10091187_Return SET Fine = @PenaltyFee WHERE CarNo = @CarNo";
                using (SqlCommand command = new SqlCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@PenaltyFee", penaltyFee);
                    command.Parameters.AddWithValue("@CarNo", carNo);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

            // Rebind the data to refresh the GridView
            BindRentalGrid();
        }


        private int CalculatePenaltyFee(DateTime returnDate, int elapsedDays)
        {
            // Calculate the penalty fee based on your business rules
            // For example, let's assume the penalty fee is R30 per day
            int penaltyPerDay = 30;
            int penaltyFee = penaltyPerDay * elapsedDays;

            return penaltyFee;
        }


        protected void RentalGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            RentalGridView.EditIndex = -1;
            BindRentalGrid();
        }

        protected void RentalGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string carno = RentalGridView.DataKeys[e.RowIndex].Value.ToString();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM ST10091187_Rentals__ WHERE CarNo = @CarNo";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CarNo", carno);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

            BindRentalGrid();
        }
        private void BindRentalGrid()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("SELECT * FROM ST10091187_Rentals__", connection))
                {
                    connection.Open();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    RentalGridView.DataSource = dataTable;
                    RentalGridView.DataBind();
                }
            }
        }

        private void ClearRentalForm()
        {
            CarNoTextBox.Text = string.Empty;
            InspectorTextBox.Text = string.Empty;
            DriverTextBox.Text = string.Empty;
            RentalFeeTextBox.Text = string.Empty;
            StartDateTextBox.Text = string.Empty;
            EndDateTextBox.Text = string.Empty;
        }
    }
}