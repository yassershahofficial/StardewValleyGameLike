using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ItemSlot{
    public Item item;
    public int count;
}

[CreateAssetMenu(menuName = "Data/Item Container")]
public class ItemContainer : ScriptableObject
{
    public List<ItemSlot> slots;

    public void Add(Item item, int count = 1){
        if(item.stackable == true){
            //stackable item, find item space for more same item
            ItemSlot itemSlot = slots.Find(x => x.item == item);
            if(itemSlot != null){
                itemSlot.count += count;
            }
            //stackable item, find empty spaces for new item
            else{
                itemSlot = slots.Find(x => x.item == null);
                if(itemSlot != null){
                    itemSlot.item = item;
                    itemSlot.count = count;
                }
            }
        }
        else{
            //non stackable item, find empty spaces for new item
            ItemSlot itemSlot = slots.Find(x => x.item == null);
            if(itemSlot != null){
                itemSlot.item = item;
                itemSlot.count = count;
            }
        }
    }
}

