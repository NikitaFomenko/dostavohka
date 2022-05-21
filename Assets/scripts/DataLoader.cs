using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class DataLoader : MonoBehaviour
{
    public GameObject buttonEnable;
    public GameObject buttonDisable;

    // Start is called before the first frame update
    void Start()
    {
        string fileName = @"DostSave\savelevel.txt";
        string lines = File.ReadAllText(fileName);
        if (lines=="u")
        {
            Destroy(buttonDisable);
        }
        else
        {
            Destroy(buttonEnable);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
