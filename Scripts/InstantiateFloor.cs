using Godot;
using System;

public partial class InstantiateFloor : Node3D
{
	[Export] public PackedScene tile;
	[Export] public int mapSize = 10;


	private int startInt;
	private int endInt;

	public override void _Ready()
	{
		GenerateFloor();

		GD.Print("_Ready completed.");
	}

	void GenerateFloor()
	{
		GD.Print("GenerateFloor() start.");

		int half = (int)(mapSize / 2);
		startInt = (int)(0 - half);
		endInt = (int)(mapSize - half);


		GD.Print($"Half: {half}. Start at {startInt} and end at {endInt}.");

		for (int x = startInt; x < endInt; x++)
		{
			for (int z = startInt; z < endInt; z++)
			{
				Node3D t = tile.Instantiate<Node3D>();
				t.Name = $"FloorTile [x:{x}, y:0 z:{z}]";
				t.Transform = new Transform3D(Basis.Identity, new Vector3(x, 0, z));

				AddChild(t);
			}
		}

		GD.Print("GenerateFloor() end.");
	}

}
