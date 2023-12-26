using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueItem : Item
{
    public int textNumber = 0;
    protected void OnMouseDown()
    {
        Debug.Log("diatest");

        if (myDia.textFinished)
        {
            if (!myGameManager.diaList[ID]&&myGameManager.mask==Yuji)
            {
                myDia.GetTextFromFile(myGameManager.dias[ID], NAME, ID);
            }
        }
        SoundManager.instance.ClickAudio();
    }
}
