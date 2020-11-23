using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAI : MonoBehaviour {

	public Transform target;
	Animator animator;                  //control the animation
    private bool collidePlayer = false;   //check whether the mosnter collide with player or not
	protected Vector2 direction;
	
	private float MoveSpeed = 2.0f;
	// Use this for initialization
	void Start () {
		target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
		if(!collidePlayer)
		{
			transform.position = Vector2.MoveTowards(transform.position, target.position, MoveSpeed*Time.deltaTime);
		}
		
		direction = target.transform.position - transform.position;
		
		float posX = Math.Abs(direction.x);
		float posY = Math.Abs(direction.y);
		
		
		if(!collidePlayer)
		{
			if ((posX > posY) && (direction.x < 0))
				{
					animator.Play("MoveLeft");               
				}
			else if ((posX > posY) && (direction.x > 0))
				{
					animator.Play("MoveRight");                
				}
			else if ((posY > posX) && (direction.y < 0))
				{
					animator.Play("MoveDown");
				}
			else if ((posY > posX) && (direction.y > 0))
				{
					animator.Play("MoveFront");
				}
		}
			
		if(collidePlayer)
		{
			transform.Translate(0f,0f,0f);
		}
		
	}
	
	private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            collidePlayer = true;
            animator.Play("Explosion");
			Destroy (gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length); 
        }

    }
}
