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
    /// Interaction logic for AddNewTeamForm.xaml
    /// </summary>
    public partial class AddNewTeamForm : Window
    {
        public AddNewTeamForm()
        {
            InitializeComponent();
            TabIndex = 0;
            TextBoxName.TabIndex = TabIndex++;
            TextBoxCoach.TabIndex = TabIndex++;
            TextBoxPoints.TabIndex = TabIndex++;
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            AddTeam();
        }

        private void AddTeam()
        {
            if (TextBoxName.Text != string.Empty && TextBoxCoach.Text != string.Empty)
            {
                using (var connection = DatabaseConnectionHelper.OpenDefaultConnection())
                using (var sqlCommand = connection.CreateCommand())
                {
                    var teamNameParameter = sqlCommand.Parameters.AddWithValue("@Name", TextBoxName.Text);
                    var teamCoachParameter = sqlCommand.Parameters.AddWithValue("@Coach", TextBoxCoach.Text);
                    var teamPointsParameter = sqlCommand.Parameters.AddWithValue("@Points", TextBoxPoints.Text);

                    sqlCommand.CommandText =
                        $@"INSERT INTO [dbo].[Team]
                    ([Name], [Coach], [Points])
                    VALUES ({teamNameParameter.ParameterName}, {teamCoachParameter.ParameterName}, {teamPointsParameter.ParameterName})";
                    sqlCommand.ExecuteNonQuery();
                }

                MessageBox.Show("Success!", "", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            else
                MessageBox.Show("Veld mag niet leeg zijn!", "Velden moeten gevuld zijn", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
