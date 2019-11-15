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
    /// Lógica de interacción para frmNuevaEmpresa.xaml
    /// </summary>
    public partial class frmNuevaEmpresa : MetroWindow
    {
        public static string mensje;
        EmpresaBL empreBL = new EmpresaBL();
        Empresa empre = new Empresa();
        DepartamentoBL depaBL = new DepartamentoBL();
        MunicipioBL muniBL = new MunicipioBL();
        Municipio muniBE = new Municipio();
        Departamento depaBE = new Departamento();

        public frmNuevaEmpresa()
        {
            InitializeComponent();
            ocultarErrores();
        }
        public void ocultarErrores()
        {
            error1.Visibility = Visibility.Collapsed;
            error2.Visibility = Visibility.Collapsed;
            error3.Visibility = Visibility.Collapsed;
            error4.Visibility = Visibility.Collapsed;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CargarDepartamentos();
            txtFecha.Text = DateTime.Today.ToString("dd/MM/yyyy");
            txtSucursales.Focus();

            cbEstado.Items.Add("Abierto");
            cbEstado.Items.Add("Cerrado");

            cbTipo.Items.Add("Ins. Pers. Juridica");
            cbTipo.Items.Add("Act. Pers. Juridica");
            cbTipo.Items.Add("Ins. Pers. Natural");
            cbTipo.Items.Add("Act. Pers. Natural");
            
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

        private void Actualizar()
        {
            txtFecha.Text = DateTime.Today.ToString("dd/MM/yyyy");
            txtSucursales.Focus();

            txtSucursales.Text = string.Empty;
            txtNoInscripcion.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtGiro.Text = string.Empty;
            txtCapitalActivo.Text = string.Empty;
            txtCapitalSocial.Text = string.Empty;
            txtNit.Text = string.Empty;
            txtRepresentanteLegal.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtPersonaDesignada.Text = string.Empty;

            cbEstado.Text = string.Empty;
            cbTipo.Text = string.Empty;
            cbDepartamento.ItemsSource = depaBL.Mostrar();
            cbMunicipio.ItemsSource = null;

            txtFecha.Focus();
        }

        private async void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!(txtFecha.Text == "" || txtSucursales.Text == "" || txtNoInscripcion.Text == "" ||
                txtNombre.Text == "" || txtGiro.Text == "" || txtCapitalActivo.Text == "" ||
                txtCapitalSocial.Text == "" || txtNit.Text == "" || txtRepresentanteLegal.Text == "" ||
                txtTelefono.Text == "" || txtDireccion.Text == "" || txtPersonaDesignada.Text == ""))
                {
                    MessageDialogResult resp = await this.ShowMessageAsync("Advertencia!", "¿Está todo correcto?", MessageDialogStyle.AffirmativeAndNegative);
                    if (resp == MessageDialogResult.Affirmative)
                    {
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

                        empre.FechaActualizacion = DateTime.Today.ToString("dd/MM/yyyy");

                        if (empreBL.AgregarEmpresa(empre) > 0)
                        {
                            await this.ShowMessageAsync("Éxito", "Empresa registrada correctamente.");
                            Actualizar();
                            ocultarErrores();
                        }
                        else
                        {
                            await this.ShowMessageAsync("Error", "No se pudo guardar el registro.");
                            Actualizar();
                        }
                    }
                }
                else
                {
                    await this.ShowMessageAsync("Advertencia!", "Todos los campos son requeridos", MessageDialogStyle.Affirmative);
                    Actualizar();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No introduzca texto en campos de tipo numérico", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                // Actualizar();
                error1.Visibility = Visibility;
                error2.Visibility = Visibility;
                error3.Visibility = Visibility;
                error4.Visibility = Visibility;
                txtSucursales.Focus();
            }
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            Actualizar();
            MainMenu frmMain = new MainMenu();
            MainMenu.mensje = mensje;
            frmMain.Show();
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
    }
}
