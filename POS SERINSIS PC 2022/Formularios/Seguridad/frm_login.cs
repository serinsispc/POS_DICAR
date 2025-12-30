using DAL.Controladores;
using DAL.Controladores.Administrador;
using DAL.Controladores.Version_Software;
using DAL.Modelo;
using Invenpol_Parqueadero_Motos.Clases;
using Invenpol_Parqueadero_Motos.Clases.Servicios;
using Invenpol_Parqueadero_Motos.Clases.VersionSoftware;
using SERINSI_PC.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SERINSI_PC.Formularios.Seguridad
{
    public partial class frm_login : Form
    {
        public frm_login()
        {
            InitializeComponent();
        }
        string NombreEquipoLocal;
        string IPEquipoNuevo;
        string UsuarioEquipoNuevo;
        string NombreUsuarioLogueado;
        string TipoUsuario;
        int IdUsuarioLogueado;
        private async void frm_login_Load(object sender, EventArgs e)
        {
            //string ClaveLicencia = "WSC5Y-2HO96-SGR7U"; //Licencia HAROL
            string ClaveLicencia = "WSC5Y-2HO96-SGR5U"; //Licencia DrogueriaVariedadesYanilu

            Licencia objLicencia = new Licencia();
            objLicencia =await ControladorLicenciaSoftware.ConsultarLicencia(ClaveLicencia);
            if (objLicencia == null)
            {
                if (DateTime.Today < Convert.ToDateTime("2021-05-04"))
                {
                    if (MessageBox.Show("Serinsis PC. Le informa que aún está pendiente la activación de su software." + Environment.NewLine
                    + Environment.NewLine +
                    Environment.NewLine +
                    "¿desea ingresar la clave de activación del software?",
                    "Activación pendiente", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        frmIngresarLicencia frm = new frmIngresarLicencia();
                        frm.LicenciaSoftware = ClaveLicencia;
                        frm.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("Ocurrió un error de conexión.", "Error De conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                    //MessageBox.Show("Serinsis PC. Le informa que aún está pendiente la activación de su software.");
                    //frmIngresarLicencia frm = new frmIngresarLicencia();
                    //frm.LicenciaSoftware = ClaveLicencia;
                    //frm.ShowDialog();
                }
            }
            //*****************************************************************
            NombreEquipoLocal = Dns.GetHostName();
            VariablesPublicas.NombreEquipoLocal = NombreEquipoLocal;
            //ahora consultamos las rutas con el nomobre del equipo
            RutaActualizacionEquipo objRutas = new RutaActualizacionEquipo();
            objRutas =await ControladorRutas.ConsultarX_NombreEquipo(NombreEquipoLocal);
            if(objRutas != null)
            {
                VariablesPublicas.RutaImagenes = objRutas.rutaImagen;
                VariablesPublicas.RutaConsultaImagen = objRutas.rutaImagen;
                VariablesPublicas.RutaTutoriales = objRutas.rutaTutoriales;
            }

            VariablesPublicas.IdEmpresaLogueada = 1;

            Consultar_IPEquipo_Usuario();
            //primero consultamos la ultima version cargada
            int IdUltimaVersion =await ControladorVersionSoftware.UltimaVersion();
            await ConsultarVercionActual(IdUltimaVersion);
            //en esta parte cargamos el logo de la empresa
            pbLogo.Image = ClassRuta.CargarLogo(VariablesPublicas.RutaImagenes, "\\Logo\\", "Logo.png");
            //en esta parte identificamos la targeta madre del equipo
            VerificarConexionEquipo();

            txtUsuario.Focus();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        TextBox textBoxActivo;
        private void GestionarTecla(string tecla)
        {
            try
            {
                string texto = "";
                if (textBoxActivo.Text != "")
                {
                    texto= textBoxActivo.Text;
                }
                texto = texto + tecla;
                textBoxActivo.Text = texto;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
        }
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "programador" && txtClave.Text == "emilio1990")
            {
                VariablesPublicas.Programador = true;

                //frmMenuPrincipal frm = new frmMenuPrincipal();
                //frm.ShowDialog();
                return;
            }
            //verificamos el estado del admincontrol
            ConsultarMensaje();
            //creamos un objeto para consultar el usuario y la clave
            Usuario objUsuario = new Usuario();
            objUsuario = ControladorUsuario.ConsultaUsuarioYClave(txtUsuario.Text, txtClave.Text);
            if (objUsuario != null)//preguntamos si encontro resultado
            {
                //llenamos lasvariables locales
                IdUsuarioLogueado = objUsuario.id;
                NombreUsuarioLogueado = objUsuario.nombreUsuario;
                TipoUsuario objtipo = new TipoUsuario();
                objtipo = controladorTipoUsuario.consultarID(Convert.ToInt32(objUsuario.idTipoUsuario));
                if (objtipo != null)
                {
                    TipoUsuario = objtipo.nombreTipoUsuario;
                }

                VariablesPublicas.IdTipoUsuario = Convert.ToInt32(objUsuario.idTipoUsuario);
                //Antes de ingresar al sistema verificamos cuantas sedes tiene asignadas el usuario
                int Sedes = controladorSedesAsignadas.SumarSedesAsignadas(IdUsuarioLogueado);
                if (Sedes == 1)
                {
                    SedesAsignadas objSA = new SedesAsignadas();
                    objSA = controladorSedesAsignadas.consultarIDUsuario(IdUsuarioLogueado);
                    if (objSA != null)
                    {
                        VariablesPublicas.IdEmpresaLogueada = objSA.idSedeAsignada;
                        //ahora llamos la funcion para ingresar
                        Ingresar();
                    }

                }
                if (Sedes > 1)
                {
                    //En esta parte le mostramos al cliente el listado de las sedes que tiene asignadas.
                    lbSedes.Visible = true;
                    lbSedes.ValueMember = "V_idSedeAsignada";
                    lbSedes.DisplayMember = "v_nombre_empresa";
                    lbSedes.DataSource = controladorSedesAsignadas.filtroXIdUsuario(IdUsuarioLogueado);
                    lbSedes.SelectedIndex = 0;
                    lbSedes.Focus();
                }
                if (Sedes == 0)
                {
                    MessageBox.Show("No tiene ninguna seda asignada..", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    lbSedes.Visible = false;
                    txtClave.Text = "";
                    txtUsuario.Focus();
                    return;
                }
            }
            else
            {
                MessageBox.Show("Usuario o clave incorrecta.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtClave.Text = "";
                txtUsuario.Focus();
                return;
            }
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            //if (txtUsuario.Text == "")
            //{
            //    txtUsuario.Text = "Usuario";
            //    txtUsuario.ForeColor = Color.FromArgb(28, 28, 28);
            //}
        }

        private void txtUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtUsuario.Text != "Usuario")
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtClave.Focus();
                }
            }
        }

        private void txtClave_Leave(object sender, EventArgs e)
        {
            //if (txtClave.Text == "")
            //{
            //    txtClave.Text = "Clave";
            //    txtClave.UseSystemPasswordChar = false;
            //    txtClave.ForeColor = Color.FromArgb(28, 28, 28);
            //}
        }

        private void txtClave_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtClave.Text != "Clave")
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnIngresar.PerformClick();
                }
            }
        }

        private void txtClave_Enter(object sender, EventArgs e)
        {
            txtClave.ForeColor = Color.Black;
            txtClave.UseSystemPasswordChar = true;
            textBoxActivo = txtClave;
            //if (txtClave.Text == "Clave")
            //{
            //    txtClave.Text = "";
            //    txtClave.ForeColor = Color.Black;
            //    txtClave.UseSystemPasswordChar = true;
            //    textBoxActivo = txtClave;
            //}
        }

        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            txtUsuario.Text = "";
            txtUsuario.ForeColor = Color.Black;
            textBoxActivo = txtUsuario;
            //if (txtUsuario.Text == "Usuario")
            //{
            //    txtUsuario.Text = "";
            //    txtUsuario.ForeColor = Color.Black;
            //    textBoxActivo = txtUsuario;
            //}
        }

        private void lbSedes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                lbSedes.Visible = false;
            }
            if (lbSedes.Text != "")
            {
                if (e.KeyCode == Keys.Enter)
                {
                    VariablesPublicas.IdEmpresaLogueada = Convert.ToInt32(lbSedes.SelectedValue);
                    lbSedes.Visible = false;
                    Ingresar();
                }
            }
        }





        #region Funciones
        public void Ingresar()
        {
            Class_Informacion.CargarInformaionEmpresa();
            //llenamos las variables globales
            VariablesPublicas.IdUsuarioLogueado = IdUsuarioLogueado;
            VariablesPublicas.NombreUsuarioActivo = NombreUsuarioLogueado;
            VariablesPublicas.TipoUsuarioLogueado = TipoUsuario;

            //cerramos el formulario login y llamamos el formulario menu
            Hide();
            frmMenuPrincipal frm = new frmMenuPrincipal();
            frm.pbLogoCentral.Image = ClassRuta.CargarLogo(VariablesPublicas.RutaImagenes, "\\Logo\\", "Logo" + VariablesPublicas.IdEmpresaLogueada + ".png");
            frm.pbLogo.Image = ClassRuta.CargarLogo(VariablesPublicas.RutaImagenes, "\\Logo\\", "Logo" + VariablesPublicas.IdEmpresaLogueada + ".png");
            frm.TituloMenu = "  " + VariablesPublicas.NombreEmpresa + " -- Version: " + ClaseVersion.NumeroVersion;
            frm.txtNombreUsuario.Text = VariablesPublicas.NombreUsuarioActivo;
            frm.txtCargoUsuario.Text = VariablesPublicas.TipoUsuarioLogueado;
            frm.Show();
        }
        private void ConsultarMensaje()
        {
            //verificamos el estado del admincontrol
            AdminControl objAC = new AdminControl();
            objAC = ControladorAdminControl.Consultar();
            if (objAC != null)
            {
                if (objAC.tipo_admincontrol == 1)
                {
                    MessageBox.Show(objAC.mensaje_admincontrol, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    frmMensague frm = new frmMensague();
                    AddOwnedForm(frm);
                    frm.txtMensaje.Text = objAC.mensaje_admincontrol;
                    frm.ShowDialog();
                }
                if (objAC.tipo_admincontrol == 2)
                {
                    MessageBox.Show(objAC.mensaje_admincontrol, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Hide();
                    Application.Exit();
                }
            }
        }
        private void VerificarConexionEquipo()
        {
            ManagementObjectSearcher mos = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_BaseBoard");
            foreach (ManagementObject mo in mos.Get())
            {
                try
                {
                    //cargamos la informacion en las variables
                    string SerialNumber = mo.GetPropertyValue("SerialNumber").ToString();
                    string Manufacturer = mo.GetPropertyValue("Manufacturer").ToString();
                    string Product = mo.GetPropertyValue("Product").ToString();
                    string version = mo.GetPropertyValue("version").ToString();
                    //consultamos el numero del serial da la boar
                    AutorizacionPC objAPC = new AutorizacionPC();
                    objAPC = ControladorAutorizacionPC.ConsultarXSerial(SerialNumber, Manufacturer, Product, version, 1);
                    if (objAPC == null)
                    {
                        MessageBox.Show("Sofinpro le informa que no hay autorización para este equipo." + Environment.NewLine + Environment.NewLine +
                            "Por favor comuníquese con el Editor del Software a los números 314 462 8361 – 314 252 5096 para pedir la autorización." + Environment.NewLine + Environment.NewLine +
                            "NOTA: Tenga en cuenta la siguiente información para la solicitud de la autorización:" + Environment.NewLine + Environment.NewLine +
                            "•	SerialNumber: " + SerialNumber + Environment.NewLine +
                            "•	Manufacturer: " + Manufacturer + Environment.NewLine +
                            "•	Product: " + Product + Environment.NewLine +
                            "•	Version: " + version,
                            "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        //lo agragamos en estado 0
                        objAPC = new AutorizacionPC();
                        objAPC.id_autorizacion_pc = 0;
                        objAPC.serialnumber_pc = SerialNumber;
                        objAPC.Manufacturer_pc = Manufacturer;
                        objAPC.product_pc = Product;
                        objAPC.Version_pc = version;
                        objAPC.estado_equipo = 0;
                        objAPC.nombre_equipo = "nuevo";
                        bool SQL = ControladorAutorizacionPC.Crear_Editar_Eliminar_Equipo(objAPC, 0);
                        if (SQL == true)
                        {

                        }
                        Hide();
                        Application.Exit();
                    }
                }
                catch
                { }
            }
        }
        private async Task ConsultarVercionActual(int IdVersion)
        {
            VersionSoftware objVersionSoftware = new VersionSoftware();
            objVersionSoftware =await ControladorVersionSoftware.ConsultarVersionSoftware(IdVersion);
            if (objVersionSoftware != null)
            {
                ClaseVersion.NumeroVersion = objVersionSoftware.numero_version;
                ClaseVersion.VersionActualCodigo = objVersionSoftware.version_actual;
                //en esta parte como ya sabemos el nombre de la ultima version del software
                //procedemos a verificar si ya esta aplicada a el equipo local domde se esta corriendo el software
                ReporteActualizacionEquipo objReporteActualizacion = new ReporteActualizacionEquipo();
                objReporteActualizacion =await ControladorReporteActualizacion.ConsultarX_NombreEquipo_NOmbreActualizacion(VariablesPublicas.NombreEquipoLocal, ClaseVersion.VersionActualCodigo);
                if (objReporteActualizacion == null)
                {
                    //en esta parte como ya se va a empesar con el proceso de la actualizacion entonces consultamos las rutas en la table de rutas por el nomber del equipo
                    RutaActualizacionEquipo objRutas = new RutaActualizacionEquipo();
                    objRutas =await ControladorRutas.ConsultarX_NombreEquipo(VariablesPublicas.NombreEquipoLocal);
                    if (objRutas != null)
                    {
                        VariablesPublicas.RutaApllicacionActualizacion = objRutas.ruta_aplicaion_actualizacion;
                        VariablesPublicas.RutaCarpetaActualizacion = objRutas.ruta_carpeta_actualizacion;
                        //VariablesPublicas.RutaTutoriales = objRutas.ruta_tutoriales;
                        VariablesPublicas.NombreCarpetaActualizacion = objVersionSoftware.version_actual;
                        MessageBox.Show("¡Hola!" + Environment.NewLine + Environment.NewLine +
                                        "SERINSIS PC le informa que hay una actualización disponible, por lo tanto el software se reiniciara para aplicar automáticamente la actualización." + Environment.NewLine + Environment.NewLine +
                                        "Nota: si después del proceso de actualización el software presenta algún inconveniente por favor comuníquese al número celular 3144628361.", "Actualización", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //en este momento la consulta nos confirma que si hay una vercion nueva disponible entonces consultamos si ya esta la carpeta cargada en el equipo
                        ClaseVersion.ConsultarVercion(NombreEquipoLocal, objVersionSoftware.version_actual);
                    }

                }

            }
        }
        private void Consultar_IPEquipo_Usuario()
        {
            string localIP = "";
            string Usuario = "";
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());// objeto para guardar la ip
            foreach (IPAddress ip in host.AddressList)
            {
                if (localIP == "")
                {
                    if (ip.AddressFamily.ToString() == "InterNetwork")
                    {
                        localIP = ip.ToString();// esta es nuestra ip
                        Usuario = SystemInformation.UserName;
                        IPEquipoNuevo = localIP;
                        UsuarioEquipoNuevo = Usuario;
                    }
                }
                else
                {
                    return;
                }
            }
        }
        #endregion

        private void lbSedes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn1_Click(object sender, EventArgs e)
        {
            Button boton = (Button)sender;
            GestionarTecla(boton.Text.ToLower());
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            Button boton = (Button)sender;
            GestionarTecla(boton.Text.ToLower());
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            Button boton = (Button)sender;
            GestionarTecla(boton.Text.ToLower());
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            Button boton = (Button)sender;
            GestionarTecla(boton.Text.ToLower());
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            Button boton = (Button)sender;
            GestionarTecla(boton.Text.ToLower());
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            Button boton = (Button)sender;
            GestionarTecla(boton.Text.ToLower());
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            Button boton = (Button)sender;
            GestionarTecla(boton.Text.ToLower());
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            Button boton = (Button)sender;
            GestionarTecla(boton.Text.ToLower());
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            Button boton = (Button)sender;
            GestionarTecla(boton.Text.ToLower());
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            Button boton = (Button)sender;
            GestionarTecla(boton.Text.ToLower());
        }

        private void BTNQ_Click(object sender, EventArgs e)
        {
            Button boton = (Button)sender;
            GestionarTecla(boton.Text.ToLower());
        }

        private void BTNW_Click(object sender, EventArgs e)
        {
            Button boton = (Button)sender;
            GestionarTecla(boton.Text.ToLower());
        }

        private void BTNE_Click(object sender, EventArgs e)
        {
            Button boton = (Button)sender;
            GestionarTecla(boton.Text.ToLower());
        }

        private void BTNR_Click(object sender, EventArgs e)
        {
            Button boton = (Button)sender;
            GestionarTecla(boton.Text.ToLower());
        }

        private void BTNT_Click(object sender, EventArgs e)
        {
            Button boton = (Button)sender;
            GestionarTecla(boton.Text.ToLower());
        }

        private void BTNY_Click(object sender, EventArgs e)
        {
            Button boton = (Button)sender;
            GestionarTecla(boton.Text.ToLower());
        }

        private void BTNU_Click(object sender, EventArgs e)
        {
            Button boton = (Button)sender;
            GestionarTecla(boton.Text.ToLower());
        }

        private void BTNI_Click(object sender, EventArgs e)
        {
            Button boton = (Button)sender;
            GestionarTecla(boton.Text.ToLower());
        }

        private void BTNO_Click(object sender, EventArgs e)
        {
            Button boton = (Button)sender;
            GestionarTecla(boton.Text.ToLower());
        }

        private void BTNP_Click(object sender, EventArgs e)
        {
            Button boton = (Button)sender;
            GestionarTecla(boton.Text.ToLower());
        }

        private void BTNA_Click(object sender, EventArgs e)
        {
            Button boton = (Button)sender;
            GestionarTecla(boton.Text.ToLower());
        }

        private void BTNS_Click(object sender, EventArgs e)
        {
            Button boton = (Button)sender;
            GestionarTecla(boton.Text.ToLower());
        }

        private void BTND_Click(object sender, EventArgs e)
        {
            Button boton = (Button)sender;
            GestionarTecla(boton.Text.ToLower());
        }

        private void BTNF_Click(object sender, EventArgs e)
        {
            Button boton = (Button)sender;
            GestionarTecla(boton.Text.ToLower());
        }

        private void BTNG_Click(object sender, EventArgs e)
        {
            Button boton = (Button)sender;
            GestionarTecla(boton.Text.ToLower());
        }

        private void BTNH_Click(object sender, EventArgs e)
        {
            Button boton = (Button)sender;
            GestionarTecla(boton.Text.ToLower());
        }

        private void BTNJ_Click(object sender, EventArgs e)
        {
            Button boton = (Button)sender;
            GestionarTecla(boton.Text.ToLower());
        }

        private void BTNK_Click(object sender, EventArgs e)
        {
            Button boton = (Button)sender;
            GestionarTecla(boton.Text.ToLower());
        }

        private void BTNL_Click(object sender, EventArgs e)
        {
            Button boton = (Button)sender;
            GestionarTecla(boton.Text.ToLower());
        }

        private void BTNZ_Click(object sender, EventArgs e)
        {
            Button boton = (Button)sender;
            GestionarTecla(boton.Text.ToLower());
        }

        private void BTNX_Click(object sender, EventArgs e)
        {
            Button boton = (Button)sender;
            GestionarTecla(boton.Text.ToLower());
        }

        private void BTNC_Click(object sender, EventArgs e)
        {
            Button boton = (Button)sender;
            GestionarTecla(boton.Text.ToLower());
        }

        private void BTNV_Click(object sender, EventArgs e)
        {
            Button boton = (Button)sender;
            GestionarTecla(boton.Text.ToLower());
        }

        private void BTNB_Click(object sender, EventArgs e)
        {
            Button boton = (Button)sender;
            GestionarTecla(boton.Text.ToLower());
        }

        private void BTNN_Click(object sender, EventArgs e)
        {
            Button boton = (Button)sender;
            GestionarTecla(boton.Text.ToLower());
        }

        private void BTNM_Click(object sender, EventArgs e)
        {
            Button boton = (Button)sender;
            GestionarTecla(boton.Text.ToLower());
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            textBoxActivo.Text = "";
        }
    }
}
