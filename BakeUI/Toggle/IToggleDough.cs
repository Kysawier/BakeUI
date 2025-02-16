using Microsoft.AspNetCore.Components;

namespace BakeUI.Toggle;

public interface IToggleDough
{
    bool Disabled { get; set; }
    bool DefaultPressed { get; set; }
    bool Pressed { get; set; }
    EventCallback<bool> OnPressedChange { get; set; }
    Task HandleToggle();
}