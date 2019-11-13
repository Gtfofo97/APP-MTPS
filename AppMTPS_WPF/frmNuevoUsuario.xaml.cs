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
    /// Lógica de interacción para frmNuevoUsuario.xaml
    /// </summary>
    public partial class frmNuevoUsuario : MetroWindow
    {
        public static string mensje;
        public frmNuevoUsuario()
        {
            InitializeComponent();
            txtNombre.Focus();
        }
        private void Actualizar()
        {
            txtNombre.Text = string.Empty;
            txtUsuario.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtClave.Text = string.Empty;

            txtNombre.Focus();
        }

        private async void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            Usuario _user = new Usuario();
            UsuarioBL _userBL = new UsuarioBL();

            try
            {
                if (!(txtNombre.Text == "" && txtUsuario.Text == "" && txtEmail.Text == "" && txtClave.Text == ""))
                {
                    _user.Nombre = txtNombre.Text;
                    _user.Email = txtEmail.Text;
                    _user.Username = txtUsuario.Text;
                    _user.Clave = txtClave.Text;

                    if (_userBL.AgregarUsuario(_user) == 1)
                    {
                        await this.ShowMessageAsync("Éxito", "Se guardó el usuario exitosamente.", MessageDialogStyle.Affirmative);
                        Actualizar();
                        if (mensje != null)
                        {
                            MainMenu main = new MainMenu();
                            MainMenu.mensje = mensje;
                            main.Show();
                            Close();
                        }
                        else
                        {
                            frmLogin log = new frmLogin();
                            log.Show();
                            Close();
                        }

                    }
                    else
                    {
                        await this.ShowMessageAsync("Error", "No se pudo guardar el usuario.");
                        Actualizar();
                    }
                }
                else
                {
                    await this.ShowMessageAsync("Advertencia!", "Todos los campos son requeridos", MessageDialogStyle.Affirmative);
                    Actualizar();
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Ocurrió un error inesperado.","Error");
            }
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            Actualizar();
            if (mensje == null)
            {
                frmLogin log = new frmLogin();
                log.Show();
                Close();
            }
            else
            {
                MainMenu frmMain = new MainMenu();
                MainMenu.mensje = mensje;
                Close();
                frmMain.ShowDialog();
            }
        }
    }
}
