using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ordenes2.Formularios
{
    public partial class FrmNuevaOrden : Form
    {
        public FrmNuevaOrden()
        {
            InitializeComponent();
        }

        private void FrmNuevaOrden_Load(object sender, EventArgs e)
        {
            CargarMateriales();

            // Y CON DATAPICKER ?????
            //dtpFecha =  DateTime.Today.ToString();
            txtFecha.Text = DateTime.Today.ToString("dd/MM/yyyy");
            txtResponsable.Text = "Juan";
            txtCantidad.Text = "1";

        }

        private void CargarMateriales()
        {
            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString = @"Data Source=DESKTOP-93BGHGN\SQLEXPRESS;Initial Catalog=db_ordenes;Integrated Security=True";
            conexion.Open();
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "SP_CONSULTAR_MATERIALES";
            DataTable tabla = new DataTable();
            tabla.Load(comando.ExecuteReader());
           
            conexion.Close();
           
            cboMateriales.DataSource = tabla;
            cboMateriales.DisplayMember = "nombre";
            cboMateriales.ValueMember = "codigo";
            cboMateriales.DropDownStyle = ComboBoxStyle.DropDownList; // para que no nos deje escribir el combo
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (cboMateriales.Text.Equals(string.Empty))
            {
                MessageBox.Show("Debe seleccionar un material..", "Control",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return;
            }
            if (txtResponsable.Text == null)
            {
                MessageBox.Show("Debe cargar un responsable..", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if(string .IsNullOrEmpty(txtCantidad.Text) || !int.TryParse(txtCantidad.Text,out _))
            {
                MessageBox.Show("Debe ingresar cantidad valida..", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }
    }
}
