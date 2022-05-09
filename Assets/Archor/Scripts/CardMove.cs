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
 *
 * ���ع����
 */


public class CardMove : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public float lifeTime;
    private float _lifeTime;

    public Text text;
    public bool CanTime = false;
    public float numCards;

    [SerializeField] private float UpMove;
    [SerializeField] private float DownMove;
    [SerializeField] private bool CanDownMove = true;


    public void Start()
    {
        _lifeTime = lifeTime;
    }

    public void FixedUpdate()
    {
        //ʹ��Alphaͨ�����ӡ���ÿ��ơ���Ч��
        if (CanTime)
        {
            _lifeTime = _lifeTime - 0.02f;//FixedUpdate()�����ĵ���Ƶ���ǣ�
            text.text = _lifeTime.ToString("f1");//���ı�����ʾ�б���һλС��
            if (_lifeTime <= 0.01f)
            {
                Database.cardDeleted = true;
                Destroy(gameObject, 0.01f);//���ʱ�����þ͸պã�0.02f,0.2f,0.2f��
            }
        }
    }


    public void OnPointerEnter(PointerEventData eventData)    //�������
    {
        transform.DOLocalMoveY(UpMove, 0.1f, true);
        transform.localScale = new Vector3(3f, 3f, 3f);
        transform.SetAsLastSibling();
    }

    public void OnPointerExit(PointerEventData eventData)    //����Ƴ�
    {
        if (CanDownMove)
        {
            transform.DOLocalMoveY(DownMove, 0.1f, true);
            transform.localScale = new Vector3(2f, 2f, 2f);
        }
    }

    public void Onclick()
    {
        if (CanDownMove)
        {
            CanDownMove = false;
        }
        else
        {
            CanDownMove = true;
        }
        //��ȡ�������֣�����DialogueController.cs�����ж�
        Database.currentCardName = gameObject.name;
        GameObject.Find("GameController").GetComponent<DialogueController>().CardCheck(CanDownMove);
        GameObject.Find("GameController").GetComponent<DialogueController>().CardsCheck();
    }
}