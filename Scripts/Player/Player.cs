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
			Vector3 dir = Vector3.Zero;
			FireProjectile(dir);
		}
	}
}
