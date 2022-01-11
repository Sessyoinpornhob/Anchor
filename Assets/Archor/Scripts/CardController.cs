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
            _cardList[i].gameObject.GetComponent<RectTransform>().localPosition = new Vector3(((i+1)/ (numCards+1)) * _width - 60, 0);//�趨λ��
            //Debug.Log(i+1 + " ���Ƶ�λ���� " + CardList[i].gameObject.GetComponent<RectTransform>().localPosition.x);
            //�ϸ�����������ط�������DOTween����������������ټӡ�
        }
    }
    
    public void ReSortCards(float numCards)
    {
        _cardList = GameObject.FindGameObjectsWithTag("Card");
        for (int i = 0; i < _cardList.Length; i++)
        {
            _cardList[i].gameObject.GetComponent<RectTransform>().localPosition = new Vector3(((i+1)/ (numCards+1)) * _width - 60, 0);//�趨λ��
            //Debug.Log(i+1 + " ���Ƶ�λ���� " + CardList[i].gameObject.GetComponent<RectTransform>().localPosition.x);
            //�ϸ�����������ط�������DOTween����������������ټӡ�
        }
    }

    void GetCard(GameObject prefabName)
    {
        //������ʹ��Э������һ����ʱ������ʱDelayTime�Ժ�ִ�����溯��
        //��Ϊʲô���ھ�������Ժ�ſ�ʼ��ʱ�İ�
        //0f��ʾ�����ã�0.1f��ʾ��������Ժ�ʼ��ʱ0.1s
        Database.numCards++;
        GameObject prefabInstance = Instantiate(prefabName);
        prefabInstance.transform.parent = GameObject.Find("UI/CardPanel").gameObject.transform;
        prefabInstance.gameObject.GetComponent<RectTransform>().localScale = new Vector3(2, 2, 2);//�趨���ƴ�С
        prefabInstance.gameObject.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
        SortCards(Database.numCards);
    }
    
    //����ΪʹDialogueSystem���÷�������õĺ���
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
