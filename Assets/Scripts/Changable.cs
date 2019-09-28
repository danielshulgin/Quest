using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Changable : MonoBehaviour
{
    public Sprite first;
    public Sprite second;
    public bool activeFirst = true;
    public SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }
    public void Change()
    {
        if (activeFirst)
        {
            spriteRenderer.sprite = second;
            activeFirst = false;
        }
        else
        {
            activeFirst = true;
            spriteRenderer.sprite = first; 
        }
    }
}
