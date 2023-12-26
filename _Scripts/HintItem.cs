using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HintItem : Item
{
    public UnityEvent action;
    protected void OnMouseDown()
    {
        Debug.Log("diatest");
        action?.Invoke();
        myDia.GetTextFromFile(myGameManager.dias[ID],"",ID);
        SoundManager.instance.ClickAudio();
    }
}
