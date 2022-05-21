using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class level2end : MonoBehaviour
{
void OnTriggerEnter2D(Collider2D other)
    {
        PlayerMove controller = other.GetComponent<PlayerMove>();

        if (controller != null)
        {
            SceneManager.LoadScene(4);
    
        }
    }
}