using DAL.Controladores;
using DAL.Modelo;
using Invenpol_Parqueadero_Motos.Clases;
using SERINSI_PC.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SERINSI_PC.Formularios.Inventario_
{
    public partial class frm_H_compras : Form
    {
        int IdCompra_frm = 0;
        public frm_H_compras()
        {
            InitializeComponent();
        }
        private void CargarDG()
        {
            dgCompras.DataSource = ControladorCompra.ListaCompleta_Sede(VariablesPublicas.IdEmpresaLogueada,2);
        }
        private void frm_H_compras_Load(object sender, EventArgs e)
        {
            CargarDG();
        }
        private void SeleccionarCompra()
        {
            if (dgCompras.RowCount > 0 && dgCompras.CurrentRow.Index >= 0)
            {
                DataGridViewRow fila = dgCompras.Rows[dgCompras.CurrentRow.Index];
                IdCompra_frm = Convert.ToInt32(fila.Cells["idV"].Value);
            }
        }

        private void btnArchivo_Click(object sender, EventArgs e)
        {
            frmArchivosCompras frm = new frmArchivosCompras();
            AddOwnedForm(frm);
            frm.IdCompra_frm = IdCompra_frm;
            frm.ShowDialog();
        }

        private void btnDetalle_Click(object sender, EventArgs e)
        {
            try
            {
                SeleccionarCompra();
                frm_DetalleCompras frm = new frm_DetalleCompras();
                AddOwnedForm(frm);
                frm.dgDetalleCompra.DataSource = ControladorDetalleCompra.Filtrar_IdCompra(IdCompra_frm);
                frm.ShowDialog();
            }
            catch(Exception ex)
            {
                string error = ex.Message;
            }
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                SeleccionarCompra();
                //prosedemos a eliminar el detalle
                List<DetalleCompra> detalleCompra = new List<DetalleCompra>();
                detalleCompra =await ControladorDetalleCompra.Lista_XidCompra(IdCompra_frm);
                if (detalleCompra != null)
                {
                    bool deleteDetalle =await ControladorDetalleCompra.EliminarLista(IdCompra_frm);
                    if (deleteDetalle == true)
                    {
                        //ahora eliminamos la compra
                        Compras compras = new Compras();
                        EliminarPagos(IdCompra_frm);
                        compras =await ControladorCompra.Consultar_Id(IdCompra_frm);
                        if (compras != null)
                        {
                            bool deleteCompra =await ControladorCompra.GuardarEditarEliminarCompra(compras,2);
                            if (deleteCompra == true)
                            {
                                MessageBox.Show("Compra eliminada correctamente.","Eliminado",MessageBoxButtons.OK,MessageBoxIcon.Information);
                                CargarDG();
                            }
                        }
                    }
                    else
                    {
                        //ahora eliminamos la compra
                        Compras compras = new Compras();
                        EliminarPagos(IdCompra_frm);
                        compras =await ControladorCompra.Consultar_Id(IdCompra_frm);
                        if (compras != null)
                        {
                            bool deleteCompra =await ControladorCompra.GuardarEditarEliminarCompra(compras, 2);
                            if (deleteCompra == true)
                            {
                                MessageBox.Show("Compra eliminada correctamente.", "Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                CargarDG();
                            }
                        }
                    }
                }
            }
            catch( Exception ex)
            {
                string error = ex.Message;
            }
        }

        private void EliminarPagos(int IdCompra)
        {
            try
            {
                using (SistemaPOSEntities cn =new SistemaPOSEntities())
                {
                    cn.EliminarPagoCompras(IdCompra);
                    cn.EliminarArchivoComra(IdCompra);
                }
            }
            catch(Exception ex)
            {
                string error = ex.Message;
            }
        }

        string Ruta;
        string NombreArchivo;
        string Extencion;
        Guid guidArchivo_frm;
        byte[] Arreglo;
        string ArchivoTExto;
        private async void button1_Click(object sender, EventArgs e)
        {
            SeleccionarCompra();
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
                    guidArchivo_frm = Guid.NewGuid();
                }
                //convertimos nuestro archivo en byte[]
                Arreglo = File.ReadAllBytes(Ruta);
                //convertimos nuestro arreglo a texto
                ArchivoTExto = System.Text.Encoding.UTF8.GetString(Arreglo);
                //en esta parte enviamos a guardar el archivo a la carpeta de las facturas de compra
                //File.WriteAllBytes(VariablesPublicas.RutaImagenes+ "\\FacturasCompras\\" + guidArchivo_frm+Extencion,Arreglo);
                int Cargar = ClassGuardarImagen.guardarImagenDriver(Arreglo, VariablesPublicas.RutaImagenes, "\\FacturasCompras\\", guidArchivo_frm + Extencion);
                int CargarServidor = ClassArchivos.SubirArchivo(ClassRutas.ServidorImagenes, ClassRutas.UsuarioServidor, ClassRutas.ClaveServidor, VariablesPublicas.RutaImagenes + "\\FacturasCompras\\" + guidArchivo_frm + Extencion, Convert.ToString(guidArchivo_frm), Extencion, "FacturasCompras");

                if (Cargar == 1)
                {
                    //en esta parte insertamos el registro del archivo a la bae de datos 
                    ArchivoCompras archivoCompras = new ArchivoCompras();
                    archivoCompras =await controladorArchivoCompra.ConsultarGuidArchivo(guidArchivo_frm);
                    if (archivoCompras != null)
                    {
                        MessageBox.Show("El archivo ya existe.", "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        archivoCompras = new ArchivoCompras();
                        archivoCompras.id = 0;
                        archivoCompras.idCompra = IdCompra_frm;
                        archivoCompras.guidArchivo = guidArchivo_frm;
                        archivoCompras.extencion = Extencion;
                        bool insert =await controladorArchivoCompra.CrearEditarEliminar(archivoCompras, 0);
                        if (insert == true)
                        {
                            MessageBox.Show("El archivo fue cargado correctamente.", "¡OK!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("El archivo no se puedo cargar.", "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
        }
    }
}
