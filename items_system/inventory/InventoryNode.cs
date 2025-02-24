using Godot;
using System;

public partial class InventoryNode : Node
{
	[Export] protected Inventory inventoryResource;
	
	public ItemStack GetItemStackAt(int itemIndex)
	{
		if(itemIndex < inventoryResource.size)
			
			return inventoryResource.itemStacks[itemIndex];
		
		else

			return null;
	}

	public int GetSize()
	{
		return inventoryResource.size;
	}
}
