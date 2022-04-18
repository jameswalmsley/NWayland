using System;


namespace NWayland.Interop
{
    public class NWaylandException : Exception
    {
        public NWaylandException() { }

        public NWaylandException(string message) : base(message) { }
    }
}
