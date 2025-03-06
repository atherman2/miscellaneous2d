using Godot;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

public partial class Storage : Node
{
    [Signal] public delegate void StorageChangedEventHandler();
    protected List<ItemStack> items;
    protected int sizeAvailable, sizeCapacity;

    public List<ItemStack> GetItems()
    {
        return items;
    }
    public void LoadItems(List<ItemStack> items)
    {
        if(this.items.Count == 0)
        {
            this.items = items;
        }
        else
        {
            throw new WarningException("Trying to load a non-empty storage.");
        }
    }
    public ItemStack AddItem(ItemStack newItemStack)
    {
        int newItemStackSize = newItemStack.amount * newItemStack.item.size;
        int amountAdded, amountLeft;
        if(sizeAvailable >= newItemStackSize)
        {
            sizeAvailable -= newItemStackSize;
            amountAdded = newItemStack.amount;
            amountLeft = 0;
        }
        else
        {
            amountAdded = sizeAvailable/newItemStack.item.size;
            amountLeft = newItemStack.amount - amountAdded;
        }
        ItemStack correspondentItem = FindItemStackBasedOnItem(newItemStack.item);
        if(correspondentItem != null)
        {
            correspondentItem.amount += amountAdded;
        }
        else
        {
            ItemStack itemStackAdded = ItemStack.ItemStackCopy(newItemStack);
            itemStackAdded.amount = amountAdded;
            items.Add(itemStackAdded);
        }
        if(amountLeft > 0)
        {
            ItemStack itemStackLeft = new ItemStack();
            itemStackLeft.item = newItemStack.item;
            itemStackLeft.amount = amountLeft;
            return itemStackLeft;
        }
        else
        {
            return null;
        }
    }
    public ItemStack FindItemStackBasedOnItem(Item item)
    {
        ItemStack correspondentItem = null;
        foreach(ItemStack itemStack in items)
        {
            if(itemStack.item == item)
            {
                correspondentItem = itemStack;
            }
        }
        return correspondentItem;
    }
}
