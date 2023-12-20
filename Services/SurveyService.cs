using SurveysApp.Models;
using SurveysApp.Services.Interfaces;

namespace SurveysApp.Services;

public class SurveyService : ISurveyService
{
    public async Task<bool> SaveSurveyAsync(SurveyModel survey)
    {
        if (survey == null)
        {
            return false;
        }

        if (string.IsNullOrEmpty(survey.Answer1) ||
            survey.Answer2 == 0 ||
            string.IsNullOrEmpty(survey.Answer3))
        {
            return false;
        }

        await Task.Delay(250);

        Settings.Answer1 = survey.Answer1;
        Settings.Answer2 = survey.Answer2;
        Settings.Answer3 = survey.Answer3;

        return true;
    }
}
