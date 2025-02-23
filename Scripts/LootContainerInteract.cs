using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootContainerInteract : Interactable
{
    [SerializeField] GameObject closed;
    [SerializeField] GameObject opened;
    [SerializeField] bool isOpen;

    public override void Interact(Character character)
    {
        if(isOpen == false){
            isOpen = true;
            closed.SetActive(false);
            opened.SetActive(true);
        }
        else if(isOpen == true){
            isOpen = false;
            closed.SetActive(true);
            opened.SetActive(false);
        }
    }
}
