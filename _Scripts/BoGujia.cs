using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoGujia : Item
{
    bool firstDuihua = false;
    private void OnMouseDown()
    {
        if (!firstDuihua)
        {
            firstDuihua = true;
            myDia.GetTextFromFile(myGameManager.dias[28], NAME, 28);
            this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
        
    }
}
