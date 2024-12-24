using System.ComponentModel;

namespace RgoSystem.View.BaseControls;

public abstract class BaseTextBox : TextBox, IBaseControl
{
    [Category("Custom Properties")]
    [Description("Indicates if the text box is searchable.")]
    [DefaultValue(false)]
    public bool Searchable
    {
        get => _searchable;
        set
        {
            _searchable = value;
        }
    }

    [Category("Custom Properties")]
    [Description("Indicates if the text box is invalid.")]
    [DefaultValue(false)]
    public bool Invalid
    {
        get => _invalid;
        set
        {
            _invalid = value;
        }
    }

    private bool _searchable;
    private bool _invalid;
    protected override void OnCreateControl()
    {
        base.OnCreateControl();

    }

    protected override void OnEnter(EventArgs e)
    {
        base.OnEnter(e);

        SelectAll();
    }

    protected override void OnLeave(EventArgs e)
    {
        base.OnLeave(e);

        this.TrimText();
    }

    protected override void OnGotFocus(EventArgs e)
    {
        base.OnGotFocus(e);

        this.UpdateColors();
    }

    protected override void OnLostFocus(EventArgs e)
    {
        base.OnLostFocus(e);

        this.UpdateColors();
    }

    protected override void OnReadOnlyChanged(EventArgs e)
    {
        base.OnReadOnlyChanged(e);

        this.UpdateColors();
    }

    protected override void OnTextChanged(EventArgs e)
    {
        base.OnTextChanged(e);

        this.UpdateColors();
    }

    protected new void SelectAll()
    {
        if (!IsHandleCreated)
        {
            return;
        }

        BeginInvoke(base.SelectAll);
    }

    protected override void OnKeyDown(KeyEventArgs e)
    {
        base.OnKeyDown(e);

        if (e.KeyData is Constants.ControlKeyData
            or Constants.ShiftKeyData
            or Constants.AltKeyData)
        {
            return;
        }

        if (e.KeyData.IsAnyArrow())
        {
            return;
        }

        if (e.KeyData is Constants.ControlC)
        {
            if (SelectionLength == 0)
            {
                this.ShowInfoToolTip("Nada para copiar!");
                return;
            }

            this.ShowInfoToolTip("Copiado!");
            return;
        }

        if (ReadOnly)
        {
            this.ShowInfoToolTip("Caixa de texto somente leitura!");
        }
    }
}