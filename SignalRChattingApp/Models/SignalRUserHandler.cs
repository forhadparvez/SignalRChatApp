using System.Collections.Generic;

namespace SignalRChattingApp.Models
{
    public static class SignalRUserHandler
    {
        public static List<SignalRUser> Users=new List<SignalRUser>();
    }

    public class SignalRUser
    {
        public string Id { get; set; }
        public string UserName { get; set; }
    }
}