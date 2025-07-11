using Godot;
using System;

public partial class RayCast3d : RayCast3D
{
    public override void _Ready()
    {
        // Initialize the RayCast3D node
        base._Ready();
        
        // Set the ray length and enable it
        this.Enabled = true;
    }

    public override void _PhysicsProcess(double delta)
    {
        // Check if the ray is colliding with something
        if (IsColliding())
        {
            var collider = GetCollider();
            GD.Print("Ray is colliding with: " + collider);
        }
    }
}
