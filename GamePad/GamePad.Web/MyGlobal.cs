using GamePad.Web.Components.Pages;
using System.Security.Cryptography;

namespace GamePad.Web
{
    public static class MyGlobal
    {
        public static EventHandler GlobalCounterChanged;
        public static int counter = 0;

        public static void Inc()
        {
            counter++;
            GlobalCounterChanged?.Invoke(null, EventArgs.Empty);
        }
    }
}
