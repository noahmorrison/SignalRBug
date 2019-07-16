namespace SignalRBug
{
    public class PingClass
    {
        public PingType Type;
        public string Message;

        public override string ToString()
        {
            return $"{Type} ({Message})";
        }
    }
}