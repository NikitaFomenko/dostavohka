using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    public AudioClip clip;
    public AudioClip clip2;
    AudioSource audioSource;
    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        audioSource= GetComponent<AudioSource>();
        audioSource.PlayOneShot(clip);
    }
    
    public void Launch(Vector2 direction, float force)
    {
        rigidbody2d.AddForce(direction * force);
    }
    
    void Update()
    {
        if(transform.position.magnitude > 1000.0f)
        {
            Destroy(gameObject);
        }
    }
    
    void OnCollisionEnter2D(Collision2D other)
    {
        EnemyControlerClosly e = other.collider.GetComponent<EnemyControlerClosly>();
        if (e != null)
        {
            e.died();
            audioSource.PlayOneShot(clip2);
        }
    
        Destroy(gameObject);
    }
}