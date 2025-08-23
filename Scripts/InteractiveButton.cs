using Godot;
using System;

public partial class InteractiveButton : Node3D
{
    [Export]
    public Door targetDoor;

    public override void _Ready()
    {
        //Signal nutzen, um auf Interaktionen zu reagieren
        InteractiveArea trigger = GetNode<InteractiveArea>("MeshInstance3D/Area3D");
        trigger.PlayerInteracted += PlayerInteract;
    }

    private void PlayerInteract()
    {
        targetDoor.opened = true;
    }
}
