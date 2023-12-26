using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Huopen :Item
{
    // Start is called before the first frame update
    private void OnMouseDown()
    {
        if (myGameManager.diaList[17] && myGameManager.diaList[18])
        {
            myDia.GetTextFromFile(myGameManager.dias[19], "", 19);
        }
        else
        {
            myDia.GetTextFromFile(myGameManager.dias[54], "", 54);
        }
    }
}
