using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views;

namespace MauiAndDevDemo;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
    /// <summary>
    /// I added
    /// </summary>
    protected override void OnCreate(Bundle savedInstanceState)
    {
        base.OnCreate(savedInstanceState);

        Window.AddFlags(WindowManagerFlags.Fullscreen);
        Window.SetNavigationBarColor(Android.Graphics.Color.Transparent); //导航栏透明
        Window.AddFlags(WindowManagerFlags.DrawsSystemBarBackgrounds);
        Window.SetStatusBarColor(Android.Graphics.Color.Transparent);
    }

    /// <summary>
    /// I added
    /// </summary>
    public override void OnWindowFocusChanged(bool hasFocus)
    {
        base.OnWindowFocusChanged(hasFocus);

        if (hasFocus)
        {
            //https://developer.android.com/training/system-ui/immersive.html#java
            SetSystemUiVisibility();
        }
    }

    /// <summary>
    /// I added
    /// </summary>
    public void SetSystemUiVisibility()
    {
        var uiOptions = SystemUiFlags.HideNavigation | SystemUiFlags.LayoutHideNavigation | SystemUiFlags.LayoutFullscreen | SystemUiFlags.Fullscreen | SystemUiFlags.LayoutStable | SystemUiFlags.ImmersiveSticky;
        Window.DecorView.SystemUiVisibility = (StatusBarVisibility)uiOptions;
    }
}
