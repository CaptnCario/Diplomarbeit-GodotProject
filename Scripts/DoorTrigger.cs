using Godot;
using System;
using System.Security.Cryptography.X509Certificates;

public partial class DoorTrigger : Area3D
{
	[Export]
	public Door targetDoor;

	[Export]
	public bool appOpen = false;
	[Export]
	public bool leaveClose = false;

	// Open on approach: The door opens when the player touches the trigger
	// Close on leave: The door closes when the player leaves the trigger

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		//Variablen sind von Area3D -> Public Variablen
		BodyEntered += OnPlayerEnter;
		BodyExited += OnPlayerExit;
	}

	public void OnPlayerEnter(Node3D player)
	{
		if (appOpen)
		{
			targetDoor.opened = true;
		}

	}

	public void OnPlayerExit(Node3D player)
	{
		if (leaveClose)
		{
			targetDoor.opened = false;
		}
	}
}
