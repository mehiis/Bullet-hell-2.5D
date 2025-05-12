using Godot;
using System;

public partial class Projectile : Area3D
{
    [Export] public Vector3 direction;
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
            Destroy();
        }
    }

    private void Movement(float delta)
    {
        this.GlobalPosition += direction * moveSpeed * delta;

        // Rotate the player to face the shooting direction
        LookAt(GlobalPosition + direction, Vector3.Forward);
    }

    private void Destroy()
    {
        GD.Print("Destroy projectile");
        QueueFree();
    }
}
