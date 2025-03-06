using Godot;
using System;

[GlobalClass]
public partial class Item : Resource
{
	[Export] public string id, name;
	[Export] public Texture2D texture;
	[Export] public int stackSize = 100;
	[Export] public int size = 10;
}
