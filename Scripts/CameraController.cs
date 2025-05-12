using Godot;
using System;

public partial class CameraController : Camera3D
{
	[Export] private Vector3 offset;
	[Export] private float lerpSpeed = 5.0f;
	private CharacterBody3D target;

	[Export] private float minX = -25.0f / 2;
	[Export] private float maxX = 25.0f / 2;
	[Export] private float minZ = -25.0f / 2;
	[Export] private float maxZ = 30.0f;

	public override void _Ready()
	{
		target = GetNode<CharacterBody3D>("../Player");
	}


	public override void _Process(double delta)
	{
		// Get the target position (player's position + offset)
		Vector3 targetPosition = target.GlobalTransform.Origin + offset;

		// Interpolate between the current position and the target position
		Vector3 smoothedPosition = GlobalTransform.Origin.Lerp(targetPosition, lerpSpeed * (float)delta);

		// Clamp the X and Z values
		smoothedPosition.X = Mathf.Clamp(smoothedPosition.X, minX, maxX);
		smoothedPosition.Z = Mathf.Clamp(smoothedPosition.Z, minZ, maxZ);

		// Update the camera's position while keeping its rotation
		GlobalTransform = new Transform3D(GlobalTransform.Basis, smoothedPosition);
	}
}
