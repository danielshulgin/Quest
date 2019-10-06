using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public List<string> notes = new List<string>();

    public void Interact(int id)
    {
        if (notes.Count - 1 >= id)
        {
            Debug.Log(notes[id]);
            UIManager.instance.ShowNote(notes[id]);
        }
    }
}
