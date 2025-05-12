using Godot;
using System;

public partial class EnemyAI : Character
{
    [Export] private Player player;

    public override void _Process(double delta)
    {
        base._Process(delta);
    }
}
