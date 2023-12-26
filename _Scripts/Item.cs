using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public static int Yuji = 0;
    public static int BaWang = 1;

    public bool ChangeCursor = false;
    public int ID;
    public string NAME;
    public int PuzzleNumber;
    public bool canBeTouch;
    public bool firstTouch; 

    public GameManager myGameManager;
    
    public DialogueSystem myDia;


    protected void Awake()
    {
        myDia = GameObject.FindGameObjectWithTag("Dialogue").GetComponent<DialogueSystem>();
        
       
        canBeTouch = true;
        firstTouch = true;
        myGameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

    }

    public  void OnMouseEnter()
    {
        if (myGameManager.mask==Yuji&&canBeTouch)
        { 
            
            CursorMgr.Instance.FindCursor();
            // Cursor.SetCursor(cursorTexture, cursorPos, CursorMode.Auto); 
        }
    }
   
    public void OnMouseExit()
    {
        CursorMgr.Instance.DefaultCursor();
        //Cursor.SetCursor(cursorTexture1, cursorPos, CursorMode.Auto);
    }

    public IEnumerator MoveToPosition(Vector3 target, float moveSpeed = 2.0f)
    {
        while (transform.position != target)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);
            yield return 0;
        }
    }
    public IEnumerator JianYin(float moveSpeed = 1f)
    {
        Color test = GetComponent<SpriteRenderer>().color;
        while (test.a > 0)
        {
            test.a -= moveSpeed * Time.deltaTime;
            GetComponent<SpriteRenderer>().color = test;
            yield return 0;
        }
    }
    public IEnumerator JianXian(float moveSpeed = 1f)
    {
        Color test = GetComponent<SpriteRenderer>().color;
        while (test.a > 0)
        {
            test.a += moveSpeed * Time.deltaTime;
            GetComponent<SpriteRenderer>().color = test;
            yield return 0;
        }
    }
}
