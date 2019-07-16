namespace SignalRBug
{
    public class PingClass
    {
        public PingType Type { get; set; }
        public string Message { get; set; }

        public override string ToString()
        {
            return $"{Type} ({Message})";
        }

        public static bool operator ==(PingClass self, PingClass other)
        {
            return self.Type == other.Type
                && self.Message == other.Message;
        }

        public static bool operator !=(PingClass self, PingClass other)
        {
            return !(self == other);
        }
    }
}