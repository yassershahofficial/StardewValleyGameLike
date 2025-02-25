using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryButton : MonoBehaviour
{
    [SerializeField] Image icon;
    [SerializeField] TextMeshProUGUI text;

    int thisIndex;

    public void SetIndex(int index){
        thisIndex = index;
    }

    public void Set(ItemSlot slot){
        if(slot.item.icon == null){
            icon.gameObject.SetActive(false);
        }
        else{
            icon.gameObject.SetActive(true);
            icon.sprite =  slot.item.icon;
        }

        if(slot.item.stackable == true){
            text.gameObject.SetActive(true);
            text.text = slot.count.ToString();
        }
        else{
            text.gameObject.SetActive(false);
        }
    }

    public void Clean(){
        icon.sprite = null;
        text.gameObject.SetActive(false);
        icon.gameObject.SetActive(false);
    }

}
