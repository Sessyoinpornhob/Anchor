using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;

/*
 * ����ű����ڿ��Ƶ��ſ��Ƶı仯���ƶ����������п��ƵĻ���
 * 
 * ���ܰ�����������롢����Ƴ�������¼�������һ��Button���������ê�㿨�Ƶļ�ʱ�Ի�
 * 
 * Dialogue System��ص��ı�������ʶ����Я����Ϣ��Dialogue Controller.cs
 */


public class CardMove : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public float LifeTime;
    [SerializeField] private float lifeTime;

    public Text text;
    public bool CanTime = false;

    [SerializeField] private float UpMove;
    [SerializeField] private float DownMove;
    [SerializeField] private bool CanDownMove = true;


    public void Start()
    {
        lifeTime = LifeTime;
    }

    public void FixedUpdate()
    {
        if (CanTime)
        {
            lifeTime = lifeTime - 0.02f;//FixedUpdate()�����ĵ���Ƶ���ǣ�

            text.text = lifeTime.ToString("f1");//���ı�����ʾ�б���һλС��

            if (lifeTime <= 0.2f)
            {
                
                
                Destroy(gameObject, 0.2f);//���ʱ�����þ͸պã�0.02f,0.2f,0.2f��
            }
        }

    }


    public void OnPointerEnter(PointerEventData eventData)    //�������
    {
        //Debug.Log("the card is under mouse");

        transform.DOLocalMoveY(UpMove, 0.1f, true);

        transform.localScale = new Vector3(3f, 3f, 3f);//����С�������⽨��public�������ø�

        transform.SetAsLastSibling();//�ı���Ⱦ�㼶
    }

    public void OnPointerExit(PointerEventData eventData)    //����Ƴ�
    {
        //Debug.Log("exit");

        if (CanDownMove)
        {
            transform.DOLocalMoveY(DownMove, 0.1f, true);
            
            transform.localScale = new Vector3(2f, 2f, 2f);
            
            //cv.sortingOrder += 100;
        }

    }

    public void Onclick()
    {
        //Debug.Log("click");

        if (CanDownMove)
        {
            CanDownMove = false;
        }
        else
        {
            CanDownMove = true;
        }

        Database.currentCardName = gameObject.name;//����static����

        GameObject.Find("GameController").GetComponent<DialogueController>().CardCheck(CanDownMove);//���ñ��public����

        GameObject.Find("GameController").GetComponent<DialogueController>().CardsCheck();
    }

}