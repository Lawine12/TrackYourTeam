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
    /// Interaction logic for ViewTeamsForm.xaml
    /// </summary>
    public partial class ViewTeamsForm : Window
    {
        private DataTable _teamData;

        public ViewTeamsForm()
        {
            InitializeComponent();
            LoadData();
            buttonEditTeam.IsEnabled = false;
            buttonDeleteTeam.IsEnabled = false;
        }

        private void LoadData()
        {
            dataGridTeams.CanUserAddRows = false;
            dataGridTeams.SelectionMode = DataGridSelectionMode.Single;
            dataGridTeams.IsReadOnly = true;

            string querystring = "SELECT * FROM dbo.Team";

            using (var connection = DatabaseConnectionHelper.OpenDefaultConnection())
            {
                var cmd = new SqlCommand(querystring, connection);
                var dataAdapter = new SqlDataAdapter(cmd);
                _teamData = new DataTable();
                dataAdapter.Fill(_teamData);
                dataGridTeams.DataContext = _teamData;
                dataGridTeams.ItemsSource = _teamData.DefaultView;
            }
        }

        //Add Team
        private void buttonAddATeam_Click(object sender, RoutedEventArgs e)
        {
            var addTeam = new AddNewTeamForm();
            addTeam.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            addTeam.ShowDialog();
            LoadData();
        }

        //Edit Team
        private void buttonEditTeam_Click(object sender, RoutedEventArgs e)
        {
            Object selectedRow = dataGridTeams.SelectedItem;
            if (selectedRow != null)
            {
                string id = (dataGridTeams.SelectedCells[0].Column.GetCellContent(selectedRow) as TextBlock).Text;
                var team = dataGridTeams.SelectedCells[1].Item;
                var editTeam = new EditTeamForm(id);
                editTeam.ShowDialog();
                LoadData();
                buttonDeleteTeam.IsEnabled = false;
                buttonEditTeam.IsEnabled = false;
            }
        }

        //Delete Team
        private void buttonDeleteTeam_Click(object sender, RoutedEventArgs e)
        {

            Object selectedRow = dataGridTeams.SelectedItem;
            if (selectedRow != null)
            {
                string team = (dataGridTeams.SelectedCells[0].Column.GetCellContent(selectedRow) as TextBlock).Text;

                if (MessageBox.Show("Weet u het zeker?", "", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.OK)
                {
                    var itemSource = dataGridTeams.ItemsSource as DataView;

                    itemSource.Delete(dataGridTeams.SelectedIndex);
                    dataGridTeams.ItemsSource = itemSource;
                    buttonDeleteTeam.IsEnabled = false;
                    buttonEditTeam.IsEnabled = false;
                }
                else
                {
                    return;
                }

                var queryString = "SELECT * FROM dbo.Team";
                using (var connection = DatabaseConnectionHelper.OpenDefaultConnection())
                {
                    var cmd = new SqlCommand(queryString, connection);
                    var dataAdapter = new SqlDataAdapter(cmd);
                    var cmdBuilder = new SqlCommandBuilder(dataAdapter);

                    dataAdapter.Update(_teamData);
                }
            }
        }

        private void dataGridTeams_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            buttonEditTeam.IsEnabled = true;
            buttonDeleteTeam.IsEnabled = true;
        }
    }
}
