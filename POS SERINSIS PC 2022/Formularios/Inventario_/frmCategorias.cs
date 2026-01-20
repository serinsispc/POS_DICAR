using DAL.Controladores.Tienda;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL.Modelo;
using DAL.Controladores.Administrador;
using System.IO;
using SERINSI_PC.Formularios.Inventario;
using SERINSI_PC.Clases;
using Invenpol_Parqueadero_Motos.Clases;
using DAL.Controladores.Version_Software;
using DAL.Controladores;

namespace SERINSI_PC.Formularios.Ventas
{
    public partial class frmCategorias : Form
    {
        public frmCategorias()
        {
            InitializeComponent();
        }
        Guid guidCat;
        int IdCategoria;
        string Ruta;
        string NombreArchivo;
        string Extencion;
        byte[] Arreglo = null;
        string ArchivoTexto;
        private void frmCategorias_Load(object sender, EventArgs e)
        {
            GEstionarBotones(0);
            CargarDG();
            txtCategoria.Focus();
            try
            {
                foreach (DataGridViewImageColumn column in dgCategorias.Columns)
                {
                    column.ImageLayout = DataGridViewImageCellLayout.Stretch;
                    column.Description = "Stretched";
                }
            }
            catch (Exception) { 
}
        }
        private void CargarDG()
        {
            dgCategorias.DataSource = ConotroladorCategoria.listaCompleta();
        }
        private void GEstionarBotones(int Boton)
        {
            if(Boton == 0)
            {
                btnGuardar.Text = "Crear";
                btnEliminar.Enabled = false;
            }
            else
            {
                btnGuardar.Text = "Editar";
                btnEliminar.Enabled = true;
            }
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtCategoria.Text != "")
            {
                if (btnGuardar.Text == "Crear")
                {
                    await GestionarCategoria(0);
                }
                else
                {
                    await GestionarCategoria(1);
                }
            }
        }

        private async Task GestionarCategoria(int Boton)
        {
            if (Boton == 0)
            {
                guidCat = Guid.NewGuid();
            }

            MemoryStream ms = new MemoryStream();
            pbImagenCategoria.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            Arreglo = ms.GetBuffer();
            ArchivoTexto = Convert.ToBase64String(Arreglo);

            RutaActualizacionEquipo objRuta = new RutaActualizacionEquipo();
            objRuta =await ControladorRutas.ConsultarX_NombreEquipo(VariablesPublicas.NombreEquipoLocal);

            ClassGuardarImagen.guardarImagenDriver(Arreglo, objRuta.rutaImagen, "\\Categorias\\", guidCat + ".png");
            ClassArchivos.SubirArchivo(ClassRutas.ServidorImagenes, ClassRutas.UsuarioServidor, ClassRutas.ClaveServidor, objRuta.rutaImagen + "\\Categorias\\" + Convert.ToString(guidCat) + ".png", Convert.ToString(guidCat), ".png", "Categorias");

            CategoriaProducto objcat = new CategoriaProducto();
            objcat =await ControladorCategoriaProducto.ConsultarGuid(guidCat);
            if (objcat != null)
            {
                if (Boton == 0)
                {
                    MessageBox.Show("La categoría "+txtCategoria.Text +" ya se existe.","¡Error!",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    btnActualizar.PerformClick();
                    return;
                }
                else
                {
                    //en esta parte consultamos que el nombre de la categoria no se repita.
                    bool nombre =await VerificarNombreCategoria(txtCategoria.Text);
                    if (nombre == false)
                    {
                        MessageBox.Show("La categoría " + txtCategoria.Text + " ya se existe.","¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        btnActualizar.PerformClick();
                        return;
                    }
                }
            }
            if (Boton == 0)
            {
                IdCategoria = 0;
                objcat = new CategoriaProducto();
            }
            objcat.id = IdCategoria;
            objcat.guidCategoria = guidCat;
            objcat.nombreCategoria = txtCategoria.Text;
            bool sqlCat =await ControladorCategoriaProducto.Crear_Editar_Eliminar_Categoria(objcat,Boton);
            if (sqlCat == true)
            {
                MessageBox.Show("La categoría " + txtCategoria.Text + " fue "+btnGuardar.Text+" correctamente.", "¡OK!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("La categoría " + txtCategoria.Text + " no se pudo "+btnGuardar.Text+".", "¡OK!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            btnActualizar.PerformClick();
        }
        private async Task<bool> VerificarNombreCategoria(string nombre)
        {
            CategoriaProducto objcat = new CategoriaProducto();
            objcat =await ControladorCategoriaProducto.ConsultarNombre(nombre);
            if (objcat != null)
            {
                if (objcat.guidCategoria != guidCat)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return true;
            }
        }
        private void LimpiarFormulario()
        {
            IdCategoria = 0;
            guidCat = new Guid();
            txtCategoria.Text = "";
            CargarDG();
            GEstionarBotones(0);
            txtCategoria.Focus();
            LimpiarPB();
            NombreArchivo = "";
            ArchivoTexto = "";
        }

        private async void dgCategorias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgCategorias.RowCount > 0 && e.RowIndex >= 0)
            {
                DataGridViewRow Fila = dgCategorias.Rows[e.RowIndex];

                IdCategoria = Convert.ToInt32(Fila.Cells["id"].Value);
                txtCategoria.Text = Convert.ToString(Fila.Cells["nombreCategoria"].Value);
  
                if (pbImagenCategoria.Image == null)
                {
                    pbImagenCategoria.Image = POS_SERINSIS_PC_2022.Properties.Resources.inventario1;
                }
                CategoriaProducto objcat = new CategoriaProducto();
                objcat =await ControladorCategoriaProducto.ConsulatarID(IdCategoria);
                if (objcat != null)
                {
                    guidCat = (Guid)objcat.guidCategoria;
                }
                pbImagenCategoria.Image = ClassRuta.CargarProductoCategoria(VariablesPublicas.RutaImagenes, "\\Categorias\\", guidCat + ".png");
                GEstionarBotones(1);
                txtCategoria.Focus();
            }
        }
        private void LimpiarPB()
        {
            pbImagenCategoria.Image = POS_SERINSIS_PC_2022.Properties.Resources.inventario1;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCategoria_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnGuardar.PerformClick();
            }
        }

        private void frmCategorias_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnCerrar.PerformClick();
            }
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnCargarImagenCategoria_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.InitialDirectory = "c:\\";
                openFileDialog1.Filter = "Todos los archivos (*.*)|*.*";
                openFileDialog1.FilterIndex = 1;
                openFileDialog1.RestoreDirectory = true;

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    Ruta = openFileDialog1.FileName;
                    NombreArchivo = Path.GetFileNameWithoutExtension(openFileDialog1.FileName);
                    Extencion = Path.GetExtension(openFileDialog1.FileName);
                    string imagen = openFileDialog1.FileName;
                    pbImagenCategoria.Image = Image.FromFile(imagen);
                    //ahora converto el archivo en Bytes
                    ConvertirArchivoABytes();
                }
            }
            catch(Exception ex)
            {
                string error = ex.Message;
            }

        }
        private void ConvertirArchivoABytes()
        {
            if (Ruta != "")
            {
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                pbImagenCategoria.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                Arreglo = ms.GetBuffer();
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarDG();
            LimpiarFormulario();
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            CategoriaProducto objcat = new CategoriaProducto();
            objcat =await ControladorCategoriaProducto.ConsulatarID(IdCategoria);
            if (objcat != null)
            {
                if (MessageBox.Show("Esta seguro de eliminar la categoría "+objcat.nombreCategoria, "¡Eliminar!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    bool eliminar =await ControladorCategoriaProducto.Crear_Editar_Eliminar_Categoria(objcat,2);
                    if (eliminar == true)
                    {
                        MessageBox.Show("La categoría " + objcat.nombreCategoria + " fue eliminada correctamente.", "¡OK!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("La categoría " + objcat.nombreCategoria + " no fue eliminada correctamente.", "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    btnActualizar.PerformClick();
                }
            }
        }
    }
}
