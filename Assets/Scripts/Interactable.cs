using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Interactable : MonoBehaviour
{
    public int id = 0;

    public List<string> tagsToRemove = new List<string>();
    public List<StringBoolPair> tagsToChange = new List<StringBoolPair>();
    public List<StringBoolPair> tagsToCheck = new List<StringBoolPair>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //collision.GetComponent<Interaction>().Interact(id);
            NoteManager.instance.Interact(tagsToRemove, tagsToChange,tagsToCheck, id);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            UIManager.instance.HideNote();
        }
    }
}
