using System;
using System.Windows.Forms;
using System.Drawing;
using NivelAccesDate1;
using NivelAccesDate2;
using LibrarieModele;

namespace Biblioteca_Form
{
    class Program
    {
        static void Main(string[] args)
        {
            Formular form1 = new Formular();
            form1.Show();
            Application.Run();
        }
    }
    public class Formular : Form
    {
        //Carte labels
        private Label lblTitlu;
        private Label lblAutor;
        private Label lblEditura;
        private Label lblNrExemplare;
        private Label lblGen;
        private Label lblLimba;

        //Cititor labels
        private Label lblNume;
        private Label lblPrenume;
        private Label lblNrImprumuturi;

        //Label informativ
        private Label lblInfo;

        //Carte TextBoxes
        private TextBox txtTitlu;
        private TextBox txtAutor;
        private TextBox txtEditura;
        private TextBox txtNrExemplare;
        private TextBox txtGen;
        private TextBox txtLimba;

        //Cititor TextBoxes
        private TextBox txtNume;
        private TextBox txtPrenume;
        private TextBox txtNrImprumuturi;

        //Buttons
        private Button btnAdauga;

        //constante
        private const int LATIME_CONTROL = 150;
        private const int INALTIME_CONTROL = 20;
        private const int DIMENSIUNE_PAS_Y = 30;
        private const int DIMENSIUNE_PAS_X = 170;
        private const int LUNGIME_MAX = 30;

        IStocareData1 adminCarti;
        IStocareData2 adminCititori;

        public Formular()
        {
            adminCarti = StocareFactory.GetAdministratorStocare1();
            adminCititori = StocareFactory.GetAdministratorStocare2();

            //proprietatile ferestrei aplicatiei
            this.Size = new System.Drawing.Size(1000, 500);
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new System.Drawing.Point(100, 100);
            this.Font = new Font("Arial", 9, FontStyle.Bold);
            this.Text = "Administrare Biblioteca";
            this.BackColor = Color.Firebrick;

            //Proprietatile label titlu
            lblTitlu = new Label();
            lblTitlu.Width = LATIME_CONTROL;
            lblTitlu.Text = "Titlu: ";
            lblTitlu.BackColor = Color.PaleGoldenrod;
            this.Controls.Add(lblTitlu);

            //Proprietatile label autor
            lblAutor = new Label();
            lblAutor.Width = LATIME_CONTROL;
            lblAutor.Top = DIMENSIUNE_PAS_Y;
            lblAutor.Text = "Autor: ";
            lblAutor.BackColor = Color.PaleGoldenrod;
            this.Controls.Add(lblAutor);

            //Proprietatile label editura
            lblEditura = new Label();
            lblEditura.Width = LATIME_CONTROL;
            lblEditura.Top = 2 * DIMENSIUNE_PAS_Y;
            lblEditura.Text = "Editura: ";
            lblEditura.BackColor = Color.PaleGoldenrod;
            this.Controls.Add(lblEditura);

            //Proprietatile label Nr exemplare
            lblNrExemplare = new Label();
            lblNrExemplare.Width = LATIME_CONTROL;
            lblNrExemplare.Top = 3 * DIMENSIUNE_PAS_Y;
            lblNrExemplare.Text = "Numarul de exemplare: ";
            lblNrExemplare.BackColor = Color.PaleGoldenrod;
            this.Controls.Add(lblNrExemplare);

            //Proprietatile textbox titlu
            txtTitlu = new TextBox();
            txtTitlu.Width = LATIME_CONTROL;
            txtTitlu.Location = new System.Drawing.Point(DIMENSIUNE_PAS_X, 0);
            this.Controls.Add(txtTitlu);

            //Proprietatile textbox autor
            txtAutor = new TextBox();
            txtAutor.Width = LATIME_CONTROL;
            txtAutor.Location = new Point(DIMENSIUNE_PAS_X, DIMENSIUNE_PAS_Y);
            this.Controls.Add(txtAutor);

            //Proprietatile textbox editura
            txtEditura = new TextBox();
            txtEditura.Width = LATIME_CONTROL;
            txtEditura.Location = new Point(DIMENSIUNE_PAS_X, 2 * DIMENSIUNE_PAS_Y);
            this.Controls.Add(txtEditura);

            //Proprietatile textbox nr exemplare
            txtNrExemplare = new TextBox();
            txtNrExemplare.Width = LATIME_CONTROL;
            txtNrExemplare.Location = new Point(DIMENSIUNE_PAS_X, 3 * DIMENSIUNE_PAS_Y);
            this.Controls.Add(txtNrExemplare);

            //Proprietatile buton adauga
            btnAdauga = new Button();
            btnAdauga.Width = LATIME_CONTROL;
            btnAdauga.Location = new Point(DIMENSIUNE_PAS_X, 4 * DIMENSIUNE_PAS_Y);
            btnAdauga.Text = "Adauga";
            btnAdauga.BackColor = Color.PaleGoldenrod;
            this.Controls.Add(btnAdauga);

            btnAdauga.Click += OnButtonAdaugaClicked;
            this.Controls.Add(btnAdauga);

            //Proprietati label info
            lblInfo = new Label();
            lblInfo.Width = LATIME_CONTROL * 2;
            lblInfo.Height = INALTIME_CONTROL*4;
            lblInfo.Location = new Point(0, 5 * DIMENSIUNE_PAS_Y);
            lblInfo.BackColor = Color.PaleGoldenrod;
            this.Controls.Add(lblInfo);
        }
        private void OnButtonAdaugaClicked(object sender, EventArgs e)
        {
            int validare = Validare();

            txtTitlu.BackColor = Color.White;
            txtAutor.BackColor = Color.White;
            txtEditura.BackColor = Color.White;
            txtNrExemplare.BackColor = Color.White;

            if (validare == 0)

            {
                Carte c = new Carte(txtTitlu.Text, txtAutor.Text, txtEditura.Text, Convert.ToInt32(txtNrExemplare.Text));
                lblInfo.Text = c.ConversieLaSir();
                adminCarti.AddCarte(c);
            }
            else
            {

                switch (validare)
                {
                    case 1:
                        txtTitlu.BackColor = Color.LightCoral;
                        MessageBox.Show("Nu ati introdus un titlu sau acesta a depasit limita de caractere.", "Titlu incorect",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case 2:
                        txtAutor.BackColor = Color.LightCoral;
                        MessageBox.Show("Nu ati introdus autorul sau acesta a depasit limita de caractere.", "Autor incorect",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case 3:
                        txtEditura.BackColor = Color.LightCoral;
                        MessageBox.Show("Nu ati introdus editura sau aceasta a depasit limita de caractere.", "Editura incorecta",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case 4:
                        txtNrExemplare.BackColor = Color.LightCoral;
                        MessageBox.Show("Ati introdus un numar de exemplare invalid.", "Numar de exemplare incorect",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    default:
                        break;
                }

            }
        }
        private int Validare()
        {
            if (txtTitlu.Text == string.Empty || txtTitlu.Text.Length > LUNGIME_MAX)
            {
                return 1;
            }
            else if (txtAutor.Text == string.Empty || txtAutor.Text.Length > LUNGIME_MAX)
            {
                return 2;
            }
            else if (txtEditura.Text == string.Empty || txtEditura.Text.Length>LUNGIME_MAX)
            {
                return 3;
            }
            else if(txtNrExemplare.Text==string.Empty || Int32.TryParse(txtNrExemplare.Text, out int rez)==false)
            {
                return 4;
            }


            return 0;
        }
    }
}
