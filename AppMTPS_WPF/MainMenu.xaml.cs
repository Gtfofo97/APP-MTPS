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

using EN_MTPS;
using MahApps.Metro.Controls;

namespace AppMTPS_WPF
{
    /// <summary>
    /// Lógica de interacción para MainMenu.xaml
    /// </summary>
    public partial class MainMenu : MetroWindow
    {
        public static string mensje;
        Empresa empre = new Empresa();

        public MainMenu()
        {
            InitializeComponent();
        }

        private void Logout()
        {
            mensje = null;
            frmNuevaEmpresa.mensje = null;
            frmNuevoUsuario.mensje = null;
            frmMostrarEmpresas.mensje = null;
            frmMostrarUsuarios.mensje = null;
        }

        private void Cerrar()
        {
            frmLogin log = new frmLogin();

            Logout();
            log.Close();
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            lbBienvenido.Content = "Bienvenido " + mensje; //Mensaje de bienvenido al usuario
            DateTime hoy = DateTime.Now;
            lbFechaHora.Content = hoy.ToString("dd/MM/yyyy"); //Muestra la fecha
        }

        private void btnNuevaEmpresa_Click(object sender, RoutedEventArgs e)
        {
            frmNuevaEmpresa frmEmp = new frmNuevaEmpresa();
            frmNuevaEmpresa.mensje = mensje;
            Hide();
            frmEmp.ShowDialog();
        }

        private void btnNuevoUsuario_Click(object sender, RoutedEventArgs e)
        {
            frmNuevoUsuario frmNuevo = new frmNuevoUsuario();
            frmNuevoUsuario.mensje = mensje;
            Hide();
            frmNuevo.ShowDialog();
        }

        private void btnMostrarEmpresas_Click(object sender, RoutedEventArgs e)
        {
            frmMostrarEmpresas frmEmpre = new frmMostrarEmpresas();
            frmMostrarEmpresas.mensje = mensje;
            Hide();
            frmEmpre.ShowDialog();
        }

        private void btnMostrarUsuarios_Click(object sender, RoutedEventArgs e)
        {
            frmMostrarUsuarios frmUsers = new frmMostrarUsuarios();
            frmMostrarUsuarios.mensje = mensje;
            Hide();
            frmUsers.ShowDialog();
        }

        private void Tile1_Click(object sender, RoutedEventArgs e)
        {
            Logout();
            frmLogin log = new frmLogin();
            Close();
            log.Show();
        }

        private void Tile2_Click(object sender, RoutedEventArgs e)
        {
            Cerrar();
        }
    }
}
