using Godot;
using System;

public partial class Projectile : Area3D
{
	[Export] public Vector3 direction;
	[Export] public bool isPlayerProjectile;
	[Export] private int damage;
	[Export] private float moveSpeed = 2.0f;
	[Export] private float lifeTime = 2.0f;


	public override void _Process(double delta)
	{
		HandleLifetTime((float)delta);
		Movement((float)delta);
	}

	private void HandleLifetTime(float delta)
	{
		lifeTime -= delta;

		if (lifeTime <= 0)
		{
			DestroyProjectile();
		}
	}

	private void Movement(float delta)
	{
		GlobalPosition += direction * moveSpeed * delta;
		LookAt(GlobalPosition - direction, Vector3.Forward);
	}

	private void DestroyProjectile()
	{
		QueueFree();
	}

	private void OnTriggerEnter(Node body)
	{
		// Check if the body is an Entity (Player or Enemy)
		if (body is Entity entity)
		{
			if (isPlayerProjectile && body is Enemy)
			{
				entity.TakeDamage(damage);
				DestroyProjectile();
			}

			else if (!isPlayerProjectile && body is Player)
			{
				entity.TakeDamage(damage);
				DestroyProjectile();
			}
		}
	}
}
