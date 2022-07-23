using Godot;
using System;

public class Health : RichTextLabel
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";
	Player player;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
		player = (Player) GetNode("../../Player");
		player.Connect("HealthChanged", this, "onHealthChange");
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
  public override void _Process(float delta)
  {
	 if(player == null){
		return;
	}
	 //SetText(player.GetHealth().ToString());
  }
	public void onHealthChange(float health)
	{
		SetText(health.ToString());
	}
}





