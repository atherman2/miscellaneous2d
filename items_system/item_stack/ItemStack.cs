using Godot;
using System;

[GlobalClass]
public partial class ItemStack : Resource
{
    [Export] public Item item;
    [Export] public int amount = 1;
}
