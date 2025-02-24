using Godot;
using System;

public partial class InventoryController : Node2D
{
	[Export] protected InventoryNode inventoryNode;
	[Export] protected InventoryView inventoryView;
	[Export] protected PackedScene itemStackPackedScene;

	public override void _Ready()
	{
		inventoryView.SetupInventorySlots(inventoryNode.GetSize());

		base._Ready();
	}

	public void LoadInventoryView()
	{
		for(int itemIndex = 0; itemIndex < inventoryNode.GetSize(); itemIndex++)
		{
			ItemStack itemStack = inventoryNode.GetItemStackAt(itemIndex); 
			if(itemStack != null)
			{
				ItemStackNode itemStackNode = itemStackPackedScene.Instantiate<ItemStackNode>();
				itemStackNode.itemStack = itemStack;
				inventoryView.ChangeInventorySlotItem(itemIndex, itemStackNode);
			}
		}
	}
}
