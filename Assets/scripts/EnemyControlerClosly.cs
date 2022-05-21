using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class EnemyControlerClosly : MonoBehaviour
{
    public float speed;
    public bool vertical;
    public float changeTime = 3.0f;
    public TextMeshProUGUI HealtBar;
    Rigidbody2D rigidbody2D;
    float timer;
    int direction = 1;
    public int damage;
    //Animator animator;
    AudioSource audioSource;
    public AudioClip clip1;
    public GameObject player;
    public Image blood;
    
    Animator animator2;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        timer = changeTime;
        audioSource=player.GetComponent<AudioSource>();
        animator2=blood.GetComponent<Animator>();
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            direction = -direction;
            timer = changeTime;
            transform.localScale = new Vector3 (transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }
    }
    
    void FixedUpdate()
    {
       
        Vector2 position = rigidbody2D.position;
        
        if (vertical)
        {
            position.y = position.y + Time.deltaTime * speed * direction;
        }
        else
        {
            position.x = position.x + Time.deltaTime * speed * direction;
        }
        rigidbody2D.MovePosition(position);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerMove controller = other.GetComponent<PlayerMove>();

        if (controller != null)
        {
                controller.currentHealth=controller.currentHealth-damage;
                controller.PlaySound(clip1);
                HealtBar.text = Convert.ToString(controller.currentHealth)+"/"+Convert.ToString(controller.maxHealth);
                animator2.SetTrigger("heat");
                if (controller.currentHealth <= 0)
                {
                    SceneManager.LoadScene(2);
                }
        }
    }
public void died()
{

Destroy(gameObject);
}
}
