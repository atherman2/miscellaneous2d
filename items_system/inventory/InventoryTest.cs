using Godot;
using System;

public partial class InventoryTest : Node2D
{
	public override void _PhysicsProcess(double delta)
	{
		Position += 10 * Vector2.Down * (float) delta;
		GD.Print($"{Position}");
		base._PhysicsProcess(delta);
	}
}
