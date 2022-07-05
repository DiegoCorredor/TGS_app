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
        string ruta = "..\\..\\..\\..\\Propiedades_de_los_sistemas\\leader.txt";
        ArrayList myAl;

        Int32 aux;

        ArrayList SizeFile()
        {
            myAl = new ArrayList();
            TextReader read = new StreamReader(ruta);
            string contend;
            while ((contend = read.ReadLine()) != null)
            {
                myAl.Add(contend);
            }

            read.Close();
            return myAl;
        }

        void mostrarTabla()
        {
            for (int i = ((SizeFile().Count) - 1); i >= 0; i--)
            {
                if (i == SizeFile().Count - 1)
                {
                    lblPrimero.Text = GetOrdenados()[i].ToString();
                }
                if (i == SizeFile().Count - 2)
                {
                    lblSegundo.Text = GetOrdenados()[i].ToString();
                }
                if (i == SizeFile().Count - 3)
                {
                    lblTercero.Text = GetOrdenados()[i].ToString();
                }
            }
        }

        int[] GetOrdenados()
        {
            int[] datos = new Int32[SizeFile().Count];
            for (int i = 0; i < SizeFile().Count; i++){
                datos[i] = Int32.Parse(myAl[i].ToString());
            }
            for (int i = 0; i < (SizeFile().Count) - 1; i++){
                for (int j = 0; j < (SizeFile().Count) - 1; j++){
                    if (datos[j] > datos[j + 1]){
                        aux = datos[j];
                        datos[j] = datos[j + 1];
                        datos[j + 1] = aux;
                    }
                }
            }
            return datos;
        }
        int GetPosicion(int points)
        {
            for (int i = ((SizeFile().Count) - 1); i >= 0; i--)
            {
                if (points == GetOrdenados()[i])
                {
                    return (SizeFile().Count - i);
                }
            }
            return 0;
        }



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
            btnTerminar.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            mostrarTabla();
        }

        private void btnCuestionario_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel3.Visible = true;
            btnCuestionario.Visible = false;
            btnTerminar.Visible = true;
        }

        private void btnTerminar_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel3.Visible = false;
            int puntos = 0;
            //aqui calcular puntos acertados
            if (combo1.SelectedIndex == 0)
            {
                puntos += 2;
            }

            if (combo2.SelectedIndex == 2)
            {
                puntos += 2;
            }

            if (combo3.SelectedIndex == 0)
            {
                puntos += 2;
            }

            if (combo4.SelectedIndex == 1)
            {
                puntos += 2;
            }
            if (combo5.SelectedIndex == 2)
            {
                puntos += 2;
            }
            if (combo6.SelectedIndex == 2)
            {
                puntos += 2;
            }
            if (combo7.SelectedIndex == 1)
            {
                puntos += 2;
            }
            if (combo8.SelectedIndex == 3)
            {
                puntos += 2;
            }
            if (combo9.SelectedIndex == 0)
            {
                puntos += 2;
            }
            if (combo10.SelectedIndex == 1)
            {
                puntos += 2;
            }
            if (combo11.SelectedIndex == 0)
            {
                puntos += 2;
            }
            if (combo12.SelectedIndex == 0)
            {
                puntos += 2;
            }
            if (combo13.SelectedIndex == 0)
            {
                puntos += 2;
            }
            if (combo14.SelectedIndex == 0)
            {
                puntos += 2;
            }
            if (combo15.SelectedIndex == 1)
            {
                puntos += 2;
            }
            if (combo16.SelectedIndex == 0)
            {
                puntos += 2;
            }
            if (combo17.SelectedIndex == 0)
            {
                puntos += 2;
            }
            if (combo18.SelectedIndex == 0)
            {
                puntos += 2;
            }
            if (combo19.SelectedIndex == 0)
            {
                puntos += 2;
            }
            if (combo20.SelectedIndex == 0)
            {
                puntos += 2;
            }
            if (combo21.SelectedIndex == 0)
            {
                puntos += 2;
            }
            if (combo22.SelectedIndex == 3)
            {
                puntos += 2;
            }
            if (combo23.SelectedIndex == 0)
            {
                puntos += 2;
            }
            if (combo24.SelectedIndex == 1)
            {
                puntos += 2;
            }
            if (combo25.SelectedIndex == 2)
            {
                puntos += 2;
            }
            //Guardar nombre y puntaje
            StreamWriter sw = File.AppendText(ruta);
            try
            {
                sw.WriteLine(puntos.ToString()) ;
                sw.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error.\nNo se pueden guardar los datos en este momento.\nError: " + ex.Message,"Error al guardar",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            finally
            {
                MessageBox.Show("¡Prueba terminada!\n\nHemos registrado tu puntaje "+txtNombre.Text+", se mostrará a continuación en la tabla de clasificación.\n\nPuntaje: " + puntos.ToString()+" de 50.", "Gracias por jugar "+txtNombre.Text, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            //reset visual
            txtNombre.Text = "";
            txtNombre.Enabled = true;
            btnIniciar.Enabled = true;
            pictureBox5.Visible = true;
            lblNombre.Visible = false;
            lblNombre.Text = "¡Hola!, ";
            btnTerminar.Visible = false;
            //Actualizar tabla
            mostrarTabla();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}