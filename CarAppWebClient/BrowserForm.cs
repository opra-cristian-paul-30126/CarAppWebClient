using CarAppWebClient.BrowseService;
using CarAppWebClient.LoginService;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace CarAppWebClient
{
    public partial class BrowserForm : Form
    {
        private User user;
        private Admin admin;
        private Announce announce;
        private DataSet dsAnnounces;
        private BrowseServiceSoapClient BrowseService = new BrowseServiceSoapClient();
        // DEFAULT CONSTRUCTOR
        public BrowserForm(){ InitializeComponent(); }

        // USER CONSTRUCTOR
        public BrowserForm(User user)
        {
            InitializeComponent();
            this.user = user;

            label18.Text = user.nume + " " + user.prenume;
            pictureBoxUser.Image = ConvertByteArrayToImage(user.pozaProfil);

            // POPULATE GRIDVIEW
            dsAnnounces = BrowseService.PopulateGrid();
            dataGridView.DataSource = dsAnnounces.Tables["Announces"].DefaultView;

            // IF THERE ARE ANNOUNCES 
            if (dataGridView.Rows.Count > 0)
            {
                // SELECT THE FIRST ANNOUNCE AND GET ITS ID
                int id = int.Parse(dataGridView.Rows[0].Cells[1].Value.ToString());
                byte[] announceImageCollumValue = (byte[])dataGridView.Rows[0].Cells[dataGridView.Rows[0].Cells.Count - 4].Value;
                // DRAW THE PICTURE OF THE ANNOUNCE
                pictureBoxAnnounce.Image = ConvertByteArrayToImage(announceImageCollumValue);
                announce = BrowseService.getAnounceData(id);
            }
            init();
            resetFilters();

        }

        // ADMIN CONSTRUCTOR
        public BrowserForm(Admin admin)
        {
            InitializeComponent();
            this.admin = admin;
            label18.Text = admin.nume + " " + admin.prenume;

            pictureBoxUser.Image = ConvertByteArrayToImage(admin.pozaProfil);
            buttonMyAnnounces.Text = "Admin Tools";

            // POPULATE GRIDVIEW
            dsAnnounces = BrowseService.PopulateGrid();
            dataGridView.DataSource = dsAnnounces.Tables["Announces"].DefaultView;

            // IF THERE ARE ANNOUNCES 
            if (dataGridView.Rows.Count > 0)
            {
                // SELECT THE FIRST ANNOUNCE AND GET ITS ID
                int id = int.Parse(dataGridView.Rows[0].Cells[1].Value.ToString());
                byte[] announceImageCollumValue = (byte[])dataGridView.Rows[0].Cells[dataGridView.Rows[0].Cells.Count - 4].Value;
                // DRAW THE PICTURE OF THE ANNOUNCE
                pictureBoxAnnounce.Image = ConvertByteArrayToImage(announceImageCollumValue);
                announce = BrowseService.getAnounceData(id);
            }

            init();
            resetFilters();
        }

        // INITIALISE 
        private void init()
        {
            dataGridView.Columns["IdUser"].Visible = false;
            dataGridView.Columns["IdAnunt"].Visible = false;
            dataGridView.Columns["Imagine1"].Visible = false;
            dataGridView.Columns["Imagine2"].Visible = false;
            dataGridView.Columns["Imagine3"].Visible = false;

        }

        // RESET ADVANCED FILTERS
        private void resetAdvancedFilters() {

            comboBoxAn.Items.Clear();
            comboBoxAn.Items.Add("Nespecificat");
            comboBoxAn.Items.Add("< 1970");
            comboBoxAn.Items.Add("1971 - 1975");
            comboBoxAn.Items.Add("1976 - 1980");
            comboBoxAn.Items.Add("1981 - 1985");
            comboBoxAn.Items.Add("1986 - 1990");
            comboBoxAn.Items.Add("1991 - 1995");
            comboBoxAn.Items.Add("1996 - 2000");
            comboBoxAn.Items.Add("2001 - 2005");
            comboBoxAn.Items.Add("2006 - 2010");
            comboBoxAn.Items.Add("2011 - 2015");
            comboBoxAn.Items.Add("2016 - 2020");
            comboBoxAn.Items.Add("> 2020");
            comboBoxAn.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxAn.SelectedIndex = 0;

            comboBoxCC.Items.Clear();
            comboBoxCC.Items.Add("Nespecificat");
            comboBoxCC.Items.Add("< 50 cc");
            comboBoxCC.Items.Add("51 - 200 cc");
            comboBoxCC.Items.Add("201 - 400 cc");
            comboBoxCC.Items.Add("401 - 600 cc");
            comboBoxCC.Items.Add("601 - 800 cc");
            comboBoxCC.Items.Add("801 - 1000 cc");
            comboBoxCC.Items.Add("1001 - 1400 cc");
            comboBoxCC.Items.Add("1401 - 1800 cc");
            comboBoxCC.Items.Add("1801 - 2200 cc");
            comboBoxCC.Items.Add("2201 - 3000 cc");
            comboBoxCC.Items.Add("> 3001 cc");
            comboBoxCC.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxCC.SelectedIndex = 0;

            comboBoxCaroserie.Items.Clear();
            comboBoxCaroserie.Items.Add("Nespecificat");
            comboBoxCaroserie.Items.Add("Hatchback");
            comboBoxCaroserie.Items.Add("Sedan");
            comboBoxCaroserie.Items.Add("Combi");
            comboBoxCaroserie.Items.Add("Cabriolet");
            comboBoxCaroserie.Items.Add("Coupe");
            comboBoxCaroserie.Items.Add("Pick-up");
            comboBoxCaroserie.Items.Add("Off-road");
            comboBoxCaroserie.Items.Add("Alta caroserie");
            comboBoxCaroserie.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxCaroserie.SelectedIndex = 0;

            comboBoxCuloare.Items.Clear();
            comboBoxCuloare.Items.Add("Nespecificat");
            comboBoxCuloare.Items.Add("Albastru");
            comboBoxCuloare.Items.Add("Rosu");
            comboBoxCuloare.Items.Add("Galben");
            comboBoxCuloare.Items.Add("Verde");
            comboBoxCuloare.Items.Add("Gri");
            comboBoxCuloare.Items.Add("Negru");
            comboBoxCuloare.Items.Add("Alb");
            comboBoxCuloare.Items.Add("Maro");
            comboBoxCuloare.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxCuloare.SelectedIndex = 0;

            comboBoxCutieViteze.Items.Clear();
            comboBoxCutieViteze.Items.Add("Nespecificat");
            comboBoxCutieViteze.Items.Add("Manuala");
            comboBoxCutieViteze.Items.Add("Automata");
            comboBoxCutieViteze.Items.Add("Semi-automata");
            comboBoxCutieViteze.Items.Add("Secventiala");
            comboBoxCutieViteze.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxCutieViteze.SelectedIndex = 0;

            comboBoxCombustibil.Items.Clear();
            comboBoxCombustibil.Items.Add("Nespecificat");
            comboBoxCombustibil.Items.Add("Benzina FTW");
            comboBoxCombustibil.Items.Add("Motorina");
            comboBoxCombustibil.Items.Add("GPL");
            comboBoxCombustibil.Items.Add("Hybrid");
            comboBoxCombustibil.Items.Add("Electric");
            comboBoxCombustibil.Items.Add("Altul");
            comboBoxCombustibil.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxCombustibil.SelectedIndex = 0;

            textBoxPwMin.Text = "De la";
            textBoxPwMax.Text = "Pana la";
            textBoxKmMin.Text = "De la";
            textBoxKmMax.Text = "Pana la";
        }

        // RESET ALL FILTERS
        private void resetFilters()
        {
            textBoxMarca.Text = "Nespecificat";
            textBoxModel.Text = "Nespecificat";
            textBoxPretMin.Text = "De la";
            textBoxPretMax.Text = "Pana la";
            textBoxVarianta.Text = "GTI,RS,OPC,ST";
            textBoxLocatie.Text = "Nespecificat";
            resetAdvancedFilters();
           
        }


        // FILTER ANNOUNCES

        private void buttonFilter_Click(object sender, EventArgs e)
        {
            DataSet dsAnnounces = new DataSet();

            string marca = textBoxMarca.Text;
            string model = textBoxModel.Text;
            string pretmin = textBoxPretMin.Text;
            string pretmax = textBoxPretMax.Text;
            string varianta = textBoxVarianta.Text;
            string combustibil = comboBoxCombustibil.SelectedItem.ToString();
            string anFabricatie = comboBoxAn.SelectedItem.ToString();
            string cc = comboBoxCC.SelectedItem.ToString();
            string putereMin = textBoxPwMin.Text;
            string putereMax = textBoxPwMax.Text;
            string kmMin = textBoxKmMin.Text;
            string kmMax = textBoxKmMax.Text;
            string caroserie = comboBoxCaroserie.SelectedItem.ToString();
            string culoare = comboBoxCuloare.SelectedItem.ToString();
            string cutieViteze = comboBoxCutieViteze.SelectedItem.ToString();
            string locatie = textBoxLocatie.Text;
            string anMin = "0", anMax = "0";
            string ccMin = "0", ccMax = "0";

            // ------------------------------------------MARCA--------------------------------------
            if (marca.Equals("Nespecificat") || string.IsNullOrEmpty(marca)) marca = "Neselectat";
            // -------------------------------------------MODEL------------------------------------------
            if (model.Equals("Nespecificat") || string.IsNullOrEmpty(model)) model = "Neselectat";
            // ------------------------------------------VARIANTA--------------------------------------------------
            if (varianta.Equals("GTI,RS,OPC,ST") || string.IsNullOrEmpty(varianta)) varianta = "Neselectat";
            // ----------------------------------------COMBUSTIBIL--------------------------------------------------
            if (combustibil.Equals("Nespecificat") || string.IsNullOrEmpty(combustibil)) combustibil = "Neselectat";
            // -----------------------------------------CAROSERIE---------------------------------------------
            if (caroserie.Equals("Nespecificat") || string.IsNullOrEmpty(caroserie)) caroserie = "Neselectat";
            // ----------------------------------------CUTIEVITEZE--------------------------------------------------
            if (cutieViteze.Equals("Nespecificat") || string.IsNullOrEmpty(cutieViteze)) cutieViteze = "Neselectat";
            // ------------------------------------------LOCATIE------------------------------------------
            if (locatie.Equals("Nespecificat") || string.IsNullOrEmpty(locatie)) locatie = "Neselectat";
            // ------------------------------------------CULOARE------------------------------------------
            if (culoare.Equals("Nespecificat") || string.IsNullOrEmpty(culoare)) culoare = "Neselectat";
            // -----------------------------------PRET------------------------------------
            if (pretmin.Equals("De la") || string.IsNullOrEmpty(pretmin)) pretmin = "0";
            if (pretmax.Equals("Pana la") || string.IsNullOrEmpty(pretmax)) pretmax = "0";
            // -------------------------------------PUTERE---------------------------------------
            if (putereMin.Equals("De la") || string.IsNullOrEmpty(putereMin)) putereMin = "0";
            if (putereMax.Equals("Pana la") || string.IsNullOrEmpty(putereMax)) putereMax = "0";
            // --------------------------------KILOMETRAJ---------------------------------
            if (kmMin.Equals("De la") || string.IsNullOrEmpty(kmMin)) kmMin = "0";
            if (kmMax.Equals("Pana la") || string.IsNullOrEmpty(kmMax)) kmMax = "0";

            // ------------------------------------AN------------------------------------
            if (anFabricatie.Equals("Nespecificat")) { anMin = "0"; anMax = "0"; }
            if (anFabricatie.Equals("< 1970")) { anMin = "0"; anMax = "1970"; }
            if (anFabricatie.Equals("1971 - 1975")) { anMin = "1971"; anMax = "1975"; }
            if (anFabricatie.Equals("1976 - 1980")) { anMin = "1976"; anMax = "1980"; }
            if (anFabricatie.Equals("1981 - 1985")) { anMin = "1981"; anMax = "1985"; }
            if (anFabricatie.Equals("1991 - 1995")) { anMin = "1991"; anMax = "1995"; }
            if (anFabricatie.Equals("1996 - 2000")) { anMin = "1996"; anMax = "2000"; }
            if (anFabricatie.Equals("2001 - 2005")) { anMin = "2001"; anMax = "2005"; }
            if (anFabricatie.Equals("2006 - 2010")) { anMin = "2006"; anMax = "2010"; }
            if (anFabricatie.Equals("2011 - 2015")) { anMin = "2011"; anMax = "2015"; }
            if (anFabricatie.Equals("2016 - 2020")) { anMin = "2016"; anMax = "2020"; }
            if (anFabricatie.Equals("> 2020")) { anMin = "2020"; anMax = "2025"; }
            // ------------------------------------CC------------------------------------
            if (cc.Equals("Nespecificat")) { ccMin = "0"; ccMax = "0"; }
            if (cc.Equals("< 50 cc")) { ccMin = "0"; ccMax = "50"; }
            if (cc.Equals("51 - 200 cc")) { ccMin = "51"; ccMax = "200"; }
            if (cc.Equals("201 - 400 cc")) { ccMin = "201"; ccMax = "400"; }
            if (cc.Equals("401 - 600 cc")) { ccMin = "401"; ccMax = "600"; }
            if (cc.Equals("601 - 800 cc")) { ccMin = "601"; ccMax = "800"; }
            if (cc.Equals("801 - 1000 cc")) { ccMin = "801"; ccMax = "1000"; }
            if (cc.Equals("1001 - 1400 cc")) { ccMin = "1001"; ccMax = "1400"; }
            if (cc.Equals("1401 - 1800 cc")) { ccMin = "1401"; ccMax = "1800"; }
            if (cc.Equals("1801 - 2200 cc")) { ccMin = "1801"; ccMax = "2200"; }
            if (cc.Equals("2201 - 3000 cc")) { ccMin = "2201"; ccMax = "3000"; }
            if (cc.Equals("> 3001 cc")) { ccMin = "3001"; ccMax = "30000"; }

            dsAnnounces = BrowseService.FilterGrid(marca, model, pretmin, pretmax, varianta,
                                                         combustibil, anMin, anMax, ccMin, ccMax,
                                                         putereMin, putereMax, kmMin, kmMax, caroserie,
                                                         culoare, cutieViteze, locatie);

            this.dataGridView.DataSource = dsAnnounces.Tables["Announces"].DefaultView;
        }

        // DISABLES/ENABLES ADVANCE FILTERING
        private void checkBoxFiltre_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxFiltre.Checked)
            {
                groupBox2.Enabled = true;
            }
            else
            {
                resetAdvancedFilters();
                groupBox2.Enabled = false;
            }
        }

        // REMOVES FILTERS
        private void buttonRemoveFilter_Click(object sender, EventArgs e)
        {
            resetFilters();
            // REPOPULATE DATAGRIDVIEW WITH ALL THE ANNOUNCES
            dsAnnounces = BrowseService.PopulateGrid();
            dataGridView.DataSource = dsAnnounces.Tables["Announces"].DefaultView;
        }

        // CONVERTS BYTE ARRAY TO IMAGE, USED FOR DISPLAYING ANNOUNCE PICTURE
        public System.Drawing.Image ConvertByteArrayToImage(byte[] byteArray)
        {
            MemoryStream ms = new MemoryStream(byteArray);
            System.Drawing.Image rez = System.Drawing.Image.FromStream(ms);
            return rez;
        }

        // SELECTS THE ANNOUNCE AFTER CLICKKING 
        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // IF CLICKED WITHIN THE DATAGRIDVIEW
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView.SelectedRows[0];
                // GETS THE ANNOUNCE PICTURE FOR THE PICTURE BOX, IF THERE IS ANY
                if (selectedRow.Cells[selectedRow.Cells.Count - 1].Value != DBNull.Value)
                {
                    byte[] announceImageCollumValue = (byte[])selectedRow.Cells[selectedRow.Cells.Count - 4].Value;
                    if (announceImageCollumValue.Length > 0)
                        pictureBoxAnnounce.Image = ConvertByteArrayToImage(announceImageCollumValue);
                }
                int id = int.Parse(selectedRow.Cells[1].Value.ToString());
                announce = BrowseService.getAnounceData(id);
            }
            else
                announce = null;
        }

        // OPENS MY ANNOUNCES FORM, OR IF ADMIN, ADMIN TOOLS
        private void buttonMyAnnounces_Click(object sender, EventArgs e)
        {
            // IF ADMIN
            if (admin != null)
            {
                // OPENS AdminToolsForm, HIDES THIS FORM
                AdminToolsForm atf = new AdminToolsForm(admin);
                this.Hide();
                atf.Show();
                if (atf.IsDisposed)
                {
                    this.Show();
                }
            }
            else
            {
                // IF USER
                if (user != null)
                {
                    // OPENS MyAnnouncesForm, HIDES THIS FORM
                    MyAnnounces ma = new MyAnnounces(user);
                    this.Hide();
                    ma.Show();
                    if (ma.IsDisposed)
                    {
                        this.Show();
                    }
                }

            }
        }

        // OPENS ANNOUNCE IN NEW FORM
        private void buttonViewAnnounce_Click(object sender, EventArgs e)
        {
            // IF AN ANNOUNCE HAS BEEN SELECTED BEFORE, THEREFOR IT EXISTS
            if (announce != null)
            {
                // IF THERE IS A USER
                if (user != null)
                {
                    // OPENS A ViewAnnounceForm FORM WITH THE SELECTED ANNOUNCE, CLOSES THIS ONE
                    ViewAnnounceForm vaf = new ViewAnnounceForm(announce, user);
                    this.Hide();
                    vaf.Show();
                    if (vaf.IsDisposed)
                    {
                        this.Show();
                    }
                }
                // IF THERE IS AN ADMIN
                if (admin != null)
                {
                    // OPENS A ViewAnnounceForm FORM WITH THE SELECTED ANNOUNCE, CLOSES THIS ON
                    ViewAnnounceForm vaf = new ViewAnnounceForm(announce, admin);
                    this.Hide();
                    vaf.Show();
                    if (vaf.IsDisposed)
                    {
                        this.Show();
                    }
                }
            }

        }

        // CLOSES THE APPLICATION
        private void BrowserForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        // LOGOUT
        private void buttonLogOut_Click(object sender, EventArgs e)
        {
            this.Dispose();
            new LoginForm().Show();
        }





        private void pictureBoxAnnounce_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (pictureBoxAnnounce.Image != null)
            {
                System.Drawing.Image image = pictureBoxAnnounce.Image;
                int width = image.Width;
                int height = image.Height;
                PictureForm pf = new PictureForm(image);
                pf.ShowDialog();
            }
        }


        private void textBoxPwMin_MouseClick(object sender, MouseEventArgs e) { textBoxPwMin.Text = null; }
        private void textBoxPwMax_MouseClick(object sender, MouseEventArgs e) { textBoxPwMax.Text = null; }

        private void textBoxKmMin_MouseClick(object sender, MouseEventArgs e) { textBoxKmMin.Text = null; }
        private void textBoxKmMax_MouseClick(object sender, MouseEventArgs e) { textBoxKmMax.Text = null; }

        private void textBoxPretMin_MouseClick(object sender, MouseEventArgs e) {textBoxPretMin.Text = null; }
        private void textBoxPretMax_MouseClick(object sender, MouseEventArgs e) {textBoxPretMax.Text = null; }


        private void onlyNumbers(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void textBoxPwMin_KeyPress(object sender, KeyPressEventArgs e) { onlyNumbers(sender, e); }
        private void textBoxPwMax_KeyPress(object sender, KeyPressEventArgs e) { onlyNumbers(sender, e); }

        private void textBoxKmMin_KeyPress(object sender, KeyPressEventArgs e) { onlyNumbers(sender, e); }
        private void textBoxKmMax_KeyPress(object sender, KeyPressEventArgs e) { onlyNumbers(sender, e); }

        private void textBoxPretMin_KeyPress(object sender, KeyPressEventArgs e) { onlyNumbers(sender, e); }
        private void textBoxPretMax_KeyPress(object sender, KeyPressEventArgs e) { onlyNumbers(sender, e); }

 
    }
}
