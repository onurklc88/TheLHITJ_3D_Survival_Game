using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public List<Item> ourInventory = new List<Item>();

    public List<Item> draggedItem = new List<Item>();

    KeyCode[] hotbarKeys = new KeyCode[] { KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3, KeyCode.Alpha4, KeyCode.Alpha5, KeyCode.Alpha6 };

    public static Inventory inv;

    public int slotsNumber;

    public GameObject x;
    public int n;
    public int a;
    public int b;
   
    public int holdSlotNumber;

    public int rest;
    public bool shift;
    public bool ctrl;
    public bool isOpen;
    public bool inventoryOpen;

    //weapon open checker
    public bool axeOpen;
    public bool shotgunOpen;
    public bool revolverOpen;


    public int slotTemporary;

    public GameObject Camera;
    public GameObject InventorySlots;
    public GameObject[] HotbarSlots;
    public GameObject[] HotbarItems;
    public Image[] slot;
    public Sprite[] slotSprite;
    public Text[] stackText;
    public int[] slotStack;


    private void Awake()
    {
        inv = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        ourInventory[4] = ItemData.itemList[4];
        slotStack[4] = 5;
        ourInventory[5] = ItemData.itemList[4];
        slotStack[5] = 3;
    }

    // Update is called once per frame
    void Update()
    {
        closeInventory();
        Hotbar();
        for (int i=0; i < slotsNumber; i++)
        {
            if(slotStack[i] == 0)
            {
                ourInventory[i] = ItemData.itemList[0];
            }
        }



        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            shift = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            shift = false;
        }
        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            ctrl = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            ctrl = false;
        }


        for (int i=0; i < slotsNumber; i++)
        {
            if (ourInventory[i].id == 0)
            {
                stackText[i].text = "";
            }
            else
            {
                stackText[i].text = "" + slotStack[i];
            }
        }



        for(int i=0; i<slotsNumber; i++)
        {
            slot[i].sprite = slotSprite[i];
        }
        for(int i=0; i<slotsNumber; i++)
        {
            slotSprite[i] = ourInventory[i].itemSprite;
            
        }



        if (PickItem.y != null)
        {
            x = PickItem.y;
            n = x.GetComponent<ThisItem>().thisId;
        }
        else
        {
            x = null;
        }
        
        if(PickItem.pick == true)
        {
            for(int i = 0; i < slotsNumber; i++)
            {
                if(ourInventory[i].id == n)
                {
                    if(slotStack[i] == ourInventory[i].maxStack)
                    {
                        continue;
                    }
                    else
                    {
                        slotStack[i] += 1;
                        i = slotsNumber;
                        PickItem.pick = false;
                    }
                 
                }
            }


            for(int i=0; i<slotsNumber; i++)
            {
                if (ourInventory[i].id == 0 && PickItem.pick == true)
                {
                    ourInventory[i] = ItemData.itemList[n];
                    slotStack[i] += 1;
                    PickItem.pick = false;

                    
    
                    stackText[i].enabled = true;
                    
                }
            }
            PickItem.pick = false;
        }
        

    }
     
    public void StartDrag(Image slotX)
    {
        for(int i=0; i<slotsNumber; i++)
        {
            if(slot[i] == slotX)
            {
                a = i;

            }
        }
    }

    public void Drop(Image slotX)
    {
        if (shift == true && ctrl != true)
        {
            if (ourInventory[b].id == 0)
            {
                ourInventory[b] = ourInventory[a];
                slotStack[b] = slotStack[a] / 2;
                rest = slotStack[a] % 2;
                slotStack[a] = slotStack[a] / 2 + rest;
            }
        }
        else if(ctrl == true && shift != true) 
        {
            if(ourInventory[b].id == 0)
            {
                ourInventory[b] = ourInventory[a];
                rest = slotStack[a] - 1;
                slotStack[b] = slotStack[a] - rest;
                slotStack[a] = rest;
            }
        } 
        else
        {
            if (a != b)
            {
                if (ourInventory[a].id != ourInventory[b].id)
                {
                    draggedItem[0] = ourInventory[a];
                    slotTemporary = slotStack[a];
                    ourInventory[a] = ourInventory[b];
                    slotStack[a] = slotStack[b];
                    ourInventory[b] = draggedItem[0];
                    slotStack[b] = slotTemporary;
                    a = 0;
                    b = 0;
                }
                else
                {
                    if (slotStack[a] + slotStack[b] <= ourInventory[a].maxStack)
                    {
                        slotStack[b] = slotStack[a] + slotStack[b];
                        ourInventory[a] = ItemData.itemList[0];
                    }
                    else
                    {
                        slotStack[a] = slotStack[a] + slotStack[b] - ourInventory[a].maxStack;
                        slotStack[b] = ourInventory[a].maxStack;
                    }
                }


            }
        }
    }

    public void Enter(Image slotX)
    {
        for (int i = 0; i < slotsNumber; i++)
        {
            if (slot[i] == slotX)
            {
                b = i;
              
            }
        }
    }

    public void Hotbar()
    {
        for(int i=0; i < 6; i++)
        {
            if (Input.GetKeyDown(hotbarKeys[i]))
            {
                if(ourInventory[20+i].canUse == true && isOpen == false)
                {
                    Debug.Log("true");
                    isOpen = true;
                    HotbarSlots[i].GetComponent<RectTransform>().localScale = new Vector3(1.2f, 1.2f, 1);
                   
                    holdSlotNumber = i;

                    if(ourInventory[20+i].id == 1)
                    {
                        HotbarItems[0].SetActive(true);
                        axeOpen = true;
                    }
                    else if (ourInventory[20 + i].id == 2)
                    {
                        HotbarItems[1].SetActive(true);
                        revolverOpen = true;
                    }
                    else if (ourInventory[20 + i].id == 3)
                    {
                        HotbarItems[2].SetActive(true);
                        shotgunOpen = true;
                    }
                }
                else if(ourInventory[20 + i].canUse == true && isOpen == true && i == holdSlotNumber)
                {
                    isOpen = false;
                    HotbarSlots[i].GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1);


                    if (ourInventory[20 + i].id == 1)
                    {
                        HotbarItems[0].SetActive(false);
                        axeOpen = false;
                    }
                    else if (ourInventory[20 + i].id == 2)
                    {
                        HotbarItems[1].SetActive(false);
                        revolverOpen = false;
                    }
                    else if (ourInventory[20 + i].id == 3)
                    {
                        HotbarItems[2].SetActive(false);
                        shotgunOpen = false;
                    }
                }
                else if (ourInventory[20 + i].canUse == true && i != holdSlotNumber)
                {
                    HotbarSlots[holdSlotNumber].GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1);
                    HotbarSlots[i].GetComponent<RectTransform>().localScale = new Vector3(1.2f, 1.2f, 1);
                    isOpen = true;

                    if (ourInventory[20 + i].id == 1)
                    {
                        HotbarItems[0].SetActive(true);
                        HotbarItems[1].SetActive(false);
                        HotbarItems[2].SetActive(false);
                        axeOpen = true;
                        revolverOpen = false;
                        shotgunOpen = false;
                    }
                    else if (ourInventory[20 + i].id == 2)
                    {
                        HotbarItems[1].SetActive(true);
                        HotbarItems[2].SetActive(false);
                        HotbarItems[0].SetActive(false);
                        axeOpen = false;
                        revolverOpen = true;
                        shotgunOpen = false;
                    }
                    else if (ourInventory[20 + i].id == 3)
                    {
                        HotbarItems[2].SetActive(true);
                        HotbarItems[0].SetActive(false);
                        HotbarItems[1].SetActive(false);
                        axeOpen = false;
                        revolverOpen = false;
                        shotgunOpen = true;
                    }


                    holdSlotNumber = i;
                    
                }


            }
        }
    }


    private void closeInventory()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if(inventoryOpen == false)
            {
                InventorySlots.SetActive(true);
                inventoryOpen = true;
                Camera.GetComponent<MouseLook>().enabled = false;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                InventorySlots.SetActive(false);
                inventoryOpen = false;
                Camera.GetComponent<MouseLook>().enabled = true;
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
            
        }
    }



}
