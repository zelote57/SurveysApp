using SurveysApp.ViewModels;

namespace SurveysApp.Views;

public partial class SurveyPage : ContentPage
{
	public SurveyPage(SurveyPageViewModel surveyPageViewModel)
	{
		InitializeComponent();
		BindingContext = surveyPageViewModel;
	}
}