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

    void Update()
    {

    }

    //�Ӵ������ֺ��ַ��������Ƕȿ����Ż��������ж������ͶԻ�ϵͳ�����ַ���
    public void CardCheck(bool CanDownMove)
    {
        //���ڵ��ſ��Ƶ��ı������ͱ���¼��
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

    //Ҫ�������ݳ������⣺Flag��̨���ݽ��У����ܴ�����һ��̨�ʣ��Ḳ�ǡ�
    public void CardsCheck()
    {
        if (Database.getCardBrown && Database.getCardFlag)
        {
            Invoke("GetCardStoryToWinterSweet",2f);
        }

        if (Database.getCardBrown && Database.getCardRadiation)
        {
            Invoke("GetCardStoryToTears", 2f);
            //Ϊ�˷�ֹ�Ի�ϵͳͨ������������ʱ�ķ�ʽ�ܿ���Ƭ�����������
            //ʲô�����������ȥ�ұذ�unity�Ļ���֪ʶ�ͼܹ��Լ����������������
        }
    }

    //to wintersweet
    public void GetCardStoryToWinterSweet()
    {
        DialogueManager.StartConversation("StoryToWinterSweet", actor.transform, conversant.transform);
        Invoke("GetCardWinterSweet", 12f);
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



}
