using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using PixelCrushers.DialogueSystem;

public class DialogueController : MonoBehaviour
{
    public GameObject actor;
    public GameObject conversant;

    void Start()
    {

    }

    //测试后门
    void Update()
    {
        if (Input.GetKeyDown("k"))
        {
            GameObject.Find("StoryToKnowledge").GetComponent<DialogueSystemTrigger>().enabled = true;
        }
        if (Input.GetKeyDown("c"))
        {
            GameObject.Find("StoryToConfidenceAndElectricity").GetComponent<DialogueSystemTrigger>().enabled = true;
        }
        if (Input.GetKeyDown("w"))
        {
            GameObject.Find("StoryToWinterSweet").GetComponent<DialogueSystemTrigger>().enabled = true;
        }
    }

    //从传入名字和字符串操作角度考虑优化（反正判定条件和对话系统都是字符串
    public void CardCheck(bool CanDownMove)
    {
        //用于单张卡牌的文本触发和变量录入
        if (Database.currentCardName == "C_Brown(Clone)")
        {
            if (CanDownMove == false)
            {
                DialogueManager.StartConversation("Story_Brown", actor.transform, conversant.transform);
                Database.getCardBrown = true;
            }
            else
            {
                Database.getCardBrown = false;
            }
        }

        if (Database.currentCardName == "C_Flag(Clone)")
        {
            if (CanDownMove == false)
            {
                DialogueManager.StartConversation("Story_Flag", actor.transform, conversant.transform);
                Database.getCardFlag = true;
            }
            else
            {
                Database.getCardFlag = false;
            }
        }

        if (Database.currentCardName == "C_Radiation(Clone)")
        {
            if (CanDownMove == false)
            {
                DialogueManager.StartConversation("Story_Radiation", actor.transform, conversant.transform);
                Database.getCardRadiation = true;
            }
            else
            {
                Database.getCardRadiation = false;
            }
        }

        if (Database.currentCardName == "C_Knowledge(Clone)")
        {
            if (CanDownMove == false)
            {
                DialogueManager.StartConversation("Story_Knowledge", actor.transform, conversant.transform);
                Database.getCardKnowledge = true;
            }
            else
            {
                Database.getCardKnowledge = false;
            }
        }

        if (Database.currentCardName == "C_WinterSweet(Clone)")
        {
            if (CanDownMove == false)
            {
                DialogueManager.StartConversation("Story_WinterSweet", actor.transform, conversant.transform);
                Database.getCardWinterSweet = true;
            }
            else
            {
                Database.getCardWinterSweet = false;
            }
        }

        if (Database.currentCardName == "C_Electricity(Clone)")
        {
            if (CanDownMove == false)
            {
                DialogueManager.StartConversation("Story_Electricity", actor.transform, conversant.transform);
                Database.getCardElectricity = true;
            }
            else
            {
                Database.getCardElectricity = false;
            }
        }

        if (Database.currentCardName == "C_Confidence(Clone)")
        {
            if (CanDownMove == false)
            {
                DialogueManager.StartConversation("Story_Confidence", actor.transform, conversant.transform);
                Database.getCardConfidence = true;
            }
            else
            {
                Database.getCardConfidence = false;
            }
        }

        if (Database.currentCardName == "C_Tears(Clone)")
        {
            if (CanDownMove == false)
            {
                DialogueManager.StartConversation("Story_Tears", actor.transform, conversant.transform);
                Database.getCardTears = true;
            }
            else
            {
                Database.getCardTears = false;
            }
        }

        if (Database.currentCardName == "C_XuMei(Clone)")
        {
            if (CanDownMove == false)
            {
                DialogueManager.StartConversation("Story_XuMei", actor.transform, conversant.transform);
                Database.getCardXuMei = true;
            }
            else
            {
                Database.getCardXuMei = false;
            }
        }

        if (Database.currentCardName == "C_Pills(Clone)")
        {
            if (CanDownMove == false)
            {
                DialogueManager.StartConversation("Story_Pills", actor.transform, conversant.transform);
                Database.getCardPills = true;
            }
            else
            {
                Database.getCardPills = false;
            }
        }

        if (Database.currentCardName == "C_Life(Clone)")
        {
            if (CanDownMove == false)
            {
                DialogueManager.StartConversation("Story_Life", actor.transform, conversant.transform);
                Database.getCardLife = true;
            }
            else
            {
                Database.getCardLife = false;
            }
        }

        if (Database.currentCardName == "C_Daughter(Clone)")
        {
            if (CanDownMove == false)
            {
                DialogueManager.StartConversation("Story_Daughter", actor.transform, conversant.transform);
                Database.getCardDaughter = true;
            }
            else
            {
                Database.getCardDaughter = false;
            }
        }

        if (Database.currentCardName == "C_Calander(Clone)")
        {
            if (CanDownMove == false)
            {
                DialogueManager.StartConversation("Story_Calander", actor.transform, conversant.transform);
                Database.getCardCalander = true;
            }
            else
            {
                Database.getCardCalander = false;
            }
        }

        if (Database.currentCardName == "C_Death(Clone)")
        {
            if (CanDownMove == false)
            {
                DialogueManager.StartConversation("Story_Death", actor.transform, conversant.transform);
                Database.getCardDeath = true;
            }
            else
            {
                Database.getCardDeath = false;
            }
        }
    }

    //要考虑吞演出的问题：Flag的台词演进中，不能触发下一段台词，会覆盖。
    public void CardsCheck()
    {
        if (Database.getCardBrown && Database.getCardFlag)
        {
            Invoke("GetCardStoryToWinterSweet",3f);
        }

        if (Database.getCardBrown && Database.getCardRadiation)
        {
            Invoke("GetCardStoryToTears", 2f);
            //为了防止对话系统通道阻塞，用延时的方式避开卡片自身的描述。
            //什么垃圾插件，回去我必把unity的基础知识和架构以及这两个插件搞明白
        }

        if (Database.getCardFlag && Database.getCardRadiation)
        {
            Invoke("GetCardStoryToKnowledge", 3f);
        }

        if (Database.getCardTears && Database.getCardXuMei)
        {
            Invoke("GetCardStoryToPills", 8f);
        }

        if (Database.getCardKnowledge && Database.getCardRadiation)
        {
            Invoke("GetCardStoryToConfidenceAndElectricity", 3f);
        }

        if (Database.getCardConfidence && Database.getCardWinterSweet)
        {
            Invoke("GetCardStoryToXuMei", 3f);
        }

        if (Database.getCardXuMei && Database.getCardElectricity)
        {
            Invoke("GetCardStoryToLife", 3f);
        }

        if (Database.getCardLife)
        {
            Invoke("GetCardStoryToCalander", 3f);
        }

        if (Database.getCardXuMei && Database.getCardCalander || Database.getCardCalander && Database.getCardPills)
        {
            Invoke("GetCardStoryToDeath", 3f);
            //结局
        }
    }


    //to wintersweet
    public void GetCardStoryToWinterSweet()
    {
        DialogueManager.StartConversation("StoryToWinterSweet", actor.transform, conversant.transform);
        Invoke("GetCardWinterSweet", 12f);

        //Invoke("ReGetCardWinterSweet", 12f);
    }
    public void GetCardWinterSweet()
    {
        GameObject.Find("StoryToWinterSweet").GetComponent<DialogueSystemTrigger>().enabled = true;
    }

    //to tears
    public void GetCardStoryToTears()
    {
        DialogueManager.StartConversation("StoryToTears", actor.transform, conversant.transform);
        Invoke("GetCardTears", 12f);
    }
    public void GetCardTears()
    {
        GameObject.Find("StoryToTears").GetComponent<DialogueSystemTrigger>().enabled = true;
    }

    //to Knowledge
    public void GetCardStoryToKnowledge()
    {
        DialogueManager.StartConversation("StoryToKnowledge", actor.transform, conversant.transform);
        Invoke("GetCardKnowledge", 6f);
    }
    public void GetCardKnowledge()
    {
        GameObject.Find("StoryToKnowledge").GetComponent<DialogueSystemTrigger>().enabled = true;
    }

    //to Pills
    public void GetCardStoryToPills()
    {
        DialogueManager.StartConversation("StoryToPills", actor.transform, conversant.transform);
        Invoke("GetCardPills", 6f);
    }
    public void GetCardPills()
    {
        GameObject.Find("StoryToPills").GetComponent<DialogueSystemTrigger>().enabled = true;
    }

    //to Confidence / Electricity
    public void GetCardStoryToConfidenceAndElectricity()
    {
        DialogueManager.StartConversation("StoryToConfidenceAndElectricity", actor.transform, conversant.transform);
        Invoke("GetCardToConfidenceAndElectricity", 15f);
    }
    public void GetCardToConfidenceAndElectricity()
    {
        GameObject.Find("StoryToConfidenceAndElectricity").GetComponent<DialogueSystemTrigger>().enabled = true;
    }

    //to XuMei
    public void GetCardStoryToXuMei()
    {
        DialogueManager.StartConversation("StoryToXuMei", actor.transform, conversant.transform);
        Invoke("GetCardToXuMei", 8f);
    }
    public void GetCardToXuMei()
    {
        GameObject.Find("StoryToXuMei").GetComponent<DialogueSystemTrigger>().enabled = true;
    }

    //to Life
    public void GetCardStoryToLife()
    {
        DialogueManager.StartConversation("StoryToLife", actor.transform, conversant.transform);
        Invoke("GetCardToLife", 8f);
    }
    public void GetCardToLife()
    {
        GameObject.Find("StoryToLife").GetComponent<DialogueSystemTrigger>().enabled = true;
    }

    //to Life
    public void GetCardStoryToCalander()
    {
        DialogueManager.StartConversation("StoryToCalander", actor.transform, conversant.transform);
        Invoke("GetCardToCalander", 3f);
    }
    public void GetCardToCalander()
    {
        GameObject.Find("StoryToCalander").GetComponent<DialogueSystemTrigger>().enabled = true;
    }

    //to Death
    public void GetCardStoryToDeath()
    {
        DialogueManager.StartConversation("StoryToDeath", actor.transform, conversant.transform);
        Invoke("GetCardToDeath", 8f);
    }
    public void GetCardToDeath()
    {
        GameObject.Find("StoryToDeath").GetComponent<DialogueSystemTrigger>().enabled = true;
    }

}
