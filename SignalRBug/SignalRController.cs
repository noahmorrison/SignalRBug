using System;
using Microsoft.AspNetCore.SignalR;

namespace SignalRBug
{
    internal class SignalRController : Hub
    {
        public void Ping(PingType type, string msg)
        {
            Console.WriteLine($"Ping type {type}: {msg}");
        }

        public PingClass PingWithClass(PingClass p)
        {
            Console.WriteLine($"Ping type {p.Type}: {p.Message}");
            return p;
        }
    }
}