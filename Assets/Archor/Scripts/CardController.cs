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
    private GameObject[] _obj00;

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

        if (Input.GetKeyDown("f"))
        {
            _obj00 = GameObject.FindGameObjectsWithTag("00");
            _obj00[0].gameObject.GetComponent<SpriteRenderer>().DOFade(1, 3);
            //DOTween真的行 你妈的真的行
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
            _cardList[i].gameObject.GetComponent<RectTransform>().DOLocalMoveX(((i+1)/ (numCards+1)) * _width - (_width * 0.5f) - 60, 0.5f, true);
            //由于cardPanel的锚点在中间，所以需要减掉原本的1/2_width和卡牌本身的宽度（卡牌的计算锚点是左下角）
            //Debug.Log(i+1 + " 号牌的位置是 " + _cardList[i].gameObject.GetComponent<RectTransform>().localPosition.x);
            //严格来讲，这个地方可以用DOTween来解决，但先做完再加。
        }
    }
    
    public void ReSortCards(float numCards)
    {
        _cardList = GameObject.FindGameObjectsWithTag("Card");
        for (int i = 0; i < _cardList.Length; i++)
        {
            _cardList[i].gameObject.GetComponent<RectTransform>().DOLocalMoveX(((i+1)/ (numCards+1)) * _width - (_width * 0.5f) - 60, 0.5f, true);
        }
    }

    void GetCard(GameObject prefabName)
    {
        Database.numCards++;
        GameObject prefabInstance = Instantiate(prefabName);
        prefabInstance.transform.parent = GameObject.Find("UI/CardPanel").gameObject.transform;
        prefabInstance.gameObject.GetComponent<RectTransform>().localScale = new Vector3(2, 2, 2);
        prefabInstance.gameObject.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
        SortCards(Database.numCards);
    }
    
    //以下为 DialogueSystem调用方便而设置的函数
    //正在重构中...但是没时间了你妈的你妈的你妈的
    //现在是2.8号23：55明天还要去字节上班，项目优化不完简历还没写，大哥下次你有这种事要交作品集早点说谢谢您。
    /*public void GetCardByName(string prefabName)
    {
        GetCard(prefabName);
    }*/
    
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
