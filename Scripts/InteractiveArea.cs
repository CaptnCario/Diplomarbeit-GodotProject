using Godot;
using System;

public partial class InteractiveArea : Area3D
{
	[Signal]
	public delegate void PlayerInteractedEventHandler();

	public void Interact()
	{
		EmitSignal(nameof(PlayerInteracted));
	}
}
