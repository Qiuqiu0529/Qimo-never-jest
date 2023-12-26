using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    static InventoryManager instance;
    public Inventory myBag;
    public GameObject slotGrid;
    public Slot slotPrefab;
    public float originPos;
    void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
        }
        instance = this;
        //Vector3 temp = slotGrid.transform.position;
        //temp.y =0f;
        //slotGrid.transform.position = temp;
        originPos = slotGrid.transform.position.y;
        
}

    public void GridUp()
    {
        Debug.Log("GridUUU");
        Debug.Log(slotGrid.transform.position); 
        if (slotGrid.transform.position.y > originPos)
        {
            Debug.Log("GridsdffsaeUUU");
            Vector3 temp = slotGrid.transform.position;
            temp.y -= 66f;
            slotGrid.transform.position = temp;
        }
        Debug.Log(slotGrid.transform.position);

    }
    public void GridDown()
    {
        if (slotGrid.transform.position.y <= originPos+4*66f)
        {
            Debug.Log("GridDDDssfgsD");
            Vector3 temp = slotGrid.transform.position;
            temp.y += 66f;
            slotGrid.transform.position = temp;
        }
        Debug.Log(slotGrid.transform.position);

    }
    public static void CreateItem(BagItem item)
    {
        Slot newItem = Instantiate(instance.slotPrefab, instance.slotGrid.transform.position, Quaternion.identity);
        newItem.gameObject.transform.SetParent(instance.slotGrid.transform);
        newItem.slotBagItem = item;
        newItem.slotImage.sprite = item.bagIcon;
        newItem.gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
    }
}
