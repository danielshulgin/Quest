using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public Text notePopUptext;
    public CanvasGroup notePanelCanvasGroup;
    public Image filler;

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

    public IEnumerator ShowFiller()
    {
        for (int i = 0; i < 255; i += 20)
        {
            filler.color = new Color(1, 1, 1, i/255f);
            yield return null;
        }
    }

    public IEnumerator HideFiller()
    {
        for (int i = 255; i >= 0; i -= 20)
        {
            filler.color = new Color(1, 1, 1, i / 255f);
            yield return null;
        }
    }
}
