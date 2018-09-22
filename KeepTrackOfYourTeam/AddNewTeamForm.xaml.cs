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
            buttonAdddPlayer.TabIndex = TabIndex++;
            comboBoxPlayers.TabIndex = TabIndex++;
            TextBoxName.TabIndex = TabIndex++;
            TextBoxCoach.TabIndex = TabIndex++;
            TextBoxPoints.TabIndex = TabIndex++;
        }

        private void AddAPlayer_Click(object sender, RoutedEventArgs e)
        {
            var addPlayer = new AddAPlayerForm();
            addPlayer.ShowDialog();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

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
            if (TextBoxName.Text == string.Empty || TextBoxCoach.Text == string.Empty || TextBoxPoints.Text == string.Empty)
            {
                MessageBox.Show("Veld mag niet leeg zijn!", "Velden moeten gevuld zijn", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                using (var connection = DatabaseConnectionHelper.OpenDefaultConnection())
                using (var sqlCommand = connection.CreateCommand())
                {
                    var teamNameParameter = sqlCommand.Parameters.AddWithValue("@Name", TextBoxName.Text);
                    var teamCoachParameter = sqlCommand.Parameters.AddWithValue("@CoachId", TextBoxCoach.Text);
                    var TeamPointsParameter = sqlCommand.Parameters.AddWithValue("@Points", TextBoxPoints.Text);

                    sqlCommand.CommandText =
                        $@"INSERT INTO [dbo].[Team]
                    ([Name], [CoachId], [Points])
                    VALUES ({teamNameParameter.ParameterName}, {teamCoachParameter.ParameterName}, {TeamPointsParameter.ParameterName})";
                    sqlCommand.ExecuteNonQuery();
                }

                MessageBox.Show("Success!", "", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
        }
    }
}
