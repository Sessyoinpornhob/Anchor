using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using PixelCrushers.DialogueSystem;

public class DialogueController : MonoBehaviour
{
    public GameObject actor;
    public GameObject conversant;

    private void Update()
    {
        if (Input.GetKeyDown("q"))
        {
            DialogueManager.StartConversation("Story_Death", actor.transform, conversant.transform);
        }
    }

    //从传入名字和字符串操作角度考虑优化（反正判定条件和对话系统都是字符串
    public void CardCheck(bool canDownMove)
    {
        //用于单张卡牌的文本触发和变量录入
        //或者搞一个字典......
        switch (Database.currentCardName)
        {
            case "C_Brown(Clone)":
                if (canDownMove == false) {
                    DialogueManager.StartConversation("Story_Brown", actor.transform, conversant.transform);
                    Database.getCardBrown = true;
                }else {
                    Database.getCardBrown = false;
                } break;
            
            case "C_Flag(Clone)":
                if (canDownMove == false) {
                    DialogueManager.StartConversation("Story_Flag", actor.transform, conversant.transform);
                    Database.getCardFlag = true;
                }else {
                    Database.getCardFlag = false;
                } break;
            
            case "C_Radiation(Clone)":
                if (canDownMove == false) {
                    DialogueManager.StartConversation("Story_Radiation", actor.transform, conversant.transform);
                    Database.getCardRadiation = true;
                }else {
                    Database.getCardRadiation = false;
                } break;
            
            case "C_Knowledge(Clone)":
                if (canDownMove == false) {
                    DialogueManager.StartConversation("Story_Knowledge", actor.transform, conversant.transform);
                    Database.getCardKnowledge = true;
                }else{
                    Database.getCardKnowledge = false;
                } break;
            
            case "C_WinterSweet(Clone)":
                if (canDownMove == false) {
                    DialogueManager.StartConversation("Story_WinterSweet", actor.transform, conversant.transform);
                    Database.getCardWinterSweet = true;
                }else {
                    Database.getCardWinterSweet = false;
                } break;
            
            case "C_Electricity(Clone)":
                if (canDownMove == false) {
                    DialogueManager.StartConversation("Story_Electricity", actor.transform, conversant.transform);
                    Database.getCardElectricity = true;
                }else {
                    Database.getCardElectricity = false;
                } break;
            
            case "C_Confidence(Clone)":
                if (canDownMove == false) {
                    DialogueManager.StartConversation("Story_Confidence", actor.transform, conversant.transform);
                    Database.getCardConfidence = true;
                }else {
                    Database.getCardConfidence = false;
                } break;
            
            case "C_Tears(Clone)":
                if (canDownMove == false) {
                    DialogueManager.StartConversation("Story_Tears", actor.transform, conversant.transform);
                    Database.getCardTears = true;
                }else {
                    Database.getCardTears = false;
                } break;
            
            case "C_XuMei(Clone)":
                if (canDownMove == false) {
                    DialogueManager.StartConversation("Story_XuMei", actor.transform, conversant.transform);
                    Database.getCardXuMei = true;
                }else {
                    Database.getCardXuMei = false;
                } break;
            
            case "C_Pills(Clone)":
                if (canDownMove == false) {
                    DialogueManager.StartConversation("Story_Pills", actor.transform, conversant.transform);
                    Database.getCardPills = true;
                }else {
                    Database.getCardPills = false;
                } break;
            
            case "C_Life(Clone)":
                if (canDownMove == false) {
                    //DialogueManager.StartConversation("Story_Life", actor.transform, conversant.transform);
                    Database.getCardLife = true;
                }else {
                    Database.getCardLife = false;
                } break;
            
            case "C_Daughter(Clone)":
                if (canDownMove == false) {
                    DialogueManager.StartConversation("Story_Daughter", actor.transform, conversant.transform);
                    Database.getCardDaughter = true;
                }else {
                    Database.getCardDaughter = false;
                } break;
            case "C_Calander(Clone)":
                if (canDownMove == false) {
                    DialogueManager.StartConversation("Story_Calander", actor.transform, conversant.transform);
                    Database.getCardCalander = true;
                }else {
                    Database.getCardCalander = false;
                } break;
            case "C_Death(Clone)":
                if (canDownMove == false) {
                    DialogueManager.StartConversation("Story_Death", actor.transform, conversant.transform);
                    Database.getCardDeath = true;
                }else {
                    Database.getCardDeath = false;
                } break;
        }
    }
    //为了防止对话系统通道阻塞，用延时的方式避开卡片自身的描述
    //延时脚本见DelayToInvoke.cs
    //卡牌生成的事件调用在插件中，简化代码
    public void CardsCheck()
    {
        if (Database.getCardBrown && Database.getCardFlag)
        {
            //梅花 WinterSweet
            StartCoroutine(DelayToInvoke.DelayToInvokeDo(() =>
            {
                DialogueManager.StartConversation("StoryToWinterSweet", actor.transform, conversant.transform);
            }, 2.5f));
        }

        if (Database.getCardBrown && Database.getCardRadiation)
        {
            //to tears
            StartCoroutine(DelayToInvoke.DelayToInvokeDo(() =>
            {
                DialogueManager.StartConversation("StoryToTears", actor.transform, conversant.transform);
            }, 2.5f));
        }
        
        if (Database.getCardRadiation && Database.getCardFlag)
        {
            //to Knowledge
            StartCoroutine(DelayToInvoke.DelayToInvokeDo(() =>
            {
                DialogueManager.StartConversation("StoryToKnowledge", actor.transform, conversant.transform);
            }, 2.5f));
        }
        
        if (Database.getCardRadiation && Database.getCardKnowledge)
        {
            //to Electricity_Confidence
            StartCoroutine(DelayToInvoke.DelayToInvokeDo(() =>
            {
                DialogueManager.StartConversation("StoryToElectricity_Confidence", actor.transform, conversant.transform);
            }, 2.5f));
        }
        
        if (Database.getCardConfidence && Database.getCardWinterSweet)
        {
            //to XuMei
            StartCoroutine(DelayToInvoke.DelayToInvokeDo(() =>
            {
                DialogueManager.StartConversation("StoryToXuMei", actor.transform, conversant.transform);
            }, 2.5f));
        }
        
        if (Database.getCardXuMei && Database.getCardElectricity)
        {
            //to Life
            StartCoroutine(DelayToInvoke.DelayToInvokeDo(() =>
            {
                DialogueManager.StartConversation("StoryToLife", actor.transform, conversant.transform);
            }, 5f));
        }
        
        if (Database.getCardXuMei && Database.getCardTears)
        {
            //to Pills
            StartCoroutine(DelayToInvoke.DelayToInvokeDo(() =>
            {
                DialogueManager.StartConversation("StoryToPills", actor.transform, conversant.transform);
            }, 2.5f));
        }
        
        if (Database.getCardLife)
        {
            //to Calander
            StartCoroutine(DelayToInvoke.DelayToInvokeDo(() =>
            {
                DialogueManager.StartConversation("StoryToCalander", actor.transform, conversant.transform);
            }, 0.5f));
        }
        
        if (Database.getCardXuMei && Database.getCardCalander || Database.getCardPills && Database.getCardCalander )
        {
            //to Death
            StartCoroutine(DelayToInvoke.DelayToInvokeDo(() =>
            {
                DialogueManager.StartConversation("StoryToDeath", actor.transform, conversant.transform);
            }, 5f));
        }
    }

}
