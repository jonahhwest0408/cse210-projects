using System;
using System.Collections.Generic;

public class NotificationManager
{
    private List<string> notifications;

    public NotificationManager()
    {
        notifications = new List<string>();
    }

    public void AddNotification(string notification)
    {
        notifications.Add(notification);
    }

    public void DisplayNotifications()
    {
        Console.WriteLine("Notifications:");
        foreach (var notification in notifications)
        {
            Console.WriteLine(notification);
        }
    }
}
