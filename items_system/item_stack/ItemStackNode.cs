using Godot;
using System;

public partial class ItemStackNode : Node2D
{
	[Export] protected Item itemResource;
	[Export] protected Sprite2D sprite;
	[Export] protected Label nameLabel, amountLabel;
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
	public Item IncreaseItemAmount(int increment)
	{
		return null;
	}
}
