using Godot;
using System;

public partial class Player : Character
{
	public override void _Process(double delta)
	{
		Cooldown((float)delta);

		HandleMoveInput();
		HandleShooting();
	}

	private void HandleMoveInput()
	{
		Vector2 input = Vector2.Zero;

		if (Input.IsActionPressed("Up"))
			input.Y = 1;

		if (Input.IsActionPressed("Down"))
			input.Y = -1;

		if (Input.IsActionPressed("Right"))
			input.X = 1;

		if (Input.IsActionPressed("Left"))
			input.X = -1;

		Move(input);
	}

	private void HandleShooting()
	{
		if (Input.IsActionPressed("Fire"))
		{
			Camera3D camera = GetViewport().GetCamera3D();

			Vector2 mousePos = GetViewport().GetMousePosition();
			Vector3 rayOrigin = camera.ProjectRayOrigin(mousePos);
			Vector3 rayDirection = camera.ProjectRayNormal(mousePos);

			Vector3? intersection = new Plane(Vector3.Up, 0).IntersectsRay(rayOrigin, rayDirection);

			Vector3 dir = (intersection.Value - GlobalPosition).Normalized();
			dir.Y = 0;

			FireProjectile(dir, true);
		}
	}
}
