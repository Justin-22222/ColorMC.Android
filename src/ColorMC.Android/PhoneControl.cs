using Avalonia.Controls;
using Avalonia.Interactivity;

namespace ColorMC.Android;

public partial class PhoneControl : UserControl
{
    private readonly MainActivity _activity;
    public PhoneControl(MainActivity activity)
    {
        _activity = activity;

        WrapPanel panel = new();
        Button button = new()
        {
            Width = 120,
            Height = 25,
            Content = "打开手机渲染设置",
            Margin = new(0, 0, 5 ,0)
        };
        button.Click += Button_Click;
        panel.Children.Add(button);

        CheckBox check = new()
        {
            Content = "使用lwjgl-vulkan运行库",
            IsChecked = PhoneConfigUtils.Config.LwjglVk
        };
        check.IsCheckedChanged += Check_IsCheckedChanged;
        panel.Children.Add(check);

        Content = panel;
    }

    private void Button_Click(object? sender, RoutedEventArgs e)
    {
        _activity.Setting();
    }

    private void Check_IsCheckedChanged(object? sender, RoutedEventArgs e)
    {
        if (sender is not CheckBox check)
        {
            return;
        }

        PhoneConfigUtils.Config.LwjglVk = check.IsChecked == true;
        PhoneConfigUtils.Save();
    }
}
