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
                //textboxTeamName.Text = (string)row["TeamName"];
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
    }
}
