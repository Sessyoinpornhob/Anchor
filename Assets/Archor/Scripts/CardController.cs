using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CardController : MonoBehaviour
{
    //�������ʵ��������ͻ�������������
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
            //DOTween����� ����������
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
            //����cardPanel��ê�����м䣬������Ҫ����ԭ����1/2_width�Ϳ��Ʊ���Ŀ�ȣ����Ƶļ���ê�������½ǣ�
            //Debug.Log(i+1 + " ���Ƶ�λ���� " + _cardList[i].gameObject.GetComponent<RectTransform>().localPosition.x);
            //�ϸ�����������ط�������DOTween����������������ټӡ�
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
    
    //����Ϊ DialogueSystem���÷�������õĺ���
    //�����ع���...����ûʱ�������������������
    //������2.8��23��55���컹Ҫȥ�ֽ��ϰ࣬��Ŀ�Ż����������ûд������´�����������Ҫ����Ʒ�����˵лл����
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
