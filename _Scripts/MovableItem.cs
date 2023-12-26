using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableItem : Item
{
    public float x, y=0;
    private void OnMouseDown()
    {
        if (myGameManager.mask == BaWang&&!myGameManager.puzzleList[PuzzleNumber])
        {
            myGameManager.PuzzleListSet(PuzzleNumber);
            Vector3 targetPos = this.transform.position + new Vector3(x, y);
            StartCoroutine(MoveToPosition(targetPos));
            SoundManager.instance.PushBoxAudio();
            this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            
        }   
    }
}
