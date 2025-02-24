using Godot;
using System;

[GlobalClass]
public partial class Inventory : Resource
{
    [Export] public ItemStack[] itemStacks;
    [Export] public int size;
}
