using Godot;
using System;

public class FlyingEnemy : KinematicBody
{
	Spatial target;
	Vector3 velocity;
	float health = 100;

	bool isDead()
    {
		return (health <= 0);
    }

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
			health -= val;
			
		}
		GD.Print("DAMAGED");
	}

	void GetTarget()
	{

		target = (Spatial)GetNode("../Player");
	}

	public override void _PhysicsProcess(float delta)
	{
        if (isDead())
        {
			velocity = new Vector3();
			velocity.y += -98f * delta;
			velocity = MoveAndSlide(velocity, Vector3.Up);
			return;
		}

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
}