using GamePad.Web.Components.Management;
using Microsoft.AspNetCore.Components;

namespace GamePad.Web.Components.BasePages
{
    public abstract class Client : ComponentBase
    {
        [Parameter]
        public string SessionId { get; init; }
        [Parameter]
        public string Name { get; init; }
        public Session Session { get; protected set; }

        protected override void OnInitialized()
        {
            Session = Manager.GetSessionById(SessionId);
        }
    }
}
