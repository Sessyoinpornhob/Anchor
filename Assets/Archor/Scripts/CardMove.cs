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
            lifeTime = lifeTime - 0.02f;//FixedUpdate()方法的调用频率是？

            text.text = lifeTime.ToString("f1");//在文本的显示中保留一位小数

            if (lifeTime <= 0.2f)
            {
                
                
                Destroy(gameObject, 0.2f);//这个时间配置就刚好（0.02f,0.2f,0.2f）
            }
        }

    }


    public void OnPointerEnter(PointerEventData eventData)    //鼠标移入
    {
        //Debug.Log("the card is under mouse");

        transform.DOLocalMoveY(UpMove, 0.1f, true);

        transform.localScale = new Vector3(3f, 3f, 3f);//变大变小这种问题建议public出来，好改

        transform.SetAsLastSibling();//改变渲染层级
    }

    public void OnPointerExit(PointerEventData eventData)    //鼠标移出
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

        Database.currentCardName = gameObject.name;//调用static变量

        GameObject.Find("GameController").GetComponent<DialogueController>().CardCheck(CanDownMove);//调用别的public函数

        GameObject.Find("GameController").GetComponent<DialogueController>().CardsCheck();
    }

}