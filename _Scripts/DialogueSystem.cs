using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    public Text jiantiName, jiantiDia, fantiName, fantiDia;


    public Text myDia;
    public int index;
    List<string> textList = new List<string>();
    public GameObject diaImage;
    private CanvasGroup canvasGroup;
    public float textSpeed;
    public bool textFinished = true;

    public GameManager gameManager;
    public static int maxSize = 140;

    public Slider speedSet;

    public Text SpeekerName;
    public string speeker;

    public bool diaFinish = false;
    public GameObject choice;
    public Text choiceA, choiceB;
    bool haveChose, needChoose;
    int diaNumber;
    void Awake()
    {
        diaNumber = 0;
        canvasGroup = diaImage.GetComponent<CanvasGroup>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }


    public void ChangeJianti()
    {
        myDia.text = "";
        myDia = jiantiDia;
        SpeekerName.text = "";
        SpeekerName = jiantiName;

    }
    public void ChangeFanti()
    {
        myDia.text = "";
        myDia = fantiDia;
        SpeekerName.text = "";
        SpeekerName = fantiName;

    }

    public void SetSpeed()
    {
        textSpeed = speedSet.value;
    }
    public void GetTextFromFile(TextAsset file, string speekername = "", int id = 0)
    {
        //Debug.Log("Startdia");
        if (textFinished)
        {
            diaNumber = id;
            SpeekerName.text = "";
            speeker = speekername;
            diaFinish = false;
            diaImage.SetActive(true);
            canvasGroup.alpha = 1f;
            textList.Clear();
            index = 0;
            var lineData = file.text.Split('\n');
            foreach (var line in lineData)
            {
                textList.Add(line);
            }
            Debug.Log(textList.Count);
            Print();
        }
    }

    public void ChooseA()
    {
    }
    public void ChooseB()
    {
    }

    public void Jump()
    {
        if (index >= textList.Count - 1)
        {
            StopAllCoroutines();
            StartCoroutine(Disappear());
        }
        else if (!diaFinish)
        {
            diaFinish = true;
            StopAllCoroutines();
            StartCoroutine(JumpText());
        }
    }

    public IEnumerator JumpText()
    {
        textFinished = false;

        bool huanhang = false;
        for (; index < textList.Count; ++index)
        {
            myDia.text = "";
            if (textList[index][0] == 'A' && textList[index].Length <= 2)
                SpeekerName.text = "";
            else if (textList[index][0] == 'B' && textList[index].Length <= 2)
                SpeekerName.text = speeker;
            else
            {
                for (int i = 0; i < textList[index].Length; ++i)
                {
                    if (i % maxSize == 0 && i > 0)
                    {
                        huanhang = true;
                    }
                    if (huanhang && textList[index][i] == ' ')
                    {
                        huanhang = false;
                        myDia.text = "";
                        yield return new WaitForSeconds(0.2f);
                    }
                    myDia.text += textList[index][i];
                }
                yield return new WaitForSeconds(0.2f);
            }
        }
        StartCoroutine(Disappear());

    }
    public void DiaFinished()
    {
        textFinished = true;
        SpeekerName.text = "";
        Debug.Log("DiaFinish");
        diaImage.SetActive(false);
        diaFinish = true;
        index = 0;
        gameManager.SetTrue(diaNumber);
    }
    public void Print()
    {
        StartCoroutine(SetTextUi());
    }

    public IEnumerator SetTextUi()
    {
        textFinished = false;
        bool huanhang = false;
        while (index < textList.Count)
        {
            //Debug.Log(index);
            //Debug.Log(textList.Count);

            myDia.text = "";
            if (textList[index][0] == 'A' && textList[index].Length <= 2)
                SpeekerName.text = "";
            else if (textList[index][0] == 'B' && textList[index].Length <= 2)
                SpeekerName.text = speeker;
            else
            {
                //Debug.Log("for (int i = 0; i < textList[index].Length; ++i)");
                for (int i = 0; i < textList[index].Length; ++i)
                {
                    if (i % maxSize == 0 && i > 0)
                    {
                        huanhang = true;

                    }
                    if (huanhang && textList[index][i] == ' ')
                    {
                        yield return new WaitForSeconds(textSpeed * 5 + 0.5f);
                        myDia.text = "";
                        huanhang = false;
                    }
                    else
                    {

                        myDia.text += textList[index][i];
                        yield return new WaitForSeconds(textSpeed);

                    }

                }
                yield return new WaitForSeconds(textSpeed * 5 + 0.5f);
            }
            ++index;
        }

        StartCoroutine(Disappear());

    }
    public IEnumerator Disappear()
    {
        while (canvasGroup.alpha > 0)
        {
            canvasGroup.alpha -= 0.2f;
            yield return new WaitForSeconds(0.05f);
        }
        DiaFinished();
    }
}
