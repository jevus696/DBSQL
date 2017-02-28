using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.OleDb;

namespace DBSQL 
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public string StrFileName;
        

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void BtnLimpiar_Click_1(object sender, EventArgs e)
        {
            TxtId.Clear();
            TxtNombre.Clear();
            TxtFechaAlta.Clear();
            TxtNIF.Clear();
            TxtFechaNac.Clear();
            TxtDireccion.Clear();
            TxtPoblacion.Clear();
            TxtTelefono.Clear();
            TxtEstadoCivil.Clear();
            pictureBox1.ImageLocation = "";
            TxtId.Focus();
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                const string insertar = @"Insert Into Vendedores Values (@IdVendedor, @NombreVendedor,
                @FechaAlta, @NIF, @FechaNac,@Direccion,@Poblacion,@Telefono,@EstadoCivil,@Fotografia)";
                var cmd = new OleDbCommand(insertar, Cnx) { CommandType = CommandType.Text };
                cmd.Parameters.AddWithValue("@IdVendedor", TxtId.Text);
                cmd.Parameters.AddWithValue("@NombreVendedor", TxtNombre.Text);
                cmd.Parameters.AddWithValue("@FechaAlta", TxtFechaAlta.Text);
                cmd.Parameters.AddWithValue("@NIF", TxtNIF.Text);
                cmd.Parameters.AddWithValue("@FechaNac", TxtFechaNac.Text);
                cmd.Parameters.AddWithValue("@Direccion", TxtDireccion.Text);
                cmd.Parameters.AddWithValue("@Poblacion", TxtPoblacion.Text);
                cmd.Parameters.AddWithValue("@Telefono", TxtTelefono.Text);
                cmd.Parameters.AddWithValue("@EstadoCivil", TxtEstadoCivil.Text);
                pictureBox1.ImageLocation = StrFileName;
                cmd.Parameters.AddWithValue("@Fotografia", pictureBox1.ImageLocation);
                Cnx.Open();
                cmd.ExecuteNonQuery();
                Cnx.Close();
                MessageBox.Show(@"El Contacto Fue Registrado");
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"La Clave a Registrar Ya Existe", ex.Message);
            }
            TxtId.Clear();
            TxtNombre.Clear();
            TxtFechaAlta.Clear();
            TxtNIF.Clear();
            TxtFechaNac.Clear();
            TxtDireccion.Clear();
            TxtPoblacion.Clear();
            TxtTelefono.Clear();
            TxtEstadoCivil.Clear();
            pictureBox1.ImageLocation = "";
            TxtId.Focus();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnBuscar_Click_1(object sender, EventArgs e)
        {
            const string buscar = "SELECT * FROM Vendedores WHERE IdVendedor=@Id";
            var cmdBuscar = new OleDbCommand(buscar, Cnx) { CommandType = CommandType.Text };
            cmdBuscar.Parameters.AddWithValue("@Id", TxtId.Text);
            Cnx.Open();
            var lectura = cmdBuscar.ExecuteReader();
            if (lectura != null && lectura.Read() == true)
            {
                TxtNombre.Text = lectura[1].ToString();
                TxtFechaAlta.Text = lectura[2].ToString();
                TxtNIF.Text = lectura[3].ToString();
                TxtFechaNac.Text = lectura[4].ToString();
                TxtDireccion.Text = lectura[5].ToString();
                TxtPoblacion.Text = lectura[6].ToString();
                TxtTelefono.Text = lectura[7].ToString();
                TxtEstadoCivil.Text = lectura[8].ToString();
                pictureBox1.ImageLocation = lectura[9].ToString();
            }
            else
            {
                MessageBox.Show(@"Los Datos a Buscar No Estan Registrados");
                TxtId.Clear();
                TxtId.Focus();
            }
            Cnx.Close();
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                const string actualizar = @"UPDATE Vendedores SET IdVendedor=@Id, NombreVendedor=@Nombre ,FechaAlta = @FechaAlta,
                                    NIF = @NIF, FechaNac = @FechaNac, Direccion = @Direccion, Poblacion = @Poblacion,
                                    Telefon = @Telefon, EstalCivil = @EstalCivil,Fotografia = @Fotografia WHERE IdVendedor = @Id";
                var cmd = new OleDbCommand(actualizar, Cnx) { CommandType = CommandType.Text };
                cmd.Parameters.AddWithValue("@Id", TxtId.Text);
                cmd.Parameters.AddWithValue("@Nombre", TxtNombre.Text);
                cmd.Parameters.AddWithValue("@FechaAlta", TxtFechaAlta.Text);
                cmd.Parameters.AddWithValue("@NIF", TxtNIF.Text);
                cmd.Parameters.AddWithValue("@FechaNac", TxtFechaNac.Text);
                cmd.Parameters.AddWithValue("@Direccion", TxtDireccion.Text);
                cmd.Parameters.AddWithValue("@Poblacion", TxtPoblacion.Text);
                cmd.Parameters.AddWithValue("@Telefon", TxtTelefono.Text);
                cmd.Parameters.AddWithValue("@EstalCivil", TxtEstadoCivil.Text);
                cmd.Parameters.AddWithValue("@Fotografia", pictureBox1.ImageLocation);
                Cnx.Open();
                cmd.ExecuteNonQuery();
                Cnx.Close();
                MessageBox.Show(@"Los Datos Del Contacto Fueron Actualizados");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, null, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            TxtId.Clear();
            TxtNombre.Clear();
            TxtFechaAlta.Clear();
            TxtNIF.Clear();
            TxtFechaNac.Clear();
            TxtDireccion.Clear();
            TxtPoblacion.Clear();
            TxtTelefono.Clear();
            TxtEstadoCivil.Clear();
            pictureBox1.ImageLocation = "";
            TxtId.Focus();

        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                const string eliminar = "DELETE FROM Vendedores WHERE IdVendedor=@Id";
                var cmd = new OleDbCommand(eliminar, Cnx) { CommandType = CommandType.Text };
                cmd.Parameters.AddWithValue("@Id", TxtId.Text);
                Cnx.Open();
                cmd.ExecuteNonQuery();
                Cnx.Close();
                MessageBox.Show(@"El Contacto Fue Eliminado....");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, null, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            TxtId.Clear();
            TxtNombre.Clear();
            TxtFechaAlta.Clear();
            TxtNIF.Clear();
            TxtFechaNac.Clear();
            TxtDireccion.Clear();
            TxtPoblacion.Clear();
            TxtTelefono.Clear();
            TxtEstadoCivil.Clear();
            pictureBox1.ImageLocation = "";
            TxtId.Focus();
        }

        private void BtnCargarFoto_Click(object sender, EventArgs e)
        {
            if (openFileDialog1 == null) return;
            openFileDialog1.Filter = @"jpegs|*.jpg|gifs|*.gif|Bitmaps|*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.Title = @"Abrir un archivo de imagen";
            if (openFileDialog1.ShowDialog() != DialogResult.OK) return;
            try
            {
                StrFileName = openFileDialog1.FileName;
                pictureBox1.Image = Image.FromFile(StrFileName);
                openFileDialog1.Reset();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, null, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}