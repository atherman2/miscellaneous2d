using Godot;
using System;

public partial class ItemStackNode : Control
{
	[Export] public ItemStack itemStack;
	[Export] protected Sprite2D sprite;
	[Export] protected Label nameLabel, amountLabel;
	[Export] protected TextureButton hoverButton;

	public override void _Ready()
	{
		sprite.Texture = itemStack.item.texture;
		nameLabel.Text = itemStack.item.name;
		UpdateAmountLabel();
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
	public void UpdateAmountLabel()
	{
		if(itemStack.amount > 1)

			amountLabel.Text = $"{itemStack.amount}";
		
		else

			amountLabel.Text = "";
	}
	public ItemStack IncreaseAmount(int increment)
	{
		if((itemStack.amount + increment) > itemStack.item.stackSize)
		{
			ItemStack leftOver = new();
			leftOver.item = itemStack.item;
			leftOver.amount = itemStack.amount + increment - itemStack.item.stackSize;
			SetAmount(itemStack.item.stackSize);
			return leftOver;
		}
		else
		{
			SetAmount(itemStack.amount + increment);
			return null;
		}
	}
	protected void SetAmount(int newAmount)
	{
		itemStack.amount = newAmount;
		UpdateAmountLabel();
	}
	public void UpdateView()
	{
		if(itemStack.item.id == "empty")
		{
			sprite.Visible = false;
			nameLabel.Text = "";
			UpdateAmountLabel();
		}
		else
		{
			sprite.Visible = true;
			sprite.Texture = itemStack.item.texture;
			nameLabel.Text = itemStack.item.name;
			UpdateAmountLabel();
		}
	}
}
