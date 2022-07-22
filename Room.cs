using Godot;
using System;

public class Room : Spatial
{

	private Node doorRoot;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		doorRoot = (Node)FindNode("Doors");
		for(int i = 0; i < doorRoot.GetChildCount(); i++)
		{
			GD.Print(doorRoot.GetChild(i).Name);
		}
		
	}

	public Basis GetDoor()
	{

		Spatial door = (Spatial)doorRoot.GetChild(0);
		return door.Transform.basis;
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
