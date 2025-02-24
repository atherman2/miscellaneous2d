using Godot;
using System;

[GlobalClass]
public partial class Item : Resource
{
	[Export] public string id, name;
	[Export] public Texture2D texture;
}
