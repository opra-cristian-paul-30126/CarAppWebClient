using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CarAppWebClient.BrowseService;
using CarAppWebClient.LoginService;
namespace CarAppWebClient
{
    public partial class AdminToolsForm : Form
    {

        AdminService.AdminServiceSoapClient service = new AdminService.AdminServiceSoapClient();
        private Admin admin;
        private int userId;
        private DataSet dsUsers;
        public AdminToolsForm()
        {
            InitializeComponent();
            admin = null;
            userId = -1;
        }

        public AdminToolsForm(Admin admin)
        {
            InitializeComponent();
            userId = -1;
            this.admin = admin;
            dsUsers = service.PopulateUsers(true);
            dataGridViewUsers.DataSource = dsUsers.Tables["Users"].DefaultView;
        }

        private void buttonBan_Click(object sender, EventArgs e)
        {
            if (admin != null && userId != -1)
            {
                Console.WriteLine("O SA BANEZ PE OMU CU IDU:" + userId);
                    service.banUser(userId);
                refresh();
            }
        }

        private void buttonUnBan_Click(object sender, EventArgs e)
        {
            if (admin != null && userId != -1)
            {
                service.unbanUser(userId);
                   refresh();
            }
        }

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
