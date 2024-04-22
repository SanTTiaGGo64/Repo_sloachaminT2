using Microsoft.Maui.Controls;

namespace sloachaminT2;
public partial class LoginTarea : ContentPage
{
    string[] usuarios = { "Carlos", "Ana", "Jose" };
    string[] contraseñas = { "carlos123", "ana123", "jose123" };

    public LoginTarea()
    {
        InitializeComponent();
    }

    private void LoginButtonClicked(object sender, EventArgs e)
    {
        string strUser = string.Empty;
        string strContraseña = string.Empty;
        int posicion = -1;

        //Comprobar datos vacios
        if (string.IsNullOrEmpty(txtUsuario.Text))
        {
            DisplayAlert("AVISO", "Ingrese un usuario.", "Ok");
            return;
        }
        else if (string.IsNullOrEmpty(txtContraseña.Text))
        {
            DisplayAlert("AVISO", "Ingrese una contraseña.", "Ok");
            return;
        }
        else
        {
            strUser = txtUsuario.Text;
            strContraseña = txtContraseña.Text;

            //Varible para tomar la posicion del usuario
            for (int i = 0; i < usuarios.Length; i++)
            {
                if (usuarios[i] == strUser)
                {
                    posicion = i;
                    break;
                }
            }
            if (posicion == -1)
            {
                DisplayAlert("AVISO", "Usuario no encontrado.", "Ok");
                return;
            }
        }

        if(strContraseña == contraseñas[posicion]){
            DisplayAlert("AVISO", "Ingreso exitoso, bienvenid@ " + strUser + ".", "Ok");
            MainPage mainPage = new MainPage();
            Navigation.PushAsync(mainPage);
        }
        else
        {
            DisplayAlert("AVISO", "Contraseña incorrecta.", "Ok");
        }
    }
}
