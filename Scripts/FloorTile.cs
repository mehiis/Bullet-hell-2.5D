using Godot;
using System;
using System.Collections.Generic;

public enum TileType { GRASS, DIRT, STONE, HELL }
public partial class FloorTile : Node3D
{
	[Export] private TileType tileType;
	[Export] private PackedScene[] grassDecorations;


	public override void _Ready()
	{
		RandomNumberGenerator rng = new RandomNumberGenerator();
		rng.Randomize();
		int random = rng.RandiRange(0, 20);

		if (random == 5)
		{
			switch (tileType)
			{
				case TileType.GRASS:
					//GD.Print($"[GRASS] {this.Name} + generates decorations.");
					Node3D t = grassDecorations[0].Instantiate<Node3D>();
					t.Transform = new Transform3D(Basis.Identity, new Vector3(0, 0, 0));

					AddChild(t);

					break;
				case TileType.DIRT:
					GD.Print($"{this.Name} + generates decorations.");
					break;
				case TileType.STONE:
					GD.Print($"{this.Name} + generates decorations.");
					break;
				case TileType.HELL:
					GD.Print($"{this.Name} + generates decorations.");
					break;
			}
		}
	}


}
