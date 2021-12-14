using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class Item
{
    public int id;
    public string name;
    public string description;
    public Sprite itemSprite;
    public int stack;
    public int maxStack;
    public bool canUse;

    public Item()
    {

    }

    public Item(int Id,string Name, string Description, Sprite ItemSprite, int Stack, int MaxStack, bool CanUse)
    {
        id = Id;
        name = Name;
        description = Description;
        itemSprite = ItemSprite;
        stack = Stack;
        maxStack = MaxStack;
        canUse = CanUse;
    }

}
