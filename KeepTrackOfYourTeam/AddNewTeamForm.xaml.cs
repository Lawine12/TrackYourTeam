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
    }
}
