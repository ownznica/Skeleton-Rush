using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour {

    public GameObject rock;
	public GameObject monster;
    public GameObject life;
    public GameObject ammo;
    public float spawnTimeRock = 2.0f;
	public float spawnTimeMonster = 4.0f;
    public float spawnLife = 15.0f;
    public float spawnAmmo = 10.0f;
    private float timeElaspedMonster = 0f;
	private float timeElaspedRock = 0f;
    private float timeElaspedLife = 0f;
    private float timeElaspedAmmo = 0f;
    public bool spawning = true;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        timeElaspedRock += Time.deltaTime;
		timeElaspedMonster += Time.deltaTime;
        timeElaspedAmmo += Time.deltaTime;
        timeElaspedLife += Time.deltaTime;
        if(timeElaspedRock > spawnTimeRock)
        {
            if(spawning)
            {
                GameObject spawn1;
                spawn1 = Instantiate(rock) as GameObject;
                spawn1.transform.position = new Vector3(Random.Range(-5, 5), 7.0f, -1.0f);
                timeElaspedRock = 0f;
            }
        }
		
		if(timeElaspedMonster > spawnTimeMonster)
        {
            GameObject spawn2;
            spawn2 = Instantiate(monster) as GameObject;
            spawn2.transform.position = new Vector3(Random.Range(-5, 5), 7.0f, -1.0f);
            timeElaspedMonster = 0f;
        }

        if (timeElaspedLife > spawnLife)
        {
            GameObject spawn3;
            spawn3 = Instantiate(life) as GameObject;
            spawn3.transform.position = new Vector3(Random.Range(-5, 5), 7.0f, -1.0f);
            timeElaspedLife = 0f;
        }

        if (timeElaspedAmmo > spawnAmmo)
        {
            GameObject spawn4;
            spawn4 = Instantiate(ammo) as GameObject;
            spawn4.transform.position = new Vector3(Random.Range(-5, 5), 7.0f, -1.0f);
            timeElaspedAmmo = 0f;
        }
    }
}

