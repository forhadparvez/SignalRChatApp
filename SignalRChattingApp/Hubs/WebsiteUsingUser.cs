using System.Collections.Generic;

namespace SignalRChattingApp.Hubs
{
    public static class WebsiteUsingUser
    {
        public static List<User> _Users=new List<User>();

    }

    public class User
    {
        public string UserName { get; set; }
        public string Id { get; set; }
    }
}