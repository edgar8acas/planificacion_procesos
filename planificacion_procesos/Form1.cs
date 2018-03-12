using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace planificacion_procesos
{
    public partial class Form1 : Form
    {
        SimuladorProcesos sp;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            sp = new SimuladorProcesos(Convert.ToInt32(txtNoProcesos.Text), Convert.ToInt32(txtTiempoMaximo.Text));
            int[] procesos = sp.Procesos;
            txtProcesos.Text = "";
            for(int i=0; i<procesos.Length; i++)
            {
                txtProcesos.Text += "Proceso #" + (i + 1) + ":\t" + procesos[i] + Environment.NewLine;
            }
        }

        private void btnAnalizar_Click(object sender, EventArgs e)
        {
            txtAnalisis.Text = "FCFS" + Environment.NewLine + sp.FirstComeFirstServed() + Environment.NewLine +
                               "SJF" + Environment.NewLine + sp.SmallestJobFirst() + Environment.NewLine +
                               "LJF" + Environment.NewLine + sp.LargestJobFirst() + Environment.NewLine;
        }

    }
}
