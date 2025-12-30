using System.Globalization;
using System.Security.Cryptography;

namespace FriendlyPasswordGenerator.Main;

public partial class FormPasswordGenerator : Form
{
    sealed record PasswordSettings()
    {
        public bool AsciiCaractersOnly { get; set; } = true;
        public int MinimumLenght { get; set; } = 40;
    }

    private readonly List<string> PasswordHistory = [];
    private readonly string[] WordsList = null!;
    private readonly PasswordSettings _passwordSettings = new();

    public FormPasswordGenerator()
    {
        InitializeComponent();
        Button_GenerateNewPassword.Click += Button_GenerateNewPassword_Click;
        Label_CurrentPassword.Click += CopyLabelText;
        MainTabControl.SelectedIndexChanged += MainTabControl_SelectedIndexChanged;
        ListView_PasswordHistory.MouseClick += ListView_PasswordHistory_MouseClick;

        NumericPicker_MinimumLenght.DataBindings.Add("Value", _passwordSettings, nameof(PasswordSettings.MinimumLenght), false, DataSourceUpdateMode.OnPropertyChanged);
        CheckBox_AllowNonAsciiCaracters.DataBindings.Add("Checked", _passwordSettings, nameof(PasswordSettings.AsciiCaractersOnly), false, DataSourceUpdateMode.OnPropertyChanged);

        WordsList = Properties.Resources.wordlist_ptbr.Split("\n");

        Button_GenerateNewPassword.PerformClick();
    }

    private async void ListView_PasswordHistory_MouseClick(object? sender, MouseEventArgs e)
    {
        if (sender is not ListView listView)
        {
            return;
        }

        if (listView.SelectedItems.Count < 0)
        {
            return;
        }

        try
        {
            var selectedItem = listView.SelectedItems[0];
            Clipboard.SetText(selectedItem.Text);

            using ToolTip _tooltip = new();
            _tooltip.Show("Copied!",
                listView,
                selectedItem.Bounds.Location.X + (selectedItem.Bounds.Width/2),
                selectedItem.Bounds.Location.Y,
                500);
            await Task.Delay(500);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }

    }

    private void MainTabControl_SelectedIndexChanged(object? sender, EventArgs e)
    {
        if (MainTabControl.SelectedTab == PasswordHistoryTabPage)
        {
            ListView_PasswordHistory.Items.Clear();

            var newItems = PasswordHistory
                .Select(x => new ListViewItem(x))
                .ToArray();

            ListView_PasswordHistory.Items.AddRange(newItems);
        }
    }

    private async void CopyLabelText(object? sender, EventArgs e)
    {
        try
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
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private async void Button_GenerateNewPassword_Click(object? sender, EventArgs e)
    {
        try
        {
            var password = GeneratePassword();

            Label_CurrentPassword.Text = password;
            PasswordHistory.Add(password);
            CopyLabelText(Label_CurrentPassword, e);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private string GeneratePassword()
    {
        List<string> parts = [];

        static IEnumerable<string> InBetweenWords()
        {
            for (int i = 0; i < 3; i++)
            {
                yield return RandomNumberGenerator.GetInt32(2) == 0
                    ? RandomSymbol()
                    : RandomNumber();
            }
        }

        parts.AddRange(InBetweenWords());
        while (parts.Sum(p => p.Length) < _passwordSettings.MinimumLenght)
        {
            parts.Add(RandomWord());
            parts.AddRange(InBetweenWords());
        }

        return string.Concat(parts);
    }

    private string RandomWord()
    {
        while (true)
        {
            var randomIndex = RandomNumberGenerator.GetInt32(WordsList.Length);

            var word = WordsList[randomIndex]
                .Trim()
                .ToLower()
                .Replace(char.ConvertFromUtf32(32), string.Empty);

            if (_passwordSettings.AsciiCaractersOnly && word.Any(x => !char.IsAscii(x)))
            {
                continue; // try again
            }

            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(word);
        }
    }

    private static string RandomSymbol()
    {
        string symbols = "!@#$%&*-=+[]{}";
        char randomSymbol = symbols[RandomNumberGenerator.GetInt32(symbols.Length)];
        return randomSymbol.ToString();
    }

    private static string RandomNumber()
    {
        return RandomNumberGenerator.GetInt32(10).ToString();
    }
}
