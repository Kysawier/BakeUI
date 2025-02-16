using Microsoft.AspNetCore.Components;

namespace BakeUI.Toggle;

public class ToggleDough : IToggleDough
{
    private readonly Action<bool>? _userCallback;
    public ToggleDough(
        bool? disabled, 
        bool? defaultPressed, 
        bool? pressed,
        // EventCallback<bool>? onPressedChange,
        Action<bool>? onPressedChange = null
        )
    {
        Disabled = disabled ?? false;
        DefaultPressed = defaultPressed ?? false;
        Pressed = pressed ?? false;
        _userCallback = onPressedChange;

        OnPressedChange = EventCallback.Factory.Create<bool>(this, value =>
        {
            Pressed = value;
            _userCallback?.Invoke(value);
        });

        // OnPressedChange = onPressedChange ??
        //                   EventCallback.Factory.Create<bool>(this, (value) => Pressed = value);
    }

    public bool Disabled { get; set; }
    public bool DefaultPressed { get; set; }
    public bool Pressed { get; set; }
    public EventCallback<bool> OnPressedChange { get; set; }

    public Task HandleToggle() => OnPressedChange.InvokeAsync(!Pressed);
}