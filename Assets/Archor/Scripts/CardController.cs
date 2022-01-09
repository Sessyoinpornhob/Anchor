using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CardController : MonoBehaviour
{
    //解决卡牌实例化问题和基础的排列问题
    public GameObject CardPanel;
    public GameObject prefabRadiation;
    public GameObject prefabBrown;
    public GameObject prefabFlag;
    public GameObject prefabKnowledge;
    public GameObject prefabWinterSweet;
    public GameObject prefabElectricity;
    public GameObject prefabConfidence;
    public GameObject prefabTears;
    public GameObject prefabXuMei;
    public GameObject prefabPills;
    public GameObject prefabLife;
    public GameObject prefabDaughter;
    public GameObject prefabCalander;
    public GameObject prefabDeath;

    private GameObject Card;
    private GameObject[] CardList;

    private RectTransform rect;

    private float NumCards;
    private float width;


    void Start()
    {
        RectTransform rect = CardPanel.gameObject.GetComponent<RectTransform>();

        width = rect.rect.width;

        NumCards = 0f;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SortCards(float NumCards)
    {
        CardList = GameObject.FindGameObjectsWithTag("Card");

        for (int i = 0; i < CardList.Length; i++)
        {

            CardList[i].gameObject.GetComponent<RectTransform>().localPosition = new Vector3(((i+1)/ (NumCards+1)) * width - 60, 0);//设定位置

            //Debug.Log(i+1 + " 号牌的位置是 " + CardList[i].gameObject.GetComponent<RectTransform>().localPosition.x);
        }
    }

    IEnumerator GetCard(float DelayTime, GameObject prefabName)
    {
        yield return new WaitForSeconds(DelayTime);

        //本来想使用协程制作一个计时器，延时DelayTime以后执行下面函数

        //Debug.Log("见鬼了");

        //但为什么是在剧情过完以后才开始计时的啊
        //0f表示不启用，0.1f表示剧情过完以后开始计时0.1s

        NumCards = NumCards + 1;

        GameObject PrefabInstance = Instantiate(prefabName);

        PrefabInstance.transform.parent = GameObject.Find("Canvas/CardPanel").gameObject.transform;

        PrefabInstance.gameObject.GetComponent<RectTransform>().localScale = new Vector3(2, 2, 2);//设定卡牌大小

        PrefabInstance.gameObject.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);

        SortCards(NumCards);
    }


    //以下为使DialogueSystem调用方便而设置的函数
    public void GetTears()
    {
        StartCoroutine(GetCard(0.1f, prefabTears));
    }

    public void GetBrown()
    {
        StartCoroutine(GetCard(0.1f, prefabBrown));
    }

    public void GetFlag()
    {
        StartCoroutine(GetCard(0.1f, prefabFlag));
    }

    public void GetKnowledge()
    {
        StartCoroutine(GetCard(0.1f, prefabKnowledge));
    }

    public void GetWinterSweet()
    {
        StartCoroutine(GetCard(0.1f, prefabWinterSweet));
    }

    public void GetElectricity()
    {
        StartCoroutine(GetCard(0.1f, prefabElectricity));
    }

    public void GetConfidence()
    {
        StartCoroutine(GetCard(0.1f, prefabConfidence));
    }

    public void GetRadiation()
    {
        StartCoroutine(GetCard(0.1f, prefabRadiation));
    }

    public void GetXuMei()
    {
        StartCoroutine(GetCard(0.1f, prefabElectricity));
    }

    public void GetPills()
    {
        StartCoroutine(GetCard(0.1f, prefabPills));
    }

    public void GetLife()
    {
        StartCoroutine(GetCard(0.1f, prefabLife));
    }

    public void GetCalander()
    {
        StartCoroutine(GetCard(0.1f, prefabCalander));
    }

    public void GetDeath()
    {
        StartCoroutine(GetCard(0.1f, prefabDeath));
    }

}
