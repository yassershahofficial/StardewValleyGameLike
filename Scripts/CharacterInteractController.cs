using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInteractController : MonoBehaviour
{
    characterController2D player;
    Rigidbody2D rb;
    [SerializeField] float offsetDistance = 1f;
    [SerializeField] float sizeOfInteractableArea = 1.2f;
    Character character;
    [SerializeReference] HighlightController highlightController;


    private void Awake(){
        player = GetComponent<characterController2D>();
        rb = GetComponent<Rigidbody2D>();
        character = GetComponent<Character>();
    }

    private void Update(){
        Check();
        if(Input.GetMouseButtonDown(1)){
            Interact();
        }
    }
    private void Check(){
        Vector2 position = rb.position + player.lastMotionVector * offsetDistance;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, sizeOfInteractableArea);

        if (colliders.Length > 0){
            highlightController.Hide();
        }

        foreach(Collider2D c in colliders){
            Interactable hit = c.GetComponent<Interactable>();
            if(hit != null){
                highlightController.Highlight(hit.gameObject);
                break;
            }
        }
    }
    private void Interact(){
        Vector2 position = rb.position + player.lastMotionVector * offsetDistance;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, sizeOfInteractableArea);

        foreach(Collider2D c in colliders){
            Interactable hit = c.GetComponent<Interactable>();
            if(hit != null){
                hit.Interact(character);
                break;
            }
        }
    }
    void OnDrawGizmos()
    {
        if(rb == null) return;
        Vector2 position = rb.position + player.lastMotionVector * offsetDistance;
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(position, sizeOfInteractableArea);
    }
}
