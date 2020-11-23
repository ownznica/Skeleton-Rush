using UnityEngine;
using UnityEngine.UI; 
using System.Collections;
using UnityEngine.SceneManagement;


    public class GameControl : MonoBehaviour {
    public Text scoreText, minText, secText, bulletText, gameOverText, livesText , reloadText, levelText;
	
    int playerScore = 0;
    int playerLives = 5;
    int playerBullet = 5;
    int level = 1;
    int MaxAmmo = 5;
    bool freezeTime = false;
    AnimationControl aniControl;
    AudioControl audioControl;
    Spawning spawning;
	
	
    void Start(){
	    aniControl = GameObject.FindObjectOfType<AnimationControl>();
        audioControl = GameObject.FindObjectOfType<AudioControl>();
        spawning = GameObject.FindObjectOfType<Spawning>();
    }
	
    void Update(){
        if (!freezeTime)
        {
            //float gametime = Time.realtimeSinceStartup;
			float gametime = Time.timeSinceLevelLoad;
            //Compute the gametime in minutes and seconds

            int minutes = (int)(gametime / 60f);
            int seconds = (int)(gametime % 60f);

            if (minutes < 10 && seconds < 10)
            {
                minText.text = "0" + minutes.ToString();
                secText.text = "0" + seconds.ToString();
            }
            else if (seconds < 10)
            {
                minText.text = minutes.ToString();
                secText.text = "0" + seconds.ToString();
            }
            else if (minutes < 10)
            {
                minText.text = "0" + minutes.ToString();
                secText.text = seconds.ToString();
            }
            else
            {
                minText.text = minutes.ToString();
                secText.text = seconds.ToString();
            }
        }
		
    }
	
	
	public int BulletNum()
    {
		playerBullet --;
		bulletText.text = "Bullet : " + playerBullet.ToString();
        return playerBullet;
	}
	
	public void reloaded()
    {
        playerBullet = MaxAmmo;
        bulletText.text = "Bullet : " + playerBullet.ToString();
       	reloadText.enabled = false;
    }

    public void AddAmmo()
    {
        MaxAmmo++;
    }
	
	public void AddScore()
    {
		playerScore ++;
		scoreText.text = "Score : " + playerScore.ToString();
		
		PlayerPrefs.SetInt("PlayerEndScore", playerScore);
	
		if(playerScore%6 == 0)
        {
            audioControl.LevelUp();
            level++;
            levelText.text = "Level : " + level.ToString();
            if(spawning.spawnTimeMonster != 0.5f)
                spawning.spawnTimeMonster = spawning.spawnTimeMonster - 0.5f;
        }
		
		if(playerScore > PlayerPrefs.GetInt("HighestScore"))
		{
			PlayerPrefs.SetInt("HighestScore", playerScore);
		}
		
		
	}
	
	
    public void LivesNum()
    {
		playerLives --;
		livesText.text = "Lives : " + playerLives.ToString();
        if(playerLives == 0)
        {
            freezeTime = true;
            gameOverText.enabled = true; // Display the Game Over! Text
            Time.timeScale = 0; // This freezes the game
			
			
			SceneManager.LoadScene(2);
        }
	}

    public void AddLives()
    {
        playerLives++;
        livesText.text = "Lives : " + playerLives.ToString();
    }
	
    public void Reload() {
		
	    reloadText.enabled = true;
		
	    //relocate the text according to the player's position		
	    reloadText.transform.position = aniControl.playerPos + new Vector3 (0f, 0.8f, 0);
	
    }
    public void DeleteAll()
    {
        GameObject[] rocks;
        rocks = GameObject.FindGameObjectsWithTag("Rock");

        foreach(GameObject rock in rocks)
        {
            Destroy(rock);
        }

        GameObject[] monsters;
        monsters = GameObject.FindGameObjectsWithTag("Monster");

        foreach(GameObject monster in monsters)
        {
            Destroy(monster);
        }
    }
	
}
	
