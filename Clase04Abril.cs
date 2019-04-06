using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            DriveInfo[] u = DriveInfo.GetDrives();
            foreach (DriveInfo unidad in u)
            {
                try
                {
                    listBox1.Items.Add(unidad.Name);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error de lectura" + ex.Message);
                    //MensageBox.Show("Error leyendo los discos" + ex.Mesahe)
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //listBox2.Items.Add("aa");
            listBox2.Items.Clear();
            String unidades = listBox1.SelectedIndex.ToString();
            DriveInfo d= new DriveInfo(unidades)
            listBox2.Items.Add("Disco:" + d.Name +"\n");
            if(d.IsReady){
                listBox2.Items.Add("Espacio ocupado (GB):" + (d.TotalSize - d.AvailableFreeSpace) /1024 /1024 /1024 +"\n"); //k,m,g
                listBox2.Items.Add("Espacio disponible (GB):" + (d.TotalSize - d.AvailableFreeSpace) /1024 /1024 /1024 +"\n");
                listBox2.Items.Add("Espacio total (GB):" + (d.TotalSize) /1024 /1024 /1024 +"\n");
            }

            listBox2.Items.Add("Tipo de disco utilizado" + d.DriveType.ToString()+"\n");
        }
    }
}
