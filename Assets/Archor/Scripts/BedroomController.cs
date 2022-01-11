using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedroomController : MonoBehaviour
{
    private GameObject[] _00List;
    private GameObject[] _01List;
    void Start()
    {
        _00List = GameObject.FindGameObjectsWithTag("00");
        _01List = GameObject.FindGameObjectsWithTag("01");
        
        for (int i = 0; i < _00List.Length; i++)
        {
            _00List[i].GetComponent<SpriteRenderer>().enabled = false;
        }
        for (int i = 0; i < _00List.Length; i++)
        {
            _01List[i].GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    public void BookShelf00()
    {
        _00List[0].GetComponent<SpriteRenderer>().enabled = true;
        //列表顺序就是Hierarchy中的顺序，酷啊
        //或者写一个字典简化代码？
    }
    public void Happiness00()
    {
        _00List[1].GetComponent<SpriteRenderer>().enabled = true;
    }
    public void NighTable00()
    {
        _00List[2].GetComponent<SpriteRenderer>().enabled = true;
    }
    public void TableFront00()
    {
        _00List[3].GetComponent<SpriteRenderer>().enabled = true;
    }
    public void TV00()
    {
        _00List[4].GetComponent<SpriteRenderer>().enabled = true;
    }
    public void WallA00()
    {
        _00List[5].GetComponent<SpriteRenderer>().enabled = true;
    }
    public void WallB00()
    {
        _00List[6].GetComponent<SpriteRenderer>().enabled = true;
    }

    //从00-01
    public void A()
    {
        _01List[0].GetComponent<SpriteRenderer>().enabled = true;
    }
    public void B()
    {
        _01List[1].GetComponent<SpriteRenderer>().enabled = true;
    }
    public void C()
    {
        _01List[2].GetComponent<SpriteRenderer>().enabled = true;
    }
    public void D()
    {
        _01List[3].GetComponent<SpriteRenderer>().enabled = true;
    }
    public void E()
    {
        _01List[4].GetComponent<SpriteRenderer>().enabled = true;
    }
    public void F()
    {
        _01List[5].GetComponent<SpriteRenderer>().enabled = true;
    }
    public void G()
    {
        _01List[6].GetComponent<SpriteRenderer>().enabled = true;
    }
    public void H()
    {
        _01List[7].GetComponent<SpriteRenderer>().enabled = true;
    }
    public void I()
    {
        _01List[8].GetComponent<SpriteRenderer>().enabled = true;
    }
    
}
