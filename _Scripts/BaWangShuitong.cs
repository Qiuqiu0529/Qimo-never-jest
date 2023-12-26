using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaWangShuitong : Item
{
    private void OnMouseDown()
    {
        myGameManager.PuzzleListSet(17);
        this.gameObject.SetActive(false);
    }
}
