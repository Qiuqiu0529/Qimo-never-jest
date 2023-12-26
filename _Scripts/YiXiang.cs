using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YiXiang : HintItem
{
    public GameObject yixianglock;
    private void OnMouseDown()
    {
        //if (!myGameManager.diaList[3])
        //{
        //    myDia.GetTextFromFile(myGameManager.dias[48], "", 48);
        //}
        //else 
        //{
        //    myDia.GetTextFromFile(myGameManager.dias[49], "", 49);
        //}
        yixianglock.SetActive(true);
       
    }
}
