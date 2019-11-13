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
    /// Lógica de interacción para frmMostrarUsuarios.xaml
    /// </summary>
    public partial class frmMostrarUsuarios : MetroWindow
    {
        public static string mensje;
        Usuario user = new Usuario();
        UsuarioBL userBL = new UsuarioBL();

        public frmMostrarUsuarios()
        {
            InitializeComponent();
        }

        private void Actualizar()
        {
            try
            {
                dgUsuarios.ItemsSource = userBL.ObtenerUsuario();
            }
            catch (Exception er)
            {
                this.ShowMessageAsync("Error", "Hubo un problema con la lista de registros. " + er);
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

        
        private void txtBusqueda_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (!(txtBusqueda.Text == ""))
                {
                    dgUsuarios.ItemsSource = userBL.Busqueda(txtBusqueda.Text);
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

        private void dgUsuarios_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                user = dgUsuarios.SelectedItem as Usuario;

                if (user == null)
                {
                    MessageBox.Show("No has seleccionado ningun registro.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    frmDetails frmDet = new frmDetails(user);
                    Hide();
                    frmDet.Show();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ocurrió un error.", "Error");
            }
        }
    }
}
