using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData : MonoBehaviour
{
    public static List<Item> itemList = new List<Item>();

    void Awake()
    {
        // OUR DATABASE
        itemList.Add(new Item(0, "None", "None", Resources.Load <Sprite>("0"), 0 , 0 , false, false, 0, false, 0, 0, 0, 0, 0, 0));
        itemList.Add(new Item(1, "Axe", "Weapon", Resources.Load<Sprite>("1"), 0, 1, true, false, 0, false, 0, 0, 0, 0, 0, 0));
        itemList.Add(new Item(2, "Revolver", "Weapon", Resources.Load<Sprite>("2"), 0, 1, true, false, 0, false, 0, 0, 0, 0, 0, 0));
        itemList.Add(new Item(3, "Shotgun", "Weapon", Resources.Load<Sprite>("3"), 0, 1, true, false, 0, false, 0, 0, 0, 0, 0, 0));
        itemList.Add(new Item(4, "Meat", "Food", Resources.Load<Sprite>("4"), 0, 10, false, true, 20, false, 0, 0, 0, 0, 0, 0));
        itemList.Add(new Item(5, "Apple", "Food", Resources.Load<Sprite>("5"), 0, 20, false, true, 10, false, 0, 0, 0, 0, 0, 0));
        itemList.Add(new Item(6, "Water", "Water", Resources.Load<Sprite>("6"), 0, 1, false, false, 0, false, 0, 0, 0, 0, 0, 0));
        itemList.Add(new Item(7, "Leather", "Craft", Resources.Load<Sprite>("7"), 0, 10, false, false, 0, false, 0, 0, 0, 0, 0, 0));
        itemList.Add(new Item(8, "Wood", "Craft", Resources.Load<Sprite>("8"), 0, 25, false, false, 0, false, 0, 0, 0, 0, 0, 0));
        itemList.Add(new Item(9, "Rock", "Craft", Resources.Load<Sprite>("9"), 0, 50, false, false, 0, false, 0, 0, 0, 0, 0, 0));
        itemList.Add(new Item(10, "Stick", "Craft", Resources.Load<Sprite>("10"), 0, 50, false, false, 0, false, 0, 0, 0, 0, 0, 0));
        itemList.Add(new Item(11, "Rope", "Craft", Resources.Load<Sprite>("11"), 0, 10, false, false, 0, true, 7, 10, 0, 1, 3, 0));
        itemList.Add(new Item(12, "Gunpowder", "Craft", Resources.Load<Sprite>("12"), 0, 50, false, false, 0, true, 0, 0, 0, 0, 0, 0));
        itemList.Add(new Item(13, "Bullet", "Craft", Resources.Load<Sprite>("13"), 0, 20, false, false, 0, true, 0, 0, 0, 0, 0, 0));
        itemList.Add(new Item(14, "Torch", "Craft", Resources.Load<Sprite>("14"), 0, 1, true, false, 0, true, 10, 12, 0, 1, 5, 0));
    }
}
/*
    public int id;
    public string name;
    public string description;
    public Sprite itemSprite;
    public int stack;
    public int maxStack;
    public bool canUse;
    public bool consumable;
    public int nutritionalValue;
    public bool canBeCraftable;
    public int n1;
    public int n2;
    public int n3;
    public int q1;
    public int q2;
    public int q3;

*/