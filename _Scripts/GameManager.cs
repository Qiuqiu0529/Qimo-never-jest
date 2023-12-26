using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
public class GameManager : MonoBehaviour
{
    public DialogueSystem myDia;            
    public List<GameObject> past=new List<GameObject>();
    public List<GameObject> now = new List<GameObject>();
    public GameObject vignette;
    public bool morePlace;
    public bool unlockGuiBin;
    public List<TextAsset> dias;

    public List<bool> diaList;
    public List<bool> puzzleList;

    public const int jianCollect = 1;
    public const int wuQiCollect = 2;
    public const int daoJuCollect = 3;

    public int mask;
    public Image yuji, bawang;

    public const int daoJuJianOne = -2;
    public const int daoJuJianTwo = 1;
    public const int daoJuJianThree = 2;

    public const int WuQiOne = 3;
    public const int WuQiTwo = 4;
    public const int WuQiThree = 5;

    public const int daoJuGong = 6;
    public const int daoJuHuaDai = 7;
    public const int daoJuLingQi =8;
    public const int daoJuJiuBei= 9;

    public const int yiXiangOpen = 10;
    public const int findYuJiMask = 11;
    public const int findBaWangMask = 12;


    public const int Tieqiaoshikuai = 13;
    public const int hecheng = 14;
    public const int bawangMaskDown= 15;
    public const int shuitonghejing = 16;


    public const int getBaWangMask = 17;
    public const int getJian3 = 18;
    public const int bawangyiguiyi = 19;

    public const int dakaiYIxiang = 20;
    public const int yidonghuaping= 21;


    public const int kaiPianSuXing = 1;
    public const int poSuiDeChangJian = 2;
    public const int baoZhi = 3;
    public const int baoZhiHouRenWuXinLi = 4;
    public const int duiHuaWuQi = 5;
    public const int zuShiGongXiang = 6;
    public const int duiHuaZuShiGongXiang = 7;
    public const int duiHuaHuaKuangOne = 8;
    public const int duiHuaNiaoLong = 9;
    public const int poSunDeHeYing = 10;
    public const int duiHuaHuaKuangTwo = 11;
    public const int duiHuaJiShou = 12;
    public const int duiHuaXiuFuJian = 13;
    public const int duiHuaBiHua = 14;
    public const int chuanYue = 15;
    public const int duiHuaWuQiJia = 16;
    public const int miMaBenShang = 17;
    public const int miMaBenXia = 18;
    public const int miMa = 19;
    public const int yanQiang = 20;
    public const int duiHuaYanQiang = 21;
    public const int huaPing = 22;
    public const int duiHuaHuaPing = 23;
    public const int piXiang = 24;
    public const int daKaiPiXiang = 25;
    public const int riBenShan = 26;
    public const int boGuJia = 27;
    public const int duiHuaBoGuJia = 28;
    public const int jianQiao = 29;
    public const int duiHuaJianQiao = 30;
    public const int lingQi = 31;
    public const int gongJian = 32;
    public const int huaDai = 33;
    public const int jiuBei = 34;
    public const int yuJiZiWenDaDuanCi = 35;
    public const int xiangLu = 36, wuShiDao = 37, pingFeng = 38, juQingCi = 39, boGuJiaDuiHua = 40;
    public const int danmask = 41, shengmask = 42;
    public const int BaGe=43,CantMoveBaWang=44, CantMoveYuJi=45, CantMoveGuiBin=46,chajuHint=47;
    public const int yixiangClose = 48, yiXiangAfter = 49, kujing = 50, paibian = 51,desuipian3=52;

    public Item PingFeng, xiTaiange, wuqiduiying1, wuqiduiying2, openYixiang, yixiang, jing, 
        shuitong, shikuai, suizhaopian,hechengzhaopian,bwangshuitong;
    public BagItem bagGong,tieQiao, bagJianOne, bagJianTwo, bagJianThree, bagHuaDai, bagJiuBei,bagLingQi,wuqiOne,wuqiThree;
    public GameObject luojian, dahaosuipian1, dahaosuipian2, dahaosuipian3,yixiangguanbi,banbenmimaBW,bawanghuaping,bawangyaoshi,bwyixiangkai;
    public GameObject gongimage,lingqiImage,huadaiimage,jiubeiimage,final,trans,gongCollider,huadaiCollider,lingqiCollider,jiubeiCollider,wanzhengjian;
    public Volume volume;
    public Vignette vignette1;

    public int jianHave=0;
    public int daojuHave = 0;
    

    private void Awake()
    {
        for (int i = 0; i < 60; i++)
        {
            bool temp = false;
            diaList.Add(temp);
            if (i < 30)
            { 
                puzzleList.Add(temp);
            }
        }
        morePlace = false;
        unlockGuiBin = false;
       
        myDia = GameObject.FindGameObjectWithTag("Dialogue").GetComponent<DialogueSystem>();
        mask = -1;
        volume.profile.TryGet(out vignette1);

    }

    public void ChangeMask()
    {
        if (puzzleList[findYuJiMask] && puzzleList[findBaWangMask])
        {
            mask = (mask + 1) % 2;
            yuji.enabled = !yuji.enabled;
            bawang.enabled = !bawang.enabled;
        }
    }

    public void GetYujiMask()
    {
        bawang.enabled = false;
        yuji.enabled = true;
        mask = 0;
    }
    public void GetBaWangMask()
    {
        bawang.enabled = true;
        yuji.enabled = false;
        mask = 1;
    }
    private void Start()
    {
        StartCoroutine(Trans());
    }

    public IEnumerator Trans()
    {
        trans.gameObject.SetActive(true);
        CanvasGroup canvasGroup = trans.GetComponent<CanvasGroup>();
        float temp = 1;
        while (canvasGroup.alpha > 0)
        {
            temp -= 0.01f;
            vignette1.intensity.Override(temp);
            canvasGroup.alpha -= 0.02f;
            yield return new WaitForSeconds(0.07f);
        }
        trans.gameObject.SetActive(false);
        canvasGroup.alpha = 1;
        myDia.GetTextFromFile(dias[kaiPianSuXing]);
    }


    public IEnumerator TrantiPast()
    {
        trans.gameObject.SetActive(true);
        CanvasGroup canvasGroup = trans.GetComponent<CanvasGroup>();
        while (canvasGroup.alpha > 0)
        {
            canvasGroup.alpha -= 0.01f;
            yield return new WaitForSeconds(0.07f);
        }
        trans.gameObject.SetActive(false);
        canvasGroup.alpha = 1;
        myDia.GetTextFromFile(dias[chuanYue]);
        SoundManager.instance.DoorOpenAudio();
    }

    public void ChangeToPast()
    {
        
        morePlace = true;
        StartCoroutine(TrantiPast());
        vignette1.intensity.Override(0);
        foreach (var item in now)
        {
            item.gameObject.SetActive(false);
        }
        foreach (var item in past)
        {
            item.gameObject.SetActive(true);
        }
        
    }
    public void AddswordTwo()
    {
        bagJianTwo.AddBag();
    }

    void IFCollectAllJian()
    {
        if (jianHave == 3)
        {
            StartCoroutine(CollectAllJian());
        }
    }

    

    public IEnumerator CollectAllJian()
    {
        bagJianOne.gameObject.SetActive(false);
        bagJianTwo.gameObject.SetActive(false);
        bagJianThree.gameObject.SetActive(false);
        yield return new WaitForSeconds(1f);
        luojian.gameObject.SetActive(true);
    }


    void IFCollectAllDaoju()
    {
        if (daojuHave==4)
        {
            myDia.GetTextFromFile(dias[40], "Curio Shelf", 40);
        }
    }
    void IFCollectAllWuqi()
    {
        if (puzzleList[WuQiOne] && puzzleList[WuQiThree])
        {
            myDia.GetTextFromFile(dias[duiHuaWuQi], "Weapon Rack", duiHuaWuQi);
        }
    }
    public void HeCheng()
    {
        myDia.GetTextFromFile(dias[10], "", 10);

    }

    public void PuzzleListSet(int puzzleNumber)
    {
         CursorMgr.Instance.DefaultCursor();
        puzzleList[puzzleNumber] = true;
        switch (puzzleNumber)
        {
            case daoJuJianThree:
                jianHave += 1;
                IFCollectAllJian();
                break;
            case getJian3:
                bagJianThree.AddBag();
                myDia.GetTextFromFile(dias[desuipian3], "", desuipian3);
                break;
            case WuQiOne:
                wuqiOne.transform.localEulerAngles = new Vector3(0, 0, 0);
                wuqiOne.transform.localPosition = new Vector3(1.58f, 0.6f, 0);
                wuqiOne.gameObject.GetComponent<SpriteRenderer>().sortingLayerName ="ItemBack";
                Destroy(wuqiduiying1.gameObject);
                Debug.Log(wuqiOne.transform.position);
                IFCollectAllWuqi();
                break;
            case WuQiThree:
                wuqiThree.transform.localEulerAngles = new Vector3(0, 0, 0); 
                wuqiThree.gameObject.transform.localPosition = new Vector3(-1.4f, 0.67f, 0);
                wuqiThree.gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "ItemBack";
                Destroy(wuqiduiying2.gameObject);
                IFCollectAllWuqi();
                break;

            case daoJuGong:
                gongimage.SetActive(true);
                bagGong.gameObject.SetActive(false);
                gongCollider.SetActive(false);
                daojuHave++;
                IFCollectAllDaoju();
                break;
            case daoJuHuaDai:
                huadaiimage.SetActive(true);
                bagHuaDai.gameObject.SetActive(false);
                huadaiCollider.SetActive(false);
                daojuHave++;
                IFCollectAllDaoju();
                break;
            case daoJuLingQi:
                lingqiImage.SetActive(true);
                bagLingQi.gameObject.SetActive(false);
                lingqiCollider.SetActive(false);
                daojuHave++;
                IFCollectAllDaoju();
                break;
            case daoJuJiuBei:
                daojuHave++;
                jiubeiimage.SetActive(true);
                bagJiuBei.gameObject.SetActive(false);
                jiubeiCollider.SetActive(false);
                IFCollectAllDaoju();
                break;
            case findYuJiMask:
                myDia.GetTextFromFile(dias[danmask], "", danmask);
                GetYujiMask();
                break;
            case Tieqiaoshikuai:
                shikuai.gameObject.SetActive(false);
                tieQiao.gameObject.SetActive(false);
                suizhaopian.gameObject.SetActive(true);
                break;
            case hecheng:
                HeCheng();
               
                break;
            case bawangMaskDown:
               
                jing.gameObject.GetComponent<BoxCollider2D>().enabled=true;
                break;
            case findBaWangMask:
                Debug.Log("shuitonghejing:");
                shuitong.gameObject.SetActive(false);
                StartCoroutine(LaShuiTong());
                
                break;
            case getBaWangMask:
                Debug.Log("getBaWangMask");
                myDia.GetTextFromFile(dias[shengmask], "", shengmask);
                GetBaWangMask();
                break;

            case bawangyiguiyi:
                Debug.Log("bawangyiguiyi");
                yixiangguanbi.gameObject.GetComponent<BoxCollider2D>().enabled=true;
                banbenmimaBW.gameObject.GetComponent<BoxCollider2D>().enabled = true;
                break;

            case dakaiYIxiang://????????????????
                yixiangguanbi.gameObject.SetActive(false);
                bwyixiangkai.gameObject.SetActive(true);
                break;
            default:

                break;
        }
    }

    public IEnumerator LaShuiTong()
    {
        SoundManager.instance.ShuitongAudio();
        yield return new WaitForSeconds(1f);
        Debug.Log("Lashuitong");
        jing.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        bwangshuitong.gameObject.SetActive(true);

    }

    public void SetTrue(int diaCount)
    {
        diaList[diaCount] = true;

        switch (diaCount)
        {
            
            case baoZhi:
                Debug.Log("AfterNews");
                myDia.GetTextFromFile(dias[baoZhiHouRenWuXinLi],"", baoZhiHouRenWuXinLi);
                break;
            case pingFeng:
                Debug.Log("Gong xian");
                PingFeng.GetComponent<BoxCollider2D>().enabled = false;
                bagGong.gameObject.SetActive(true);
                break;
            case duiHuaZuShiGongXiang:
                Debug.Log("duiHuaZuShiGongXiang");
                Vector3 targetPos = xiTaiange.transform.position + new Vector3(1f, 0);
                xiTaiange.StartCoroutine(xiTaiange.MoveToPosition(targetPos));
                xiTaiange.GetComponent<BoxCollider2D>().enabled = true;
                break;
            case duiHuaWuQi:
                Debug.Log("duiHuaWuQi");
                StartCoroutine(AddItem(tieQiao));
                break;
            case yiXiangAfter:
                yixiang.gameObject.SetActive(false);
                Debug.Log("openYixiang");
                openYixiang.gameObject.SetActive(true);
                break;
            case poSunDeHeYing:
                hechengzhaopian.gameObject.SetActive(true);
                break;
            case duiHuaXiuFuJian://????
                ChangeToPast();
                break;
             case duiHuaHuaPing:
                bawanghuaping.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                SoundManager.instance.KeyAudio();
                bawangyaoshi.gameObject.SetActive(true);
                bawanghuaping.gameObject.transform.localPosition = new Vector3(-1.83f, -0.68f, 0f);
                break;

            case daKaiPiXiang:
                StartCoroutine(JieSuoGuiBin());
                break;
            case 40://????????
                StartCoroutine(End());
                break;
            default:
               
                break;
        }
    }
    public IEnumerator End()
    {
        yield return new WaitForSeconds(1.0f);
        final.SetActive(true);
    }
    public IEnumerator AddItem(BagItem bagitem)
    {
        yield return new WaitForSeconds(0.7f);
        bagitem.AddBag();
    }
    public IEnumerator JieSuoGuiBin()
    {
        yield return new WaitForSeconds(0.7f);
        myDia.GetTextFromFile(dias[yuJiZiWenDaDuanCi],"", yuJiZiWenDaDuanCi);
        unlockGuiBin = true;
        //wanzhengjian.SetActive(false);
        SoundManager.instance.DoorOpenAudio();
    }
   
}
