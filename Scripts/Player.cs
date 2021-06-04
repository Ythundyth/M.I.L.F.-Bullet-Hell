using Godot;
using System;



public class Player : Sprite
{
	public Sprite player; // Player variable.
	public Image image;
	public Vector2 playerPos;
	public Color getPixelColor;
	public Resource playerSprite;
	public ImageTexture imageTexture;
	public float timer;
	public float deltaTime;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		player = (Sprite)GetNode("/root/MILF/Player"); // Get the player.
	}

// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(float delta)
	{
		deltaTime = delta*75;
		
		playerPos = player.GetGlobalPosition();
		this.SetGlobalPosition(new Vector2(player.GetGlobalPosition()));
		float SPEED = 8 * deltaTime; // Player movement speed. Multiplied by 0.707 when moving diagonally so you don't move faster.
		
		//Movement Code
		if (Input.IsKeyPressed((int)KeyList.Right)) {
			SPEED = SPEED*0.5f;
		}
		if (Input.IsActionPressed("up")) {
			if (Input.IsActionPressed("right") || Input.IsActionPressed("left")) {
				this.Position += new Vector2(0, -SPEED*0.707f);
			}
			else {
				this.Position += new Vector2(0, -SPEED);
			}
		}
		if (Input.IsActionPressed("down")) {
			if (Input.IsActionPressed("right") || Input.IsActionPressed("left")) {
				this.Position += new Vector2(0, SPEED*0.707f);
			}
			else {
				this.Position += new Vector2(0, SPEED);
			}
		}
		if (Input.IsActionPressed("left")) {
			if (Input.IsActionPressed("down") || Input.IsActionPressed("up")) {
				this.Position += new Vector2(-SPEED*0.707f, 0);
			}
			else {
			this.Position += new Vector2(-SPEED, 0);
			}
		}
		if (Input.IsActionPressed("right")) {
			if (Input.IsActionPressed("down") || Input.IsActionPressed("up")) {
				this.Position += new Vector2(SPEED*0.707f, 0);
			}
			else {
				this.Position += new Vector2(SPEED, 0);
			}
		}
		
		//Scren Edge Code
		if (this.GlobalPosition.y < 0) {
			this.SetGlobalPosition(new Vector2(this.GlobalPosition.x, 0));
		}
		
		if (this.GlobalPosition.y > 1080) {
			this.SetGlobalPosition(new Vector2(this.GlobalPosition.x, 1080));
		}
		
		if (this.GlobalPosition.x < 980) {
			this.SetGlobalPosition(new Vector2(980, this.GlobalPosition.y));
		}
		
		if (this.GlobalPosition.x > 1920) {
			this.SetGlobalPosition(new Vector2(1920, this.GlobalPosition.y));
		}
	}
}

