using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class SequentialInteractible : MonoBehaviour
{
    public List<BehaviourItem> behaviours = new List<BehaviourItem>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //collision.GetComponent<Interaction>().Interact(id);
            for (int i = 0; i < behaviours.Count; i++)
            {
                var behaviur = behaviours[i];
                if (NoteManager.instance.Interact(behaviur.tagsToRemove,
                    behaviur.tagsToChange, behaviur.tagsToCheck, behaviur.id))
                {
                    break;
                }
            }            
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

[System.Serializable]
class BehaviourItem
{
    public int id = 0;

    public List<string> tagsToRemove = new List<string>();
    public List<StringBoolPair> tagsToChange = new List<StringBoolPair>();
    public List<StringBoolPair> tagsToCheck = new List<StringBoolPair>();
}
