using System;
using System.IO.Ports;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;   

public class ARDUINO : MonoBehaviour
{
    // Start is called before the first frame update
    public static int incomingdata = 0;
    public static SerialPort sp = new SerialPort("COM4", 9600);
    float timer;
    void Start(){
        
        sp.Open();
        sp.ReadTimeout = 1;
        sp.WriteLine("a");
    }

    // Update is called once per frame
    void Update()
    {
        
      //  sp.Write("7");

        try
        {
            timer += 1;
            if (timer % 10 == 0)
            {
                incomingdata = int.Parse(sp.ReadLine());
                Invoke("Return", 0.034f);
                timer = 0;
            }

        }
        catch (System.Exception)
        {
        }


        if (Input.GetKeyDown("x"))
        {
            sp.Write("a");
            Debug.Log("ae");
        }
        
        if (Input.GetKeyDown("v"))
        {
            sp.Write("b");
            Debug.Log("b");
        }
        
        if (Input.GetKeyDown("b"))
        {
            sp.Write("c");
            Debug.Log("c");
        }

    }
    void Return()
    {
        incomingdata = 0;
    }

    private void OnDestroy()
    {
        sp.Close();
    }
}