using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedroomObjController : MonoBehaviour
{
    public GameObject Sprite;
    
    float alpha = 1f;

    //前置等待时长
    public float waittime = 0;

    //渐变时长
    public float time = 0.5f;

    //定时器
    public float timer;

    //目标颜色
    public Color color;

    // Start is called before the first frame update
    void Start()
    {
        alpha = Sprite.GetComponent<SpriteRenderer>().color.a;

        color = Sprite.GetComponent<SpriteRenderer>().color;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("0"))
        {
            Database.isOldManColored = true;
            
            Debug.Log("wori");

            if (Input.GetKeyDown("8"))
            {
                Debug.Log("wansui");
            }
        }
        

        if (Database.isOldManColored && timer <= 5f)
        {
            timer += Time.deltaTime;

            if (timer > waittime)
            {
                alpha = (time - (timer - waittime)) / time;

                Sprite.GetComponent<SpriteRenderer>().color = new Color(color.r, color.g, color.b, alpha);
            }   
        }

        float alphaa = alpha;

        Sprite.GetComponent<SpriteRenderer>().color = new Color(color.r, color.g, color.b, alphaa);


    }

    //输入函数一个是对应目标，一个是bool变量
    public void FadeIn()
    {
        //timer += Time.deltaTime;

        if (timer >= waittime && timer <= 5f)
        {
            timer += Time.deltaTime;

            alpha = (time - (timer - waittime)) / time;

            Sprite.GetComponent<SpriteRenderer>().color = new Color(color.r, color.g, color.b, alpha);

            timer = 0;
        }

        
    }
}
