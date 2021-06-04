using Godot;
using System;

public class Mom : Sprite
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(float delta)
	{
		//Scren Edge Code
		if (this.GlobalPosition.y < 0) {
			this.SetGlobalPosition(new Vector2(this.GlobalPosition.x, 0));
		}
		
		if (this.GlobalPosition.y > 900) {
			this.SetGlobalPosition(new Vector2(this.GlobalPosition.x, 900));
		}
		
		if (this.GlobalPosition.x < 0) {
			this.SetGlobalPosition(new Vector2(0, this.GlobalPosition.y));
		}
		
		if (this.GlobalPosition.x > 960) {
			this.SetGlobalPosition(new Vector2(960, this.GlobalPosition.y));
		}  
		/*
		if (this.GetGlobalPosition().DistanceTo(new Vector2(0,900)) < 300) {
				this.SetGlobalPosition(this.Position.MoveToward(new Vector2(0,1080), -10));
				//player.SetProcess(false);
		}
		
		if (this.GetGlobalPosition().DistanceTo(new Vector2(960,900)) < 300) {
				this.SetGlobalPosition(this.Position.MoveToward(new Vector2(960,1080), -10));
				//player.SetProcess(false);
		}
		
		if (this.GetGlobalPosition().DistanceTo(new Vector2(480,900)) < 300) {
				this.SetGlobalPosition(this.Position.MoveToward(new Vector2(960,1080), -10));
				//player.SetProcess(false);
		}
		*/
		
		this.SetGlobalPosition(this.Position.MoveToward(new Vector2(480,900), +1));
		//player.SetProcess(false);
	}
}
