using DAL.Controladores;
using DAL.Controladores.Version_Software;
using DAL.Modelo;
using FontAwesome.Sharp;
using Invenpol_Parqueadero_Motos.Clases;
using Invenpol_Parqueadero_Motos.Formularios;
using Invenpol_Parqueadero_Motos.Formularios.Configuracion;
using Invenpol_Parqueadero_Motos.Formularios.Tiemda;
using POS_SERINSIS_PC_2022.Formularios.Configuracion;
using SERINSI_PC.Clases;
using SERINSI_PC.Formularios.Configuracion;
using SERINSI_PC.Formularios.Contabilidad;
using SERINSI_PC.Formularios.Facturas_Software;
using SERINSI_PC.Formularios.Inventario;
using SERINSI_PC.Formularios.Inventario_;
using SERINSI_PC.Formularios.Ventas;
using Sistema_POS.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SERINSI_PC.Formularios
{
    public partial class frmMenuPrincipal : Form
    {
        //Fields
        private IconButton currentBtn;
        private Panel leftBorderBtn;

        public string TituloMenu;
        PermisoSubModulo objPermisoSubModulo = new PermisoSubModulo();
        PermisoModulo objPermisoModulo = new PermisoModulo();
        public frmMenuPrincipal()
        {
            InitializeComponent();
            //Estas lineas  eliminan los parpadeos del formulario o controles en la interfez grafica (pero no en un 100%)
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.DoubleBuffered = true;

            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 39);
            panelMenu.Controls.Add(leftBorderBtn);

         
        }

        //Structs
        private struct RGBColors
        {
            public static Color color1 = Color.FromArgb(85, 166, 221);
            public static Color color2 = Color.FromArgb(249, 118, 176);
            public static Color color3 = Color.FromArgb(253, 138, 114);
            public static Color color4 = Color.FromArgb(95, 77, 221);
            public static Color color5 = Color.FromArgb(249, 88, 155);
            public static Color color6 = Color.FromArgb(24, 161, 251);
        }

        //Methods
        private void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                DisableButton();
                //Button
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.FromArgb(37, 36, 81);
                currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;
                //Left border button
                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();
            }
        }

        private void DisableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.FromArgb(31, 30, 68);
                currentBtn.ForeColor = Color.Gainsboro;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.Gainsboro;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }

        //METODO PARA REDIMENCIONAR/CAMBIAR TAMAÑO A FORMULARIO  TIEMPO DE EJECUCION ----------------------------------------------------------
        private int tolerance = 15;
        private const int WM_NCHITTEST = 132;
        private const int HTBOTTOMRIGHT = 17;
        private Rectangle sizeGripRectangle;
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_NCHITTEST:
                    base.WndProc(ref m);
                    var hitPoint = this.PointToClient(new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16));
                    if (sizeGripRectangle.Contains(hitPoint))
                        m.Result = new IntPtr(HTBOTTOMRIGHT);
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        //METODOS PARA CERRAR,MAXIMIZAR, MINIMIZAR FORMULARIO------------------------------------------------------
        int lx, ly;
        int sw, sh;
        private void ocultarSubMenu()
        {
            if (panelConfiguracion.Visible == true)
                panelConfiguracion.Visible = false;
            if (panelInventario.Visible == true)
                panelInventario.Visible = false;
            if (panelVentas.Visible == true)
                panelVentas.Visible = false;
            if (panelContabilidad.Visible == true)
                panelContabilidad.Visible = false;
        }
        private void mostrarSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                ocultarSubMenu();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }
        private bool VerificarPermisoModulo(int IdModulo)
        {
            objPermisoModulo = ControladorPermisoModulo.consultarIdModuloIdusuario(VariablesPublicas.IdUsuarioLogueado, IdModulo);
            if (objPermisoModulo != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool VerificarPermisoSubModulo(int IdSubModulo)
        {
            objPermisoSubModulo = ControladorPermisoSubModulo.consultarIdSubModuloIdusuario(VariablesPublicas.IdUsuarioLogueado, IdSubModulo);
            if (objPermisoSubModulo != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void btnConfiguracion_Click(object sender, EventArgs e)
        {
            bool Permiso = VerificarPermisoModulo(1);
            if (Permiso == true)
            {
                ampliarMenu();
                mostrarSubMenu(panelConfiguracion);
                ActivateButton(sender, RGBColors.color1);
            }
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            bool Permiso = VerificarPermisoModulo(2);
            if (Permiso == true)
            {
                ampliarMenu();
                mostrarSubMenu(panelInventario);
                ActivateButton(sender, RGBColors.color1);
            }
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            bool Permiso = VerificarPermisoModulo(3);
            if (Permiso == true)
            {
                mostrarSubMenu(panelVentas);
                ActivateButton(sender,RGBColors.color1);
            }
        }

        private void btnContabilidad_Click(object sender, EventArgs e)
        {
            bool Permiso = VerificarPermisoModulo(4);
            if (Permiso == true)
            {
                ampliarMenu();
                mostrarSubMenu(panelContabilidad);
            }
        }
        private void btnParametros_Click(object sender, EventArgs e)
        {
            bool Formulario = VerificarFormulario.FormularioActivo("frmConfiguracionSoftware");
            if (Formulario == true)
            {
                AbrirFormEnPanel(new frmConfiguracionSoftware());
            }
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {

                bool Formulario = VerificarFormulario.FormularioActivo("frmProduct");
                if (Formulario == true)
                {
                    ocultarSubMenu();
                    AbrirFormEnPanel(new frmProduct());
                }
            

        }

        private void btnBodegas_Click(object sender, EventArgs e)
        {
            bool permiso = VerificarPermisoSubModulo(4);
            if (permiso == true)
            {
                bool Formulario = VerificarFormulario.FormularioActivo("frmBodega");
                if (Formulario == true)
                {
                    ocultarSubMenu();
                    AbrirFormEnPanel(new frmBodega());
                }
            }

        }

        private void btnCategorias_Click(object sender, EventArgs e)
        {
            bool permiso = VerificarPermisoSubModulo(5);
            if (permiso == true)
            {
                bool Formulario = VerificarFormulario.FormularioActivo("frmCategorias");
                if (Formulario == true)
                {
                    ocultarSubMenu();
                    AbrirFormEnPanel(new frmCategorias());
                }
            }

        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            bool permiso = VerificarPermisoSubModulo(6);
            if (permiso == true)
            {
                bool Formulario = VerificarFormulario.FormularioActivo("frmProveedor");
                if (Formulario == true)
                {
                    ocultarSubMenu();
                    AbrirFormEnPanel(new frmProveedor());
                }
            }

        }

        private void btnAgotados_Click(object sender, EventArgs e)
        {
            bool permiso = VerificarPermisoSubModulo(7);
            if (permiso == true)
            {
                bool Formulario = VerificarFormulario.FormularioActivo("frmAgotados");
                if (Formulario == true)
                {
                    ClassProcedure.ActualizarEstadoInventario();
                    ocultarSubMenu();
                    AbrirFormEnPanel(new frmAgotados());
                }
            }


        }

        private void btnCompras_Click(object sender, EventArgs e)
        {
            bool permiso = VerificarPermisoSubModulo(8);
            if (permiso == true)
            {
                bool Formulario = VerificarFormulario.FormularioActivo("frmCompras");
                if (Formulario == true)
                {
                    ocultarSubMenu();
                    AbrirFormEnPanel(new frmCompras());
                }
            }

        }

        private void btnKardex_Click(object sender, EventArgs e)
        {
            bool permiso = VerificarPermisoSubModulo(9);
            if (permiso == true)
            {
                bool Formulario = VerificarFormulario.FormularioActivo("frmKardex");
                if (Formulario == true)
                {
                    ocultarSubMenu();
                    AbrirFormEnPanel(new frmKardex());
                }
            }

        }

        private void btnOrdenCompra_Click(object sender, EventArgs e)
        {
            bool permiso = VerificarPermisoSubModulo(10);
            if (permiso == true)
            {
                bool Formulario = VerificarFormulario.FormularioActivo("frmMerma");
                if (Formulario == true)
                {
                    ocultarSubMenu();
                    AbrirFormEnPanel(new frmMerma());
                }
            }

        }

        private void btnEfectivo_Click(object sender, EventArgs e)
        {
            if (VariablesPublicas.IdBaseActiva == 0)
            {
                MessageBox.Show("Para poder continuar debe activar la base de la caja.", "Base Caja", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            bool permiso = VerificarPermisoSubModulo(11);
            if (permiso == true)
            {
                if (VariablesPublicas.TipoCajaRegistradora == 1)
                {
                    bool Formulario = VerificarFormulario.FormularioActivo("frmCajaRegistradora");
                    if (Formulario == true)
                    {
                        //ocultarSubMenu();
                        //frmCajaRegistradora frm = new frmCajaRegistradora();
                        //frm.EfectivoTarjeta = "EFECTIVO";
                        //frm.ContadoCreditoDomicilio = "CONTADO";
                        //frm.FacturaRecibo = "RECIBO";
                        //frm.NumeroCajaActiva = 1;
                        //frm.Show();
                    }
                }
                else
                {
                    bool Formulario = VerificarFormulario.FormularioActivo("frmCajaTouch");
                    if (Formulario == true)
                    {
                        ocultarSubMenu();
                        frmCajaTouch frm = new frmCajaTouch();
                        frm.Show();
                    }
                }
            }
        }

        private void btnPedido_Click(object sender, EventArgs e)
        {
            bool permiso = VerificarPermisoSubModulo(12);
            if (permiso == true)
            {

            }
        }

        private void btnHistorial_Click(object sender, EventArgs e)
        {
            bool permiso = VerificarPermisoSubModulo(13);
            if (permiso == true)
            {
                bool Formulario = VerificarFormulario.FormularioActivo("frmHistorialVentas");
                if (Formulario == true)
                {
                    ocultarSubMenu();
                    frmHistorialVentas frm = new frmHistorialVentas();
                    AbrirFormEnPanel(frm);
                }
            }

        }

        private void btnInforme_Click(object sender, EventArgs e)
        {
            bool permiso = VerificarPermisoSubModulo(14);
            if (permiso == true)
            {
                bool Formulario = VerificarFormulario.FormularioActivo("frmreporteDiario");
                if (Formulario == true)
                {
                    ocultarSubMenu();
                }
            }

        }

        private void btnCuentasPP_Click(object sender, EventArgs e)
        {
            if (VariablesPublicas.IdBaseActiva == 0)
            {
                MessageBox.Show("Para poder continuar debe activar la base de la caja.", "Base Caja", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            bool permiso = VerificarPermisoSubModulo(15);
            if (permiso == true)
            {
                bool Formulario = VerificarFormulario.FormularioActivo("frmCompraProveedor");
                if (Formulario == true)
                {
                    ocultarSubMenu();
                    frmCompraProveedor frm = new frmCompraProveedor();
                    AbrirFormEnPanel(frm);
                }
            }

        }

        private void btnCuentasPC_Click(object sender, EventArgs e)
        {
            if (VariablesPublicas.IdBaseActiva == 0)
            {
                MessageBox.Show("Para poder continuar debe activar la base de la caja.", "Base Caja", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            bool permiso = VerificarPermisoSubModulo(16);
            if (permiso == true)
            {
                bool Formulario = VerificarFormulario.FormularioActivo("frmPagoCreditos");
                if (Formulario == true)
                {
                    ocultarSubMenu();
                    frmPagoCreditos frm = new frmPagoCreditos();
                    AbrirFormEnPanel(frm);
                }
            }

        }

        private void tmHoraFecha_Tick(object sender, EventArgs e)
        {
            txtHora.Text = DateTime.Now.ToShortTimeString();

            txtFecha.Text = DateTime.Now.ToShortDateString();
        }
        Form formularioActivo;
        private void AbrirFormEnPanel(object Formhijo)
        {
            if (formularioActivo != null)
            {
                formularioActivo.Close();
            }
            reducirMunu();
            if (this.panelContenedor.Controls.Count > 0)
                pbLogoCentral.Visible = false;
            Form fh = Formhijo as Form;
            formularioActivo = fh;
            fh.TopLevel = false;
            fh.FormBorderStyle = FormBorderStyle.None;
            fh.Dock = DockStyle.Fill;
            this.panelContenedor.Controls.Add(fh);
            this.panelContenedor.Tag = fh;
            fh.Show();
        }

        private void frmMenuPrincipal_Load(object sender, EventArgs e)
        {
            maximizar();
            panelMenu.Width = 45;
            panelMenu.Width = 187;
            txtTotulo.Text = TituloMenu;


            //en esta parte consultamos si el suario tiene base activa
            BaseCaja baseCaja = new BaseCaja();
            baseCaja = ControladorBaseCaja.consultaBaseActiva("ACTIVA", VariablesPublicas.IdUsuarioLogueado,VariablesPublicas.IdEmpresaLogueada);
            if(baseCaja != null)
            {
                VariablesPublicas.IdBaseActiva = baseCaja.id;
            }
        }

        private void frmMenuPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void pbLogo_Click(object sender, EventArgs e)
        {
            if (formularioActivo != null)
            {
                formularioActivo.Close();
                formularioActivo = null;
                ampliarMenu();
                pbLogoCentral.Visible = true;
                ocultarSubMenu();
            }
        }

        private void frmMenuPrincipal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (formularioActivo != null)
                {
                    formularioActivo.Close();
                    formularioActivo = null;
                    ampliarMenu();
                    pbLogoCentral.Visible = true;
                    ocultarSubMenu();
                }
            }
            if (e.KeyCode == Keys.F1)
            {
                if (VariablesPublicas.IdBaseActiva == 0)
                {
                    MessageBox.Show("Para poder continuar debe activar la base de la caja.", "Base Caja", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    bool Formulario = VerificarFormulario.FormularioActivo("frmCajaTouch");
                    if (Formulario == true)
                    {
                        ocultarSubMenu();
                        frmCajaTouch frm = new frmCajaTouch();
                        frm.Show();
                    }
                }
            }
        }
        private void ampliarMenu()
        {
            //if (panelMenu.Width == 45)
            //{
            //    panelMenu.Width = 187;
            //}
        }
        private void reducirMunu()
        {
            //if (panelMenu.Width == 187)
            //{
            //    panelMenu.Width = 45;
            //}
        }
        private void btnMenu_Click(object sender, EventArgs e)
        {
            //if (panelMenu.Width == 187)
            //{
            //    panelMenu.Width = 45;
            //}
            //else
            //{
            //    panelMenu.Width = 187;
            //}
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            if (formularioActivo == null)
            {
                Application.Exit();
            }
            else
            {
                formularioActivo.Close();
                formularioActivo = null;
                ampliarMenu();
                pbLogoCentral.Visible = true;
                ocultarSubMenu();
            }
        }
        private void maximizar()
        {
            lx = this.Location.X;
            ly = this.Location.Y;
            sw = this.Size.Width;
            sh = this.Size.Height;
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
            btnMaximizar.Visible = false;
            btnRestaurar.Visible = true;
        }
        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            maximizar();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnGastos_Click(object sender, EventArgs e)
        {
            if (VariablesPublicas.IdBaseActiva == 0)
            {
                MessageBox.Show("Para poder continuar debe activar la base de la caja.", "Base Caja", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            bool permiso = VerificarPermisoSubModulo(17);
            if (permiso == true)
            {
                bool Formulario = VerificarFormulario.FormularioActivo("frmGastos");
                if (Formulario == true)
                {
                    ocultarSubMenu();
                    frmGastos frm = new frmGastos();
                    AbrirFormEnPanel(frm);
                }
            }

        }

        private void btnBaseCaja_Click(object sender, EventArgs e)
        {
            bool permiso = VerificarPermisoSubModulo(18);
            if (permiso == true)
            {
                bool Formulario = VerificarFormulario.FormularioActivo("frmBaseCaja");
                if (Formulario == true)
                {
                    ocultarSubMenu();
                    frmBaseCaja frm = new frmBaseCaja();
                    AbrirFormEnPanel(frm);
                }
            }

        }

        private void btnCerrarCaja_Click(object sender, EventArgs e)
        {
            bool permiso = VerificarPermisoSubModulo(19);
            if (permiso == true)
            {
                bool Formulario = VerificarFormulario.FormularioActivo("frmCerrarCaja");
                if (Formulario == true)
                {
                    ocultarSubMenu();
                    frmCerrarCaja frm = new frmCerrarCaja();
                    AbrirFormEnPanel(frm);
                }
            }

        }

        private void btnLibroDiario_Click(object sender, EventArgs e)
        {
            bool permiso = VerificarPermisoSubModulo(20);
            if (permiso == true)
            {
                bool Formulario = VerificarFormulario.FormularioActivo("frmLibroDiario");
                if (Formulario == true)
                {
                    ocultarSubMenu();
                    frmLibroDiario frm = new frmLibroDiario();
                    AbrirFormEnPanel(frm);
                }
            }

        }

        private void btnAyuda_Click(object sender, EventArgs e)
        {
            //mostrarSubMenu(panelContabilidad);
            bool Formulario = VerificarFormulario.FormularioActivo("frmTutoriales");
            if (Formulario == true)
            {
                ocultarSubMenu();
                frmTutoriales frm = new frmTutoriales();
                AbrirFormEnPanel(frm);
            }
        }
        private void pbLogoCentral_DoubleClick(object sender, EventArgs e)
        {
            frmReiniciarDB frm = new Formularios.frmReiniciarDB();
            frm.ShowDialog();
        }

        private void btnSerinsisPC_Click(object sender, EventArgs e)
        {
            bool permiso = VerificarPermisoModulo(5);
            if (permiso == true)
            {
                //mostrarSubMenu(panelContabilidad);
                bool Formulario = VerificarFormulario.FormularioActivo("frmFacturas");
                if (Formulario == true)
                {
                    ocultarSubMenu();
                    frmFacturas frm = new frmFacturas();
                    AbrirFormEnPanel(frm);
                }
            }
        }

        private async void btnActualizar_Click(object sender, EventArgs e)
        {
            //mostrarSubMenu(panelContabilidad);
            ocultarSubMenu();
            RutaActualizacionEquipo objRuta = new RutaActualizacionEquipo();
            objRuta =await ControladorRutas.ConsultarX_NombreEquipo(VariablesPublicas.NombreEquipoLocal);
            if (objRuta != null)
            {
                VariablesPublicas.RutaApllicacionActualizacion = objRuta.ruta_aplicaion_actualizacion;
            }
            Process.Start(VariablesPublicas.RutaApllicacionActualizacion);
            Application.Exit();
        }

        private void btnCerrar_Click_1(object sender, EventArgs e)
        {
            if (formularioActivo == null)
            {
                Application.Exit();
            }
            else
            {
                formularioActivo.Close();
                formularioActivo = null;
                ampliarMenu();
                pbLogoCentral.Visible = true;
                ocultarSubMenu();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            txtFecha.Text = DateTime.Now.ToShortDateString();
            txtHora.Text = DateTime.Now.ToLongTimeString();
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            bool Formulario = VerificarFormulario.FormularioActivo("frmRegistrarUsuario");
            if (Formulario == true)
            {
                AbrirFormEnPanel(new frmRegistrarUsuario());
            }
        }

        private void btnVendedores_Click(object sender, EventArgs e)
        {
            bool Formulario = VerificarFormulario.FormularioActivo("frm_Vendedor");
            if (Formulario == true)
            {
                AbrirFormEnPanel(new frm_Vendedor());
            }
        }

        private void btnHistorialCompras_Click(object sender, EventArgs e)
        {
            bool Formulario = VerificarFormulario.FormularioActivo("frm_H_compras");
            if (Formulario == true)
            {
                AbrirFormEnPanel(new frm_H_compras());
            }
        }

        private void btnContabildad_Click(object sender, EventArgs e)
        {
            bool Permiso = VerificarPermisoModulo(3);
            if (Permiso == true)
            {
                mostrarSubMenu(panelContabilidad);
                ActivateButton(sender, RGBColors.color1);
            }
        }

        private void btnMerma_Click(object sender, EventArgs e)
        {
            bool Formulario = VerificarFormulario.FormularioActivo("frmMerma");
            if (Formulario == true)
            {
                ocultarSubMenu();
                AbrirFormEnPanel(new frmMerma());
            }
        }

        private void btnCaja_Click(object sender, EventArgs e)
        {
            bool Formulario = VerificarFormulario.FormularioActivo("frmCajaTouch");
            if (Formulario == true)
            {
                ocultarSubMenu();
                frmCajaTouch frm = new frmCajaTouch();
                frm.ShowDialog();
                //AbrirFormEnPanel(new frmCajaTouch());
            }
        }

        private void btnHVentas_Click(object sender, EventArgs e)
        {
            bool Formulario = VerificarFormulario.FormularioActivo("frmHistorialVentas");
            if (Formulario == true)
            {
                ocultarSubMenu();
                AbrirFormEnPanel(new frmHistorialVentas());
            }
        }

        private void btnPedidos_Click(object sender, EventArgs e)
        {
            bool Formulario = VerificarFormulario.FormularioActivo("frm_pedidos");
            if (Formulario == true)
            {
                ocultarSubMenu();
                AbrirFormEnPanel(new frm_pedidos());
            }
        }

        private void btnInformes_Click(object sender, EventArgs e)
        {
            bool Formulario = VerificarFormulario.FormularioActivo("frmreporteDiario");
            if (Formulario == true)
            {
                ocultarSubMenu();
                AbrirFormEnPanel(new frmreporteDiario());
            }
        }

        private void btnAperturarCaja_Click(object sender, EventArgs e)
        {
            bool Formulario = VerificarFormulario.FormularioActivo("frmBaseCaja");
            if (Formulario == true)
            {
                ocultarSubMenu();
                AbrirFormEnPanel(new frmBaseCaja());
            }
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            bool Formulario = VerificarFormulario.FormularioActivo("frmClienteTienda");
            if (Formulario == true)
            {
                ocultarSubMenu();
                AbrirFormEnPanel(new frmClienteTienda());
            }
        }

        private void btnRutero_Click(object sender, EventArgs e)
        {
            bool Formulario = VerificarFormulario.FormularioActivo("frmRutero");
            if (Formulario == true)
            {
                AbrirFormEnPanel(new frmRutero());
            }
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            this.Size = new Size(sw, sh);
            this.Location = new Point(lx, ly);
            btnRestaurar.Visible = false;
            btnMaximizar.Visible = true;
        }

        private void panelTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

    }
}
