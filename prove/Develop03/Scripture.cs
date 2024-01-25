using System;
using System.Collections.Generic;

public class Scripture
{
    private string _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference.GetDisplayText();
        _words = new List<Word>();
        string[] wordArray = text.Split(' ');
        foreach (string wordText in wordArray)
        {
            _words.Add(new Word(wordText));
        }
    }

    public void HideRandomWords(int numberToHide)
    {
        Random random = new Random();
        List<int> visibleWordIndices = GetVisibleWordIndices();

        if (visibleWordIndices.Count == 0)
            return;

        int wordsToHideCount = Math.Min(numberToHide, visibleWordIndices.Count);
        List<int> wordsToHideIndices = visibleWordIndices.OrderBy(_ => random.Next()).Take(wordsToHideCount).ToList();

        foreach (int index in wordsToHideIndices)
        {
            _words[index].Hide();
        }
    }

    public string GetDisplayText()
    {
        return $"{_reference}\n{string.Join(" ", _words.Select(word => word.GetDisplayText()))}";
    }

    public bool IsCompletelyHidden()
    {
        return GetVisibleWordIndices().Count == 0;
    }

    private List<int> GetVisibleWordIndices()
{
    List<int> visibleWordIndices = new List<int>();
    for (int i = 0; i < _words.Count; i++)
    {
        if (!_words[i].IsHidden)
        {
            visibleWordIndices.Add(i);
        }
    }
    return visibleWordIndices;
}

}
