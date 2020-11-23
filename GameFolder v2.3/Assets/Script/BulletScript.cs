using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    Animator animator;
    AudioControl audioControl;
    public float movX = 0f;
    public float movY = 0f;
    public float bulletSpeed = 4.0f;
    GameControl gameControl;
    private bool collide = false;
    private float animationTime = 0.5f;
    private float counter = 0f;
    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        gameControl = GameObject.FindObjectOfType<GameControl>();
        audioControl = GameObject.FindObjectOfType<AudioControl>();
    }

    // Update is called once per frame
    void Update()
    {   if (!collide) 
            transform.Translate(movX * Time.deltaTime * bulletSpeed, movY * Time.deltaTime * bulletSpeed, 0f);
        if (collide)
        {
            counter += Time.deltaTime;
            if(counter > animationTime)
            {
                Destroy(gameObject);
                counter = 0f;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name.Equals("Rock(Clone)"))
        {
            audioControl.SmallExplosion();
            collide = true;
            animator.Play("ExplodeBullet");
            Destroy(other.gameObject);          
        }
        if (other.gameObject.name.Equals("Monster(Clone)"))
        {
            audioControl.SmallExplosion();
            collide = true;
            animator.Play("ExplodeBullet");
            Destroy(other.gameObject);
            gameControl.AddScore();
        }
    }
}
