using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ANGE : MonoBehaviour
{
    public GameObject panel;
    public int puzzleId;
    public GameManager myGameManager;
    private void OnMouseDown()
    {
        myGameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        if (!myGameManager.puzzleList[1])
        {
            panel.SetActive(true);
        }
        this.GetComponent<BoxCollider2D>().enabled = false;
    }
}
