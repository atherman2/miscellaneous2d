using Godot;
using System;

public partial class ItemStackNode : Node2D
{
	[Export] public ItemStack itemStack;
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
			hoverArea.Monitoring = false;
			sprite.Visible = false;
			nameLabel.Text = "";
			UpdateAmountLabel();
		}
		else
		{
			sprite.Texture = itemStack.item.texture;
			nameLabel.Text = itemStack.item.name;
			UpdateAmountLabel();
		}
	}
}
