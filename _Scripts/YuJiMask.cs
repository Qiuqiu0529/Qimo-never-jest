using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YuJiMask : MonoBehaviour
{
    private void OnMouseDown()
    {
        GameManager myGameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        myGameManager.PuzzleListSet(11);
        Debug.Log("yujimask");
        Destroy(this.gameObject);

    }
}
