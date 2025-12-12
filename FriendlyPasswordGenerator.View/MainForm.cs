using FriendlyPasswordGenerator.Model;

namespace FriendlyPasswordGenerator.View;

public partial class MainForm : Form
{
    public UserSettings UserSettings { get; set; } = new();

    public MainForm()
    {
        InitializeComponent();

        Load += MainForm_Load;

        Label_CurrentPassword.Click += CopyLabelText;

        Button_GenerateNewPassword.Click += Button_GenerateNewPassword_Click;
        Button_PasswordHistory.Click += Button_PasswordHistory_Click;
    }

    private void MainForm_Load(object? sender, EventArgs e)
    {
        NumericPicker_AmountOfWords.DataBindings.Add("Value", UserSettings, nameof(UserSettings.AmountOfWords), false, DataSourceUpdateMode.OnPropertyChanged);
        NumericPicker_MinimumLenght.DataBindings.Add("Value", UserSettings, nameof(UserSettings.MinimumLenght), false, DataSourceUpdateMode.OnPropertyChanged);
        CheckBox_AllowNonAsciiCaracters.DataBindings.Add("Checked", UserSettings, nameof(UserSettings.AllowNonAsciiCaracters), false, DataSourceUpdateMode.OnPropertyChanged);
    }

    private void Button_PasswordHistory_Click(object? sender, EventArgs e)
    {
        Form viewer = new ListViewer(PasswordGenerator.PasswordHistory);
        viewer.ShowDialog();
    }

    private async void Button_GenerateNewPassword_Click(object? sender, EventArgs e)
    {
        string value = string.Empty;

        Label_CurrentPassword.ForeColor = Color.Red;
        Label_CurrentPassword.Text = "Generating...";

        try
        {
            Button_GenerateNewPassword.Enabled = false;

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

            Button_GenerateNewPassword.Enabled = true;
        }
    }

    private async void CopyLabelText(object? sender, EventArgs e)
    {
        if (sender is not Label label)
            return;

        Clipboard.SetText(label.Text);

        using ToolTip _tooltip = new();

        _tooltip.Show("Copied!",
            label,
            label.Location.X + (label.Width / 2),
            label.Location.Y + (label.Height / 2),
            500);

        await Task.Delay(500);
    }
}