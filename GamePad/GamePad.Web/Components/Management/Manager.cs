using GamePad.Web.Components.Pages;

namespace GamePad.Web.Components.Management
{
    public static class Manager
    {
        public static List<GameInfo> Games { get; } =
        [
            new ("EmptyGame1", 1, 1),
            new ("EmptyGame2", 1, 6),
            new ("TanksTutorial", 1, 2)
        ];
        public static List<Session> Sessions { get; } = [];

        public static GameInfo GetGameById(string id)
        {
            return Games.FirstOrDefault(game => game.Id == id)!;
        }

        internal static Session GetSessionById(string id)
        {
            return Sessions.FirstOrDefault(session => session.Id == id)!;
        }

        public static Session CreateSession(GameInfo game)
        {
            var session = new Session(game);
            Sessions.Add(session);
            return session;
        }
    }
}
