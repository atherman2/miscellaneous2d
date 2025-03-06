using Godot;
using System;

[GlobalClass]
public partial class ItemStack : Resource
{
    [Export] public Item item;
    [Export] public int amount = 1;

    public static ItemStack ItemStackCopy(ItemStack itemStack)
    {
        ItemStack itemStackCopied = new ItemStack();
        itemStackCopied.item = itemStack.item;
        itemStackCopied.amount = itemStack.amount;
        return itemStackCopied;
    }
}
