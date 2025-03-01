using Godot;
using System;

public partial class ItemStackNode : Control
{
	[Export] protected Sprite2D sprite;
	[Export] protected Label nameLabel, amountLabel;
	[Export] protected TextureButton hoverButton;

	public override void _Ready()
	{
		hoverButton.MouseEntered += OnMouseEntered;
		hoverButton.MouseExited += OnMouseExited;

		base._Ready();
	}
	public void OnMouseEntered()
	{
		nameLabel.Visible = true;
	}
	public void OnMouseExited()
	{
		nameLabel.Visible = false;
	}
	public void UpdateView(ItemStack itemStack)
	{
		if(itemStack.item.id == "empty")
		{
			hoverButton.Disabled = true;
		}
		else
		{
			hoverButton.Disabled = false;
		}
		nameLabel.Text = itemStack.item.name;
		if(itemStack.amount > 1)
		{	
			amountLabel.Text = $"{itemStack.amount}";
		}
		else
		{
			amountLabel.Text = "";
		}
		sprite.Texture = itemStack.item.texture;
	}
}
