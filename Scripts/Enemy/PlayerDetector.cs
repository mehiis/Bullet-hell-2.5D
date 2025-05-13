using Godot;
using System;

public partial class PlayerDetector : Area3D
{
	[Export] private CharacterBody3D player;
	[Export] private Enemy enemy;

	public override void _Ready()
	{
		player = GetNode<CharacterBody3D>("../../Player");
		enemy = GetParent<Enemy>();
		//GD.Print($"{player.Transform}");
	}

	public override void _EnterTree()
	{
		base._EnterTree();
	}

	public void OnTriggerEnter(Node body)
	{
		// Check if the body is of type Node3D
		if (body is Player player)
		{
			GD.Print($"{player.Name} entered!");
			enemy.SetState(CharacterState.MOVE);
		}
	}

	public void OnTriggerExit(Node body)
	{
		// Check if the body is of type Node3D
		if (body is Player player)
		{
			enemy.SetState(CharacterState.IDLE);
			GD.Print($"{player.Name} exited!");
		}
	}

}
