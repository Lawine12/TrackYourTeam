using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace KeepTrackOfYourTeam
{
    /// <summary>
    /// Interaction logic for EditTeamForm.xaml
    /// </summary>
    public partial class EditTeamForm : Window
    {
        private readonly string _id;
        private DataTable _teamInformation;

        public EditTeamForm()
        {
            InitializeComponent();
        }

        public EditTeamForm(string id) : this()
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
            var queryString = "SELECT * FROM TeamData WHERE Id=@id";
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
