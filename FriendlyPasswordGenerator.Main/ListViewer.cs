using System.Data;

namespace FriendlyPasswordGenerator.Main;

public partial class ListViewer : Form
{
    sealed record GridRow()
    {
        public string Password { get; init; } = string.Empty;
    }

    public ListViewer(IEnumerable<string> items)
    {
        InitializeComponent();

        Password.DataPropertyName = nameof(GridRow.Password);

        MainDataGridView.DataSource = items.Select(item => new GridRow() { Password = item }).ToList();
    }
}
