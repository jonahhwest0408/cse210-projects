using System;

public class Word
{
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    public void Hide()
    {
        _isHidden = true;
    }

    public void Show()
    {
        _isHidden = false;
    }

    public bool IsHidden
    {
        get { return _isHidden; }
    }

    public string GetDisplayText()
    {
        return IsHidden ? "___" : _text; // Corrected usage of IsHidden property
    }
}
