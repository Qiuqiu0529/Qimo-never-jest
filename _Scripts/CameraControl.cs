using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraControl : MonoBehaviour
{
    public enum MyScene { YUJI = 0, BAWANG, HOUTAI, XITAI, HOUYUAN, HUIKESHI };
    public MyScene cameraScene = MyScene.YUJI;
    public List<Vector3> dirs = new List<Vector3>();
    public GameObject up, left, right, down;

    int moreDis = 0;
    int preDis = -1;
    public static int UP = 0;
    public static int DOWN = 1;
    public static int lEFT = 2;
    public static int RIGHT = 3;

    public GameManager myGameManager;
    public DialogueSystem myDia;
    private void Awake()
    {
        myDia = GameObject.FindGameObjectWithTag("Dialogue").GetComponent<DialogueSystem>();
        myGameManager= GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        Vector3 up = new Vector3(0, 10f);
        dirs.Add(up);
        Vector3 down = new Vector3(0, -10f);
        dirs.Add(down);
        Vector3 left = new Vector3(-12f, 0);
        dirs.Add(left);
        Vector3 right = new Vector3(12f, 0);
        dirs.Add(right);
        Vector3 LeftMore = new Vector3(-12f, 0);
        dirs.Add(LeftMore);
        Vector3 RightMore = new Vector3(12f, 0);
        dirs.Add(RightMore);
        ArrowXian(this.transform.position);
    }
  
    void ArrowXian(Vector3 pos)
    {
        up.SetActive(false);
        right.SetActive(false);
        left.SetActive(false);
        down.SetActive(false);
        if (pos.y == 0f)
        {
            if (pos.x <= 83f && pos.x >= 0f)
            {
                right.SetActive(true);
                if (pos.x == 0f)
                    down.SetActive(true);
            }
            if (pos.x <= 84f && pos.x >= 12f)
            {
                left.SetActive(true);
            }
        }
        if (pos.y == -10f)
        {
            if (pos.x == 0f)
                up.SetActive(true);
            if (pos.x >= -36f && pos.x < 48f)
                right.SetActive(true);
            if (pos.x <= 48f && pos.x >= -24f)
                left.SetActive(true);
        }
    }
    public void MovingBetweenScene(int Dir)
    {
        Vector3 tagPos = this.transform.position + dirs[Dir];
        if (Dir > 1)
        {
            if (!myGameManager.morePlace)
            {
                if (this.transform.position.y == -10f && this.transform.position.x == 0f && Dir == 2)
                {
                    myDia.GetTextFromFile(myGameManager.dias[GameManager.CantMoveBaWang]);
                    return;
                }
                if (this.transform.position.y == -10f && this.transform.position.x == 12f && Dir == 3)
                {
                    myDia.GetTextFromFile(myGameManager.dias[GameManager.CantMoveYuJi]);
                    return;
                }
            }

            if (this.transform.position.x == 48f && this.transform.position.y == 0f && Dir == 3)
            {
                if ((!myGameManager.morePlace)||(!myGameManager.unlockGuiBin))
                {
                    myDia.GetTextFromFile(myGameManager.dias[GameManager.CantMoveGuiBin]);
                    return;
                }
            }

            if (this.transform.position.x==0f)
            {
                if (Dir == 2)
                {
                    moreDis = 1; 
                }
                else
                    moreDis = 0;
                preDis = -1;
            }

            if (Dir == preDis)
            {
                moreDis = (moreDis + 1) % 2;
            }
            if (moreDis == 1)
            {
                tagPos += dirs[Dir + 2];
            }
            preDis = Dir;
        }
        this.transform.position = tagPos;
        ArrowXian(tagPos);
    }
}
