using Godot;
using System;

public class LevelManager : Node
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		PackedScene ground = (PackedScene)ResourceLoader.Load("res://room1.tscn");
		Spatial newGround = (Spatial)ground.Instance();
		

		AddChild(newGround);
		Room room = (Room)newGround;
		GD.Print(room.GetDoor());
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
