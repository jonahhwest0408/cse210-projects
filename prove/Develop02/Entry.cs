using System;

public class Entry
{
    public string _prompt;
    public string _response;
    public string _dateString; 

    public Entry(string prompt, string response)
    {
        _prompt = prompt;
        _response = response;
        _dateString = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"); //Set the initial date as a string representation//
    }

    public override string ToString()
    {
        return $"{_dateString}: {_prompt}\nResponse: {_response}\n";
    }
}
