using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System;

public class Level1End : MonoBehaviour
{
void OnTriggerEnter2D(Collider2D other)
    {
        PlayerMove controller = other.GetComponent<PlayerMove>();

        if (controller != null)
        {
            int i=3;
            SceneManager.LoadScene(i);
            File.WriteAllTextAsync(@"DostSave\savelevel.txt", "u");
        }
    }
}
