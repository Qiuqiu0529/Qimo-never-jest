using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class DragIcon : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler
{
    public Slot parent;
    public BagItem item;
    public Image myImage;
    string orignalLayer;
    public LayerMask myLayer;

    public GameManager myGameManager;

    private void Awake()
    {
        myGameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>() ;
    }
    //
    public void OnBeginDrag(PointerEventData eventData)
    {
        item = parent.slotBagItem;
        Color test = myImage.color;
        test.a = 0;
        myImage.color = test;
        orignalLayer = item.gameObject.GetComponent<SpriteRenderer>().sortingLayerName;
        item.gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "ItemIcon";
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        item.transform.position = new Vector3(pos.x, pos.y, 1f);

    }
    public void OnDrag(PointerEventData eventData)
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        item.transform.position = new Vector3(pos.x, pos.y, 1f);

    }
    public void OnEndDrag(PointerEventData eventData)
    {
         Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
         Collider2D testItem = Physics2D.OverlapCircle(pos, 1.0f, myLayer);
         
        if (testItem!=null&&testItem.GetComponent<Item>()!= null)
         {
            Debug.Log(testItem.name);
            Debug.Log(testItem.GetComponent<Item>().PuzzleNumber);
             Item colliderItem = testItem.GetComponent<Item>();
             if (colliderItem.PuzzleNumber == item.PuzzleNumber)
             {
                myGameManager.PuzzleListSet(item.PuzzleNumber);
                Destroy(parent.gameObject);
                return;
             }
         }

        Color test = myImage.color;
        test.a = 255;
        myImage.color = test;
        item.transform.position = new Vector3(-15f, 0f, -1f);
        item.gameObject.GetComponent<SpriteRenderer>().sortingLayerName = orignalLayer;

    }
}
