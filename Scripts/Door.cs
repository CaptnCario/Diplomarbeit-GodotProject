using Godot;
using System;

public partial class Door : Node3D
{
	Node3D doorLeft;
	Node3D doorRight;

	AudioStreamPlayer3D audioPlayerOpen;

	AudioStreamPlayer3D audioPlayerClose;

	[Export]
	public bool opened;

	[Export]
	public float speed = 1.0f;

	// Called when the node enters the scene tree for the first time.
	//Unity Start equivalent
	public override void _Ready()
	{
		audioPlayerOpen = GetNode<AudioStreamPlayer3D>("DoorOpenPlayer");
		audioPlayerClose = GetNode<AudioStreamPlayer3D>("DoorClosePlayer");
		doorLeft = GetNode<Node3D>("Door_Left");
		doorRight = GetNode<Node3D>("Door_Right");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	// Unity Update equivalent
	public override void _PhysicsProcess(double delta)
	{
		Vector3 targetLeft;
		Vector3 targetRight;

		if (opened == true)
		{
			targetLeft = new Vector3(-2.9f, 0, 0);
			targetRight = new Vector3(8.9f, 0, 1);
			if (doorLeft.Position == new Vector3(0, 0, 0))
			{
				audioPlayerOpen.Play();
			}
		}
		else
		{
			targetLeft = new Vector3(0, 0, 0);
			targetRight = new Vector3(6f, 0, 1);

			if (doorLeft.Position == new Vector3(-2.9f, 0, 0))
			{
				audioPlayerClose.Play();
			}
		}

		float step = (float)delta * speed;
		doorLeft.Position = doorLeft.Position.MoveToward(targetLeft, step);
		doorRight.Position = doorRight.Position.MoveToward(targetRight, step);
	}
}
