using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suizhaopian : HintItem
{
    private void OnMouseDown()
    {
       this.gameObject.SetActive(false);
        myGameManager.PuzzleListSet(14);
    }
}
