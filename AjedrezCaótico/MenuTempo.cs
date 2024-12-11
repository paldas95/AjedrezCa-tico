using Microsoft.Xna.Framework;
using ProyectoAjedrez;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AjedrezCaótico
{
    public partial class MenuTempo : Form
    {

        private MenuForms menuForms;
        private DriverClass driverClassInstance;

        private int tiempopartida = ValoresCompartidos.tiempoPartida;
        private int tiempoBlancas=ValoresCompartidos.tiempoPartida;
        private int tiempoNegras= ValoresCompartidos.tiempoPartida;

        private System.Windows.Forms.Timer timerBlancas;
        private System.Windows.Forms.Timer timerNegras;


        public MenuTempo(DriverClass driver)
        {
            InitializeComponent();
            tiempoBlancas = ValoresCompartidos.tiempoBlancas;
            tiempoNegras = ValoresCompartidos.tiempoNegras;
            label1.Text = ValoresCompartidos.tiempoBlancas.ToString();
            label2.Text = ValoresCompartidos.tiempoNegras.ToString();
            menuForms = new MenuForms();
            driverClassInstance = driver;
            timerBlancas = new System.Windows.Forms.Timer();
            timerBlancas.Interval = 1000; 
            timerBlancas.Tick += TimerBlancas_Tick;

            timerNegras = new System.Windows.Forms.Timer();
            timerNegras.Interval = 1000; 
            timerNegras.Tick += TimerNegras_Tick;
            _ = CheckGameStatusAsync();
            _ = UpdateTimersAsync();
            UpdateLabelTiempoNegras();
            UpdateLabelTiempoBlancas();
        }
        private void TimerBlancas_Tick(object sender, EventArgs e)
        {
            if (ValoresCompartidos.tiempoBlancas > 0 )
            {
                ValoresCompartidos.tiempoBlancas--;
                UpdateLabelTiempoBlancas();
            }
            else
            {
                if (ValoresCompartidos.controlador == false)
                {
                    timerBlancas.Stop();
                    ValoresCompartidos.controlador = true;
                    MessageBox.Show("Tiempo de las blancas ha terminado. Negras ganan");
                    
                    timerBlancas.Equals(1000);
                }
                else { ValoresCompartidos.controlador = true;}

            }
        }

        private void TimerNegras_Tick(object sender, EventArgs e)
        {
            if (ValoresCompartidos.tiempoNegras > 0)
            {
                ValoresCompartidos.tiempoNegras--;
                UpdateLabelTiempoNegras();
            }
            else
            {
                if (ValoresCompartidos.controlador == false)
                {
                    timerNegras.Stop();
                    ValoresCompartidos.controlador = true;
                    MessageBox.Show("Tiempo de las negras ha terminado. Blancas ganan");                    
                    timerNegras.Equals(1000);
                }
                else {  ValoresCompartidos.controlador = true;  }
            }
        }
        private void UpdateLabelTiempoBlancas()
        {
            TimeSpan tiempo = TimeSpan.FromSeconds(ValoresCompartidos.tiempoBlancas);
            label1.Text = tiempo.ToString(@"mm\:ss");
        }

        private void UpdateLabelTiempoNegras()
        {
            TimeSpan tiempo = TimeSpan.FromSeconds(ValoresCompartidos.tiempoNegras);
            label2.Text = tiempo.ToString(@"mm\:ss");
        }

        public void RestartForm()
        {
            label1.Text = ValoresCompartidos.tiempoPartida.ToString();
            label2.Text = ValoresCompartidos.tiempoPartida.ToString();
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void MenuTempo_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Reiniciando el juego");
            driverClassInstance.RestartGame();
            ValoresCompartidos.tiempoBlancas = ValoresCompartidos.tiempoPartida;
            ValoresCompartidos.tiempoNegras = ValoresCompartidos.tiempoPartida;
            ValoresCompartidos.controlador = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            driverClassInstance.Exit();
        }


        public async Task CheckGameStatusAsync()
        {
            if (ValoresCompartidos.controlador == false)
            {
                while (true)
                {
                    if (ValoresCompartidos.gananBlancas)
                    {
                        MessageBox.Show("JAQUE MATE. Blancas ganan");
                        ValoresCompartidos.gananBlancas = false;
                        ValoresCompartidos.controlador = true;
                        break;
                    }
                    if (ValoresCompartidos.gananNegras)
                    {
                        MessageBox.Show("JAQUE MATE. Negras ganan");
                        ValoresCompartidos.gananNegras = false;
                        ValoresCompartidos.controlador = true;
                        break;
                    }
                    if (ValoresCompartidos.victoria)
                    {
                        MessageBox.Show("JAQUE MATE");
                        ValoresCompartidos.victoria = false;
                        ValoresCompartidos.controlador = true;
                        break;
                    }
                    if (ValoresCompartidos.tablas)
                    {
                        MessageBox.Show("EMPATE");
                        ValoresCompartidos.tablas = false;
                        ValoresCompartidos.controlador = true;
                        break;
                    }

                    await Task.Delay(5000);
                }

            }
            else
            { ValoresCompartidos.controlador = true; }
        }


        public async Task UpdateTimersAsync()
        {
            if (ValoresCompartidos.controlador == false)
            {
                while (true)
                {
                    if (ValoresCompartidos.turnoBlancas)
                    {
                        timerNegras.Stop();
                        timerBlancas.Start();
                    }
                    else
                    {
                        timerBlancas.Stop();
                        timerNegras.Start();
                    }


                    await Task.Delay(1000);
                }
            }
            else 
            {
                ValoresCompartidos.controlador = true;

            }
        }
    }
}

