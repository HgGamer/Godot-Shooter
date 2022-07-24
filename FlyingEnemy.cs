using Godot;
using System;

public class FlyingEnemy : KinematicBody
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";

	Spatial target;
	Vector3 velocity;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GetTarget();
		SetMeta("type", "enemy");
		Player player = (Player)GetNode("/root/Main/Player");
		player.Connect("DamageDone", this, "onDamage");
	}

	void onDamage(Godot.Object target, float val)
	{
		if(target == this)
        {
			GD.Print("DAMAGED THIS");
		}
		GD.Print("DAMAGED");
	}

	void GetTarget()
	{

		target = (Spatial)GetNode("../Player");
	}

	public override void _PhysicsProcess(float delta)
	{
		if(target == null){
			GD.Print("Target is null");
			return;
		}
		velocity = new Vector3();

		Vector3 distance = (target.Transform.origin - Transform.origin);
		if(distance.Length() >0.4f){
			velocity = distance.Normalized()* 1;
			velocity = MoveAndSlide(velocity);
		}
	
		LookAt(target.Transform.origin,Vector3.Up);
		

	}


//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
