using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using EN_MTPS;
using BL_MTPS;

namespace AppMTPS_WPF
{
    /// <summary>
    /// Lógica de interacción para frmDetalles.xaml
    /// </summary>
    public partial class frmDetalles : MetroWindow
    {
        EmpresaBL empreBL = new EmpresaBL();
        Empresa empre = new Empresa();
        DepartamentoBL depaBL = new DepartamentoBL();
        MunicipioBL muniBL = new MunicipioBL();
        Municipio muniBE = new Municipio();
        Departamento depaBE = new Departamento();
        public frmDetalles(Empresa pEmpresa)
        {
            InitializeComponent();
            empre = pEmpresa;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cbEstado.Items.Add("Abierto");
            cbEstado.Items.Add("Cerrado");

            cbTipo.Items.Add("Ins. Pers. Juridica");
            cbTipo.Items.Add("Act. Pers. Juridica");
            cbTipo.Items.Add("Ins. Pers. Natural");
            cbTipo.Items.Add("Act. Pers. Natural");

            try
            {
                CargarDepartamentos();

                txtId.Text = empre.Id.ToString();
                txtFecha.Text = empre.Fecha;
                txtSucursales.Text = empre.CantidadSucursales.ToString();
                txtNoInscripcion.Text = empre.NoInscripcion;
                txtNombre.Text = empre.NombreEmpresa;
                txtGiro.Text = empre.Giro;
                txtCapitalActivo.Text = empre.CapitalActivo.ToString();
                txtCapitalSocial.Text = empre.CapitalActivo.ToString();
                txtNit.Text = empre.NIT;
                txtRepresentanteLegal.Text = empre.RepresentanteLegal;
                txtTelefono.Text = empre.Telefono;
                txtDireccion.Text = empre.DireccionCasaMatriz;
                txtPersonaDesignada.Text = empre.PersonaDesignada;

                cbEstado.Text = empre.EstadoEmpresa;
                cbTipo.Text = empre.Tipo;
                cbDepartamento.Text = empre.Departamento;
                cbMunicipio.Text = empre.Municipio;
                txtFechaAct.Text = empre.FechaActualizacion;

                if (txtFechaAct.Text == "")
                {
                    txtFechaAct.Text = DateTime.Today.ToString("dd/MM/yyyy");
                }
                else
                {
                    txtFechaAct.Text = empre.FechaActualizacion;
                }
                
            }
            catch(Exception er)
            {
                MessageBox.Show("Ocurrió un error." + er, "Error");
            }
        }

        public void Actualizar()
        {

        }

        #region ComboBox Dependiente
        public void CargarMuni(int Id)
        {
            cbMunicipio.ItemsSource = muniBL.ObtenerMunicipio(Id);
            cbMunicipio.DisplayMemberPath = "Nombre";
            cbMunicipio.SelectedValue = "Id";
        }
        public void CargarDepartamentos()
        {
            cbDepartamento.ItemsSource = depaBL.Mostrar();
            cbDepartamento.DisplayMemberPath = "Nombre";
            cbDepartamento.SelectedValue = "Id";
        }
        #endregion

        private void btnRegresar_Click(object sender, RoutedEventArgs e)
        {
            frmMostrarEmpresas frmMostrarEmpre = new frmMostrarEmpresas();
            frmMostrarEmpre.Show();
            Close();
        }

        private void cbDepartamento_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Departamento Dep = cbDepartamento.SelectedItem as Departamento;
            if (Dep != null)
            {
                int pDep = Convert.ToInt32(Dep.Id);
                CargarMuni(pDep);
            }
        }

        private async void btnActualizar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!(txtId.Text == "" || txtFecha.Text == "" || txtSucursales.Text == "" || txtNoInscripcion.Text == "" ||
                txtNombre.Text == "" || txtGiro.Text == "" || txtCapitalActivo.Text == "" ||
                txtCapitalSocial.Text == "" || txtNit.Text == "" || txtRepresentanteLegal.Text == "" ||
                txtTelefono.Text == "" || txtDireccion.Text == "" || txtPersonaDesignada.Text == "" || txtFechaAct.Text == ""))
                {
                    empre.Id = Convert.ToInt64(txtId.Text);
                    empre.Fecha = txtFecha.Text;
                    empre.CantidadSucursales = Convert.ToInt32(txtSucursales.Text);
                    empre.NoInscripcion = txtNoInscripcion.Text;
                    empre.NombreEmpresa = txtNombre.Text;
                    empre.Giro = txtGiro.Text;
                    empre.CapitalActivo = Convert.ToDecimal(txtCapitalActivo.Text);
                    empre.CapitalSocial = Convert.ToDecimal(txtCapitalSocial.Text);
                    empre.NIT = txtNit.Text;
                    empre.RepresentanteLegal = txtRepresentanteLegal.Text;
                    empre.Telefono = txtTelefono.Text;
                    empre.DireccionCasaMatriz = txtDireccion.Text;
                    empre.PersonaDesignada = txtPersonaDesignada.Text;
                    empre.EstadoEmpresa = cbEstado.Text;
                    empre.Tipo = cbTipo.Text;
                    empre.Departamento = cbDepartamento.Text;
                    empre.Municipio = cbMunicipio.Text;
                    empre.FechaActualizacion = txtFechaAct.Text;

                    if (empreBL.ActualizarEmpresa(empre) > 0)
                    {
                        await this.ShowMessageAsync("Éxito", "Empresa actualizada correctamente.");
                        frmMostrarEmpresas frmMostrarEmpre = new frmMostrarEmpresas();
                        Close();
                        frmMostrarEmpre.Show();
                    }
                    else
                    {
                        await this.ShowMessageAsync("Error", "No se pudo actualizar el registro.");
                    }
                }
                else
                {
                    await this.ShowMessageAsync("Advertencia!", "Todos los campos son requeridos", MessageDialogStyle.Affirmative);
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Asegurate que todos los campos tengan contenido del mismo tipo de dato", "Error");
            }
        }

        private async void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!(txtId.Text == ""))
                {
                    MessageDialogResult resp = await this.ShowMessageAsync("¡Advertencia!", "¿Está tratando de eliminar un registro de la base de datos, está segur@?", MessageDialogStyle.AffirmativeAndNegative);
                    if (resp == MessageDialogResult.Affirmative)
                    {
                        empre.Id = Convert.ToInt64(txtId.Text);

                        if (empreBL.EliminarEmpresa(empre) > 0)
                        {
                            await this.ShowMessageAsync("Éxito", "Empresa eliminada correctamente.");
                            frmMostrarEmpresas frmMostrarEmpre = new frmMostrarEmpresas();
                            Close();
                            frmMostrarEmpre.Show();
                        }
                        else
                        {
                            await this.ShowMessageAsync("Error", "No se pudo eliminar el registro.");
                        }
                    }
                    else
                    {
                        frmMostrarEmpresas frmMostrarEmpre = new frmMostrarEmpresas();
                        Close();
                        frmMostrarEmpre.Show();
                    }
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Ocurrió un error inesperado", "Error");
            }
        }
    }
}
