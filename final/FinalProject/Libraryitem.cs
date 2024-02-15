public abstract class LibraryItem
{
    public string Title { get; set; }
    public bool Availability { get; set; }

    public LibraryItem(string title)
    {
        Title = title;
        Availability = true; 
    }

    public virtual void CheckOut()
    {
        if (Availability)
        {
            Availability = false;
            Console.WriteLine($"{Title} has been checked out.");
        }
        else
        {
            Console.WriteLine($"{Title} is already checked out.");
        }
    }

    public virtual void Return()
    {
        if (!Availability)
        {
            Availability = true;
            Console.WriteLine($"{Title} has been returned.");
        }
        else
        {
            Console.WriteLine($"{Title} is already available.");
        }
    }
}
