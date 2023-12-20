using SurveysApp.Models;
using SurveysApp.Services.Interfaces;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SurveysApp.ViewModels;

public class SurveyPageViewModel : INotifyPropertyChanged
{
    private readonly ISurveyService surveyService;
    
    private string answer3;
    private double answer2;
    private string answer1;

    public event PropertyChangedEventHandler PropertyChanged;

    public string Answer1
    {
        get => answer1;
        set
        {
            if (answer1 != null)
            {
                answer1 = value;
                OnPropertyChanged();
            }
        }
    }

    public double Answer2
    {
        get => answer2;
        set
        {
            answer2 = value;
            OnPropertyChanged();
        }
    }

    public string Answer3
    {
        get => answer3;
        set
        {
            if (answer3 != null)
            {
                answer3 = value;
                OnPropertyChanged();
            }
        }
    }
   
    public bool IsValid { get; set; }

    public Command ValidateAnswersCommand { get; set; }

    public Command SaveAnswersCommand { get; set; }

    public SurveyPageViewModel(ISurveyService surveyService)
    {
        this.surveyService = surveyService;

        answer1 = string.Empty;
        answer2 = 0;
        answer3 = string.Empty;

        ValidateAnswersCommand = new Command(ValidateAnswersAsync);
        SaveAnswersCommand = new Command(SaveAnswersAsync);
    }

    private async void ValidateAnswersAsync()
    {
        IsValid = false;
        if (Answer1 != "4")
        {
            await Util.ShowToastAsync("Respuesta Equivocada en la primera pregunta");
            return;
        }

        if (Answer2 != 3.1416)
        {
            await Util.ShowToastAsync("Respuesta del valor de PI Equivocada");
            return;
        }

        if (Answer3 != "5")
        {
            await Util.ShowToastAsync("Respuesta Equivocada en la tercera pregunta");
            return;
        }
        IsValid = true;
    }

    private async void SaveAnswersAsync()
    {
        if (!IsValid)
        {
            await Util.ShowToastAsync("Debe Validar las respuestas primero");
            return;
        }

        var survey = new SurveyModel
        {
            Answer1 = Answer1,
            Answer2 = Answer2,
            Answer3 = Answer3,
        };

        var result = await surveyService.SaveSurveyAsync(survey);

        if (result)
        {
            await Util.ShowToastAsync("Respuestas Grabadas");
        }
    }

    public void OnPropertyChanged([CallerMemberName] string name = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

}
