using Godot;
using System;

public partial class InventoryView : Control
{
	public InventorySlot[] inventorySlots;
	[Export] protected PackedScene inventorySlotPackedScene;
	[Export] protected GridContainer gridContainer;

	public void SetupInventorySlots(int amount)
	{
		inventorySlots = new InventorySlot[amount];
		for(int slotIndex = 0; slotIndex < amount; slotIndex++)
		{
			inventorySlots[slotIndex] = inventorySlotPackedScene.Instantiate<InventorySlot>();
			inventorySlots[slotIndex].itemStackNode = null;
			gridContainer.AddChild(inventorySlots[slotIndex]);
		}
	}
	public void ChangeInventorySlotItem(int slotIndex, ItemStackNode newItemValue)
	{
		inventorySlots[slotIndex].AddChild(newItemValue);
		inventorySlots[slotIndex].itemStackNode = newItemValue;
		inventorySlots[slotIndex].itemStackNode.UpdateView();
	}
	public void UpdateView()
	{
		for(int slotIndex = 0; slotIndex < inventorySlots.Length; slotIndex++)
		{
			inventorySlots[slotIndex].itemStackNode.UpdateView();
		}
	}
}
