using FriendlyPasswordGenerator.Model;
using System.ComponentModel;
using System.Threading.Tasks.Dataflow;

namespace FriendlyPasswordGenerator.View;

public partial class MainForm : Form
{
    public UserSettings UserSettings { get; set; }

    public MainForm()
    {
        InitializeComponent();

        UserSettings = new();
        DownsyncUserSettings(null, null);

        Label_CurrentPassword.Click += CopyLabelText;
        NumericPicker_AmountOfWords.ValueChanged += UpsyncUserSettings;
        NumericPicker_MinimumLenght.ValueChanged += UpsyncUserSettings;
        CheckBox_AllowNonAsciiCaracters.CheckedChanged += UpsyncUserSettings;
        UserSettings.PropertyChanged += DownsyncUserSettings;

        Button_GenerateNewPassword.Click += Button_GenerateNewPassword_Click;
        Button_PasswordHistory.Click += Button_PasswordHistory_Click;
    }

    private void Button_PasswordHistory_Click(object? sender, EventArgs e)
    {
        Form a = new ListViewer(PasswordGenerator.PasswordHistory);
        a.ShowDialog();
    }

    private async void Button_GenerateNewPassword_Click(object? sender, EventArgs e)
    {
        string value = string.Empty;

        Label_CurrentPassword.ForeColor = Color.Red;
        Label_CurrentPassword.Text = "Generating...";

        try
        {
            value = await PasswordGenerator.Run(UserSettings);
        }
        catch (TimeoutException ex)
        {
            MessageBox.Show(ex.Message, "Generation Timeout", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error Caught", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            Label_CurrentPassword.ForeColor = Color.Black;
            Label_CurrentPassword.Text = value;
        };
    }

    private async void CopyLabelText(object? sender, EventArgs e)
    {
        if (sender is not Label label)
            return;

        if (label.Text == "Copied!")
            return;

        Clipboard.SetText(label.Text);

        var bkpText = label.Text;
        var bkpColor = label.ForeColor;

        label.ForeColor = Color.Green;
        label.Text = "Copied!";

        await Task.Delay(500);

        label.Text = bkpText;
        label.ForeColor = bkpColor;
    }

    private async void DownsyncUserSettings(object? sender, PropertyChangedEventArgs? e)
    {
        await Task.Run(() =>
        {
            NumericPicker_MinimumLenght.Value = UserSettings.MinimumLenght;
            NumericPicker_AmountOfWords.Value = UserSettings.AmountOfWords;
            CheckBox_AllowNonAsciiCaracters.Checked = UserSettings.AllowNonAsciiCaracters;
        });
    }

    public async void UpsyncUserSettings(object? sender, EventArgs e)
    {
        await Task.Run(() =>
        {
            UserSettings.MinimumLenght = (int)NumericPicker_MinimumLenght.Value;
            UserSettings.AmountOfWords = (int)NumericPicker_AmountOfWords.Value;
            UserSettings.AllowNonAsciiCaracters = CheckBox_AllowNonAsciiCaracters.Checked;
        });
    }
}