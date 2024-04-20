using GamePad.Web.Components.Management;
using Microsoft.AspNetCore.Components;

namespace GamePad.Web.Components.BasePages
{
    public abstract class Controller : Client, IDisposable
    {
        [Inject]
        protected NavigationManager NavigationManager { get; init; }
        protected override void OnInitialized()
        {
            base.OnInitialized();
            Session.Join(this);
            Session.Host.PlayerKicked += OnKicked;
        }

        private void OnKicked(object? sender, EventArgs e)
        {
            if (sender == this)
                NavigationManager.NavigateTo($"/kicked/{Session.Name}");
        }

        public void Dispose()
        {
            Session.Host.PlayerKicked -= OnKicked;
            Session.Leave(this);
        }
    }
}
