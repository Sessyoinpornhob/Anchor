using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;

/*
 * 这个脚本用于控制单张卡牌的变化与移动，算是所有卡牌的基类
 * 
 * 功能包括：鼠标移入、鼠标移出、点击事件（加了一个Button组件）、非锚点卡牌的计时自毁
 * 
 * Dialogue System相关的文本描述和识别卡牌携带信息见Dialogue Controller.cs
 *
 * 已重构完成
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
        //使用Alpha通道增加【获得卡牌】的效果
        if (CanTime)
        {
            _lifeTime = _lifeTime - 0.02f;//FixedUpdate()方法的调用频率是？
            text.text = _lifeTime.ToString("f1");//在文本的显示中保留一位小数
            if (_lifeTime <= 0.01f)
            {
                Database.cardDeleted = true;
                Destroy(gameObject, 0.01f);//这个时间配置就刚好（0.02f,0.2f,0.2f）
            }
        }
    }


    public void OnPointerEnter(PointerEventData eventData)    //鼠标移入
    {
        transform.DOLocalMoveY(UpMove, 0.1f, true);
        transform.localScale = new Vector3(3f, 3f, 3f);
        transform.SetAsLastSibling();
    }

    public void OnPointerExit(PointerEventData eventData)    //鼠标移出
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
        //获取卡牌名字，送入DialogueController.cs进行判断
        Database.currentCardName = gameObject.name;
        GameObject.Find("GameController").GetComponent<DialogueController>().CardCheck(CanDownMove);
        GameObject.Find("GameController").GetComponent<DialogueController>().CardsCheck();
    }
}