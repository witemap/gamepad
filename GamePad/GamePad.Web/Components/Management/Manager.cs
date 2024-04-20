using GamePad.Web.Components.Pages;

namespace GamePad.Web.Components.Management
{
    public static class Manager
    {
        public static List<Game> Games { get; } =
        [
            new ("Game1", 1, 1),
            new ("Game2", 1, 6)
        ];
        public static List<Session> Sessions { get; } = [];

        public static Game GetGameById(string id)
        {
            return Games.FirstOrDefault(game => game.Id == id);
        }

        internal static Session GetSessionById(string id)
        {
            return Sessions.FirstOrDefault(session => session.Id == id);
        }

        public static Session CreateSession(Game game)
        {
            var session = new Session(game);
            Sessions.Add(session);
            return session;
        }
    }
}
