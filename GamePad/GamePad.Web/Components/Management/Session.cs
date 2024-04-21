using GamePad.Web.Components.BasePages;
using GamePad.Web.Components.Pages;

namespace GamePad.Web.Components.Management
{
    public class Session(GameInfo game)
    {
        public string Id { get; init; } = Guid.NewGuid().ToString();
        public GameInfo GameInfo { get; init; } = game;
        public GameHost Host { get; private set; }
        public Controller?[] Controllers { get; init; } = new Controller?[game.MaxPlayers];
        private int NumActivePlayers => Controllers.Count(controller => controller != null);

        public bool IsAcceptingPlayers => NumActivePlayers < GameInfo.MaxPlayers;
        public bool IsRunning => NumActivePlayers >= GameInfo.MinPlayers;
        public string Name => GameInfo.Name + " - " + Host.Name;

        public void Initialize(GameHost host)
        {
            this.Host = host;
        }

        public EventHandler? PlayerJoined;
        public void Join(Controller controller)
        {
            AddController(controller);
            PlayerJoined?.Invoke(controller, EventArgs.Empty);
        }

        public EventHandler? PlayerLeft;
        public void Leave(Controller controller)
        {
            RemoveController(controller);
            PlayerLeft?.Invoke(controller, EventArgs.Empty);
        }

        public EventHandler<GameCommandEventArgs>? GameCommandReceived;
        public void SendCommand(Controller controller, string command)
        {
            GameCommandReceived?.Invoke(controller, new GameCommandEventArgs(command));
        }

        private void AddController(Controller controller)
        {
            Controllers[Array.IndexOf(Controllers, null)] = controller;
        }

        // remove gets triggered by dispose in the controller (either leaving voluntarily or by being kicked)
        private void RemoveController(Controller controller)
        {
            Controllers[Array.IndexOf(Controllers, controller)] = null;
        }

    }
}
