using Godot;
using System;

public partial class Player : CharacterBody3D
{
	[Export]
	public float Speed = 7.0f;

	[Export]
	public float JumpVelocity = 4.5f;

	[Export]
	public float CamSens = 0.005f; // Camera Sensitivity

	private Node3D _head;
	private Camera3D _camera;

	private RayCast3D _rayCast;

	public override void _Ready()
	{
		Input.MouseMode = Input.MouseModeEnum.Captured;
		_head = GetNode<Node3D>("Head");
		_camera = GetNode<Camera3D>("Head/Camera3D");
		_rayCast = GetNode<RayCast3D>("Head/Camera3D/RayCast3D");
	}

	public override void _Input(InputEvent @event)
	{
		//Checken ob die Maus bewegt wurde
		if (@event is InputEventMouseMotion motion)
		{
			//Updaten die Maus Rotation
			_head.RotateY(-motion.Relative.X * CamSens); //- Weil die Mausbewegung sonst in die falsche Richtung geht
			_camera.RotateX(-motion.Relative.Y * CamSens);

			//Clamp die Kamera Rotation
			Vector3 camRotation = _camera.Rotation;
			camRotation = _camera.Rotation;
			camRotation.X = Mathf.Clamp(camRotation.X, Mathf.DegToRad(-90f), Mathf.DegToRad(90f));
			_camera.Rotation = camRotation;

		}
	}


	public override void _PhysicsProcess(double delta)
	{
		// Passt die Werte an, je nach Größe des Spielers
		if (Scale == new Vector3(0.2f, 0.2f, 0.2f))
		{
			JumpVelocity = 3.0f;
			Speed = 3.0f;
		}
		else if (Scale == new Vector3(1f, 1f, 1f))
		{
			JumpVelocity = 7.0f;
			Speed = 4.5f;
		}
		PerformMovement(delta);

		//Button Interaktion
		if (Input.IsActionJustPressed("interact"))
		{
			Object collider = _rayCast.GetCollider();
			if (collider != null)
			{
				if (collider is InteractiveArea button)
				{
					button.Interact();
				}
			}
		}
	}

	private void PerformMovement(double delta) {
		Vector3 velocity = Velocity;

		// Fügt die Gravitation hinzu
		if (!IsOnFloor())
		{
			velocity += GetGravity() * (float)delta;
		}

		// Für Sprung
		if (Input.IsActionJustPressed("space") && IsOnFloor())
		{
			velocity.Y = JumpVelocity;
		}

		//Berechnung der Bewegungen
		Vector2 inputDir = Input.GetVector("move_left", "move_right", "move_up", "move_down");
		Vector3 direction = (_head.GlobalTransform.Basis * new Vector3(inputDir.X, 0, inputDir.Y)).Normalized();
		if (direction != Vector3.Zero)
		{
			velocity.X = direction.X * Speed;
			velocity.Z = direction.Z * Speed;
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
			velocity.Z = Mathf.MoveToward(Velocity.Z, 0, Speed);
		}

		Velocity = velocity;
		MoveAndSlide();
	}
}
