using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCObject : InteractableObject
{
    public string npcName;
    public string[] contentList;

    protected override void Interact()
    {
        DialogueUI.Instance.Show(npcName, contentList);
    }
}
