using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DigitLock : MonoBehaviour
{
    [SerializeField]int pos=0;
    int test = 0;
    public TMP_Text digit1;
    public void ClickDigit()
    {
        DigitUp();
        CheckAnswer();
    }
    public void CheckAnswer()
    {
        LockMgr.Instance.ChangeDigit(pos, test);
    }

    public void DigitUp()
    {
        test++;
        if (test > 9)
        {
            test = 0;
        }
        digit1.text = test.ToString();
    }

    public void DigitDown()
    {
        test--;
        if (test < 0)
        {
            test = 9;
        }
        digit1.text = test.ToString();
    }

}
