using GamePad.Web.Components.Management;
using Microsoft.AspNetCore.Components;
using System.Net.NetworkInformation;

namespace GamePad.Web.Components.BaseComponents
{
    public class Game : ComponentBase
    {
        public virtual void HandleGameCommand(object? sender, GameCommandEventArgs e)
        {
            // TODO: how to make a component abstract or interface?
            throw new NotImplementedException();
        }
    }
}

