using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemDragAndDropController : MonoBehaviour
{
    //what this file is all about is to create Seperate item slot for storing inside the "drag n drop" item slot,
    //which all information from specific index inventory button is retrived and save into the "drag n drop" item slot

    [SerializeField] ItemSlot itemSlot;
    [SerializeField] GameObject itemIcon;
    RectTransform iconTransform;
    Image itemIconImage;

    private void Start(){
        //create the new slot for "drag n drop" item slot
        itemSlot = new ItemSlot();
        iconTransform = itemIcon.GetComponent<RectTransform>();
        itemIconImage = itemIcon.GetComponent<Image>();
    }

    private void Update(){
        
        if(itemIcon.activeInHierarchy == true){
            iconTransform.position = Input.mousePosition;

            if(Input.GetMouseButtonDown(0)){
                if(EventSystem.current.IsPointerOverGameObject() == false){
                    //Debug.Log("Outside the inventory Panel is Clicked when Item contained in 'drag n drop' item slot");

                    Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    worldPos.z = 0;
                    ItemSpawnManager.instance.SpawnItem(worldPos, itemSlot.item, itemSlot.count);

                    itemSlot.Clear();
                    itemIcon.SetActive(false);
                }
            }
        }
    }

    internal void OnClick(ItemSlot itemSlot){

        if(this.itemSlot.item == null){
            this.itemSlot.Copy(itemSlot);
            itemSlot.Clear();
        }

        else{
            Item item = itemSlot.item;
            int count = itemSlot.count;

            itemSlot.Copy(this.itemSlot);
            this.itemSlot.Set(item, count);
        }

        UpdateIcon();
    }

    private void UpdateIcon(){
        if(itemSlot.item == null){
            itemIcon.SetActive(false);
        }
        else{
            itemIcon.SetActive(true);
            itemIconImage.sprite = itemSlot.item.icon;
        }
    }
}
