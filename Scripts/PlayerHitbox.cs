using Godot;
using System;

public class PlayerHitbox : Sprite
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";
	public Sprite player; // Player variable.

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		player = (Sprite)GetNode("/root/MILF/Player"); // Get the player.
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(float delta)
	{
		this.Position =  player.Position; 
	}
}
