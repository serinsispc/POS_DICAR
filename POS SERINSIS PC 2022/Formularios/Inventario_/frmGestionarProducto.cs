using DAL;
using DAL.Controladores;
using DAL.Controladores.Administrador;
using DAL.Controladores.Tienda;
using DAL.Controladores.Version_Software;
using DAL.Modelo;
using Invenpol_Parqueadero_Motos.Clases;
using SERINSI_PC.Clases;
using SERINSI_PC.Formularios.Ventas;
using Services;
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

namespace SERINSI_PC.Formularios.Inventario
{
    public partial class frmGestionarProducto : Form
    {
        public Guid guidProducto;
        public int IdProducto=0;
        public int TipoEvento=0;
        public int IdTipoMedida=0;
        public int IdEstadoProdcuto=0;
        public int IdCategoria=0;
        public int IdProveedor = 0;
        string ArchivoTexto;
        public frmGestionarProducto()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            frmProduct frm = Owner as frmProduct;
            frm.LimpiarFormulario();
            frm.LlenarCMB();
            this.Close();
        }
        public void MostrarImagen(string ImagenTexto)
        {
            if (ImagenTexto != null)
            {
                try
                {
                    StreamReader sr = new StreamReader(ImagenTexto);
                    Image xx = Image.FromStream(sr.BaseStream);
                    sr.Close();
                    pbImagenProducto.Image = xx;
                }
                catch
                {
                    
                }
            }
        }
        private async void frmGestionarProducto_Load(object sender, EventArgs e)
        {
            await LLenarCMBTipoMedida();
            await LLenarCMBEstadoProducto();
            await LLenarCMBCategoria();
            if(TipoEvento == 0 )
            {
                cmbEstadoProducto.SelectedIndex=0;
                cmbTipoMedida.SelectedIndex = 0;
            }
            txtCodigo.Focus();
        }
        private async Task LLenarCMBTipoMedida()
        {
            cmbTipoMedida.DataSource = null;
            cmbTipoMedida.ValueMember = "id";
            cmbTipoMedida.DisplayMember = "letraTipoMedida";
            cmbTipoMedida.DataSource =await ControladorTipoMedida.ListaCompleta();
            cmbTipoMedida.SelectedValue = IdTipoMedida;
        }
        private async Task LLenarCMBEstadoProducto()
        {
            cmbEstadoProducto.ValueMember = "id";
            cmbEstadoProducto.DisplayMember = "nombreEstadoAi";
            cmbEstadoProducto.DataSource =await ControladorEstadoAI.listaCompleta();
            cmbEstadoProducto.SelectedValue = IdEstadoProdcuto;
        }
        public async Task LLenarCMBCategoria()
        {
            cmbCategoria.ValueMember = "id";
            cmbCategoria.DisplayMember = "nombreCategoria";
            cmbCategoria.DataSource =await ControladorCategoriaProducto.ListaCompleta();
            cmbCategoria.SelectedValue = IdCategoria;
        }
        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            //validamos los campos
            bool campos = ValidarCampos();
            if (campos == true)
            {
                if (TipoEvento == 0)
                {
                    await GestionarProducto(0);
                }
                else
                {
                    await GestionarProducto(1);
                }
            }
            else
            {
                MessageBox.Show("Hay campos vacíos.", "¡Error!",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        private async Task GestionarProducto(int Boton)
        {
            MemoryStream ms = new MemoryStream();
            pbImagenProducto.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            Arreglo = ms.GetBuffer();
            ArchivoTexto = Convert.ToBase64String(Arreglo);

            RutaActualizacionEquipo objRuta = new RutaActualizacionEquipo();
            objRuta =await ControladorRutas.ConsultarX_NombreEquipo(VariablesPublicas.NombreEquipoLocal);

            ClassGuardarImagen.guardarImagenDriver(Arreglo, objRuta.rutaImagen, "\\Productos\\", guidProducto + ".png");
            ClassArchivos.SubirArchivo(ClassRutas.ServidorImagenes, ClassRutas.UsuarioServidor, ClassRutas.ClaveServidor, objRuta.rutaImagen + "\\Productos\\" + Convert.ToString(guidProducto) + ".png", Convert.ToString(guidProducto), ".png", "Productos");


            Producto objproducto = new Producto();
            objproducto =await ControladorProducto.ConsultarGuid(guidProducto);
            if (objproducto != null)
            {
                if (Boton == 0)
                {
                    bool respuesta =await VerificarCodigo(txtCodigo.Text);
                    if (respuesta == true)
                    {
                        MessageBox.Show("El codigo ( " + txtCodigo.Text + " ) ya existe ", "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    MessageBox.Show("El producto " + txtDescripcion.Text + " ya existe ", "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (Boton == 0)
            {
                objproducto = new Producto();
                IdProducto = 0;
                bool respuesta =await VerificarCodigo(txtCodigo.Text);
                if (respuesta == true)
                {
                    MessageBox.Show("El codigo ( " + txtCodigo.Text + " ) ya existe ", "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            objproducto.id = IdProducto;
            objproducto.guidProducto = guidProducto;
            objproducto.codigoProducto = txtCodigo.Text;
            objproducto.descripcionProducto = txtDescripcion.Text;
            objproducto.idTipoMedida =Convert.ToInt32(cmbTipoMedida.SelectedValue);
            objproducto.idCategoria = Convert.ToInt32(cmbCategoria.SelectedValue);
            objproducto.idEstadoAI = Convert.ToInt32(cmbEstadoProducto.SelectedValue);
            if (cbGramera.Checked == true)
            {
                objproducto.gramera = 1;
            }
            else
            {
                objproducto.gramera = 0;
            }
            objproducto.idSede = 1;
            objproducto.eliminado = 0;
            RespuestaCRUD sqlProducto =await ControladorProducto.GuardarEditarEliminarProducto(objproducto,Boton);
            if (sqlProducto.estado == true)
            {
                MessageBox.Show("El producto " + txtDescripcion.Text + " fue " + btnGuardar.Text + " correctamente.", "¡OK!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("El producto "+txtDescripcion.Text+" no se pudo "+btnGuardar.Text+" correctamente.","¡Error!",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

            this.Close();
        }
        private async Task<bool> VerificarCodigo(string codigo)
        {
            bool respuesta =await ControladorProducto.ConsultarCodigo(codigo);
            return respuesta;
        }
        private bool ValidarCampos()
        {
            if(txtCodigo.Text!="" &&
               txtDescripcion.Text!="" &&
               cmbCategoria.Text!="" &&
               cmbTipoMedida.Text!="" &&
               cmbEstadoProducto.Text != "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void txtCosto_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Para obligar a que sólo se introduzcan números 
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
              if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso 
            {
                e.Handled = false;
            }
            else
            {
                //el resto de teclas pulsadas se desactivan 
                e.Handled = true;
            }
        }

        private void txtUtilidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Para obligar a que sólo se introduzcan números 
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
              if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso 
            {
                e.Handled = false;
            }
            else
            {
                //el resto de teclas pulsadas se desactivan 
                e.Handled = true;
            }
        }

        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtDescripcion.Focus();
            }
        }

        private void txtDescripcion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbTipoMedida.Focus();
            }
        }


        private void cmbCategoria_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnGuardar.Focus();
            }
        }

        private void cmbProveedor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbCategoria.Focus();
            }
        }

        private void frmGestionarProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnCerrar.PerformClick();
            }
        }
        string Ruta;
        string NombreArchivo;
        string Extencion;
        private void btnCargarImagen_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Ruta = openFileDialog1.FileName;
                NombreArchivo = Path.GetFileNameWithoutExtension(openFileDialog1.FileName);
                Extencion = Path.GetExtension(openFileDialog1.FileName);
                string imagen = openFileDialog1.FileName;
                pbImagenProducto.Image = Image.FromFile(imagen);

                //ahora converto el archivo en Bytes
                ImagenTexto = GestionarArchivos.ConvertirImagen_Texto(Ruta);
            }
        }
        byte[] Arreglo;
        string ImagenTexto;
        private void ConvertirArchivoABytes()
        {
            if (Ruta != "")
            {
                Arreglo = File.ReadAllBytes(Ruta);
                ImagenTexto = Convert.ToBase64String(Arreglo);
            }
        }


        private void lkCategoria_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmCategorias frm = new Ventas.frmCategorias();
            AddOwnedForm(frm);
            frm.ShowDialog();
            LLenarCMBCategoria();
        }

        private async void btnActualizar_Click(object sender, EventArgs e)
        {
            await LLenarCMBTipoMedida();
            LLenarCMBEstadoProducto();
            LLenarCMBCategoria();
        }

        private async void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmTipoMedida frm = new frmTipoMedida();
            AddOwnedForm(frm);
            frm.tituloFormulario.Text = "Tipo de Medida";
            frm.ShowDialog();
            await LLenarCMBTipoMedida();
        }
    }
}
