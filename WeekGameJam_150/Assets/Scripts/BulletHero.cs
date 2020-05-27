using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHero : MonoBehaviour
{
    public float speed;
    public Rigidbody rb;
    private AudioManager audioManager;
    public GameObject ExplosionFX;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        audioManager = FindObjectOfType<AudioManager>();
    }
    void Start()
    {
        rb.velocity = transform.forward * speed;
        Destroy(gameObject, 5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemies"))
        {
            Destroy(gameObject);

            //Spawn and destroy Explosion Particles
            Destroy(Instantiate(ExplosionFX, transform.position, Quaternion.identity), 2f);

            //Play Sounds
            audioManager.Play("Hero Bullet Fx");
        }
    }
}
