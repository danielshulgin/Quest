using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class NoteManager : MonoBehaviour
{
    public static NoteManager instance;
    public List<StringBoolPair> GlobalTagDictionary = new List<StringBoolPair>();

    public List<string> notes = new List<string>();

    public bool Interact(List<string> tagsToRemove,
                 List<StringBoolPair> tagsToChange,
                 List<StringBoolPair> tagsToCheck, int id)
    {

        if (notes.Count - 1 >= id && TagsCorrect(tagsToCheck))
        {
            Debug.Log(id + " " + notes[id]);
            UIManager.instance.ShowNote(notes[id]);
			DeleteTags(tagsToRemove);
			SetTags(tagsToChange);
            return true;
        }
        return false;
    }
    private void Start()
    {
        instance = this;
    }

    public bool TagsCorrect(List<StringBoolPair> tagDictionary)
    {
        bool result = true;
        foreach (var pair in tagDictionary)
        {
            if (!GlobalTagDictionary.Contains(pair))
            {
                result = false;
            }
        }
        return result;
    }

    public void DeleteTags(List<string> tagsToRemove)
    {
        List<StringBoolPair> pairsToRemove = new List<StringBoolPair>();
        foreach (var tagName in tagsToRemove)
        {
            pairsToRemove.Add(GlobalTagDictionary.Find(pair => pair.tagName == tagName));
        }
        foreach (var item in pairsToRemove)
        {
            GlobalTagDictionary.Remove(item);
        }
    }
    
    public void SetTags(List<StringBoolPair> tagsToChange)
    {
        foreach (var pairToChange in tagsToChange)
        {
            var Pair = GlobalTagDictionary.Find(pair => pair.tagName == pairToChange.tagName);
            if (Pair != null)
            {
                Pair.value = pairToChange.value;
            }
            else
            {
                GlobalTagDictionary.Add(pairToChange);
            }
        }
    }
}

