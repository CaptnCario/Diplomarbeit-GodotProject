using Godot;
using System;

public partial class InteractiveButton : Node3D
{
    [Export]
    public Door targetDoor;

    public override void _Ready()
    {
        // Signals are "methods".
        // Because they trigger one or multiple methods
        // So we link a method to a signal
        // so when the signal is triggered
        // the method is called.
        InteractiveArea trigger = GetNode<InteractiveArea>("MeshInstance3D/Area3D");
        trigger.PlayerInteracted += PlayerInteract;
    }

    private void PlayerInteract()
    {
        targetDoor.opened = true;
    }
}
