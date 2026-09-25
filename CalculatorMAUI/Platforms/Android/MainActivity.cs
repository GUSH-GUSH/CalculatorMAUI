using Android.App;
using Android.Content.PM;
using Android.OS;

namespace MySecondMAUIApp
{
    [Activity(
        Icon = "@mipmap/calculator_icon",
        RoundIcon = "@mipmap/calculator_icon",
        Theme = "@style/Maui.SplashTheme",
        MainLauncher = true,
        LaunchMode = LaunchMode.SingleTop,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    public class MainActivity : MauiAppCompatActivity
    {
    }
}
