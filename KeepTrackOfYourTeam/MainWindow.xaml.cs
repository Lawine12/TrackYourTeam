using System.Windows;

namespace KeepTrackOfYourTeam
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddATeam_Click(object sender, RoutedEventArgs e)
        {
            var addTeam = new AddNewTeamForm();
            addTeam.ShowDialog();
        }

        private void AddAPlayer_Click(object sender, RoutedEventArgs e)
        {
            var addPlayer = new AddAPlayerForm();
            addPlayer.ShowDialog();
        }

        private void ViewTeams_Click(object sender, RoutedEventArgs e)
        {
            var viewTeams = new ViewTeamsForm();
            viewTeams.ShowDialog();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ViewPlayers_Click(object sender, RoutedEventArgs e)
        {
            var viewPlayers = new ViewPlayersForm();
            viewPlayers.ShowDialog();
        }
    }
}
