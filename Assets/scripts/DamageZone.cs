using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class DamageZone : MonoBehaviour
{
    public AudioClip clip2;
    public TextMeshProUGUI HealtBar;
    public GameObject player;
    public Image blood;
    Animator animator2;
    void Start()
    {
        animator2=blood.GetComponent<Animator>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerMove controller = other.GetComponent<PlayerMove>();

        if (controller != null)
        {
                controller.currentHealth=controller.currentHealth-1;
                controller.PlaySound(clip2);
                HealtBar.text = Convert.ToString(controller.currentHealth)+"/"+Convert.ToString(controller.maxHealth);
                animator2.SetTrigger("heat");
                if (controller.currentHealth <= 0)
                {
                    SceneManager.LoadScene(2);
                }
        }
    }
}

