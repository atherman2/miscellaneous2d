using Godot;
using System;

public partial class InventorySlot : Panel
{
	[Export] protected CenterContainer centerContainer;
	protected ItemStackNode itemStackNode;
	public ItemStackNode GetItemStackNode()
	{
		return itemStackNode;
	}
	public void SetItemStackNode(ItemStackNode itemStackNode)
	{
		this.itemStackNode = itemStackNode;
		if(itemStackNode != null)
		{
			centerContainer.AddChild(itemStackNode);
		}
	}
}
