using DAL.Controladores.Administrador;
using DAL.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL.Controladores;
using Invenpol_Parqueadero_Motos.Clases;
using DAL;

namespace SERINSI_PC.Formularios.Configuracion
{
    public partial class frmAsignarSede : Form
    {
        int idRelacion_frm;
        public frmAsignarSede()
        {
            InitializeComponent();
        }

        private void frmAsignarSede_Load(object sender, EventArgs e)
        {
            LlenarDG();

            cmbSede.ValueMember = "id";
            cmbSede.DisplayMember = "nombreSede";
            cmbSede.DataSource = ControladorSede.listaCompleta();

            cmbUsuario.ValueMember = "id";
            cmbUsuario.DisplayMember = "nombreusuario";
            cmbUsuario.DataSource = ControladorUsuario.listaCompleta();
        }
        private void LlenarDG()
        {
            dgSedeAsignada.DataSource = controladorSedeAsignada.listaCompleta();
        }

        private async void btnAsignar_Click(object sender, EventArgs e)
        {
            if(cmbSede.Text !=""&&
               cmbUsuario.Text != "")
            {
                SedesAsignadas objSedeAsignada = new SedesAsignadas();
                objSedeAsignada =await controladorSedeAsignada.consultarUsuarioSede(Convert.ToInt32(cmbUsuario.SelectedValue),Convert.ToInt32(cmbSede.SelectedValue));
                if (objSedeAsignada != null)
                {
                    if(objSedeAsignada.idSedeAsignada== VariablesPublicas.IdEmpresaLogueada &&
                        objSedeAsignada.idusuarioAsignado == VariablesPublicas.IdUsuarioLogueado)
                    {
                        return;
                    }
                    if (MessageBox.Show("La asignación que desea crear ya existe."+Environment.NewLine+ Environment.NewLine + "¿Desea eliminar la asignación ?", "Emilinar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        RespuestaCRUD eliminar =await controladorSedeAsignada.Crud(objSedeAsignada, 2);
                        if (eliminar.estado == true)
                        {
                            MessageBox.Show("la asignación fué eliminada correctamente", "Eliminado",MessageBoxButtons.OK,MessageBoxIcon.Information);
                            LlenarDG();
                            return;
                        }
                    }
                }
                else
                {
                    objSedeAsignada = new SedesAsignadas();
                    objSedeAsignada.id = 0;
                    objSedeAsignada.idusuarioAsignado = Convert.ToInt32(cmbUsuario.SelectedValue);
                    objSedeAsignada.idSedeAsignada = Convert.ToInt32(cmbSede.SelectedValue);
                    objSedeAsignada.contadorAsignacion = 1;
                    RespuestaCRUD crear =await controladorSedeAsignada.Crud(objSedeAsignada, 0);
                    if (crear.estado == true)
                    {
                        MessageBox.Show("la asignación fué creada correctamente", "Creada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LlenarDG();
                        return;
                    }
                }
            }
        }

        private void dgSedeAsignada_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgSedeAsignada.RowCount>0 && e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgSedeAsignada.Rows[e.RowIndex];

               
            }
        }
    }
}
