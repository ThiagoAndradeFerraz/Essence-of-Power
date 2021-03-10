using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{
    protected override void InteractionInventory()
    {
        Debug.Log("inventory...");
    }

    protected override void InteractionTalk()
    {
        Debug.Log("talking...");
    }

    protected override void InteractionUse()
    {
        Debug.Log("using...");
    }
}
