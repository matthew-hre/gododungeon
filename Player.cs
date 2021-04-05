using Godot;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

public class Player : Area2D
{
	int tileSize = 8;
	String[] inputs = { "move_right", "move_left", "move_up", "move_down" };
	Vector2[] dirs = { new Vector2(1, 0), new Vector2(-1, 0), new Vector2(0, -1), new Vector2(0, 1) };
	
	public override void _Ready()
	{
		Position = Position.Snapped(new Vector2(8, 8));
	}

	public override void _UnhandledInput(InputEvent @event) {
		if (@event is InputEventKey eventKey)
		{
			for (int i = 0; i < inputs.Length; i++)
			{
				if (eventKey.IsActionPressed(inputs[i]))
				{
					Move(i);
				}
			}
		}
	}

	public void Move(int i)
	{
		RayCast2D ray = ((RayCast2D) GetNode("RayCast2D"));
		ray.CastTo = dirs[i] * tileSize;
		ray.ForceRaycastUpdate();
		if (!ray.IsColliding())
		{
			Position += dirs[i] * tileSize;
		}
	}
}
