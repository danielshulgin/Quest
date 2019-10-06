using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashBackManager : MonoBehaviour
{
    public static FlashBackManager instance;
    public Changable[] timeChangable;
    public bool updateInitialList = false;

    public GameObject player;

    void Start()
    {
        instance = this;
        timeChangable = FindObjectsOfType<Changable>();
    }

    public void ChangeMode()
    {
        if (updateInitialList == true)
        {
            timeChangable = FindObjectsOfType<Changable>();
        }
        foreach (var changable in timeChangable)
        {
            changable.Change();
        }
    }

    public void Teleport(Vector3 position)
    {
        player.transform.position = position;
    }
}
