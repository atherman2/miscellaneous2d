using Godot;
using System;

public partial class ItemNode : Node2D
{
	[Export] protected Item itemResource;
	[Export] protected Sprite2D sprite;
	[Export] protected Label nameLabel;
	[Export] protected Area2D hoverArea;

	public override void _Ready()
	{
		nameLabel.Text = itemResource.name;
		sprite.Texture = itemResource.texture;
		hoverArea.MouseEntered += OnHoverAreaMouseEntered;
		hoverArea.MouseExited += OnHoverAreaMouseExited;

		base._Ready();
	}
	public void OnHoverAreaMouseEntered()
	{
		nameLabel.Visible = true;
	}
	public void OnHoverAreaMouseExited()
	{
		nameLabel.Visible = false;
	}
}
