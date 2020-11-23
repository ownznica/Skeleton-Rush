using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rockscript : MonoBehaviour {
	
	public float moveSpeed = 1.0f;
	public Transform target;
	Animator animator;                  //control the animation

	// Use this for initialization
	void Start () {
		target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(0f, -moveSpeed * Time.deltaTime, 0f);
	}
	
	private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            animator.Play("ExplodeRock");
			Destroy (gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length); 
        }
    }
}

