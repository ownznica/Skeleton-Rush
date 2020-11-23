using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shedder : MonoBehaviour {
	
    GameControl gameControl;

    void Start()
    {
        gameControl = GameObject.FindObjectOfType<GameControl>();
    }
    //remove gameobjects that's moved outside the game scene
    private void OnTriggerEnter2D(Collider2D other)
    {
        Vector3 respawnPos = new Vector3(0f, 0f, 0f);
        if(other.gameObject.name.Equals("Player"))
        {
            gameControl.LivesNum();
            other.transform.localPosition = respawnPos;
            gameControl.DeleteAll();
        }
        else
            Destroy(other.gameObject);

    }
}
