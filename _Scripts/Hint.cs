using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Hint : MonoBehaviour
{
   /* public Text myDia;
    public GameObject hintPanel;
    bool hintFinish = true;
    private CanvasGroup canvasGroup;
    void Awake()
    {
        canvasGroup = hintPanel.GetComponent<CanvasGroup>();
    }
    //public Color test;
    public void Print(string hintDia)
    {
        if (hintFinish)
        {
            hintFinish = false;
           // test = hintPanel.GetComponent<Image>().color;
            Debug.Log("print");
            myDia.text = "";
            hintPanel.SetActive(true);
            myDia.text = hintDia;
            StartCoroutine(Disappear());
        }
    }
    public IEnumerator Disappear()
    {
        while (canvasGroup.alpha <1)
        {
            canvasGroup.alpha += 0.2f;
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(1.0f);
        while (canvasGroup.alpha > 0)
        {
            canvasGroup.alpha -= 0.3f;
            yield return new WaitForSeconds(0.1f);
        }
        hintPanel.SetActive(false);
        hintFinish = true;
    }*/
}
