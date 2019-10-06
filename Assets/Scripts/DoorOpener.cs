using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class DoorOpener : MonoBehaviour
{
    public Animator animator;
    public bool closedByDefault;
    public List<StringBoolPair> tagsToCheck = new List<StringBoolPair>();
    public void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //collision.GetComponent<Interaction>().Interact(id);
            if ((NoteManager.instance.TagsCorrect(tagsToCheck) && 
                tagsToCheck.Count > 0) || !closedByDefault)
            {
                animator.SetBool("Open", true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            animator.SetBool("Open", false);
        }
    }
}
