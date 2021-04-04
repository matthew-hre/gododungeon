using Godot;
using System;

public class Player : Node2D
{
	public Vector2 pos = new Vector2();
	
	public void GetInput() 
	{
		pos = GetPosition();
		
		if(Input.IsActionJustPressed("move_right")) {
			pos.x += 8;
		} else if(Input.IsActionJustPressed("move_left")) {
			pos.x -= 8;
		} else if(Input.IsActionJustPressed("move_up")) {
			pos.y -= 8;
		} else if(Input.IsActionJustPressed("move_down")) {
			pos.y += 8;
		}
	}
	
	public override void _PhysicsProcess(float delta) 
	{
		GetInput();
		SetPosition(pos);
	}
}
