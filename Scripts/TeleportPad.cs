using Godot;
using System;
using System.IO;

public partial class TeleportPad : Area3D
{
	[Export]
	public AudioStreamPlayer3D teleportSound;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		BodyEntered += OnBodyEntered;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void OnBodyEntered(Node3D body)
	{
		//Wir bekommen den Namen des Nodes in der Szene
		string sceneName = Owner.Name;
		GD.Print("PAD:"+sceneName);
		

		if(body.Name == "Player")
		{
			switch (sceneName)
			{
				case "TeleportPad1":
					body.GlobalPosition = new Vector3(61.642f, 1.097f, -16.559f);
					break;

				case "TeleportPad2":
					body.GlobalPosition = new Vector3(61.642f, 1.097f, 2.941f);
					break;

				case "TeleportPad3":
					body.GlobalPosition = new Vector3(70.842f, 1.097f, -6.759f);
					break;

				case "TeleportPad4":
					body.GlobalPosition = new Vector3(79.842f, 1.097f, -6.759f);
					break;

				case "TeleportPad5":
					body.GlobalPosition = new Vector3(77.842f, 1.097f, -16.259f);
					break;

				case "TeleportPad6":
					body.GlobalPosition = new Vector3(61.642f, 1.097f, -16.559f);
					break;

				case "TeleportPad7":
					body.GlobalPosition = new Vector3(77.842f, 1.097f, -16.259f);
					break;

				case "TeleportPad8":
					body.GlobalPosition = new Vector3(77.842f, 1.097f, 3.241f);
					break;

				case "TeleportPad9":
					body.GlobalPosition = new Vector3(61.642f, 1.097f, 2.941f);
					break;

				case "TeleportPad10":
					body.GlobalPosition = new Vector3(51.842f, 1.097f, -6.759f);
					break;

				case "TeleportPad11":
					body.GlobalPosition = new Vector3(51.842f, 1.097f, 4.441f);
					break;

				case "TeleportPad12":
					body.GlobalPosition = new Vector3(51.842f, 1.097f, -6.759f);
					break;

				case "TeleportPad13":
					body.GlobalPosition = new Vector3(61.642f, 1.097f, -16.559f);
					break;

				case "TeleportPad14":
					body.GlobalPosition = new Vector3(77.842f, 1.097f, -16.259f);
					break;

				case "TeleportPad15":
					body.GlobalPosition = new Vector3(77.842f, 1.097f, 3.241f);
					break;

				case "TeleportPad16":
					body.GlobalPosition = new Vector3(77.842f, 1.097f, 3.241f);
					break;

				case "TeleportPad17":
					body.GlobalPosition = new Vector3(51.842f, 1.097f, -6.759f);
					break;

				case "TeleportPad18":
					body.GlobalPosition = new Vector3(51.842f, 1.097f, 4.441f);
					break;

				case "TeleportPad19":
					body.GlobalPosition = new Vector3(51.842f, 1.097f, -17.759f);
					break;

				case "TeleportPad20":
					body.GlobalPosition = new Vector3(51.842f, 1.097f, 4.441f);
					break;

				case "TeleportPad21":
					body.GlobalPosition = new Vector3(61.642f, 1.097f, 2.941f);
					break;

				case "TeleportPad22":
					body.GlobalPosition = new Vector3(70.842f, 1.097f, -6.759f);
					break;

				case "TeleportPad23":
					body.GlobalPosition = new Vector3(61.642f, 1.097f, -16.559f);
					break;

				case "TeleportPad24":
					body.GlobalPosition = new Vector3(61.642f, 1.097f, 2.941f);
					break;

				case "TeleportPad25":
					body.GlobalPosition = new Vector3(51.842f, 1.097f, -17.759f);
					break;

				case "TeleportPad26":
					body.GlobalPosition = new Vector3(70.842f, 1.097f, -6.759f);
					break;

				default:
					GD.Print("Unknown teleport pad: " + sceneName);
					break;
			}
			teleportSound.Play();
		}
	}
}
