using DAL;
using DAL.Controladores;
using DAL.Modelo;
using Invenpol_Parqueadero_Motos.Clases;
using SERINSI_PC.Clases;
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

namespace SERINSI_PC.Formularios.Configuracion
{
    public partial class frmPermisos : Form
    {
        bool CargandoModulo = false;
        public int IdusuarioGestion = 0;
        public frmPermisos()
        {
            InitializeComponent();
        }

        private void flechaConfiguracion_Click(object sender, EventArgs e)
        {
            if (cbConfiguracion.Checked == true)
            {
                AbrirSubPanel("panelConfiguracion");
            }
        }

        private void flechaInventario_Click(object sender, EventArgs e)
        {
            if (cbInventario.Checked == true)
            {
                AbrirSubPanel("panelInventario");
            }
        }

        private void flechaVentas_Click(object sender, EventArgs e)
        {
            if (cbVentas.Checked == true)
            {
                AbrirSubPanel("panelVentas");
            }
        }

        private void flechaContabilidad_Click(object sender, EventArgs e)
        {
            if (cbContabilidad.Checked == true)
            {
                AbrirSubPanel("panelContabilidad");
            }
        }
        private void AbrirSubPanel(string panelAbrir)
        {

            if (panelAbrir == "panelConfiguracion")
            {
                if (panelConfiguracion.Visible == true)
                {
                    CerrarPanel();
                }
                else
                {
                    CerrarPanel();
                    panelConfiguracion.Visible = true;
                }

            }
            if (panelAbrir == "panelInventario")
            {
                if (panelInventario.Visible == true)
                {
                    CerrarPanel();
                }
                else
                {
                    CerrarPanel();
                    panelInventario.Visible = true;
                }

            }
            if (panelAbrir == "panelVentas")
            {
                if (panelVentas.Visible == true)
                {
                    CerrarPanel();
                }
                else
                {
                    CerrarPanel();
                    panelVentas.Visible = true;
                }

            }
            if (panelAbrir == "panelContabilidad")
            {
                if (panelContabilidad.Visible == true)
                {
                    CerrarPanel();
                }
                else
                {
                    CerrarPanel();
                    panelContabilidad.Visible = true;
                }
            }
            if (panelAbrir == "panelOrdenServicio")
            {
                if (panelOrdenServicio.Visible == true)
                {
                    CerrarPanel();
                }
                else
                {
                    CerrarPanel();
                    panelOrdenServicio.Visible = true;
                }
            }
        }
        private void CerrarPanel()
        {
            panelConfiguracion.Visible = false;
            panelInventario.Visible = false;
            panelVentas.Visible = false;
            panelContabilidad.Visible = false;
            panelOrdenServicio.Visible = false;
        }
        private void GestionarSubModulo(int IdSubModulo, int Boton, int IdUsuario)
        {
            if (CargandoModulo == true)
            {
                return;
            }
            try
            {
                ConexionSQL.AbrirConexion();
                SqlCommand cmd = ConexionSQL.connection.CreateCommand();
                if (Boton == 0)
                {
                    cmd.CommandText = "insert  into PermisoSubModulo (idUsuario,idSubModulo)values(" + IdUsuario + "," + IdSubModulo + ") ";
                }
                else if (Boton == 2)
                {
                    cmd.CommandText = "delete PermisoSubModulo where idUsuario = " + IdUsuario + " and idSubModulo = " + IdSubModulo;
                }
                cmd.ExecuteNonQuery();
                ConexionSQL.CerrarConexion();
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
        }
        private void GestionarModulo(int IdModulo,int Boton,int IdUsuario)
        {
            if (CargandoModulo == true) return;
            try
            {
                ConexionSQL.AbrirConexion();
                SqlCommand cmd = ConexionSQL.connection.CreateCommand();
                if (Boton == 0)
                {
                    cmd.CommandText = "insert  into PermisoModulo (idUsuario,idModulo)values(" + IdUsuario + "," + IdModulo + ") ";
                }
                else if (Boton == 2)
                {
                    cmd.CommandText = "delete PermisoModulo where idUsuario = " + IdUsuario + " and idModulo = " + IdModulo;
                }
                cmd.ExecuteNonQuery();
                ConexionSQL.CerrarConexion();
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
        }
        private void frmPermisos_Load(object sender, EventArgs e)
        {
            ActualizarPermisos();
        }
        private void ActualizarPermisos()
        {
            CargandoModulo = true;
            MostarModulos();
            MostarSubModulos();
            CargandoModulo = false;
        }
        private async Task MostarSubModulos()
        {
            List<PermisoSubModulo> objPermisoSubModulo = new List<PermisoSubModulo>();
            objPermisoSubModulo =await ControladorPermisoSubModulo.consultarIdusuario(IdusuarioGestion);
            if (objPermisoSubModulo != null)
            {
                foreach(var rows in objPermisoSubModulo)
                {
                    if((int)rows.idSubModulo == 1)
                    {
                        cbUsuario.Checked = true;
                    }
                    else
                    if ((int)rows.idSubModulo == 2)
                    {
                        cbParametros.Checked = true;
                    }
                    else
                    if ((int)rows.idSubModulo == 3)
                    {
                        cbProductos.Checked = true;
                    }
                    else
                    if ((int)rows.idSubModulo == 4)
                    {
                        cbBodegas.Checked = true;
                    }
                    else
                    if ((int)rows.idSubModulo == 5)
                    {
                        cbCategorias.Checked = true;
                    }
                    else
                    if ((int)rows.idSubModulo == 6)
                    {
                        cbProveedores.Checked = true;
                    }
                    else
                    if ((int)rows.idSubModulo == 7)
                    {
                        cbAgotados.Checked = true;
                    }
                    else
                    if ((int)rows.idSubModulo == 8)
                    {
                        cbCompras.Checked = true;
                    }
                    else
                    if ((int)rows.idSubModulo == 9)
                    {
                        cbKardex.Checked = true;
                    }
                    else
                    if ((int)rows.idSubModulo == 10)
                    {
                        cbMerma.Checked = true;
                    }
                    else
                    if ((int)rows.idSubModulo == 11)
                    {
                        cbCaja.Checked = true;
                    }
                    else
                    if ((int)rows.idSubModulo == 12)
                    {
                        cbPedido.Checked = true;
                    }
                    else
                    if ((int)rows.idSubModulo == 13)
                    {
                        //cb.Checked = true;
                    }
                    else
                    if ((int)rows.idSubModulo == 14)
                    {
                        cbInforme.Checked = true;
                    }
                    else
                    if ((int)rows.idSubModulo == 15)
                    {
                        cbCuentasPP.Checked = true;
                    }
                    else
                    if ((int)rows.idSubModulo == 16)
                    {
                        cbCuentasPC.Checked = true;
                    }
                    else
                    if ((int)   rows.idSubModulo == 17)
                    {
                        cbGastos.Checked = true;
                    }
                    else
                    if ((int)rows.idSubModulo == 18)
                    {
                        cbBaseCaja.Checked = true;
                    }
                    else
                    if ((int)rows.idSubModulo == 19)
                    {
                        cbCierreCaja.Checked = true;
                    }
                    else
                    if ((int)rows.idSubModulo == 20)
                    {
                        cbLibroDiario.Checked = true;
                    }
                    else
                    if ((int)rows.idSubModulo == 21)
                    {
                        cbOrdenServicio.Checked = true;
                    }
                    else
                    if ((int)rows.idSubModulo    == 22)
                    {
                        cbTipoServicio.Checked = true;
                    }
                    else
                    if ((int)rows.idSubModulo == 23)
                    {
                        cbArticulo.Checked = true;
                    }
                }
            }
        }
        private async Task MostarModulos()           
        {
            List<PermisoModulo> objPermisoModulo = new List<PermisoModulo>();
            objPermisoModulo =await ControladorPermisoModulo.consultarIdUsuario(IdusuarioGestion);
            if (objPermisoModulo != null)
            {
                foreach(var rows in objPermisoModulo)
                {
                    if ((int)rows.idModulo == 1)
                    {
                        cbConfiguracion.Checked = true;
                    }
                    else
                    if ((int)rows.idModulo == 2)
                    {
                        cbInventario.Checked = true;
                    }
                    else
                    if ((int)rows.idModulo == 3)
                    {
                        cbVentas.Checked = true;
                    }
                    else
                    if ((int)rows.idModulo == 4)
                    {
                        cbContabilidad.Checked = true;
                    }
                    else
                    if ((int)rows.idModulo == 5)
                    {
                        cbSerinsisPC.Checked = true;
                    }
                    else
                    if ((int)rows.idModulo == 6)
                    {
                        cbFabrica.Checked = true;
                    }
                    else
                    if ((int)rows.idModulo == 7)
                    {
                        cbOrdenServicio.Checked = true;
                    }
                }
            }

        }
        private void cbConfiguracion_CheckedChanged(object sender, EventArgs e)
        {
            if (cbConfiguracion.Checked == true)
            {
                GestionarModulo(1,0,IdusuarioGestion);
            }
            else
            {
                GestionarModulo(1, 2, IdusuarioGestion);
            }
        }

        private void cbInventario_CheckedChanged(object sender, EventArgs e)
        {
            if (cbInventario.Checked == true)
            {
                GestionarModulo(2, 0, IdusuarioGestion);
            }
            else
            {
                GestionarModulo(2, 2, IdusuarioGestion);
            }
        }

        private void cbVentas_CheckedChanged(object sender, EventArgs e)
        {
            if (cbVentas.Checked == true)
            {
                GestionarModulo(3, 0, IdusuarioGestion);
            }
            else
            {
                GestionarModulo(3, 2, IdusuarioGestion);
            }
        }

        private void cbContabilidad_CheckedChanged(object sender, EventArgs e)
        {
            if (cbContabilidad.Checked == true)
            {
                GestionarModulo(4, 0, IdusuarioGestion);
            }
            else
            {
                GestionarModulo(4, 2, IdusuarioGestion);
            }
        }

        private void cbUsuario_CheckedChanged(object sender, EventArgs e)
        {
            if (cbUsuario.Checked == true)
            {
                GestionarSubModulo(1, 0, IdusuarioGestion);
            }
            else
            {
                GestionarSubModulo(1, 2, IdusuarioGestion);
            }
        }

        private void cbParametros_CheckedChanged(object sender, EventArgs e)
        {
            if (cbParametros.Checked == false)
            {
                GestionarSubModulo(2, 2, IdusuarioGestion);
            }
            else
            {
                GestionarSubModulo(2, 0, IdusuarioGestion);
            }
        }

        private void cbProductos_CheckedChanged(object sender, EventArgs e)
        {
            if (cbProductos.Checked == false)
            {
                GestionarSubModulo(3, 2, IdusuarioGestion);
            }
            else
            {
                GestionarSubModulo(3, 0, IdusuarioGestion);
            }
        }

        private void cbBodegas_CheckedChanged(object sender, EventArgs e)
        {
            if (cbBodegas.Checked == false)
            {
                GestionarSubModulo(4, 2, IdusuarioGestion);
            }
            else
            {
                GestionarSubModulo(4, 0, IdusuarioGestion);
            }
        }

        private void cbCategorias_CheckedChanged(object sender, EventArgs e)
        {
            if (cbCategorias.Checked == false)
            {
                GestionarSubModulo(5, 2, IdusuarioGestion);
            }
            else
            {
                GestionarSubModulo(5, 0, IdusuarioGestion);
            }
        }

        private void cbProveedores_CheckedChanged(object sender, EventArgs e)
        {
            if (cbProveedores.Checked == false)
            {
                GestionarSubModulo(6, 2, IdusuarioGestion);
            }
            else
            {
                GestionarSubModulo(6, 0, IdusuarioGestion);
            }
        }

        private void cbAgotados_CheckedChanged(object sender, EventArgs e)
        {
            if (cbAgotados.Checked == false)
            {
                GestionarSubModulo(7, 2, IdusuarioGestion);
            }
            else
            {
                GestionarSubModulo(7, 0, IdusuarioGestion);
            }
        }

        private void cbCompras_CheckedChanged(object sender, EventArgs e)
        {
            if (cbCompras.Checked == false)
            {
                GestionarSubModulo(8, 2, IdusuarioGestion);
            }
            else
            {
                GestionarSubModulo(8, 0, IdusuarioGestion);
            }
        }

        private void cbKardex_CheckedChanged(object sender, EventArgs e)
        {
            if (cbKardex.Checked == false)
            {
                GestionarSubModulo(9, 2, IdusuarioGestion);
            }
            else
            {
                GestionarSubModulo(9, 0, IdusuarioGestion);
            }
        }

        private void cbMerma_CheckedChanged(object sender, EventArgs e)
        {
            if (cbMerma.Checked == false)
            {
                GestionarSubModulo(10, 2, IdusuarioGestion);
            }
            else
            {
                GestionarSubModulo(10, 0, IdusuarioGestion);
            }
        }

        private void cbCaja_CheckedChanged(object sender, EventArgs e)
        {
            if (cbCaja.Checked == false)
            {
                GestionarSubModulo(11, 2, IdusuarioGestion);
            }
            else
            {
                GestionarSubModulo(11, 0, IdusuarioGestion);
            }
        }

        private void cbPedido_CheckedChanged(object sender, EventArgs e)
        {
            if (cbPedido.Checked == false)
            {
                GestionarSubModulo(12, 2, IdusuarioGestion);
            }
            else
            {
                GestionarSubModulo(12, 0, IdusuarioGestion);
            }
        }

        private void cbHVentas_CheckedChanged(object sender, EventArgs e)
        {
            if (cbHVentas.Checked == false)
            {
                GestionarSubModulo(13, 2, IdusuarioGestion);
            }
            else
            {
                GestionarSubModulo(13, 0, IdusuarioGestion);
            }
        }

        private void cbInforme_CheckedChanged(object sender, EventArgs e)
        {
            if (cbInforme.Checked == false)
            {
                GestionarSubModulo(14, 2, IdusuarioGestion);
            }
            else
            {
                GestionarSubModulo(14, 0, IdusuarioGestion);
            }
        }

        private void cbCuentasPP_CheckedChanged(object sender, EventArgs e)
        {
            if (cbCuentasPP.Checked == false)
            {
                GestionarSubModulo(15, 2, IdusuarioGestion);
            }
            else
            {
                GestionarSubModulo(15, 0, IdusuarioGestion);
            }
        }

        private void cbCuentasPC_CheckedChanged(object sender, EventArgs e)
        {
            if (cbCuentasPC.Checked == false)
            {
                GestionarSubModulo(16, 2, IdusuarioGestion);
            }
            else
            {
                GestionarSubModulo(16, 0, IdusuarioGestion);
            }
        }

        private void cbGastos_CheckedChanged(object sender, EventArgs e)
        {
            if (cbGastos.Checked == false)
            {
                GestionarSubModulo(17, 2, IdusuarioGestion);
            }
            else
            {
                GestionarSubModulo(17, 0, IdusuarioGestion);
            }
        }

        private void cbBaseCaja_CheckedChanged(object sender, EventArgs e)
        {
            if (cbBaseCaja.Checked == false)
            {
                GestionarSubModulo(18, 2, IdusuarioGestion);
            }
            else
            {
                GestionarSubModulo(18, 0, IdusuarioGestion);
            }
        }

        private void cbCierreCaja_CheckedChanged(object sender, EventArgs e)
        {
            if (cbCierreCaja.Checked == false)
            {
                GestionarSubModulo(19, 2, IdusuarioGestion);
            }
            else
            {
                GestionarSubModulo(19, 0, IdusuarioGestion);
            }
        }

        private void cbLibroDiario_CheckedChanged(object sender, EventArgs e)
        {
            if (cbLibroDiario.Checked == false)
            {
                GestionarSubModulo(20, 2, IdusuarioGestion);
            }
            else
            {
                GestionarSubModulo(20, 0, IdusuarioGestion);
            }
        }

        private void FlechaSerinsisPC_Click(object sender, EventArgs e)
        {
            if (cbSerinsisPC.Checked == true)
            {
                AbrirSubPanel("");
            }
        }

        private void cbSerinsisPC_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSerinsisPC.Checked == true)
            {
                GestionarModulo(5, 0, IdusuarioGestion);
            }
            else
            {
                GestionarModulo(5, 2, IdusuarioGestion);
            }
        }

        private void cbFabrica_CheckedChanged(object sender, EventArgs e)
        {
            if (cbFabrica.Checked == true)
            {
                GestionarModulo(6, 0, IdusuarioGestion);
            }
            else
            {
                GestionarModulo(6, 2, IdusuarioGestion);
            }
        }

        private void FlechaFabrica_Click(object sender, EventArgs e)
        {
            if (cbFabrica.Checked == true)
            {
                AbrirSubPanel("");
            }
        }

        private void FlechaOrdenServicio_Click(object sender, EventArgs e)
        {
            if (cbOrdenServicio.Checked == true)
            {
                AbrirSubPanel("panelOrdenServicio");
            }
        }

        private void cbOrdenServicio_CheckedChanged(object sender, EventArgs e)
        {
            if (cbOrdenServicio.Checked == true)
            {
                GestionarModulo(7, 0, IdusuarioGestion);
            }
            else
            {
                GestionarModulo(7, 2, IdusuarioGestion);
            }
        }

        private void cbSubOrdenServicio_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSubOrdenServicio.Checked == false)
            {
                GestionarSubModulo(21, 2, IdusuarioGestion);
            }
            else
            {
                GestionarSubModulo(21, 0, IdusuarioGestion);
            }
        }

        private void cbTipoServicio_CheckedChanged(object sender, EventArgs e)
        {
            if (cbTipoServicio.Checked == false)
            {
                GestionarSubModulo(22, 2, IdusuarioGestion);
            }
            else
            {
                GestionarSubModulo(22, 0, IdusuarioGestion);
            }
        }

        private void cbArticulo_CheckedChanged(object sender, EventArgs e)
        {
            if (cbArticulo.Checked == false)
            {
                GestionarSubModulo(23, 2, IdusuarioGestion);
            }
            else
            {
                GestionarSubModulo(23, 0, IdusuarioGestion);
            }
        }

        private void cbTraslados_CheckedChanged(object sender, EventArgs e)
        {
            if (cbTraslados.Checked == false)
            {
                GestionarSubModulo(24, 2, IdusuarioGestion);
            }
            else
            {
                GestionarSubModulo(24, 0, IdusuarioGestion);
            }
        }

        private void cbAsignarSede_CheckedChanged(object sender, EventArgs e)
        {
            if (cbAsignarSede.Checked == false)
            {
                GestionarSubModulo(25, 2, IdusuarioGestion);
            }
            else
            {
                GestionarSubModulo(25, 0, IdusuarioGestion);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
