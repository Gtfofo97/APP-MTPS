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
using EN_MTPS;
using BL_MTPS;

namespace AppMTPS_WPF
{
    /// <summary>
    /// Lógica de interacción para frmLogin.xaml
    /// </summary>
    public partial class frmLogin : MetroWindow
    {
        public static string mensje;

        public frmLogin()
        {
            InitializeComponent();
            txtUser.Focus();
        }

        private void Actualizar()
        {
            txtUser.Text = string.Empty;
            pwbClave.Password = string.Empty;
            lbNotice.Content = string.Empty;
        }

        private void btnSubmitLogin_Click(object sender, RoutedEventArgs e)
        {
            Usuario _user = new Usuario();
            UsuarioBL _userBL = new UsuarioBL();
            try
            {
                if (!(txtUser.Text == "" || pwbClave.Password == ""))
                {
                    _user.Username = txtUser.Text;
                    _user.Clave = pwbClave.Password;
                    if (_userBL.Login(_user) == 1)
                    {
                        MainMenu frm2 = new MainMenu();
                        MainMenu.mensje = txtUser.Text; //Envia el user al otro form
                        Actualizar();
                        this.Hide();
                        frm2.ShowDialog();
                    }
                    else
                    {
                        txtUser.Text = string.Empty; //Vacia los campos
                        pwbClave.Password = string.Empty;
                        lbNotice.Content = "Usuario o Contraseña no válido";
                    }
                }
                else
                {
                    lbNotice.Content = "Advertencia, llene todos los campos";
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Ocurrió un error inesperado.", "Error");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ValidationUsersPermission();
            frmNuevoUsuario frmNuevo = new frmNuevoUsuario();
            frmNuevoUsuario.mensje = mensje;
            Actualizar();
            Hide();
            frmNuevo.ShowDialog();
        }

        private void ValidationUsersPermission()
        {
            List<Usuario> lista = new List<Usuario>();
            UsuarioBL _userBL = new UsuarioBL();
            lista = _userBL.ObtenerUsuario();

            if (lista.Count > 0)
            {
                btnUsers.IsEnabled = false;
                //MessageBox.Show("Ya existe un usuario primario, utiliza ese para ingresar.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                btnUsers.IsEnabled = true;
            }
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Actualizar();
            ValidationUsersPermission();
        }
    }
}
