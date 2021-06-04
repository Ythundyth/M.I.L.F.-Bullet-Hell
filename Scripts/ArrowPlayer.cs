using Godot;
using System;

public class ArrowPlayer : Sprite
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";
	public float deltaTime;
	public float speed = 10;
	public float myAngleInDegrees;
	public float spawnerDegrees;
	public Spawner spawnerScript; // Get the spawner script.
	public Sprite enemy; // Player variable.
	public bool immune = false;
	public float speedPlayerBullet;
	public float currentAngleIncrement = 0;
	public bool gravity = false;
	public float gravitySpeed;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		spawnerScript = (Spawner)GetNode("/root/MILF/Spawner"); // Get the spawner script.
		spawnerDegrees = spawnerScript.myAngleInDegreesPlayer;
		speedPlayerBullet = spawnerScript.speedPlayerBullet;
		currentAngleIncrement = spawnerScript.bulletAngleIncrementPlayer;
		gravity = spawnerScript.gravityPlayer;
		speed = speedPlayerBullet;
		enemy = (Sprite)GetNode("/root/MILF/Mom"); // Get the player.
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(float delta)
	{
		if (this.GetGlobalPosition().DistanceTo(enemy.GetGlobalPosition()) < 100) {
				enemy.SetGlobalPosition(enemy.Position.MoveToward(this.Position, -10));
				//player.SetProcess(false);
		}
		
		if (this.GetGlobalPosition().DistanceTo(enemy.GetGlobalPosition()) < 10 && immune == false) {
				spawnerScript.missesEnemy += 1;
				immune = true;
				QueueFree();
				//player.Hide();
				//player.SetProcess(false);
		}
		/*
		if (this.GetGlobalPosition().DistanceTo(enemy.GetGlobalPosition()) > 200) {
				enemy.SetGlobalPosition(enemy.Position.MoveToward(new Vector2(480,900), -10));
				//player.SetProcess(false);
		}*/
		
		if (this.GlobalPosition.y < 0) {
			QueueFree();
		}
		
		if (this.GlobalPosition.y > 1080) {
			QueueFree();
		}
		
		if (this.GlobalPosition.x < 0) {
			QueueFree();
		}
		
		if (this.GlobalPosition.x > 960) {
			QueueFree();
		}
		
		//GD.Print(spawnerDegrees); 
		deltaTime = delta*75;
		spawnerDegrees += currentAngleIncrement * deltaTime;
	
		float myAngleInRadians = Mathf.Deg2Rad(spawnerDegrees);
		//float myAngleInRadians = spawnerDegrees + 0 * Mathf.Pi / 180;
		//float myAngleInRadians = myAngleInDegrees + currentAngle * Mathf.PI / 180;
		Vector2 angleVector = new Vector2((float)Mathf.Cos(myAngleInRadians), (float)Mathf.Sin(myAngleInRadians));
		if (gravity == true) 
		{
			myAngleInRadians = Mathf.Rad2Deg(Mathf.Atan2(this.Position.x, 1080) - Mathf.Atan2(angleVector.x, angleVector.y));
			if (gravitySpeed <= speed*2) 
			{
				gravitySpeed += 0.03f;
			}
		}
		Vector2 angleVectorFinal = new Vector2((float)Mathf.Cos(myAngleInRadians), (float)Mathf.Sin(myAngleInRadians));
			
		this.RotationDegrees = spawnerDegrees + 90;
		/*if (gravity == false) 
		{
			this.Position = this.GetGlobalPosition() + new Vector2(angleVector.x * speed * deltaTime, angleVector.y * speed * deltaTime);
		}*/
		this.Position = this.GetGlobalPosition() + new Vector2(angleVector.x * speed * deltaTime, angleVector.y * speed * deltaTime);
		if (gravity == true) 
		{
			this.Position = this.GetGlobalPosition() + new Vector2(angleVectorFinal.x * gravitySpeed * deltaTime, angleVectorFinal.y * gravitySpeed * deltaTime);
		}
		//this.Position = this.GetGlobalPosition() + new Vector2(angleVector.x * speed * deltaTime, angleVector.y * speed * deltaTime);
		//this.Position = this.GetGlobalPosition() + new Vector2(angleVector.x * speed * deltaTime, angleVector.y * speed * deltaTime);
	}
}
