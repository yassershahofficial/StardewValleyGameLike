using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightController : MonoBehaviour
{
    [SerializeField] GameObject highlighter;
    [SerializeField] float offset = 0.1f;

    GameObject currentTarget;

    public void Highlight(GameObject target){
        if(currentTarget == target){
            return;
        }
        currentTarget = target;
        Vector3 position = target.transform.position + Vector3.down * offset;
        Visible(position);
    }

    public void Visible(Vector3 position){
        highlighter.SetActive(true);
        highlighter.transform.position = position;
    }

    public void Hide(){
        currentTarget = null;
        highlighter.SetActive(false);
    }
}
