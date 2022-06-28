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
using System.Collections;

namespace Propiedades_de_los_sistemas
{
    public partial class Form1 : Form
    {
        ArrayList myAL;
        string ruta = "..\\..\\..\\..\\Propiedades_de_los_sistemas\\leader.txt";
        public Form1()
        {
            InitializeComponent();
            lblNombre.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            btnCuestionario.Visible = false;
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            lblNombre.Text = lblNombre.Text + " " + txtNombre.Text;
            lblNombre.Visible = true;
            txtNombre.Enabled = false;
            btnIniciar.Enabled = false;
            pictureBox5.Visible = false;
            panel2.Visible = true;
            btnCuestionario.Visible = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label5.Visible = false;
        }

        private void btnCuestionario_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel3.Visible = true;
            btnCuestionario.Visible = false;
        }

        private void btnTerminar_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel3.Visible = false;
            int puntos = 0;
            //aqui calcular puntos acertados

            
            //codigo lindo
            StreamWriter sw = File.AppendText(ruta);
            try
            {
                sw.WriteLine(txtNombre.Text + "_" + puntos.ToString()) ;
                sw.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error.\nNo se pueden guardar los datos en este momento.\nError: " + ex.Message,"Error al guardar",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            finally
            {
                MessageBox.Show("¡Prueba terminada!\n\nHemos registrado tu puntaje "+txtNombre.Text+", se mostrará a continuación en la tabla de clasificación.\n\nPuntaje: " + puntos.ToString(), "Gracias por jugar "+txtNombre.Text, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }


            txtNombre.Text = "";
            txtNombre.Enabled = true;
            btnIniciar.Enabled = true;
            pictureBox5.Visible = true;
            lblNombre.Visible = false;
            lblNombre.Text = "¡Hola!, ";

            /*Actualizar tabla
            lblPrimero.Text = primero;
            lblSegundo.Text = segundo;
            lblTercero.Text = tercero;*/
        }
    }
}