using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Unity;
using System.Collections;

class InteracatbleFlashBack : Interactable
{
    public GameObject teleportPoint;
    public float teleportDelay = 2f;
    public bool reEnableMovement = true;
    private bool wait = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //collision.GetComponent<Interaction>().Interact(id);
            if (NoteManager.instance.Interact(tagsToRemove, tagsToChange, tagsToCheck, id, clip)
                && !wait)
            {
                StartCoroutine(TeleportWithDelay());
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

    IEnumerator TeleportWithDelay()
    {
        wait = true;
        MoveController.instance.maxSpeed = 0;
        yield return new WaitForSeconds(teleportDelay / 2f);
        StartCoroutine(UIManager.instance.ShowFiller());
        yield return new WaitForSeconds(teleportDelay / 2f);
        FlashBackManager.instance.Teleport(teleportPoint.transform.position);
        wait = false;
        StartCoroutine(UIManager.instance.HideFiller());
        if (reEnableMovement)
            MoveController.instance.maxSpeed = MoveController.instance.defaultMaxSpeed;
    }
}

