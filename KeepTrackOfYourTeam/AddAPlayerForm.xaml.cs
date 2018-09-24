using System;
using System.Collections.Generic;
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
    /// Interaction logic for AddAPlayerForm.xaml
    /// </summary>
    public partial class AddAPlayerForm : Window
    {
        private readonly int _id;

        public AddAPlayerForm()
        {
            InitializeComponent();
            TabIndex = 0;
            TextBoxLastName.TabIndex = TabIndex++;
            TextBoxAdres.TabIndex = TabIndex++;
            TextBoxCity.TabIndex = TabIndex++;
            DatePickerBirthDate.TabIndex = TabIndex++;
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            AddPlayer();
        }

        private void AddPlayer()
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
    }
}
