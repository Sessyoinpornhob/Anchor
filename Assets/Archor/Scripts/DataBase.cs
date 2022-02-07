using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Database
{
    public static string currentCardName = "waiting";

    public static bool getCardBrown = false;
    public static bool getCardFlag = false;
    public static bool getCardRadiation = false;
    public static bool getCardKnowledge = false;
    public static bool getCardWinterSweet = false;
    public static bool getCardElectricity = false;
    public static bool getCardConfidence = false;
    public static bool getCardTears = false;
    public static bool getCardXuMei = false;
    public static bool getCardPills = false;
    public static bool getCardLife = false;
    public static bool getCardDaughter = false;
    public static bool getCardCalander = false;
    public static bool getCardDeath = false;

    public static float numCards = 0f;
    public static bool cardDeleted = false;

    public static bool is00Active = false;
    public static bool is01Active = false;


    //顺便研究一下数据库怎么写
    //用静态的公开变量记录卡牌的选择状态，在其他的脚本内调用。可行
    //抉择：静态变量是用bool还是string？
}