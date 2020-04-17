using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dotnet_lab6
{
    public partial class Form1 : Form
    {
        List<Valuta> valute = new List<Valuta>();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnKreiraj_Click(object sender, EventArgs e)
        {
            double tecaj;

            if (double.TryParse(txtTecaj.Text.Replace(".",","), out tecaj))
            {
                Valuta Val = new Valuta(txtNaziv.Text, tecaj);

                var manje = new List<string>();
                var vise = new List<string>();

                    foreach (Valuta v in valute)
                    {
                        if (Val.CompareTo(v) < 0)
                            manje.Add(v.Naziv);
                        else
                            vise.Add(v.Naziv);
                    }

                    string msg = "Valuta je ";
                    if (vise.Count > 0)
                        msg = msg + "vrijednija od " + String.Join(", ", vise);

                    if (manje.Count > 0)
                    {
                        if (vise.Count > 0) msg += ", a ";
                        msg += "manje vrijedna od " + String.Join(", ", manje);
                    }

                if (valute.Count == 0)
                    msg = "Valuta dodana!";
                else
                    msg += ".";
                valute.Add(Val);
                MessageBox.Show(msg, "Uneseno!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else 
                MessageBox.Show("Greska kod unosa tecaja!", "Greska!", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void btnIspisi_Click(object sender, EventArgs e)
        {
            if (valute.Count > 0)
            {
                Valuta val = valute.Last();
                MessageBox.Show(val.Ispis(), "Ispis!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Nema spremljenog zapisa!", "Greska!", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

    }
}
