using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Factura
{
    public partial class Factura1 : Form
    {
        public Factura1()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lblCodigo_Click(object sender, EventArgs e)
        {

        }

        private void txtCantidad_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            int cod;
            string nom;
            float precio;

            cod = cmbProducto.SelectedIndex;
            nom = cmbProducto.SelectedItem.ToString();
            precio = cmbProducto.SelectedIndex;


            switch(cod)
            {
                case 0: lblCodigo.Text = "0011";break;
                case 1: lblCodigo.Text = "0022";break;
                case 2: lblCodigo.Text = "0033"; break;
                case 3: lblCodigo.Text = "0044"; break;
                default: lblCodigo.Text = "0055"; break;

            }

            switch (nom)
            {
                
            case "Jean": lblNombre.Text = "Jean"; break;
            case "Zapatos": lblNombre.Text = "Zapatos"; break;
            case "Gorro": lblNombre.Text = "Gorro"; break;
            case "Medias": lblNombre.Text = "Medias"; break;
            default: lblNombre.Text = "Camiseta"; break;

            }

            switch (precio)
            {
                case 0: lblPrecio.Text = "110"; break;
                case 1: lblPrecio.Text = "220"; break;
                case 2: lblPrecio.Text = "330"; break;
                case 3: lblPrecio.Text = "440"; break;
                default: lblPrecio.Text = "550"; break;

            }

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            
            DataGridViewRow file = new DataGridViewRow();
            file.CreateCells(dgvLista);
            file.Cells[0].Value = lblCodigo.Text;
            file.Cells[1].Value = lblNombre.Text;
            file.Cells[2].Value = lblPrecio.Text;
            file.Cells[3].Value = txtCantidad.Text;
            file.Cells[4].Value = (float.Parse(lblPrecio.Text)* float.Parse(txtCantidad.Text)).ToString();

            dgvLista.Rows.Add(file);

            lblCodigo.Text= lblNombre.Text= lblPrecio.Text=txtCantidad.Text="";
            obtenerTotal();

        }

        public void obtenerTotal()
        {
            float constat = 0;
            int contador = 0;
            contador = dgvLista.RowCount;
            for (int i = 0; i < contador; i++)
            {
                constat += float.Parse(dgvLista.Rows[i].Cells[4].Value.ToString());
            }
            lblTotalPagar.Text= constat.ToString();

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult rppta = MessageBox.Show("¿Desea Eliminar el Producto?", "Eliminacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(rppta == DialogResult.Yes)
                {
                    dgvLista.Rows.Remove(dgvLista.CurrentRow);

                }             
            }
            catch { }
            obtenerTotal();
        }

        private void txtEfectivo_TextChanged(object sender, EventArgs e)
        {
            try {
                lblDevolucion.Text = (float.Parse(txtEfectivo.Text) - float.Parse(lblTotalPagar.Text)).ToString();
                }
            catch { }
        }
    }
}
