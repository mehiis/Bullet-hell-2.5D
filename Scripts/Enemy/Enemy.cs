using Godot;
using System;

public enum MoveType { WALK, FLY };
public partial class Enemy : Character
{
    [Export] private Player player;
    [Export] private MoveType moveType;
    public override void _Ready()
    {
        base._Ready();
        player = GetTree().Root.GetNode<Player>("GameScene/Player");
    }

    public override void _Process(double delta)
    {
        base._Process(delta);

        if (state == CharacterState.MOVE)
        {
            Fire();
            Movement();
        }
    }

    protected override void Die()
    {
        base.Die();
        QueueFree();
    }

    private void Fire()
    {
        if (player == null)
        {
            GD.PrintErr("Player reference is not set!");
            return;
        }

        Vector3 directionToPlayer = (player.GlobalPosition - GlobalPosition).Normalized();
        base.FireProjectile(directionToPlayer, false);
    }

    private void Movement()
    {
        switch (moveType)
        {
            case MoveType.WALK:
                Walk();
                break;
            case MoveType.FLY:
                GD.Print("Flying not implemented.");
                break;
        }
        MoveAndSlide();
    }


    private void Walk()
    {

    }
}
