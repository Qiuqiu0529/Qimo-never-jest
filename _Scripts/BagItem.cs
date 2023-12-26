using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BagItem : Item
{
    public Inventory player;
    public Sprite bagIcon;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
    }

    public void AddBag()
    {
        this.GetComponent<BoxCollider2D>().enabled = false;
        player.myBag.Add(this);
        this.transform.position = new Vector3(-15f, 0f, -1f);
        InventoryManager.CreateItem(this);

        SoundManager.instance.BagAudio();
    }
    public void OnMouseDown()
    {
        if (myDia.textFinished)
        {
            AddBag();
        }
    }
}
