using CarAppWebClient.LoginService;
using CarAppWebClient.BrowseService;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
namespace CarAppWebClient
{
    public partial class MyAnnounces : Form
    {
        private User user;
        private DataSet dsAnnounces;
        private Announce announce;
        private MyAnnouncesService.MyAnnouncesServicesSoapClient Service = new MyAnnouncesService.MyAnnouncesServicesSoapClient();
        private BrowseServiceSoapClient Service2 = new BrowseServiceSoapClient();
        public MyAnnounces(User user)
        {
            InitializeComponent();
            this.user = user;
            refresh();

        }

        private void refresh()
        {
            dsAnnounces = Service.PopulateGrid(user.id);
            dataGridView.DataSource = dsAnnounces.Tables["Announces"].DefaultView;
            dataGridView.Columns["IdUser"].Visible = false;
            dataGridView.Columns["IdAnunt"].Visible = false;
            dataGridView.Columns["Imagine1"].Visible = false;
            dataGridView.Columns["Imagine2"].Visible = false;
            dataGridView.Columns["Imagine3"].Visible = false;

            // sa selecteze primul element automat, daca exista
            if (dataGridView.Rows.Count > 0)
            {
                int id = int.Parse(dataGridView.Rows[0].Cells[1].Value.ToString());
                Console.WriteLine(id);
                announce = Service2.getAnounceData(id);
                pictureBox.Image = ConvertByteArrayToImage(announce.imagAnunt);
            }

        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView.SelectedRows[0];
                if (selectedRow.Cells[selectedRow.Cells.Count - 1].Value != DBNull.Value)
                {
                    byte[] announceImageCollumValue = (byte[])selectedRow.Cells[selectedRow.Cells.Count - 4].Value;
                    if (announceImageCollumValue.Length > 0)
                        pictureBox.Image = ConvertByteArrayToImage(announceImageCollumValue);
                }
                int id = int.Parse(selectedRow.Cells[1].Value.ToString());
                Console.WriteLine(id);
                announce = Service2.getAnounceData(id);
            }
            else
                announce = null;
        }

        public System.Drawing.Image ConvertByteArrayToImage(byte[] byteArray)
        {
            MemoryStream ms = new MemoryStream(byteArray);
            System.Drawing.Image rez = System.Drawing.Image.FromStream(ms);
            return rez;
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (announce != null)
            {
                Service.deleteAnnounce(announce.idAnunt);
                refresh();
            }

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            AnnounceAddModifyForm admf = new AnnounceAddModifyForm(user);
            this.Hide();
            admf.Show();
            if(admf.IsDisposed)
            {
                this.Show();
                refresh();
            }

        }

        private void buttonModift_Click(object sender, EventArgs e)
        {
            if(announce!=null)
            {
                AnnounceAddModifyForm admf = new AnnounceAddModifyForm(announce, user);
                this.Hide();
                admf.Show();
                if (admf.IsDisposed)
                {
                    this.Show();
                    refresh();
                }
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Dispose();
            new BrowserForm(user).Show();
        }

        private void MyAnnounces_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
