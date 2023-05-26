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
        User user;
        DataSet dsAnnounces;
        Announce announce;
        MyAnnouncesService.MyAnnouncesServicesSoapClient Service = new MyAnnouncesService.MyAnnouncesServicesSoapClient();
        BrowseService.BrowseServiceSoapClient Service2 = new BrowseService.BrowseServiceSoapClient();
        public MyAnnounces(User user)
        {
            InitializeComponent();
            this.user = user;
            dsAnnounces = Service.PopulateGrid(user.id);
            Console.WriteLine(user.id);
            dataGridView.DataSource = dsAnnounces.Tables["Announces"].DefaultView;
            dataGridView.Columns["IdUser"].Visible  = false;
            dataGridView.Columns["IdAnunt"].Visible = false;
            dataGridView.Columns["Imagine1"].Visible  = false;
            dataGridView.Columns["Imagine2"].Visible  = false;
            dataGridView.Columns["Imagine3"].Visible  = false;
        }



        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow selectedRow = dataGridView.SelectedRows[0];
            if (selectedRow.Cells[selectedRow.Cells.Count - 1].Value != DBNull.Value)
            {
                byte[] lastColumnValue = (byte[])selectedRow.Cells[selectedRow.Cells.Count - 1].Value;
                if (lastColumnValue.Length > 0)
                    pictureBox.Image = ConvertByteArrayToImage(lastColumnValue);
            }
            int id = int.Parse(selectedRow.Cells[0].Value.ToString());
            Console.WriteLine(id);
            announce = Service2.getAnounceData(id);
        }

        public System.Drawing.Image ConvertByteArrayToImage(byte[] byteArray)
        {
            MemoryStream ms = new MemoryStream(byteArray);
            System.Drawing.Image rez = System.Drawing.Image.FromStream(ms);
            return rez;
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            AnnounceAddModifyForm admf = new AnnounceAddModifyForm(user);
            admf.ShowDialog();
        }

        private void buttonModift_Click(object sender, EventArgs e)
        {
            AnnounceAddModifyForm admf = new AnnounceAddModifyForm(announce,user);
            admf.ShowDialog();
        }
    }
}
