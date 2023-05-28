using CarAppWebClient.LoginService;
using CarAppWebClient.BrowseService;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics.Eventing.Reader;

namespace CarAppWebClient
{
    public partial class BrowserForm : Form
    {
       private User user;
       private Admin admin;
        private Announce announce;
        private DataSet dsAnnounces;
        BrowseService.BrowseServiceSoapClient BrowseService = new BrowseService.BrowseServiceSoapClient();
        public BrowserForm(User user)
        {
            InitializeComponent();
            this.user = user;
            label18.Text = user.nume + " " + user.prenume;
            pictureBoxUser.Image = ConvertByteArrayToImage(user.pozaProfil);

            dsAnnounces = BrowseService.PopulateAnunturi("Neselectat", "Neselectat", "0", "0", "Neselectat", "Neselectat", "0", "0", "0", "0", "0", "0", "0", "0", "Neselectat", "Neselectat", "Neselectat", "Neselectat");
            dataGridView.DataSource = dsAnnounces.Tables["Announces"].DefaultView;

            init();
            resetFilters();
        }

        public BrowserForm(Admin admin)
        {
            InitializeComponent();
            this.admin = admin;
            label18.Text = admin.nume + " " + admin.prenume;
            pictureBoxUser.Image = ConvertByteArrayToImage(admin.pozaProfil);

            dsAnnounces = BrowseService.PopulateAnunturi("Neselectat", "Neselectat", "0", "0", "Neselectat", "Neselectat", "0", "0", "0", "0", "0", "0", "0", "0", "Neselectat", "Neselectat", "Neselectat", "Neselectat");
            dataGridView.DataSource = dsAnnounces.Tables["Announces"].DefaultView;

            buttonMyAnnounces.Text = "Admin Tools";
            
            init();
            resetFilters();
        }


        private void init()
        {
            dataGridView.Columns["IdUser"].Visible   = false;
            dataGridView.Columns["IdAnunt"].Visible  = false;
            dataGridView.Columns["Imagine1"].Visible = false;
            dataGridView.Columns["Imagine2"].Visible = false;
            dataGridView.Columns["Imagine3"].Visible = false;

        }

        private void resetFilters()
        {
            textBoxMarca.Text    = "Nespecificat";
            textBoxModel.Text    = "Nespecificat";
            textBoxPretMin.Text  = "De la";
            textBoxPretMax.Text  = "Pana la";
            textBoxVarianta.Text = "GTI,RS,OPC,ST";
            textBoxPwMin.Text    = "De la";
            textBoxPwMax.Text    = "Pana la";
            textBoxKmMin.Text    = "De la";
            textBoxKmMax.Text    = "Pana la";
            textBoxLocatie.Text  = "Nespecificat";

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
        }


        private void buttonFilter_Click(object sender, EventArgs e)
        {
            DataSet dsAnnounces = new DataSet();

            string marca        = textBoxMarca.Text;
            string model        = textBoxModel.Text;
            string pretmin      = textBoxPretMin.Text;
            string pretmax      = textBoxPretMax.Text;
            string varianta     = textBoxVarianta.Text;
            string combustibil  = comboBoxCombustibil.SelectedItem.ToString();
            string anFabricatie = comboBoxAn.SelectedItem.ToString();
            string cc           = comboBoxCC.SelectedItem.ToString();
            string putereMin    = textBoxPwMin.Text;
            string putereMax    = textBoxPwMax.Text;
            string kmMin        = textBoxKmMin.Text;
            string kmMax        = textBoxKmMax.Text;
            string caroserie    = comboBoxCaroserie.SelectedItem.ToString();
            string culoare      = comboBoxCuloare.SelectedItem.ToString();
            string cutieViteze  = comboBoxCutieViteze.SelectedItem.ToString();
            string locatie      = textBoxLocatie.Text;
            string anMin = "0", anMax = "0";
            string ccMin = "0", ccMax = "0";

            // ------------------------------MARCA------------------------------
            if (marca.Equals("Nespecificat")) marca = "Neselectat";
            // ------------------------------MODEL------------------------------
            if (model.Equals("Nespecificat")) model = "Neselectat";
            // -----------------------------VARIANTA----------------------------
            if (varianta.Equals("ex:GTI,RS,OPC,ST")) varianta = "Neselectat";
            // ---------------------------COMBUSTIBIL---------------------------
            if (combustibil.Equals("Nespecificat")) combustibil = "Neselectat";
            // ----------------------------CAROSERIE----------------------------
            if (caroserie.Equals("Nespecificat")) caroserie = "Neselectat";
            // ---------------------------CUTIEVITEZE---------------------------
            if (cutieViteze.Equals("Nespecificat")) cutieViteze = "Neselectat";
            // -----------------------------LOCATIE-----------------------------
            if (locatie.Equals("Nespecificat")) locatie = "Neselectat";
            // -----------------------------CULOARE-----------------------------
            if (culoare.Equals("Nespecificat")) culoare = "Neselectat";
            // ------------------------------PRET-------------------------------
            if (pretmin.Equals("De la")) pretmin = "0";
            if (pretmax.Equals("Pana la")) pretmax = "0";
            // -----------------------------PUTERE------------------------------
            if (putereMin.Equals("De la")) putereMin = "0";
            if (putereMax.Equals("Pana la")) putereMax = "0";
            // ---------------------------KILOMETRAJ----------------------------
            if (kmMin.Equals("De la")) kmMin = "0";
            if (kmMax.Equals("Pana la")) kmMax = "0";
            // ------------------------------------AN------------------------------------
            if (anFabricatie.Equals("Nespecificat")) { anMin = "0";    anMax = "0";    }
            if (anFabricatie.Equals("< 1970"))       { anMin = "0";    anMax = "1970"; }
            if (anFabricatie.Equals("1971 - 1975"))  { anMin = "1971"; anMax = "1975"; }
            if (anFabricatie.Equals("1976 - 1980"))  { anMin = "1976"; anMax = "1980"; }
            if (anFabricatie.Equals("1981 - 1985"))  { anMin = "1981"; anMax = "1985"; }
            if (anFabricatie.Equals("1991 - 1995"))  { anMin = "1991"; anMax = "1995"; }
            if (anFabricatie.Equals("1996 - 2000"))  { anMin = "1996"; anMax = "2000"; }
            if (anFabricatie.Equals("2001 - 2005"))  { anMin = "2001"; anMax = "2005"; }
            if (anFabricatie.Equals("2006 - 2010"))  { anMin = "2006"; anMax = "2010"; }
            if (anFabricatie.Equals("2011 - 2015"))  { anMin = "2011"; anMax = "2015"; }
            if (anFabricatie.Equals("2016 - 2020"))  { anMin = "2016"; anMax = "2020"; }
            if (anFabricatie.Equals("> 2020"))       { anMin = "2020"; anMax = "2025"; }
            // ------------------------------------CC------------------------------------
            if (cc.Equals("Nespecificat"))      { ccMin = "0"; ccMax = "0";        }
            if (cc.Equals("< 50 cc"))           { ccMin = "0"; ccMax = "50";       }
            if (cc.Equals("51 - 200 cc"))       { ccMin = "51"; ccMax = "200";     }
            if (cc.Equals("201 - 400 cc"))      { ccMin = "201"; ccMax = "400";    }
            if (cc.Equals("401 - 600 cc"))      { ccMin = "401"; ccMax = "600";    }
            if (cc.Equals("601 - 800 cc"))      { ccMin = "601"; ccMax = "800";    }
            if (cc.Equals("801 - 1000 cc"))     { ccMin = "801"; ccMax = "1000";   }
            if (cc.Equals("1001 - 1400 cc"))    { ccMin = "1001"; ccMax = "1400";  }
            if (cc.Equals("1401 - 1800 cc"))    { ccMin = "1401"; ccMax = "1800";  }
            if (cc.Equals("1801 - 2200 cc"))    { ccMin = "1801"; ccMax = "2200";  }
            if (cc.Equals("2201 - 3000 cc"))    { ccMin = "2201"; ccMax = "3000";  }
            if (cc.Equals("> 3001 cc"))         { ccMin = "3001"; ccMax = "30000"; }

            dsAnnounces = BrowseService.PopulateAnunturi(marca, model, pretmin, pretmax, varianta, 
                                                         combustibil, anMin, anMax, ccMin, ccMax, 
                                                         putereMin, putereMax, kmMin, kmMax, caroserie, 
                                                         culoare, cutieViteze, locatie);

            this.dataGridView.DataSource = dsAnnounces.Tables["Announces"].DefaultView;
        }

        private void checkBoxFiltre_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBoxFiltre.Checked)
            {
                groupBox2.Enabled = true;
            }else
            {
                groupBox2.Enabled = false;
            }
        }

        private void buttonRemoveFilter_Click(object sender, EventArgs e)
        {
            resetFilters();

        }

        public System.Drawing.Image ConvertByteArrayToImage(byte[] byteArray)
        {
            MemoryStream ms = new MemoryStream(byteArray);
            System.Drawing.Image rez = System.Drawing.Image.FromStream(ms);
            return rez;
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) { 
                DataGridViewRow selectedRow = dataGridView.SelectedRows[0];
                if (selectedRow.Cells[selectedRow.Cells.Count-1].Value != DBNull.Value)
                {
                    byte[] announceImageCollumValue = (byte[])selectedRow.Cells[selectedRow.Cells.Count - 4].Value;
                    if (announceImageCollumValue.Length > 0)
                        pictureBoxAnnounce.Image = ConvertByteArrayToImage(announceImageCollumValue);
                }
                int id = int.Parse(selectedRow.Cells[1].Value.ToString());
                Console.WriteLine(id);

                announce = BrowseService.getAnounceData(id);
                Console.WriteLine(announce.imag1.Length);
            }
            else
                announce = null;
        }

        private void buttonMyAnnounces_Click(object sender, EventArgs e)
        {
            if (admin != null)
            {
                AdminToolsForm atf = new AdminToolsForm();
                atf.ShowDialog();
            }
            else
            {
                if (user != null)
                {
                    MyAnnounces ma = new MyAnnounces(user);
                    ma.Show();
                    //deschide myannouncesfrom
                }

            }
        }





        private void buttonViewAnnounce_Click(object sender, EventArgs e)
        {
            // daca e selectat anuntu
            if (announce != null)
            {
                if (user != null) 
                {
                    ViewAnnounceForm vaf = new ViewAnnounceForm(announce, user);
                    vaf.ShowDialog();
                }
                // daca e user
                if (admin != null) 
                {
                    ViewAnnounceForm vaf = new ViewAnnounceForm(announce, admin);
                    vaf.ShowDialog();
                }
            }

        }

        private void BrowserForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void buttonLogOut_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void pictureBoxAnnounce_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            System.Drawing.Image image = pictureBoxAnnounce.Image;
            int width = image.Width;
            int height = image.Height;
            PictureForm pf = new PictureForm(width, height,image);
            pf.ShowDialog();
        }
    }
}
