using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scri : HintItem
{
    private void OnMouseDown()
    {
        if (myGameManager.mask != 1)
        {
            myDia.GetTextFromFile(myGameManager.dias[51], "", 51);
        }
        else
        {
            this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            myGameManager.PuzzleListSet(GameManager.getJian3);
        }
    }
}
