using Godot;
using System;

public class HitCounterEnemy : Label
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";
	public Spawner spawnerScript; // Get the spawner script.

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		spawnerScript = (Spawner)GetNode("/root/MILF/Spawner"); // Get the spawner script.
		//SetText($"FPS: {Engine.GetFramesPerSecond()}");
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(float delta)
	{
		SetText($"Misses: {spawnerScript.missesEnemy}");  
	}
}
