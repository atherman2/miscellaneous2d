using Godot;
using System;

public partial class InventoryView : Control
{
	public InventorySlot[] inventorySlots;
	[Export] protected PackedScene inventorySlotPackedScene;
	[Export] protected PackedScene itemStackNodePackedScene;
	[Export] protected GridContainer gridContainer;

	public void SetupInventorySlots(int amount)
	{
		inventorySlots = new InventorySlot[amount];
		for(int slotIndex = 0; slotIndex < amount; slotIndex++)
		{
			inventorySlots[slotIndex] = inventorySlotPackedScene.Instantiate<InventorySlot>();
			ItemStackNode itemStackNode = itemStackNodePackedScene.Instantiate<ItemStackNode>();
			inventorySlots[slotIndex].SetItemStackNode(itemStackNode);
			gridContainer.AddChild(inventorySlots[slotIndex]);
		}
	}
	public void ChangeInventorySlotItem(int slotIndex, ItemStack newItemValue)
	{
		inventorySlots[slotIndex].GetItemStackNode().UpdateView(newItemValue);
	}
	public InventorySlot[] GetInventorySlots()
	{
		return inventorySlots;
	}
}
