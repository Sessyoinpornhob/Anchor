using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CardController : MonoBehaviour
{
    //�������ʵ��������ͻ�������������
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

            CardList[i].gameObject.GetComponent<RectTransform>().localPosition = new Vector3(((i+1)/ (NumCards+1)) * width - 60, 0);//�趨λ��

            //Debug.Log(i+1 + " ���Ƶ�λ���� " + CardList[i].gameObject.GetComponent<RectTransform>().localPosition.x);
        }
    }

    IEnumerator GetCard(float DelayTime, GameObject prefabName)
    {
        yield return new WaitForSeconds(DelayTime);

        //������ʹ��Э������һ����ʱ������ʱDelayTime�Ժ�ִ�����溯��

        //Debug.Log("������");

        //��Ϊʲô���ھ�������Ժ�ſ�ʼ��ʱ�İ�
        //0f��ʾ�����ã�0.1f��ʾ��������Ժ�ʼ��ʱ0.1s

        NumCards = NumCards + 1;

        GameObject PrefabInstance = Instantiate(prefabName);

        PrefabInstance.transform.parent = GameObject.Find("Canvas/CardPanel").gameObject.transform;

        PrefabInstance.gameObject.GetComponent<RectTransform>().localScale = new Vector3(2, 2, 2);//�趨���ƴ�С

        PrefabInstance.gameObject.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);

        SortCards(NumCards);
    }


    //����ΪʹDialogueSystem���÷�������õĺ���
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
