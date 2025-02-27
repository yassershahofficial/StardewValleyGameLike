using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class TreeCutable : ToolHit
{
    [SerializeField] GameObject dropItem;
    [SerializeField] float spread = 0.7f;

    [SerializeField] Item item;
    [SerializeField] int dropCount = 3;
    [SerializeField] int itemCountInDrop = 1;
    
    public override void Hit()
    {
        while(dropCount>0){
            dropCount-=1;

            Vector3 position = transform.position;
            position.x+= spread * UnityEngine.Random.value - spread/3;
            position.y+= spread * UnityEngine.Random.value - spread/2;

            ItemSpawnManager.instance.SpawnItem(position, item, itemCountInDrop);
            // GameObject exist = Instantiate(dropItem);
            // exist.transform.position = position;
        }

        Destroy(gameObject);
    }
}
