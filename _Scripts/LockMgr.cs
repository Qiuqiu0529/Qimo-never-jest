using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class LockMgr : Singleton<LockMgr>
{
    public bool correctAnswer;
    public int[] rightdigit = new int[4];

    public int[] digits = new int[4];

    public void ChangeDigit(int pos, int num)
    {
        SoundManager.instance.DigitAudio();
        digits[pos] = num;
        correctAnswer=Check();
        
    }

    public bool Check()
    {
        for (int i = 0; i < 4; ++i)
        {
            if(digits[i]!=rightdigit[i])
            {
                return false;
            }
        }
        GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().SetTrue(GameManager.yiXiangAfter);
        //opendoorFB.PlayFeedbacks();
        return true;
    }

}
