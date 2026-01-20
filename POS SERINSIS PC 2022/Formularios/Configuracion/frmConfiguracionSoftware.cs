using DAL.Controladores;
using DAL.Modelo;
using Invenpol_Parqueadero_Motos.Clases;
using Invenpol_Parqueadero_Motos.Clases.Servicios;
using SERINSI_PC.Clases;
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
using winRdlc2;
using System.Drawing.Imaging;
using System.Net;
using DAL.Controladores.Tienda;

namespace Invenpol_Parqueadero_Motos.Formularios.Configuracion
{
    public partial class frmConfiguracionSoftware : Form
    {
        public frmConfiguracionSoftware()
        {
            InitializeComponent();
        }
        //creamos la variables que usaremos en el formulario
        public int idEmpresa = 0;
        public int Boton = 0;
        public DateTime FechaCreacion;
        public int IdUsuarioCreador = 0;
        public DateTime FechaModificacion;
        public int IdUsuarioModificacion;
        string Ruta;
        string NombreArchivo;
        string Extencion;
        byte[] Arreglo = null;
        string ArchivoTexto;
        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// evento load del formualario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void frmConfiguracionSoftware_Load(object sender, EventArgs e)
        {
            if (VariablesPublicas.IdTipoUsuario == 1)
            {
                btnCrearSede.Visible = true;
            }
            //llenamos las variables
            idEmpresa = VariablesPublicas.IdEmpresaLogueada;
            //llamamos la funcion que se encarga de llenar los cmb
            await LLenarCmb();
            //llamamos la funcion que nos trae la informacion pedemdiendo el id de la empresa logueada
            await LLenarInformacion();
            pbLogo.Image = ClassRuta.CargarLogo(VariablesPublicas.RutaImagenes, "\\Logo\\","Logo" + VariablesPublicas.IdEmpresaLogueada + ".png");
            //llamamos la impresora predeterminada
            String printerName = Impresor.ImpresoraPredeterminada();
            txtNombreImpresora.Text = printerName;
        }
        public async Task LLenarCmb()
        {
            cmbRegimen.Items.Add("--");
            cmbRegimen.Items.Add("NO RESPONSABLE DE IVA");
            cmbRegimen.Items.Add("COMUN");
            cmbRegimen.SelectedIndex = 0;

            cmbTipoIpresora.DataSource =await ControladorImpresora.listaCompleta();
            cmbTipoIpresora.ValueMember = "tamalo_papel";
            cmbTipoIpresora.DisplayMember = "nombre_impresora";
            cmbTipoIpresora.SelectedIndex = -1;

            cmbBodega.ValueMember = "id";
            cmbBodega.DisplayMember = "nombreBodega";
            cmbBodega.DataSource=await ControladorBodega.listaCompleta();

            cbajonMonedero.Items.Add("si");
            cbajonMonedero.Items.Add("no");
        }
        /// <summary>
        /// funcion para llenar los datos del parqueadero
        /// </summary>
        public async Task LLenarInformacion()
        {
            //creamos un objeto para almacenar la información
            Sede objConfig = new Sede();
            objConfig =await ControladorSede.ConsultaXIdEmpresa(idEmpresa);
            if (objConfig != null)//si se encontraron datos 
            {
                //llenamos los campos del formulario
                txtNombreEmpresa.Text = objConfig.nombreSede;
                txtCC_NIT.Text = objConfig.nit;
                cmbRegimen.Text = objConfig.regimen;
                txtTelefono.Text = objConfig.telefono;
                txtCelular.Text = objConfig.celular;
                txtCorreo.Text = objConfig.correoAdmin1;
                txtReprecentanteLegal.Text = objConfig.reprecentante;
                txtDireccion.Text = objConfig.direccion;
                txtNombreImpresora.Text = objConfig.impresora;
                cmbTipoIpresora.Text = objConfig.tipoImpresora;
                txtTamañoPapel.Text = Convert.ToString(objConfig.tamañoPapel);
                txtLeyenda2.Text = objConfig.leyenda1;
                if (objConfig.tiendaOnline == "si")
                {
                    cbTiendaOnline.Checked = true;
                }
                else
                {
                    cbTiendaOnline.Checked = false;
                }
                if (objConfig.cortePapel == 1)
                {
                    cbcortePapel.Checked = true;
                }
                else
                {
                    cbcortePapel.Checked = false;
                }
                if (objConfig.aperturaCajon == 1)
                {
                    cbAperturaCajon.Checked = true;
                }
                else
                {
                    cbAperturaCajon.Checked = false;
                }
                txtCodigoImpresora.Text = Convert.ToString(objConfig.codigoImpresora);
                txtCodigocajon.Text = Convert.ToString(objConfig.codigoCajon);
                if (objConfig.editarPrecioVentaProducto == 1)
                {
                    cbEditarPrecioCaja.Checked = true;
                }
                if (objConfig.ventasEnNegativo == 1)
                {
                    cbVentasNegativo.Checked = true;
                }
                txtResolucion.Text = objConfig.resolucion;
                txtFechaAutorizacion.Text = objConfig.fechaResolucion;
                txtPrefijo.Text = objConfig.prefijoFectura;
                txtRango.Text = objConfig.rangoResolucion;
                txtTipoFactura.Text = objConfig.tipoFactura;
                txtTipoCaja.Text = Convert.ToString(objConfig.id_tipoCaja);
                if (objConfig.cajon_monedero == "si")
                {
                    cbajonMonedero.SelectedIndex = 0;
                }
                else
                {
                    cbajonMonedero.SelectedIndex = 1;
                }
            }
            //en esta parte llenamos la autorizacion de facturacion electronica
            AutorizacionFacturacionElectronica autorizacion = new AutorizacionFacturacionElectronica();
            autorizacion =await controladorAutorazacion_FE.consultarAutorizacion(VariablesPublicas.IdEmpresaLogueada);
            if (autorizacion != null)
            {
                txtPrefijo.Text = autorizacion.prefijo;
                txtResolucion_FE.Text = autorizacion.resolucion;
                txtFechaAvilitacion_FE.Text = autorizacion.fechaAvilitacion;
                txtRango_FE.Text = autorizacion.rango;
            }
        }
        /// <summary>
        /// evento click del boton acptar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnAceptar_Click(object sender, EventArgs e)
        {
            //verificamos las condiciones
            bool Resp = Condiciones();
            if(Resp == true)
            {
                //llamamos la funcion que se encarga de gestionar la configuracion y determinar si se va a crear,editar o eliminar
                await GestionarConfiguracion();
            }
            else
            {
                MessageBox.Show("Aún hay espacio vacío ", "ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        public async Task GestionarConfiguracion()
        {
            if(idEmpresa ==0)
            {
                Boton = 0;
            }
            else
            {
                Boton = 1;
            }
            //consultamos primero el id para saver si se va a crear o a editar
            Sede objconfig = new Sede();
            objconfig =await ControladorSede.ConsultaXIdEmpresa(VariablesPublicas.IdEmpresaLogueada);
            if(objconfig == null)//preguntamos si el objeto trajo imformacion
            {
                FechaCreacion = DateTime.Today;
                IdUsuarioCreador = Invenpol_Parqueadero_Motos.Clases.VariablesPublicas.IdUsuarioLogueado;
                FechaModificacion = DateTime.Today;
                IdUsuarioModificacion= Invenpol_Parqueadero_Motos.Clases.VariablesPublicas.IdUsuarioLogueado;
                objconfig = new Sede();
            }

            objconfig.id = idEmpresa;
            objconfig.fecha = FechaCreacion;
            objconfig.nombreSede = txtNombreEmpresa.Text; 
            objconfig.nit = txtCC_NIT.Text;
            objconfig.regimen = cmbRegimen.Text;
            objconfig.telefono = txtTelefono.Text;
            objconfig.celular = txtCelular.Text;
            objconfig.direccion = txtDireccion.Text;
            objconfig.reprecentante = txtReprecentanteLegal.Text;
            objconfig.impresora = txtNombreImpresora.Text;
            objconfig.tipoImpresora = cmbTipoIpresora.Text;
            objconfig.tamañoPapel =Convert.ToInt32(txtTamañoPapel.Text);
            objconfig.correoAdmin1 = txtCorreo.Text;
            objconfig.leyenda1 = txtLeyenda2.Text;
            if (cbTiendaOnline.Checked == true)
            {
                objconfig.tiendaOnline = "si";
            }
            else
            {
                objconfig.tiendaOnline = "no";
            }
            if (cbcortePapel.Checked == true)
            {
                objconfig.cortePapel = 1;
            }
            else
            {
                objconfig.cortePapel = 0;
            }
            if (cbAperturaCajon.Checked == true)
            {
                objconfig.aperturaCajon = 1;
            }
            else
            {
                objconfig.aperturaCajon = 0;
            }
            objconfig.codigoCajon = txtCodigocajon.Text;
            objconfig.codigoImpresora =Convert.ToInt32(txtCodigoImpresora.Text);
            if (cbEditarPrecioCaja.Checked == true)
            {
                objconfig.editarPrecioVentaProducto = 1;
            }
            else
            {
                objconfig.editarPrecioVentaProducto = 0;
            }
            if (cbVentasNegativo.Checked == true)
            {
                objconfig.ventasEnNegativo = 1;
            }
            else
            {
                objconfig.ventasEnNegativo = 0;
            }
            objconfig.resolucion = txtResolucion.Text;
            objconfig.fechaResolucion = txtFechaAutorizacion.Text;
            objconfig.prefijoFectura = txtPrefijo.Text;
            objconfig.rangoResolucion = txtRango.Text;
            objconfig.tipoFactura = txtTipoFactura.Text;
            objconfig.id_tipoCaja = Convert.ToInt32(txtTipoCaja.Text);
            if (cbGramera.Checked == true)
            {
                objconfig.gramera = 1;
            }
            else
            {
                objconfig.gramera = 0;
            }
            objconfig.cajon_monedero = cbajonMonedero.Text;
            //ahora enviamos el objeto al controlador
            bool Respuesta =await ControladorSede.CrearEditarEliminarConfiguracion(objconfig, Boton);
            if (Respuesta == true)
            {
                await Class_Informacion.CargarInformaionEmpresa();
                if (Boton == 0)
                {
                    MessageBox.Show("La configuracion fue creada correcamente. ",
                                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (Boton == 1)
                {
                    MessageBox.Show("La configuracion fue Editada correcamente. ",
                                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        /// <summary>
        /// funcion que evalua las condiciones de los campos del formulario
        /// </summary>
        /// <returns></returns>
        private bool Condiciones()
        {
            if(txtNombreImpresora.Text =="" ||
               txtCC_NIT.Text =="" ||
               cmbRegimen.Text =="" ||
               txtTelefono.Text =="" ||
               txtCelular.Text =="" ||
               txtReprecentanteLegal.Text == "" ||
               txtDireccion.Text =="" ||
               txtNombreImpresora.Text =="" ||
               cmbTipoIpresora.Text =="" ||
               txtTamañoPapel.Text ==""||
               txthoracios.Text==""||
               txtCorreo.Text==""||
               cmbBodega.Text=="")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void cmbTipoIpresora_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbTipoIpresora.Text != "")
            {
                txtTamañoPapel.Text =Convert.ToString(cmbTipoIpresora.SelectedValue);
            }
        }

        private void groupBoxdATOSeMPRESA_Enter(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void frmConfiguracionSoftware_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnCerrar.PerformClick();
            }
        }

        private void txtNombreEmpresa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtCC_NIT.Focus();
            }
        }

        private void txtCC_NIT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbRegimen.Focus();
            }
        }

        private void cmbRegimen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtTelefono.Focus();
            }
        }

        private void txtTelefono_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtCelular.Focus();
            }
        }

        private void txtCelular_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtReprecentanteLegal.Focus();
            }
        }

        private void txtReprecentanteLegal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtDireccion.Focus();
            }
        }

        private void txtDireccion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAceptar.Focus();
            }
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnCargarLogo_Click(object sender, EventArgs e)
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
                pbLogo.Image = Image.FromFile(imagen);
                //ahora converto el archivo en Bytes
                ConvertirArchivoABytes();
                //creamos la ruta para la carpeta de mis documentos
                string misDocumentos = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                ClassGuardarImagen.guardarImagenDriver(Arreglo, VariablesPublicas.RutaImagenes, "\\Logo\\","Logo"+VariablesPublicas.IdEmpresaLogueada+".png");
            }

        }
        private void ConvertirArchivoABytes()
        {
            if (Ruta != "")
            {
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                pbLogo.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                Arreglo= ms.GetBuffer();
            }
        }

        private void btnCrearSede_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta seguro de crear sede nueva con el nombre de "+txtNombreEmpresa.Text, "Crear Sede", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                idEmpresa = 0;
                //verificamos las condiciones
                bool Resp = Condiciones();
                if (Resp == true)
                {
                    //llamamos la funcion que se encarga de gestionar la configuracion y determinar si se va a crear,editar o eliminar
                    GestionarConfiguracion();
                }
                else
                {
                    MessageBox.Show("Aún hay espacio vacío ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void btnGuardarAutorizacion_FE_Click(object sender, EventArgs e)
        {
            if( txtResolucion_FE.Text!=""&&
                txtFechaAvilitacion_FE.Text!=""&&
                txtPrefijo_FE.Text != "")
            {
                try
                {
                    using(SistemaPOSEntities cn =new SistemaPOSEntities())
                    {
                        cn.insertAutorizacionFacturaElectronica(
                            VariablesPublicas.IdEmpresaLogueada,
                            txtPrefijo_FE.Text,
                            txtResolucion_FE.Text,
                            txtFechaAvilitacion_FE.Text,
                            txtRango_FE.Text);
                    }
                    MessageBox.Show("¡Autorizacion guardada correctamente.!","¡Ok!",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                }
                catch(Exception ex)
                {
                    string error = ex.Message;
                    MessageBox.Show("¡Autorizacion no se guardo correctamente.!", "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtCodigocajon_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
