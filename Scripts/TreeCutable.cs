using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class TreeCutable : ToolHit
{
    [SerializeField] GameObject dropItem;
    [SerializeField] int dropCount = 3;
    [SerializeField] float spread = 0.7f;

    public override void Hit()
    {
        while(dropCount>0){
            dropCount-=1;

            Vector3 position = transform.position;
            position.x+= spread * UnityEngine.Random.value - spread/3;
            position.y+= spread * UnityEngine.Random.value - spread/2;

            GameObject exist = Instantiate(dropItem);
            exist.transform.position = position;
        }

        Destroy(gameObject);
    }
}
