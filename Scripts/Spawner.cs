using Godot;
using System;

public class Spawner : Node2D
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";
	public float timer = 0;
	public float deltaTime;
	public float fireTimer = 0;
	public float fireTimerPlayer = 0;
	public float bulletCount;
	public float bulletCountPlayer;
	public float myAngleInDegrees = 1;
	public float myAngleInDegreesPlayer = 1;
	public float misses = 0;
	public float missesEnemy = 0;
	public float speedEnemyBullet = 10;
	public float speedPlayerBullet = 10;
	public PackedScene enemyArrow = ResourceLoader.Load("res://Scenes/ArrowEnemy.tscn") as PackedScene;
	public PackedScene playerArrow = ResourceLoader.Load("res://Scenes/ArrowPlayer.tscn") as PackedScene;
	public Godot.Collections.Array Bullets;
	public float angleIncrement;
	public float bulletAngleIncrementPlayer;
	public float bulletAngleIncrementEnemy;
	public bool gravityPlayer = false;
	public bool gravityEnemy = false;
	
	// For generating random numbers.
	Random rnd = new Random();
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(float delta)
	{
		// Restart the song with R
		if (Input.IsKeyPressed((int)KeyList.R)) {
			GetTree().ReloadCurrentScene();
		}
		
		//Exit the game with Escape.
		if (Input.IsKeyPressed((int)KeyList.Escape)) {
			GetTree().Quit();
		}
		timer += delta;
		deltaTime += delta;
		angleIncrement += 75 * delta;
		//GD.Print(timer);  
	
		
		//Attack 1 Enemy
		if ((timer >= 2f) && (timer <= 7f)) 
		{
			fireTimer = 0;
			fireTimerPlayer += delta;
			if ((fireTimerPlayer >= 0.06f)) 
			{
				speedPlayerBullet = 15;
				bulletCountPlayer = 10;
				int randomAnglePlayer = rnd.Next(0, 360);
				for (int k = 0; k < bulletCountPlayer; k++)
				{
						myAngleInDegreesPlayer = randomAnglePlayer + k * (360 / bulletCountPlayer);
						Godot.Sprite playerArrowUsed = playerArrow.Instance() as Godot.Sprite;
						AddChild(playerArrowUsed);
						playerArrowUsed.SetPosition(new Vector2(480, 100));
						//enemyArrowUsed.SetRotationDegrees(0 + i *(360/bulletCount)); // Set the angle.
						fireTimerPlayer = 0;
					}
			}
		}
		//Attack 1 Player
		if ((timer >= 7f) && (timer <= 13f)) 
		{
			fireTimer += delta;
			fireTimerPlayer = 0;
			if ((fireTimer >= 0.06f)) {
				speedEnemyBullet = 15;
				bulletCount = 10;
				int randomAngleEnemy = rnd.Next(0, 360);
				for (int i = 0; i < bulletCount; i++)
					{
						myAngleInDegrees = randomAngleEnemy + i * (360 / bulletCount);
						Godot.Sprite enemyArrowUsed = enemyArrow.Instance() as Godot.Sprite;
						AddChild(enemyArrowUsed);
						enemyArrowUsed.SetPosition(new Vector2(1440, 100));
						//enemyArrowUsed.SetRotationDegrees(0 + i *(360/bulletCount)); // Set the angle.
						fireTimer = 0;
					}
			}
		}
		//Attack 2 Enemy
		if ((timer >= 13f) && (timer <= 18f)) 
		{
			fireTimer = 0;
			fireTimerPlayer += delta;
			if ((fireTimerPlayer >= 0.02f)) 
			{
				int randomX = rnd.Next(0, 960);
				bulletCountPlayer = 10;
				myAngleInDegreesPlayer = 90;//randomAnglePlayer + k * (360 / bulletCountPlayer);
				Godot.Sprite playerArrowUsed = playerArrow.Instance() as Godot.Sprite;
				AddChild(playerArrowUsed);
				playerArrowUsed.SetPosition(new Vector2(randomX, 0));
				//enemyArrowUsed.SetRotationDegrees(0 + i *(360/bulletCount)); // Set the angle.
				fireTimerPlayer = 0;
			}
		}
		//Attack 2 Player
		if ((timer >= 18f) && (timer <= 24f)) 
		{
			fireTimer += delta;
			fireTimerPlayer = 0;
			if ((fireTimer >= 0.02f)) 
			{
				int randomX = rnd.Next(960, 1920);
				bulletCount = 10;
				myAngleInDegrees = 90;//randomAnglePlayer + k * (360 / bulletCountPlayer);
				Godot.Sprite enemyArrowUsed = enemyArrow.Instance() as Godot.Sprite;
				AddChild(enemyArrowUsed);
				enemyArrowUsed.SetPosition(new Vector2(randomX, 0));
				//enemyArrowUsed.SetRotationDegrees(0 + i *(360/bulletCount)); // Set the angle.
				fireTimer = 0;
			}
		}
		//Attack 3 Enemy
		if ((timer >= 24f) && (timer <= 29f)) 
		{
			fireTimer = 0;
			fireTimerPlayer += delta;
			if ((fireTimerPlayer >= 0.02f)) 
			{
				int randomY = rnd.Next(0, 1080);
				bulletCountPlayer = 10;
				myAngleInDegreesPlayer = 0;//randomAnglePlayer + k * (360 / bulletCountPlayer);
				Godot.Sprite playerArrowUsed = playerArrow.Instance() as Godot.Sprite;
				AddChild(playerArrowUsed);
				playerArrowUsed.SetPosition(new Vector2(0, randomY));
				//enemyArrowUsed.SetRotationDegrees(0 + i *(360/bulletCount)); // Set the angle.
				fireTimerPlayer = 0;
			}
		}
		//Attack 3 Player
		if ((timer >= 29f) && (timer <= 34f)) 
		{
			fireTimer += delta;
			fireTimerPlayer = 0;
			if ((fireTimer >= 0.02f)) 
			{
				int randomY = rnd.Next(0, 1080);
				bulletCount = 10;
				myAngleInDegrees = 180;//randomAnglePlayer + k * (360 / bulletCountPlayer);
				Godot.Sprite enemyArrowUsed = enemyArrow.Instance() as Godot.Sprite;
				AddChild(enemyArrowUsed);
				enemyArrowUsed.SetPosition(new Vector2(1920, randomY));
				//enemyArrowUsed.SetRotationDegrees(0 + i *(360/bulletCount)); // Set the angle.
				fireTimer = 0;
			}
		}
		//Attack 4 Enemy
		if ((timer >= 34f) && (timer <= 39f)) 
		{
			speedPlayerBullet = 10;
			fireTimer = 0;
			fireTimerPlayer += delta;
			if ((fireTimerPlayer >= 0.08f)) 
			{
				bulletCountPlayer = 10;
				for (int k = 0; k < bulletCountPlayer; k++)
				{
						myAngleInDegreesPlayer = angleIncrement + k * (360 / bulletCountPlayer);
						Godot.Sprite playerArrowUsed = playerArrow.Instance() as Godot.Sprite;
						AddChild(playerArrowUsed);
						playerArrowUsed.SetPosition(new Vector2(480, 100));
						//enemyArrowUsed.SetRotationDegrees(0 + i *(360/bulletCount)); // Set the angle.
						fireTimerPlayer = 0;
				}
				for (int k = 0; k < bulletCountPlayer; k++)
				{
						myAngleInDegreesPlayer = -angleIncrement + k * (360 / bulletCountPlayer);
						Godot.Sprite playerArrowUsed = playerArrow.Instance() as Godot.Sprite;
						AddChild(playerArrowUsed);
						playerArrowUsed.SetPosition(new Vector2(480, 100));
						//enemyArrowUsed.SetRotationDegrees(0 + i *(360/bulletCount)); // Set the angle.
						fireTimerPlayer = 0;
				}
			}
		}
		//Attack 4 Player
		if ((timer >= 39f) && (timer <= 45f)) 
		{
			fireTimer += delta;
			fireTimerPlayer = 0;
			speedEnemyBullet = 10;
			if ((fireTimer >= 0.08f)) {
				bulletCount = 10;
				int randomAngleEnemy = rnd.Next(0, 360);
				for (int i = 0; i < bulletCount; i++)
					{
						myAngleInDegrees = angleIncrement + i * (360 / bulletCount);
						Godot.Sprite enemyArrowUsed = enemyArrow.Instance() as Godot.Sprite;
						AddChild(enemyArrowUsed);
						enemyArrowUsed.SetPosition(new Vector2(1440, 100));
						//enemyArrowUsed.SetRotationDegrees(0 + i *(360/bulletCount)); // Set the angle.
						fireTimer = 0;
				}
				for (int i = 0; i < bulletCount; i++)
					{
						myAngleInDegrees = -angleIncrement + i * (360 / bulletCount);
						Godot.Sprite enemyArrowUsed = enemyArrow.Instance() as Godot.Sprite;
						AddChild(enemyArrowUsed);
						enemyArrowUsed.SetPosition(new Vector2(1440, 100));
						//enemyArrowUsed.SetRotationDegrees(0 + i *(360/bulletCount)); // Set the angle.
						fireTimer = 0;
				}
			}
		}
		//Attack 5 Enemy
		if ((timer >= 45f) && (timer <= 50f)) 
		{
			fireTimer = 0;
			fireTimerPlayer += delta;
			if ((fireTimerPlayer >= 0.166f)) 
			{
				bulletCountPlayer = 10;
				int randomAnglePlayer = rnd.Next(0, 360);
				for (int k = 0; k < bulletCountPlayer; k++)
				{
						bulletAngleIncrementPlayer = 1;
						myAngleInDegreesPlayer = randomAnglePlayer + k * (360 / bulletCountPlayer);
						Godot.Sprite playerArrowUsed = playerArrow.Instance() as Godot.Sprite;
						AddChild(playerArrowUsed);
						playerArrowUsed.SetPosition(new Vector2(480, 100));
						//enemyArrowUsed.SetRotationDegrees(0 + i *(360/bulletCount)); // Set the angle.
						fireTimerPlayer = 0;
				}
				for (int k = 0; k < bulletCountPlayer; k++)
				{
						bulletAngleIncrementPlayer = -1;
						myAngleInDegreesPlayer = randomAnglePlayer + k * (360 / bulletCountPlayer);
						Godot.Sprite playerArrowUsed = playerArrow.Instance() as Godot.Sprite;
						AddChild(playerArrowUsed);
						playerArrowUsed.SetPosition(new Vector2(480, 100));
						//enemyArrowUsed.SetRotationDegrees(0 + i *(360/bulletCount)); // Set the angle.
						fireTimerPlayer = 0;
				}
			}
		}
		//Attack 5 Player
		if ((timer >= 50f) && (timer <= 55f)) 
		{
			fireTimer += delta;
			fireTimerPlayer = 0;
			if ((fireTimer >= 0.166f)) {
				bulletCount = 10;
				int randomAngleEnemy = rnd.Next(0, 360);
				for (int i = 0; i < bulletCount; i++)
					{
						bulletAngleIncrementEnemy = 1;
						myAngleInDegrees = randomAngleEnemy + i * (360 / bulletCount);
						Godot.Sprite enemyArrowUsed = enemyArrow.Instance() as Godot.Sprite;
						AddChild(enemyArrowUsed);
						enemyArrowUsed.SetPosition(new Vector2(1440, 100));
						//enemyArrowUsed.SetRotationDegrees(0 + i *(360/bulletCount)); // Set the angle.
						fireTimer = 0;
					}
				for (int i = 0; i < bulletCount; i++)
					{
						bulletAngleIncrementEnemy = -1;
						myAngleInDegrees = randomAngleEnemy + i * (360 / bulletCount);
						Godot.Sprite enemyArrowUsed = enemyArrow.Instance() as Godot.Sprite;
						AddChild(enemyArrowUsed);
						enemyArrowUsed.SetPosition(new Vector2(1440, 100));
						//enemyArrowUsed.SetRotationDegrees(0 + i *(360/bulletCount)); // Set the angle.
						fireTimer = 0;
					}
			}
		}
		//Attack 6 Enemy
		if ((timer >= 55f) && (timer <= 61f)) 
		{
			bulletAngleIncrementPlayer = 0;
			fireTimer = 0;
			fireTimerPlayer += delta;
			if ((fireTimerPlayer >= 0.08f)) 
			{
				bulletCountPlayer = 10;
				int randomAnglePlayer = rnd.Next(0, 360);
				for (int k = 0; k < bulletCountPlayer; k++)
				{
						myAngleInDegreesPlayer = randomAnglePlayer + k * (360 / bulletCountPlayer);
						Godot.Sprite playerArrowUsed = playerArrow.Instance() as Godot.Sprite;
						AddChild(playerArrowUsed);
						playerArrowUsed.SetPosition(new Vector2(240, 100));
						//enemyArrowUsed.SetRotationDegrees(0 + i *(360/bulletCount)); // Set the angle.
						fireTimerPlayer = 0;
				}
				
				for (int k = 0; k < bulletCountPlayer; k++)
				{
						myAngleInDegreesPlayer = randomAnglePlayer + k * (360 / bulletCountPlayer);
						Godot.Sprite playerArrowUsed = playerArrow.Instance() as Godot.Sprite;
						AddChild(playerArrowUsed);
						playerArrowUsed.SetPosition(new Vector2(720, 100));
						//enemyArrowUsed.SetRotationDegrees(0 + i *(360/bulletCount)); // Set the angle.
						fireTimerPlayer = 0;
				}
			}
		}
		//Attack 6 Player
		if ((timer >= 61f) && (timer <= 66f)) 
		{
			bulletAngleIncrementEnemy = 0;
			fireTimer += delta;
			//fireTimerPlayer = 0;
			if ((fireTimer >= 0.08f)) {
				bulletCount = 10;
				int randomAngleEnemy = rnd.Next(0, 360);
				for (int i = 0; i < bulletCount; i++)
					{
						myAngleInDegrees = randomAngleEnemy + i * (360 / bulletCount);
						Godot.Sprite enemyArrowUsed = enemyArrow.Instance() as Godot.Sprite;
						AddChild(enemyArrowUsed);
						enemyArrowUsed.SetPosition(new Vector2(1200, 100));
						//enemyArrowUsed.SetRotationDegrees(0 + i *(360/bulletCount)); // Set the angle.
						fireTimer = 0;
					}
				for (int i = 0; i < bulletCount; i++)
					{
						myAngleInDegrees = randomAngleEnemy + i * (360 / bulletCount);
						Godot.Sprite enemyArrowUsed = enemyArrow.Instance() as Godot.Sprite;
						AddChild(enemyArrowUsed);
						enemyArrowUsed.SetPosition(new Vector2(1680, 100));
						//enemyArrowUsed.SetRotationDegrees(0 + i *(360/bulletCount)); // Set the angle.
						fireTimer = 0;
					}
			}
		}
		//Attack 7 Enemy
		if ((timer >= 66f) && (timer <= 72f)) 
		{
			speedPlayerBullet = 15;
			//fireTimer = 0;
			fireTimerPlayer += delta;
			if ((fireTimerPlayer >= 0.08f)) 
			{
				bulletCountPlayer = 10;
				int randomAnglePlayer = rnd.Next(0, 360);
				for (int k = 0; k < bulletCountPlayer; k++)
				{
						myAngleInDegreesPlayer = randomAnglePlayer + k * (360 / bulletCountPlayer);
						Godot.Sprite playerArrowUsed = playerArrow.Instance() as Godot.Sprite;
						AddChild(playerArrowUsed);
						playerArrowUsed.SetPosition(new Vector2(480, 100));
						//enemyArrowUsed.SetRotationDegrees(0 + i *(360/bulletCount)); // Set the angle.
						fireTimerPlayer = 0;
					}
			}
		}
		//Attack 7 Player
		//if ((timer >= 72f) && (timer <= 87f)) 
		if ((timer >= 72f) && (timer <= 76f)) 
		{
			speedEnemyBullet = 15;
			fireTimer += delta;
			//fireTimerPlayer += delta;
			if ((fireTimer >= 0.08f)) {
				bulletCount = 10;
				int randomAngleEnemy = rnd.Next(0, 360);
				for (int i = 0; i < bulletCount; i++)
					{
						myAngleInDegrees = randomAngleEnemy + i * (360 / bulletCount);
						Godot.Sprite enemyArrowUsed = enemyArrow.Instance() as Godot.Sprite;
						AddChild(enemyArrowUsed);
						enemyArrowUsed.SetPosition(new Vector2(1440, 100));
						//enemyArrowUsed.SetRotationDegrees(0 + i *(360/bulletCount)); // Set the angle.
						fireTimer = 0;
					}
			}
		}
		//Attack 8 Enemy
		//if ((timer >= 76f) && (timer <= 103f)) 
		if ((timer >= 76f) && (timer <= 87f)) 
		{
			//fireTimer += 0;
			speedPlayerBullet = 10;
			fireTimerPlayer += delta;
			if ((fireTimerPlayer >= 0.01f)) 
			{
				bulletCountPlayer = 4;
				int randomAnglePlayer = rnd.Next(0, 360);
				for (int k = 0; k < bulletCountPlayer; k++)
				{
						myAngleInDegreesPlayer = randomAnglePlayer + k * (10 / bulletCountPlayer);
						Godot.Sprite playerArrowUsed = playerArrow.Instance() as Godot.Sprite;
						AddChild(playerArrowUsed);
						playerArrowUsed.SetPosition(new Vector2(480, 100));
						//enemyArrowUsed.SetRotationDegrees(0 + i *(360/bulletCount)); // Set the angle.
						fireTimerPlayer = 0;
					}
			}
		}
		
		//Attack 7-2 Player
		//if ((timer >= 72f) && (timer <= 87f)) 
		if ((timer >= 76f) && (timer <= 87f)) 
		{
			speedEnemyBullet = 10;
			fireTimer += delta;
			//fireTimerPlayer += delta;
			if ((fireTimer >= 0.01f)) {
				bulletCount = 4;
				int randomAngleEnemy = rnd.Next(0, 360);
				for (int i = 0; i < bulletCount; i++)
					{
						myAngleInDegrees = randomAngleEnemy + i * (10 / bulletCount);
						Godot.Sprite enemyArrowUsed = enemyArrow.Instance() as Godot.Sprite;
						AddChild(enemyArrowUsed);
						enemyArrowUsed.SetPosition(new Vector2(1440, 100));
						//enemyArrowUsed.SetRotationDegrees(0 + i *(360/bulletCount)); // Set the angle.
						fireTimer = 0;
					}
			}
		}
		
		//Attack 8-2 Enemy
		//if ((timer >= 76f) && (timer <= 103f)) 
		if ((timer >= 87f) && (timer <= 103f)) 
		{
			//fireTimer += 0;
			speedPlayerBullet = 10;
			fireTimerPlayer += delta;
			if ((fireTimerPlayer >= 0.12f)) 
			{
				bulletCountPlayer = 10;
				int randomAnglePlayer = rnd.Next(0, 360);
				for (int k = 0; k < bulletCountPlayer; k++)
				{
						myAngleInDegreesPlayer = angleIncrement + k * (360 / bulletCountPlayer);
						Godot.Sprite playerArrowUsed = playerArrow.Instance() as Godot.Sprite;
						AddChild(playerArrowUsed);
						playerArrowUsed.SetPosition(new Vector2(240, 100));
						//enemyArrowUsed.SetRotationDegrees(0 + i *(360/bulletCount)); // Set the angle.
						fireTimerPlayer = 0;
				}
				for (int k = 0; k < bulletCountPlayer; k++)
				{
						myAngleInDegreesPlayer = -angleIncrement + k * (360 / bulletCountPlayer);
						Godot.Sprite playerArrowUsed = playerArrow.Instance() as Godot.Sprite;
						AddChild(playerArrowUsed);
						playerArrowUsed.SetPosition(new Vector2(720, 100));
						//enemyArrowUsed.SetRotationDegrees(0 + i *(360/bulletCount)); // Set the angle.
						fireTimerPlayer = 0;
				}
			}
		}
		
		//Attack 8 Player
		if ((timer >= 93f) && (timer <= 98f)) 
		{
			fireTimer += delta;
			//fireTimerPlayer += 0;
			if ((fireTimer >= 0.12f)) {
				bulletCount = 10;
				int randomAngleEnemy = rnd.Next(0, 360);
				for (int i = 0; i < bulletCount; i++)
				{
						myAngleInDegrees = angleIncrement + i * (360 / bulletCount);
						Godot.Sprite enemyArrowUsed = enemyArrow.Instance() as Godot.Sprite;
						AddChild(enemyArrowUsed);
						enemyArrowUsed.SetPosition(new Vector2(1200, 100));
						//enemyArrowUsed.SetRotationDegrees(0 + i *(360/bulletCount)); // Set the angle.
						fireTimer = 0;
				}
				for (int i = 0; i < bulletCount; i++)
				{
						myAngleInDegrees = -angleIncrement + i * (360 / bulletCount);
						Godot.Sprite enemyArrowUsed = enemyArrow.Instance() as Godot.Sprite;
						AddChild(enemyArrowUsed);
						enemyArrowUsed.SetPosition(new Vector2(1680, 100));
						//enemyArrowUsed.SetRotationDegrees(0 + i *(360/bulletCount)); // Set the angle.
						fireTimer = 0;
				}
			}
		}
		//Attack 9 Player
		if ((timer >= 103f) && (timer <= 109f)) 
		{
			fireTimer += delta;
			fireTimerPlayer = 0;
			if ((fireTimer >= 0.166f)) {
				bulletCount = 10;
				int randomAngleEnemy = rnd.Next(0, 360);
				for (int i = 0; i < bulletCount; i++)
					{
						myAngleInDegrees = randomAngleEnemy + i * (360 / bulletCount);
						Godot.Sprite enemyArrowUsed = enemyArrow.Instance() as Godot.Sprite;
						AddChild(enemyArrowUsed);
						enemyArrowUsed.SetPosition(new Vector2(1440, 100));
						//enemyArrowUsed.SetRotationDegrees(0 + i *(360/bulletCount)); // Set the angle.
						fireTimer = 0;
					}
			}
		}
		//Attack 9 Enemy
		if ((timer >= 109f) && (timer <= 114f)) 
		{
			speedPlayerBullet = 10;
			fireTimer = 0;
			gravityPlayer = true;
			fireTimerPlayer += delta;
			if ((fireTimerPlayer >= 0.166f)) 
			{
				bulletCountPlayer = 10;
				int randomAnglePlayer = rnd.Next(0, 360);
				for (int k = 0; k < bulletCountPlayer; k++)
				{
						myAngleInDegreesPlayer = randomAnglePlayer + k * (360 / bulletCountPlayer);
						float myAngleInRadians = Mathf.Deg2Rad(myAngleInDegreesPlayer);
						Godot.Sprite playerArrowUsed = playerArrow.Instance() as Godot.Sprite;
						AddChild(playerArrowUsed);
						playerArrowUsed.SetPosition(new Vector2(480, 100));
						//playerArrowUsed.SetPosition(new Vector2(480 + 200 * Mathf.Cos(myAngleInRadians), 100 + 200 * -Mathf.Sin(myAngleInRadians)));
						//enemyArrowUsed.SetRotationDegrees(0 + i *(360/bulletCount)); // Set the angle.
						fireTimerPlayer = 0;
				}
			}
		}
		//Attack 10 Player
		if ((timer >= 114f) && (timer <= 120f)) 
		{
			speedEnemyBullet = 10;
			fireTimer += delta;
			gravityEnemy = true;
			fireTimerPlayer = 0;
			if ((fireTimer >= 0.166f)) {
				bulletCount = 10;
				int randomAngleEnemy = rnd.Next(0, 360);
				for (int i = 0; i < bulletCount; i++)
					{
						myAngleInDegrees = randomAngleEnemy + i * (360 / bulletCount);
						float myAngleInRadians = Mathf.Deg2Rad(myAngleInDegrees);
						Godot.Sprite enemyArrowUsed = enemyArrow.Instance() as Godot.Sprite;
						AddChild(enemyArrowUsed);
						enemyArrowUsed.SetPosition(new Vector2(1440, 100));
						//enemyArrowUsed.SetPosition(new Vector2(1440 + 200 * Mathf.Cos(myAngleInRadians), 100 + 200 * -Mathf.Sin(myAngleInRadians)));
						//enemyArrowUsed.SetRotationDegrees(0 + i *(360/bulletCount)); // Set the angle.
						fireTimer = 0;
				}
			}
		}
	}
}
