using Godot;
using System;

public partial class PlayerDetector : Area3D
{
	[Export] private CharacterBody3D player;

	public override void _Ready()
	{
		player = GetNode<CharacterBody3D>("../../Player");
		//GD.Print($"{player.Transform}");
	}

	public override void _EnterTree()
	{
		base._EnterTree();
	}

	public void OnTriggerEnter(Node body)
	{
		// Check if the body is of type Node3D
		if (body is Node3D node3D)
		{
			GD.Print($"{node3D.Name} entered!");
		}
		else
		{
			GD.Print($"Unexpected type: {body.GetType()} entered!");
		}
	}

	public void OnTriggerExit(Node body)
	{
		// Check if the body is of type Node3D
		if (body is Node3D node3D)
		{
			GD.Print($"{node3D.Name} exited!");
		}
		else
		{
			GD.Print($"Unexpected type: {body.GetType()} exited!");
		}
	}

}
