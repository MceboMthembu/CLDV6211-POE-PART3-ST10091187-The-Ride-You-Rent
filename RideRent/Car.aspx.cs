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
    public partial class Car : System.Web.UI.Page
    {
        private string connectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            connectionString = "Data Source=lab000000\\SQLEXPRESS;Initial Catalog=ST10091187_Therideyourentdatabse;Integrated Security=True";
            if (!IsPostBack)
            {
                BindCarData();
            }
        }

        protected void BindCarData()
        {
            string query = "SELECT * FROM ST10091187_Car";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        CarGridView.DataSource = dataTable;
                        CarGridView.DataBind();
                    }
                }
            }
        }

        protected void InsertCar(object sender, EventArgs e)
        {
            string carNo = CarNoTextBox.Text;
            string make = MakeTextBox.Text;
            string model = ModelTextBox.Text;
            string bodyType = BodyTypeTextBox.Text;
            int kilometresTravelled = Convert.ToInt32(KilometresTextBox.Text);
            int serviceKilometres = Convert.ToInt32(ServiceKilometresTextBox.Text);
            string available = AvailableTextBox.Text;

            string query = "INSERT INTO ST10091187_Car (CarNo, Make, Model, BodyType, KilometresTravelled, ServiceKilometres, Available) VALUES (@CarNo, @Make, @Model, @BodyType, @KilometresTravelled, @ServiceKilometres, @Available)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CarNo", carNo);
                    command.Parameters.AddWithValue("@Make", make);
                    command.Parameters.AddWithValue("@Model", model);
                    command.Parameters.AddWithValue("@BodyType", bodyType);
                    command.Parameters.AddWithValue("@KilometresTravelled", kilometresTravelled);
                    command.Parameters.AddWithValue("@ServiceKilometres", serviceKilometres);
                    command.Parameters.AddWithValue("@Available", available);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

            ClearCarForm();
            BindCarData();
        }

        protected void CarGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            CarGridView.EditIndex = e.NewEditIndex;
            BindCarData();
        }

        protected void CarGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = CarGridView.Rows[e.RowIndex];
            string carNo = CarGridView.DataKeys[e.RowIndex].Value.ToString();
            string make = ((TextBox)row.FindControl("MakeTextBox")).Text;
            string model = ((TextBox)row.FindControl("ModelTextBox")).Text;
            string bodyType = ((TextBox)row.FindControl("BodyTypeTextBox")).Text;
            int kilometresTravelled = Convert.ToInt32(((TextBox)row.FindControl("KilometresTextBox")).Text);
            int serviceKilometres = Convert.ToInt32(((TextBox)row.FindControl("ServiceKilometresTextBox")).Text);
            string available = ((TextBox)row.FindControl("AvailableTextBox")).Text;

            string query = "UPDATE ST10091187_Car SET Make = @Make, Model = @Model, BodyType = @BodyType, KilometresTravelled = @KilometresTravelled, ServiceKilometres = @ServiceKilometres, Available = @Available WHERE CarNo = @CarNo";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Make", make);
                    command.Parameters.AddWithValue("@Model", model);
                    command.Parameters.AddWithValue("@BodyType", bodyType);
                    command.Parameters.AddWithValue("@KilometresTravelled", kilometresTravelled);
                    command.Parameters.AddWithValue("@ServiceKilometres", serviceKilometres);
                    command.Parameters.AddWithValue("@Available", available);
                    command.Parameters.AddWithValue("@CarNo", carNo);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

            CarGridView.EditIndex = -1;
            BindCarData();
        }

        protected void CarGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            CarGridView.EditIndex = -1;
            BindCarData();
        }

        protected void CarGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string carNo = CarGridView.DataKeys[e.RowIndex].Value.ToString();

            string query = "DELETE FROM ST10091187_Car WHERE CarNo = @CarNo";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CarNo", carNo);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

            BindCarData();
        }

        private void ClearCarForm()
        {
            CarNoTextBox.Text = string.Empty;
            MakeTextBox.Text = string.Empty;
            ModelTextBox.Text = string.Empty;
            BodyTypeTextBox.Text = string.Empty;
            KilometresTextBox.Text = string.Empty;
            ServiceKilometresTextBox.Text = string.Empty;
            AvailableTextBox.Text = string.Empty;
        }
    }
}