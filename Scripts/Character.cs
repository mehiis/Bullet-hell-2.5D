using Godot;
using System;

public enum CharacterState { IDLE, MOVE, SHOOT }
public partial class Character : Entity
{
    [Export] protected CharacterState state = CharacterState.IDLE;
    [Export] protected float shootSpeed = .5f;
    private float shootCounter = 0;
    [Export] protected int moveSpeed = 8;
    [Export] protected int currentMoveSpeed;
    [Export] public PackedScene projectile;

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

        SetState(CharacterState.MOVE);
        Velocity = moveDir * currentMoveSpeed;

        if (Velocity == Vector3.Zero)
        {
            SetState(CharacterState.IDLE);
            return;
        }

        MoveAndSlide();
    }

    public virtual void SetState(CharacterState state)
    {
        this.state = state;
    }

    protected virtual void FireProjectile(Vector3 direction, bool isPlayerProjectile = false)
    {
        if (projectile == null)
        {
            GD.PrintErr($"{Name} projectile reference is not set!");
            return;
        }

        if (shootCounter <= 0)
        {
            GD.Print($"{this.Name} shot a basic projectile.");

            Area3D basicBullet = projectile.Instantiate<Area3D>();
            GetTree().Root.CallDeferred("add_child", basicBullet);
            basicBullet.CallDeferred("set", "global_position", this.GlobalPosition);
            basicBullet.CallDeferred("set", "direction", direction);
            basicBullet.CallDeferred("set", "isPlayerProjectile", isPlayerProjectile);

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
