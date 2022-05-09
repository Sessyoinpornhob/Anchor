using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
//重构完成

public class ObjController : MonoBehaviour
{
    private GameObject[] _obj00;
    private GameObject[] _obj01;

    void Start()
    {
        _obj00 = GameObject.FindGameObjectsWithTag("00");
        _obj01 = GameObject.FindGameObjectsWithTag("01");
    }

    public void SetSr00(int a)
    {
        _obj00[a].gameObject.GetComponent<SpriteRenderer>().DOFade(1, 3);
    }
    
    public void SetSr01(int a)
    {
        _obj01[a].gameObject.GetComponent<SpriteRenderer>().DOFade(1, 3);
    }

}