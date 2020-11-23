using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour {
    public float speed = 1f;
	
	// Update is called once per frame
	void Update () {
        transform.Translate(0f, -speed * Time.deltaTime, 0f);

        if(transform.position.y <= -12)
        {
            transform.Translate(0f, 24f, 0f);
        }

	}
}
