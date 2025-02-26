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
			inventorySlots[slotIndex].SetItemStackNode(null);
			gridContainer.AddChild(inventorySlots[slotIndex]);
		}
	}
	public void ChangeInventorySlotItem(int slotIndex, ItemStackNode newItemValue)
	{
		newItemValue.UpdateView();
		inventorySlots[slotIndex].SetItemStackNode(newItemValue);
	}
	public void UpdateView()
	{
		for(int slotIndex = 0; slotIndex < inventorySlots.Length; slotIndex++)
		{
			InventorySlot inventorySlot = inventorySlots[slotIndex];
			ItemStackNode itemStackNode = inventorySlot.GetItemStackNode();
			if(itemStackNode != null)
			{
				itemStackNode.UpdateView();
			}
		}
	}
}
