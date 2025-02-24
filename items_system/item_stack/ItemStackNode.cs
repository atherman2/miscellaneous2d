using Godot;
using System;

public partial class ItemStackNode : Node2D
{
	[Export] protected ItemStack itemStack;
	[Export] protected Sprite2D sprite;
	[Export] protected Label nameLabel, amountLabel;
	[Export] protected Area2D hoverArea;

	public override void _Ready()
	{
		sprite.Texture = itemStack.item.texture;
		nameLabel.Text = itemStack.item.name;
		UpdateAmountLabel();
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
	public void UpdateAmountLabel()
	{
		if(itemStack.amount > 1)

			amountLabel.Text = $"{itemStack.amount}";
		
		else

			amountLabel.Text = "";
	}
	public Item IncreaseItemAmount(int increment)
	{
		return null;
	}
}
