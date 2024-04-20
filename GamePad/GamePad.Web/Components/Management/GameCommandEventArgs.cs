namespace GamePad.Web.Components.Management
{
    public class GameCommandEventArgs(string command) : EventArgs
    {
        public string Command { get; init; } = command;
    }
}
