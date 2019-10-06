using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text notePopUptext;
    public CanvasGroup notePanelCanvasGroup;

    public static UIManager instance;
    private void Start()
    {
        instance = this;
    }

    public void ShowNote(string text)
    {
        notePanelCanvasGroup.alpha = 1f;
        notePopUptext.text = text;
    }

    public void HideNote()
    {
        notePanelCanvasGroup.alpha = 0f;
    }
}
