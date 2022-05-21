using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour 
{
    public int maxHealth = 5;
    public int currentHealth;
public LayerMask whatIsGround;
Animator animator;
//public Transform groundCheck;
public Transform gh1;
public Transform gh2;
public Transform gh3;
public bool isGrounded;
public bool g1;
public bool g2;
public bool g3;
Rigidbody2D rigidbody2d;
public TextMeshProUGUI BulletBar;
public float jumpForce;
public float speed;
Rigidbody2D rb;
public bool isLookingLeft;
public GameObject bullet;
Vector2 lookDirection;
public int bulletcount;
public AudioClip shot;
AudioSource audioSource;
void Start () {
rb = GetComponent <Rigidbody2D> ();
rigidbody2d = GetComponent <Rigidbody2D> ();
currentHealth = maxHealth;
animator = GetComponent<Animator>();
audioSource= GetComponent<AudioSource>();
}
void Launch()
{
if(bulletcount>=1)
{
        GameObject projectileObject = Instantiate(bullet, rigidbody2d.position + Vector2.up * 0.24f, Quaternion.identity);

        Projectile projectile = projectileObject.GetComponent<Projectile>();
        projectile.Launch(lookDirection, 500);
bulletcount--;
audioSource.PlayOneShot(shot);
BulletBar.text = Convert.ToString(bulletcount)+"/3";
 }  
}
public void PlaySound(AudioClip clip)
{
    audioSource.PlayOneShot(clip);
}
void Update () {
if (Input.GetButtonDown ("Jump") && isGrounded) {
rb.AddForce (Vector2.up * jumpForce, ForceMode2D.Impulse);
isGrounded = false;
}
        if(Input.GetKeyDown(KeyCode.C))
        {
                if (isLookingLeft==true)
    {
        lookDirection= new Vector2(-1,0);
    }
    else
    {
        lookDirection= new Vector2(1,0);
    }
            Launch();
        }
}

void FixedUpdate () {
g1 = Physics2D.OverlapPoint (gh1.position, whatIsGround);
g2 = Physics2D.OverlapPoint (gh2.position, whatIsGround);
g3 = Physics2D.OverlapPoint (gh3.position, whatIsGround);
isGrounded=g1|g2|g3;
float x = Input.GetAxis ("Horizontal");
if(x!=0)
{
    animator.SetBool("run",true);
}
else
{
    animator.SetBool("run",false);
}
Vector3 move = new Vector3 (x * speed, rb.velocity.y, 0f);
rb.velocity = move;
if (x < 0 && !isLookingLeft)
Turn ();
if (x > 0 && isLookingLeft)
Turn ();
}
void Turn ()
{
isLookingLeft = !isLookingLeft;
transform.localScale = new Vector3 (transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
}
}