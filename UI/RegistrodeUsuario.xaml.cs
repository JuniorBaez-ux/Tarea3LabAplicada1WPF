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
using Tarea3LabAplicada1.BLL;
using Tarea3LabAplicada1.Entidades;

namespace Tarea3LabAplicada1.UI
{
    /// <summary>
    /// Interaction logic for RegistrodeUsuario.xaml
    /// </summary>
    public partial class RegistrodeUsuario : Window
    {
        Usuarios usuario = new Usuarios();

        public RegistrodeUsuario()
        {
            InitializeComponent();
        }

        private void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private bool ExisteEnLaBaseDeDatos()
        {
            Usuarios usuarios = UsuariosBLL.Buscar(Utilidades.ToInt(IDTextbox.Text));

            return (usuarios != null);
        }


        private void BuscarButton_Click(object sender, EventArgs e)
        {
            int id;
            id = Utilidades.ToInt(IDTextbox.Text.ToString());
            usuario = UsuariosBLL.Buscar(id);

            Limpiar();
            if (usuario != null)
            {
                MessageBox.Show("Persona Encotrada");
                LlenarCampos(usuario);
            }
            else
            {
                MessageBox.Show("Persona no Encontrada");
            }
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            Usuarios usuario;
            bool paso = false;
            if (!Validar())
            {
                return;
            }
            usuario = LlenarClase();
            paso = UsuariosBLL.Guardar(usuario);

            if (paso)
            {
                Limpiar();
                MessageBox.Show("Usuario guardado correctamente", "Guardado", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                Limpiar();
                MessageBox.Show("Usuario modificado correctamente", "Guardado", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void EliminarButton_Click(object sender, EventArgs e)
        {
            int id;
            int.TryParse(IDTextbox.Text, out id);
            Limpiar();
            if (UsuariosBLL.Eliminar(id))
                MessageBox.Show("Usuario eliminado correctamente", "Proceso exitoso", MessageBoxButton.OK, MessageBoxImage.Information);
            else
                MessageBox.Show( "ID no existente");
        }
        private void Limpiar()
        {
            IDTextbox.Clear();
            AliasTextbox.Clear();
            NombreTextbox.Clear();
            EmailTextBox.Clear();
            FechaIngresoDatePicker.SelectedDate = DateTime.Now;
            ActivoChecBox.IsChecked = false;
            RolComboBox.Text = "";
        }

        private void LlenarCampos(Usuarios usuarios)
        {
            IDTextbox.Text = usuarios.UsuarioID.ToString();
            NombreTextbox.Text = usuarios.Nombres;
            EmailTextBox.Text = usuarios.Email;
            AliasTextbox.Text = usuarios.Alias;
            if (usuarios.RolID == 1)
            {
                RolComboBox.Text = "Administrador";
            }
            if (usuarios.RolID == 2)
            {
                RolComboBox.Text = "Ingeniero en sistemas";
            }
            if (usuarios.RolID == 3)
            {
                RolComboBox.Text = "Profesor";
            }
            if (usuarios.RolID == 4)
            {
                RolComboBox.Text = "Ingeniero Civil";
            }
            if (usuarios.RolID == 5)
            {
                RolComboBox.Text = "Pintor";
            }
            if (usuarios.RolID == 6)
            {
                RolComboBox.Text = "Doctor";
            }
            if (usuarios.RolID == 7)
            {
                RolComboBox.Text = "Bombero";
            }
            if (usuarios.RolID == 8)
            {
                RolComboBox.Text = "Mecanico";
            }
            if (usuarios.RolID == 9)
            {
                RolComboBox.Text = "Juez";
            }
            if (usuarios.RolID == 10)
            {
                RolComboBox.Text = "Abogado";
            }
            FechaIngresoDatePicker.SelectedDate = usuarios.FechaIngreso;
            ActivoChecBox.IsChecked = usuarios.Activo;
        }

        private Usuarios LlenarClase()
        {
            Usuarios usuarios = new Usuarios();
            usuarios.UsuarioID = Utilidades.ToInt(IDTextbox.Text);
            usuarios.Email = EmailTextBox.Text;
            usuarios.Nombres = NombreTextbox.Text;
            usuarios.FechaIngreso = (DateTime)FechaIngresoDatePicker.SelectedDate;
            usuarios.Alias = AliasTextbox.Text;
            if (RolComboBox.SelectedItem.ToString() == "Administrador")
            {
                usuarios.RolID = 1;
            }
            if (RolComboBox.SelectedItem.ToString() == "Ingeniero en sistemas")
            {
                usuarios.RolID = 2;
            }
            if (RolComboBox.SelectedItem.ToString() == "Profesor")
            {
                usuarios.RolID = 3;
            }
            if (RolComboBox.SelectedItem.ToString() == "Ingeniero Civil")
            {
                usuarios.RolID = 4;
            }
            if (RolComboBox.SelectedItem.ToString() == "Pintor")
            {
                usuarios.RolID = 5;
            }
            if (RolComboBox.SelectedItem.ToString() == "Doctor")
            {
                usuarios.RolID = 6;
            }
            if (RolComboBox.SelectedItem.ToString() == "Bombero")
            {
                usuarios.RolID = 7;
            }
            if (RolComboBox.SelectedItem.ToString() == "Mecanico")
            {
                usuarios.RolID = 8;
            }
            if (RolComboBox.SelectedItem.ToString() == "Juez")
            {
                usuarios.RolID = 9;
            }
            if (RolComboBox.SelectedItem.ToString() == "Abogado")
            {
                usuarios.RolID = 10;
            }
            usuarios.Activo = (bool)ActivoChecBox.IsChecked;

            return usuarios;
        }

        private bool Validar()
        {
            bool paso = true;

            if (NombreTextbox.Text == string.Empty)
            {
                MessageBox.Show("El campo nombre no puede estar vacio");
                NombreTextbox.Focus();
                paso = false;
            }


            if (string.IsNullOrWhiteSpace(RolComboBox.Text))
            {
                MessageBox.Show("Debe agregar un rol especifico");
                RolComboBox.Focus();
                paso = false;
            }

            if (AliasTextbox.Text == string.Empty)
            {
                MessageBox.Show("El campo de alias no puede estar vacio");
                AliasTextbox.Focus();
                paso = false;
            }

            //if (ClaveTextbox.Text == string.Empty)
            //{
            //    MessageBox.Show("El campo de clave no puede estar vacio");
            //    ClaveTextbox.Focus();
            //    paso = false;
            //}

            //if (ConfirmClaveTextBox.Text == string.Empty)
            //{
            //    Errores.SetError(ConfirmClaveTextBox, "El campo de confirmar clave no puede estar vacio");
            //    ConfirmClaveTextBox.Focus();
            //    paso = false;
            //}
            if (EmailTextBox.Text == string.Empty)
            {
                MessageBox.Show("El campo de email no puede estar vacio");
                EmailTextBox.Focus();
                paso = false;
            }
            //if (UsuariosBLL.ExisteAlias(AliasTextbox.Text))
            //{
            //    MessageBox.Show("Este Alias ya existe");
            //    AliasTextbox.Focus();
            //    paso = false;
            //}
            //if (string.Equals(ClaveTextBox.Text, ConfirmClaveTextBox.Text) != true)
            //{
            //    Errores.SetError(ConfirmClaveTextBox, "La clave es distinta");
            //    ConfirmClaveTextBox.Focus();
            //    paso = false;
            //}

            return paso;
        }

        private void BuscarIDButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
