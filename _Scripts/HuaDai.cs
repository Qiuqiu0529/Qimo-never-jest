using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuaDai : BagItem
{
    private void OnMouseDown()
    {
        if (myGameManager.mask == 1)
        {
            base.OnMouseDown();
        }
        else
        {
            myDia.GetTextFromFile(myGameManager.dias[56], "", 56);
        }
    }
}
