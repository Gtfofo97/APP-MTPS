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
    /// Lógica de interacción para frmMostrarEmpresas.xaml
    /// </summary>
    public partial class frmMostrarEmpresas : MetroWindow
    {
        public static string mensje;
        Empresa empre = new Empresa();
        EmpresaBL empreBL = new EmpresaBL();

        public frmMostrarEmpresas()
        {
            InitializeComponent();
        }

        private void Actualizar()
        {
            try
            {
                dgEmpresas.ItemsSource = empreBL.ObtenerEmpresas();
            }
            catch(Exception)
            {
                this.ShowMessageAsync("Hubo un problema con la lista de registros. ", "Error");
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Actualizar();
        }
        
        private void btnRegresar_Click(object sender, RoutedEventArgs e)
        {
            MainMenu frmMain = new MainMenu();
            MainMenu.mensje = mensje;
            Close();
            frmMain.ShowDialog();
        }

        private void dgEmpresas_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                empre = dgEmpresas.SelectedItem as Empresa;

                if(empre == null)
                {
                    MessageBox.Show("No has seleccionado ningun registro.","Advertencia", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    frmDetalles frmDet = new frmDetalles(empre);
                    Hide();
                    frmDet.Show();
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Ocurrió un error.", "Error");
            }
        }

        
        private void txtBusqueda_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (!(txtBusqueda.Text == ""))
                {
                    dgEmpresas.ItemsSource = empreBL.Busqueda(txtBusqueda.Text);
                }
                else
                {
                    Actualizar();
                }
            }
            catch (Exception er)
            {
                this.ShowMessageAsync("Error", "Hubo un problema con la lista de registros. " + er);
            }
        }
    }
}
