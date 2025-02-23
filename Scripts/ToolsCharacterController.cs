using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ToolsCharacterController : MonoBehaviour
{
    characterController2D player;
    Rigidbody2D rb;
    [SerializeField] float offsetDistance = 1f;
    [SerializeField] float sizeOfInteractableArea = 1.2f;

    private void Awake(){
        player = GetComponent<characterController2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update(){
        if(Input.GetMouseButtonDown(0)){
            UseTool();
        }
    }

    private void UseTool(){
        Vector2 position = rb.position + player.lastMotionVector * offsetDistance;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, sizeOfInteractableArea);

        foreach(Collider2D c in colliders){
            ToolHit hit = c.GetComponent<ToolHit>();
            if(hit != null){
                hit.Hit();
                break;
            }
        }
    }

//just to preview the area in range
    private void OnDrawGizmos()
    {
        if (rb == null || player == null) return; // Avoid errors if not initialized

        Vector2 position = rb.position + player.lastMotionVector * offsetDistance;
        Gizmos.DrawWireSphere(position, sizeOfInteractableArea);
    }
}
