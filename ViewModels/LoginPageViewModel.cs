using SurveysApp.Models;
using SurveysApp.Views;

namespace SurveysApp.ViewModels;

public class LoginPageViewModel
{
    public string Email { get; set; }
    public string Password { get; set; }

    public Command LoginCommand { get; set; }

    public LoginPageViewModel()
    {
        LoginCommand = new Command(LoginAsync);
        Settings.RegistroEmail = "gustavo@gmail.com";
        Settings.RegistroPassword = "12345.";
    }

    private async void LoginAsync()
    {
        if (string.IsNullOrEmpty(Email) || !Util.IsAValidEmail(Email.ToLower()))
        {
            await Util.ShowToastAsync("Ingrese un Email Válido");
            return;
        }

        if (string.IsNullOrEmpty(Password))
        {
            await Util.ShowToastAsync("Ingrese una Contraseña Válida");
            return;
        }

        if (Settings.RegistroEmail != Email)
        {
            await Util.ShowToastAsync($"El correo {Email} no existe");
            return;
        }
        if (Settings.RegistroPassword != Password)
        {
            await Util.ShowToastAsync($"Contraseña Incorrecta");
            return;
        }

        Settings.IsAuthenticated = true;
        
        await Shell.Current.GoToAsync($"///{nameof(SurveyPage)}");
    }
}
