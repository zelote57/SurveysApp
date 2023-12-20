using SurveysApp.Models;

namespace SurveysApp.Services.Interfaces;

public interface ISurveyService
{
    Task<bool> SaveSurveyAsync(SurveyModel survey);
}
