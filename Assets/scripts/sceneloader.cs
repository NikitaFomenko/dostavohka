using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneloader : MonoBehaviour
{
    // Start is called before the first frame update
    public void sceneload(int i)
    {
        SceneManager.LoadScene(i);
    }
    public void quit()
    {
        Application.Quit();
    }
}
