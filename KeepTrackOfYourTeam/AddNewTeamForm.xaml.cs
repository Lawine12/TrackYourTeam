using System;
using System.Windows;
using KeepTrackOfYourTeam.Properties;

namespace KeepTrackOfYourTeam
{
    /// <summary>
    /// Interaction logic for AddNewTeamForm.xaml
    /// </summary>
    public partial class AddNewTeamForm : Window
    {
        private readonly int _id;

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
            AddTeam(_id);
        }

        private void AddTeam(int _id)
        {
            var team = new Coach();
            team.Id = _id;
            team.Name = TextBoxName.Text;
            team.CoachName = TextBoxCoach.Text;
            team.Points = Convert.ToInt32(TextBoxPoints.Text);


            if (TextBoxName.Text != string.Empty && TextBoxCoach.Text != string.Empty)
            {
                using (var connection = DatabaseConnectionHelper.OpenDefaultConnection())
                using (var sqlCommand = connection.CreateCommand())
                {
                    var teamNameParameter = sqlCommand.Parameters.AddWithValue("@Name", team.Name);
                    var teamCoachParameter = sqlCommand.Parameters.AddWithValue("@Coach", team.CoachName);
                    var teamPointsParameter = sqlCommand.Parameters.AddWithValue("@Points", team.Points);

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
