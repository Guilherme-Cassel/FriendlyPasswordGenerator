namespace RgoSystem.View.BaseControls;

public interface IBaseControl
{
    Color BackColor { get; set; }
    Color ForeColor { get; set; }
    bool Invalid { get; set; }
    bool Searchable { get; }
    bool ReadOnly { get; set; }
    bool Visible { get; set; }
    bool ContainsFocus { get; }
    bool Focused { get; }
    string? Text { get; }
}