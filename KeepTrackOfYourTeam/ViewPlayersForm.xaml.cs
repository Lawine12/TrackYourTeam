using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace KeepTrackOfYourTeam
{
    /// <summary>
    /// Interaction logic for ViewPlayersForm.xaml
    /// </summary>
    public partial class ViewPlayersForm : Window
    {

        private DataTable _teamData;

        public ViewPlayersForm()
        {
            InitializeComponent();
            LoadData();
            buttonEditAPlayer.IsEnabled = false;
            buttonDeleteAPlayer.IsEnabled = false;
        }



        private void LoadData()
        {
            dataGridViewPlayers.CanUserAddRows = false;
            dataGridViewPlayers.SelectionMode = DataGridSelectionMode.Single;
            dataGridViewPlayers.IsReadOnly = true;

            string querystring = "SELECT * FROM dbo.Person";

            using (var connection = DatabaseConnectionHelper.OpenDefaultConnection())
            {
                var cmd = new SqlCommand(querystring, connection);
                var dataAdapter = new SqlDataAdapter(cmd);
                _teamData = new DataTable();
                dataAdapter.Fill(_teamData);
                dataGridViewPlayers.DataContext = _teamData;
                dataGridViewPlayers.ItemsSource = _teamData.DefaultView;
            }
        }

        //Add Team
        private void buttonAddAPlayer_Click(object sender, RoutedEventArgs e)
        {
            var addTeam = new AddAPlayerForm();
            addTeam.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            addTeam.ShowDialog();
            LoadData();
            buttonDeleteAPlayer.IsEnabled = false;
            buttonEditAPlayer.IsEnabled = false;
        }

        //Edit Team
        private void buttonEditAPlayer_Click(object sender, RoutedEventArgs e)
        {
            Object selectedRow = dataGridViewPlayers.SelectedItem;
            if (selectedRow != null)
            {
                string id = (dataGridViewPlayers.SelectedCells[0].Column.GetCellContent(selectedRow) as TextBlock).Text;
                var team = dataGridViewPlayers.SelectedCells[1].Item;
                var editTeam = new EditPlayerForm(id);
                editTeam.ShowDialog();
                LoadData();
                buttonEditAPlayer.IsEnabled = false;
                buttonDeleteAPlayer.IsEnabled = false;
            }
        }


        //Delete Team
        private void buttonDeleteAPlayer_Click(object sender, RoutedEventArgs e)
        {

            Object selectedRow = dataGridViewPlayers.SelectedItem;
            if (selectedRow != null)
            {
                string player = (dataGridViewPlayers.SelectedCells[0].Column.GetCellContent(selectedRow) as TextBlock).Text;

                if (MessageBox.Show("Weet u het zeker?", "", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.OK)
                {
                    var itemSource = dataGridViewPlayers.ItemsSource as DataView;

                    itemSource.Delete(dataGridViewPlayers.SelectedIndex);
                    dataGridViewPlayers.ItemsSource = itemSource;
                    buttonDeleteAPlayer.IsEnabled = false;
                    buttonEditAPlayer.IsEnabled = false;
                }
                else
                {
                    return;
                }

                var queryString = "SELECT * FROM dbo.Person";
                using (var connection = DatabaseConnectionHelper.OpenDefaultConnection())
                {
                    var cmd = new SqlCommand(queryString, connection);
                    var dataAdapter = new SqlDataAdapter(cmd);
                    var cmdBuilder = new SqlCommandBuilder(dataAdapter);

                    dataAdapter.Update(_teamData);
                }
            }
        }

        private void dataGridViewPlayers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            buttonEditAPlayer.IsEnabled = true;
            buttonDeleteAPlayer.IsEnabled = true;
        }
    }
}
