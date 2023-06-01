using System;
using System.Data;
using System.Windows.Forms;
using CarAppWebClient.LoginService;
namespace CarAppWebClient
{
    public partial class AdminToolsForm : Form
    {

        private AdminService.AdminServiceSoapClient service = new AdminService.AdminServiceSoapClient();
        private Admin admin;
        private int userId;
        private DataSet dsUsers;

        // DEFAUL CONSTRUCTOR
        public AdminToolsForm()
        {
            InitializeComponent();
            admin = null;
            userId = -1;
        }

        // ADMIN CONSTRUCTOR
        public AdminToolsForm(Admin admin)
        {
            InitializeComponent();
            userId = -1;
            this.admin = admin;
            refresh();
        }

        // BANS USER
        private void buttonBan_Click(object sender, EventArgs e)
        {
            if (admin != null && userId != -1)
            { 
                service.banUser(userId);
                refresh();
            }
        }

        // UNBANS USER
        private void buttonUnBan_Click(object sender, EventArgs e)
        {
            if (admin != null && userId != -1)
            {
                service.unbanUser(userId);
                   refresh();
            }
        }

        // SELECTS USER FORM DATAGRIDVIEW, IF THERE IS ANY
        private void dataGridViewUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridViewUsers.SelectedRows[0];
                
                userId = int.Parse(selectedRow.Cells[0].Value.ToString());
                Console.WriteLine("USER ID:" + userId);
            }
            else
                userId=-1;
        }

        // REFRESHES DATAGRIDVIEW
        private void refresh()
        {
            if (checkBox.Checked)
            {
                dsUsers = service.PopulateUsers(true);
                dataGridViewUsers.DataSource = dsUsers.Tables["Users"].DefaultView;
            }
            else
            {
                dsUsers = service.PopulateUsers(false);
                dataGridViewUsers.DataSource = dsUsers.Tables["Users"].DefaultView;
            }
            if (dataGridViewUsers.Rows.Count > 0)
            {
                userId = int.Parse(dataGridViewUsers.Rows[0].Cells[0].Value.ToString());
            }
            else
                userId = 0;
        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            refresh();
        }

        // DELETS USER
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (admin != null && userId != -1)
            {
                service.deleteUser(userId);
                refresh();
            }
        }

        // CLOSES FORM, REOPENS BrowserForm
        private void buttonBack_Click(object sender, EventArgs e)
        {
            if (admin != null)
            {
                this.Dispose();
                new BrowserForm(admin).Show();
            }
        }

        // CLOSES APPLICATION
        private void AdminToolsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            refresh();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (admin != null && userId != -1)
            {
                service.deleteUser(userId);
                refresh();
            }
        }
    }
}
