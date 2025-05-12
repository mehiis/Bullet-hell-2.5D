using Godot;
using System;

public enum CharacterState { IDLE, MOVE, SHOOT }
public enum Projectiles { BASIC, TRIPLE, THREESIXTY }
public partial class Character : Entity
{
    [Export] protected CharacterState state = CharacterState.IDLE;
    [Export] protected Projectiles projectiles = Projectiles.BASIC;
    [Export] protected float shootSpeed = .5f;
    private float shootCounter = 0;
    [Export] protected int moveSpeed = 8;
    [Export] protected int currentMoveSpeed;

    public override void _Ready()
    {
        base._Ready();
        currentMoveSpeed = moveSpeed;
    }

    public override void _Process(double delta)
    {
        base._Process(delta);
        Cooldown((float)delta);
    }

    protected virtual void Move(Vector2 input)
    {
        Vector3 moveDir = Vector3.Zero;

        if (input.Y == 1)
        {
            moveDir.Z = -1;
        }

        if (input.Y == -1)
        {
            moveDir.Z = 1;
        }

        if (input.X == 1)
        {
            moveDir.X = 1;
        }

        if (input.X == -1)
        {
            moveDir.X = -1;
        }

        moveDir = moveDir.Normalized();

        state = CharacterState.MOVE;
        Velocity = moveDir * currentMoveSpeed;

        if (Velocity == Vector3.Zero)
        {
            state = CharacterState.IDLE;
            return;
        }

        MoveAndSlide();
    }

    protected virtual void FireProjectile(Vector3 direction)
    {
        if (shootCounter <= 0)
        {
            switch (projectiles)
            {
                case Projectiles.BASIC:
                    GD.Print($"{this.Name} shot a basic projectile.");
                    break;
                case Projectiles.TRIPLE:
                    GD.Print($"{this.Name} shot a triple projectile.");
                    break;
                case Projectiles.THREESIXTY:
                    GD.Print($"{this.Name} shot a 360 projectile.");
                    break;
            }

            shootCounter = shootSpeed;
        }
    }

    protected virtual void Cooldown(float delta)
    {
        if (shootCounter >= 0)
        {
            shootCounter -= delta;
        }
    }
}
