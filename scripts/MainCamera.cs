using Godot;
using System;

public partial class MainCamera : Camera3D
{
	[Export]
	private float speed = 10.0f;
	[Export]
	private float sensitivity = 0.2f;

	private Vector2 rotationDeg = new Vector2();

	public override void _Ready()
	{
		Input.MouseMode = Input.MouseModeEnum.Captured;
	}

	public override void _Input(InputEvent @event)
	{
		if (@event is InputEventMouseMotion mouseMotion)
		{
			rotationDeg.X += mouseMotion.Relative.X * sensitivity;
			rotationDeg.Y += mouseMotion.Relative.Y * sensitivity;
			rotationDeg.Y = Mathf.Clamp(rotationDeg.Y, -90, 90); // Limit vertical rotation

			// Apply rotation to the camera
			RotationDegrees = new Vector3(-rotationDeg.Y, -rotationDeg.X, 0);
		}
	}

	public override void _Process(double delta)
	{
		Vector3 direction = new Vector3();

		// Check for keyboard input to move the camera
		if (Input.IsActionPressed("move_forward"))
			direction -= Transform.Basis.Z;
		if (Input.IsActionPressed("move_backward"))
			direction += Transform.Basis.Z;
		if (Input.IsActionPressed("move_left"))
			direction -= Transform.Basis.X;
		if (Input.IsActionPressed("move_right"))
			direction += Transform.Basis.X;

		// Normalize the direction vector, then apply movement and speed
		direction = direction.Normalized();
		Transform = new Transform3D(Transform.Basis, Transform.Origin + direction * speed * (float)delta);
	}
}
