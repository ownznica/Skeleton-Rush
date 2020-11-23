using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControl : MonoBehaviour {

    //enum to control the player faced position to generate correct shooting position of bullets.
    enum PlayerFacePosition { up, left, down, right };
    PlayerFacePosition FacePosition;

    Animator animator;                  //control the animation
    BulletScript bulletScript;   //get access to BulletScript script
    GameControl gameControl;     //get access to GameControl script
    AudioControl audioControl;
    public GameObject bulletPrefab;     //delare the bullet prefab
    public float playerSpeed = 4.0f;    //player movement speed
    private float timeCount = 2.0f;     //time that rock block the player from moving
    private float reloadTime = 2.0f;
    private float bulletInterval = 0.3f;
    private float timeElapsed = 0f;
    private float counter = 0f;
    private bool reloading = false;
    public bool collideRock = false;   //check wheather the player collide with rock/mosnter or not

    public Vector3 playerPos;
    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
        gameControl = GameObject.FindObjectOfType<GameControl>();
        audioControl = GameObject.FindObjectOfType<AudioControl>();
        FacePosition = PlayerFacePosition.up;
	}
	
	// Update is called once per frame
	void Update () {
        playerPos = transform.position;
        transform.Translate(0f, -1.0f * Time.deltaTime, 0f);    //just make the player to move backward, nothing special
        if (!collideRock)                                       //enable player to move
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x + Input.GetAxis("Horizontal") * playerSpeed * Time.deltaTime, -7f, 7f), transform.position.y, transform.position.z);
            transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y + Input.GetAxis("Vertical") * playerSpeed * Time.deltaTime, -4.5f, 5f), transform.position.z);
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                animator.Play("Left");  //play the animation "Left"
                FacePosition = PlayerFacePosition.left;
            }
            else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                animator.Play("Right");
                FacePosition = PlayerFacePosition.right;
            }
            else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            {
                animator.Play("Down");
                FacePosition = PlayerFacePosition.down;
            }
            else if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
            {
                animator.Play("Front");
                FacePosition = PlayerFacePosition.up;
            }
            if(Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.W))
            {
                animator.Play("NonMoveFront");
            }
            if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.A))
            {
                animator.Play("NonMoveLeft");
            }
            if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.D))
            {
                animator.Play("NonMoveRight");
            }
            if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S))
            {
                animator.Play("NonMoveDown");
            }
        }
        if(!reloading)
        {
            timeElapsed += Time.deltaTime;
            if (Input.GetKey(KeyCode.Space) && timeElapsed > bulletInterval) //press "space" key to shoot bullets
            {
                timeElapsed = 0f;
                int bulletCount = gameControl.BulletNum();
                if (bulletCount == 0)
                    reloading = true;
                Vector3 spawnPos = transform.position;
                if (FacePosition == PlayerFacePosition.up)
                {
                    spawnPos += new Vector3(0f, 1f, 0f);
                    GameObject bullet = Instantiate(bulletPrefab, spawnPos, Quaternion.Euler(0f, 0f, 270f));
                    bulletScript = bullet.GetComponent<BulletScript>();
                    bulletScript.movX = -1.0f;
                }
                if (FacePosition == PlayerFacePosition.left)
                {
                    spawnPos += new Vector3(-1f, 0f, 0f);
                    GameObject bullet = Instantiate(bulletPrefab, spawnPos, Quaternion.identity);
                    bulletScript = bullet.GetComponent<BulletScript>();
                    bulletScript.movX = -1.0f;
                }
                if (FacePosition == PlayerFacePosition.right)
                {
                    spawnPos += new Vector3(1f, 0f, 0f);
                    GameObject bullet = Instantiate(bulletPrefab, spawnPos, Quaternion.Euler(0f, 0f, 180f));
                    bulletScript = bullet.GetComponent<BulletScript>();
                    bulletScript.movX = -1.0f;
                }
                if (FacePosition == PlayerFacePosition.down)
                {
                    spawnPos += new Vector3(0f, -1f, 0f);
                    GameObject bullet = Instantiate(bulletPrefab, spawnPos, Quaternion.Euler(0f, 0f, 90f));
                    bulletScript = bullet.GetComponent<BulletScript>();
                    bulletScript.movX = -1.0f;
                }
            }
        }
        if(collideRock) //when collide with rock, it will disable player to move for 1 second
        {
            timeCount = timeCount - 1 * Time.deltaTime;
            if (timeCount <= 0)
            {
                timeCount = 2.0f; //disable time, if you willing to change this, remember to change the value of Line 16 too
                collideRock = false;
                animator.Play("Normal");
            }
        }
        if(reloading)
        {
            counter += Time.deltaTime;
            gameControl.Reload();
            if(counter > reloadTime)
            {
                gameControl.reloaded();
                reloading = false;
                counter = 0;
            }
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name.Equals("Rock(Clone)"))
        {
            audioControl.ImpactRock();
            collideRock = true;
            animator.Play("NonMoveFront");
        }
		
	    if (other.gameObject.name.Equals("Monster(Clone)"))
        {
            audioControl.LargeExplosion();
            gameControl.LivesNum();
        }
        if (other.gameObject.name.Equals("Life(Clone)"))
        {
            audioControl.AmmoUp();
            gameControl.AddLives();
            Destroy(other.gameObject);
        }
        if (other.gameObject.name.Equals("Ammo(Clone)"))
        {
            audioControl.AmmoUp();
            gameControl.AddAmmo();
            Destroy(other.gameObject);
        }



    }
}