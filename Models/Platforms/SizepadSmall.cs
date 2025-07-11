using Godot;
using System;

public partial class SizepadSmall : Area3D
{
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
		string sceneName = Owner.Name;

		if (body.Name == "Player")
		{
			switch (sceneName)
			{
				case "SizepadSmall":
					body.Scale = new Vector3(0.2f, 0.2f, 0.2f);
					break;

				case "SizepadBig":
					body.Scale = new Vector3(1f, 1f, 1f);
					break;

				default:
					body.Scale = new Vector3(1f, 1f, 1f);
					break;
				
			}
		}
	}
}
