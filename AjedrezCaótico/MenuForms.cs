using AjedrezCaótico;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProyectoAjedrez
{
    public partial class MenuForms : Form
    {
        public MenuForms()
        {
            InitializeComponent();
            pictureBox1.Image = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes", "MenuRandom.png"));
            pictureBox2.Image = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes", "NormalMenu.png"));
            pictureBox3.Image = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes", "MenuPato.png"));
            pictureBox4.Image = Image.FromFile(Path.Combine(Application.StartupPath, "Imagenes", "MenuDemonio.png"));

        }

        public void AsignarTiempo()
        {
            int tiempoPartida;
            if (int.TryParse(textBox1.Text, out tiempoPartida) && tiempoPartida > 0)
            {
                if (tiempoPartida > 30)
                {
                    MessageBox.Show("El tiempo máximo permitido es 30 minutos. Se establecerá a 30 minutos.");
                    tiempoPartida = 30;
                }

                ValoresCompartidos.tiempoPartida = tiempoPartida * 60;
                ValoresCompartidos.tiempoBlancas = ValoresCompartidos.tiempoPartida;
                ValoresCompartidos.tiempoNegras = ValoresCompartidos.tiempoPartida;
            }
            else
            {
                MessageBox.Show("Valor no válido, se usará el máximo de tiempo de 30 minutos.");
                ValoresCompartidos.tiempoPartida = 30 * 60;
                ValoresCompartidos.tiempoBlancas = ValoresCompartidos.tiempoPartida;
                ValoresCompartidos.tiempoNegras = ValoresCompartidos.tiempoPartida;
            }
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            AsignarTiempo();

            ValoresCompartidos.modoPartida = 2;
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            AsignarTiempo();

            ValoresCompartidos.modoPartida = 1;
            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            AsignarTiempo();

            ValoresCompartidos.modoPartida = 3;
            this.Close();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            AsignarTiempo();

            ValoresCompartidos.modoPartida = 4;
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
