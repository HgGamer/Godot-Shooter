using Godot;
using System;

public class LevelManager : Node
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";

	// Called when the node enters the scene tree for the first time.
	Room lastroom;


	public override void _Ready()
	{
		PackedScene ground = (PackedScene)ResourceLoader.Load("res://room1.tscn");
		Spatial newGround = (Spatial)ground.Instance();
		

		AddChild(newGround);

		lastroom = (Room)newGround;
		AddRoom();
		AddRoom();
	}


	void AddRoom()
	{
		Spatial lastdoor = lastroom.GetDoor(0);
		PackedScene prefab = (PackedScene)ResourceLoader.Load("res://room1.tscn");
		Spatial instance = (Spatial)prefab.Instance();
		AddChild(instance);
		Spatial newDoor = ((Room)instance).GetDoor(2);
		instance.Translation = new Vector3((instance.Transform.origin.x - newDoor.Transform.origin.x) + lastdoor.GlobalTransform.origin.x, 0, (instance.Transform.origin.z - newDoor.Transform.origin.z) + lastdoor.GlobalTransform.origin.z);
		lastroom = (Room)instance;
	}


//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
