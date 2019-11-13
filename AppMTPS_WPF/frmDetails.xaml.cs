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
    /// Lógica de interacción para frmDetails.xaml
    /// </summary>
    public partial class frmDetails : MetroWindow
    {
        Usuario user = new Usuario();
        UsuarioBL userBL = new UsuarioBL();

        public frmDetails(Usuario pUser)
        {
            InitializeComponent();

            user = pUser;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                txtId.Text = user.Id.ToString();
                txtNombre.Text = user.Nombre;
                txtUsuario.Text = user.Username;
                txtEmail.Text = user.Email;
                pwbClave.Password = user.Clave;
            }
            catch(Exception)
            {
                MessageBox.Show("Ocurrió un error.", "Error");
            }
        }

        private async void btnActualizar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!(txtNombre.Text == "" || txtUsuario.Text == "" || txtEmail.Text == ""))
                {
                    user.Id = Convert.ToInt64(txtId.Text);
                    user.Nombre = txtNombre.Text;
                    user.Username = txtUsuario.Text;
                    user.Email = txtEmail.Text;
                    user.Clave = pwbClave.Password;

                    if (userBL.ActualizarUsuario(user) > 0)
                    {
                        await this.ShowMessageAsync("Éxito", "Usuario actualizado correctamente.");
                        frmMostrarUsuarios frmMostrar = new frmMostrarUsuarios();
                        Close();
                        frmMostrar.Show();
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
            catch (Exception)
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
                        user.Id = Convert.ToInt64(txtId.Text);

                        if (userBL.EliminarUsuario(user) > 0)
                        {
                            await this.ShowMessageAsync("Éxito", "Usuario eliminado correctamente.");
                            frmMostrarUsuarios frmMostrar = new frmMostrarUsuarios();
                            Close();
                            frmMostrar.Show();
                        }
                        else
                        {
                            await this.ShowMessageAsync("Error", "No se pudo eliminar el registro.");
                        }
                    }
                    else
                    {
                        frmMostrarUsuarios frmMostrar = new frmMostrarUsuarios();
                        Close();
                        frmMostrar.Show();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ocurrió un error inesperado", "Error");
            }
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            frmMostrarUsuarios frmUsers = new frmMostrarUsuarios();
            frmUsers.Show();
            Close();
        }
    }
}
