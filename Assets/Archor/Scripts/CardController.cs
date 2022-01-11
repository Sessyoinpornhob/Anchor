using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CardController : MonoBehaviour
{
    //解决卡牌实例化问题和基础的排列问题
    public GameObject cardPanel;
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

    //private GameObject Card;
    private GameObject[] _cardList;

    private RectTransform rect;
    private float _width;


    void Start()
    {
        RectTransform rect = cardPanel.gameObject.GetComponent<RectTransform>();
        _width = rect.rect.width;
    }

    private void Update()
    {
        if (Database.cardDeleted)
        {
            _cardList = GameObject.FindGameObjectsWithTag("Card");
            ReSortCards(_cardList.Length);
            Invoke("SetFalse",0.02f);
        }
    }

    public void SetFalse()
    {
        Database.cardDeleted = false;
    }
    
    public void SortCards(float numCards)
    {
        _cardList = GameObject.FindGameObjectsWithTag("Card");
        for (int i = 0; i < _cardList.Length; i++)
        {
            _cardList[i].gameObject.GetComponent<RectTransform>().localPosition = new Vector3(((i+1)/ (numCards+1)) * _width - 60, 0);//设定位置
            //Debug.Log(i+1 + " 号牌的位置是 " + CardList[i].gameObject.GetComponent<RectTransform>().localPosition.x);
            //严格来讲，这个地方可以用DOTween来解决，但先做完再加。
        }
    }
    
    public void ReSortCards(float numCards)
    {
        _cardList = GameObject.FindGameObjectsWithTag("Card");
        for (int i = 0; i < _cardList.Length; i++)
        {
            _cardList[i].gameObject.GetComponent<RectTransform>().localPosition = new Vector3(((i+1)/ (numCards+1)) * _width - 60, 0);//设定位置
            //Debug.Log(i+1 + " 号牌的位置是 " + CardList[i].gameObject.GetComponent<RectTransform>().localPosition.x);
            //严格来讲，这个地方可以用DOTween来解决，但先做完再加。
        }
    }

    void GetCard(GameObject prefabName)
    {
        //本来想使用协程制作一个计时器，延时DelayTime以后执行下面函数
        //但为什么是在剧情过完以后才开始计时的啊
        //0f表示不启用，0.1f表示剧情过完以后开始计时0.1s
        Database.numCards++;
        GameObject prefabInstance = Instantiate(prefabName);
        prefabInstance.transform.parent = GameObject.Find("UI/CardPanel").gameObject.transform;
        prefabInstance.gameObject.GetComponent<RectTransform>().localScale = new Vector3(2, 2, 2);//设定卡牌大小
        prefabInstance.gameObject.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
        SortCards(Database.numCards);
    }
    
    //以下为使DialogueSystem调用方便而设置的函数
    public void GetTears() {
        GetCard(prefabTears);
    }

    public void GetBrown() {
        GetCard(prefabBrown);
    }

    public void GetFlag() {
        GetCard(prefabFlag);
    }

    public void GetKnowledge() {
        GetCard(prefabKnowledge);
    }

    public void GetWinterSweet() {
        GetCard(prefabWinterSweet);
    }

    public void GetElectricity() {
        GetCard(prefabElectricity);
    }

    public void GetConfidence() {
        GetCard( prefabConfidence);
    }

    public void GetRadiation() {
        GetCard( prefabRadiation);
    }

    public void GetXuMei() {
        GetCard(prefabXuMei);
    }

    public void GetPills() {
        GetCard(prefabPills);
    }

    public void GetLife() {
        GetCard(prefabLife);
    }

    public void GetCalander() {
        GetCard(prefabCalander);
    }

    public void GetDeath() {
        GetCard(prefabDeath);
    }

}
