using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace KeepTrackOfYourTeam
{
    /// <summary>
    /// Interaction logic for EditPlayerForm.xaml
    /// </summary>
    public partial class EditPlayerForm : Window
    {
        private readonly string _id;
        private DataTable _teamInformation;

        public EditPlayerForm()
        {
            InitializeComponent();
        }

        public EditPlayerForm(string id) : this()
        {
            _id = id;
            LoadData();
        }

        private void LoadData()
        {
            var teamsData = GetDataTable();
            if (teamsData.Rows.Count == 1)
            {
                var row = _teamInformation.Rows[0];
                TextBoxLastName.Text = (string)row["LastName"];
                TextBoxAdres.Text = (string)row["Adres"];
                TextBoxCity.Text = (string)row["City"];
                DatePickerBirthDate.Text = row["BirthDate"] as string;
            }
        }

        private DataTable GetDataTable()
        {
            _teamInformation = new DataTable();
            var queryString = "SELECT * FROM Person WHERE Id=@id";
            using (var connection = DatabaseConnectionHelper.OpenDefaultConnection())
            using (var cmd = new SqlCommand(queryString, connection))
            {
                cmd.Parameters.AddWithValue("@id", _id);
                var sqlAdapter = new SqlDataAdapter(cmd);
                sqlAdapter.Fill(_teamInformation);
            }
            return _teamInformation;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            EditPlayer();
            this.Close();
            LoadData();
        }

        private void EditPlayer()
        {
            if (TextBoxLastName.Text == string.Empty || TextBoxAdres.Text == string.Empty || TextBoxCity.Text == string.Empty || DatePickerBirthDate.Text == string.Empty)
            {
                MessageBox.Show("Veld mag niet leeg zijn!", "Velden moeten gevuld zijn", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                using (var connection = DatabaseConnectionHelper.OpenDefaultConnection())
                using (var sqlCommand = connection.CreateCommand())
                {
                    var id = sqlCommand.Parameters.AddWithValue("@id", _id);
                    var lastNameParameter = sqlCommand.Parameters.AddWithValue("@LastName", TextBoxLastName.Text);
                    var addressParameter = sqlCommand.Parameters.AddWithValue("@Adres", TextBoxAdres.Text);
                    var cityParameter = sqlCommand.Parameters.AddWithValue("@City", TextBoxCity.Text);
                    var birthDateParameter = sqlCommand.Parameters.AddWithValue("@BirthDate", DatePickerBirthDate.SelectedDate);

                    sqlCommand.CommandText =
                        $@"INSERT INTO [dbo].[Person]
                    ([PersonId], [LastName], [Adres], [City], [BirthDate])
                    VALUES ({id}, {lastNameParameter.ParameterName}, {addressParameter.ParameterName}, {cityParameter.ParameterName}, {birthDateParameter.ParameterName})";
                    sqlCommand.ExecuteNonQuery();
                }

                MessageBox.Show("Success!", "", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
