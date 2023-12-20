namespace SurveysApp.Models;

public static class Settings
{
    private const double zero = 0.0;

    public static string Answer1
    {
        get => Preferences.Default.Get(nameof(Answer1), string.Empty);
        set => Preferences.Default.Set(nameof(Answer1), value);
    }

    public static double Answer2
    {
        get => Preferences.Default.Get(nameof(Answer2), zero);
        set => Preferences.Default.Set(nameof(Answer2), value);
    }

    public static string Answer3
    {
        get => Preferences.Default.Get(nameof(Answer3), string.Empty);
        set => Preferences.Default.Set(nameof(Answer3), value);
    }

    public static string RegistroEmail
    {
        get => Preferences.Default.Get(nameof(RegistroEmail), string.Empty);
        set => Preferences.Default.Set(nameof(RegistroEmail), value);
    }

    public static string RegistroPassword
    {
        get => Preferences.Default.Get(nameof(RegistroPassword), string.Empty);
        set => Preferences.Default.Set(nameof(RegistroPassword), value);
    }

    public static bool IsAuthenticated
    {
        get => Preferences.Default.Get(nameof(IsAuthenticated), false);
        set => Preferences.Default.Set(nameof(IsAuthenticated), value);
    }
}
