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
		AddRoom(0, 0);
		AddRoom(0, 0);
		AddRoom(1, 1);
	}


	void AddRoom(int door,int door2)
	{
		Spatial lastdoor = lastroom.GetDoor(door);
		PackedScene prefab = (PackedScene)ResourceLoader.Load("res://room1.tscn");
		Spatial instance = (Spatial)prefab.Instance();
		AddChild(instance);
		Spatial newDoor = ((Room)instance).GetDoor(door2);

		//Vector2 direction = (new Vector2(lastdoor.Transform.origin.x, lastdoor.Transform.origin.z) - new Vector2(lastroom.Transform.origin.x, lastroom.Transform.origin.z)).Normalized();
		//Vector2 direction2 = (new Vector2(newDoor.Transform.origin.x, newDoor.Transform.origin.z) - new Vector2(instance.Transform.origin.x, instance.Transform.origin.z)).Normalized();
		//instance.Rotate(Vector3.Up, (Mathf.Pi+ direction2.Angle() - direction.Angle()));
		instance.Translation = new Vector3(lastdoor.GlobalTransform.origin.x +(instance.Transform.origin.x+ newDoor.Transform.origin.x), 0, lastdoor.GlobalTransform.origin.z + (instance.Transform.origin.z+ newDoor.Transform.origin.z));
		
		
		lastroom = (Room)instance;
	}


//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
