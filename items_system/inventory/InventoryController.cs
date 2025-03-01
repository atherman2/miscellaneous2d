using Godot;
using System;

public partial class InventoryController : Node2D
{
	[Export] protected InventoryNode inventoryNode;
	[Export] protected InventoryView inventoryView;
	public override void _Ready()
	{
		inventoryView.SetupInventorySlots(inventoryNode.GetSize());
		UpdateInventoryView();

		base._Ready();
	}

	public void UpdateInventoryView()
	{
		for(int itemIndex = 0; itemIndex < inventoryNode.GetSize(); itemIndex++)
		{
			ItemStack item = inventoryNode.GetItemStackAt(itemIndex);
			if(item != null)
			{
				inventoryView.ChangeInventorySlotItem(itemIndex, item);
			}
		}
	}
}
