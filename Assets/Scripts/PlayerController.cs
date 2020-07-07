using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 750.0f;
    private float jump = 675.0f;
    public Rigidbody2D playerRigidbody2D;
    private bool isJumping = false;
    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;
    public GameObject bullet;
    public List<GameObject> bulletList;
    public static bool isDirectionRight = true;
    private Vector2 bulletPoss;
    private float fireRate = 0.05f;
    private float nextFire = 0.0f;

    void Start()
    {
        playerRigidbody2D = this.GetComponent<Rigidbody2D>();
        ManagerScript.Instance.Score = 0;
        ManagerScript.Instance.Level = 0;     
        UIController.levelUp = false;
    }

    void Update(){
        
        float directionX = Input.GetAxis ("Horizontal") * speed;
        playerRigidbody2D.velocity = new Vector2(directionX, playerRigidbody2D.velocity.y);
        
        if(Input.GetButtonDown("Jump") && !isJumping){
           playerRigidbody2D.AddForce(new Vector2(playerRigidbody2D.velocity.x, jump), ForceMode2D.Impulse);
           isJumping = true;
        }

        Camera.main.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, Camera.main.transform.position.z);

        if(Input.GetKey("right") || Input.GetKey("d"))
            isDirectionRight = true;
        else if(Input.GetKey("left") || Input.GetKey("a"))
            isDirectionRight = false;

        if(Input.GetButtonDown("Fire1") && Time.time > nextFire){
            nextFire = Time.time + fireRate;
            fire();
        }

        if(bulletList.Count >= 1)
            for(int x = 0; x < bulletList.Count; x++)
                if (bulletList[x] == null)
                    bulletList.Remove((bulletList[x]));
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Ground")){
            isJumping = false;
        }
    }

    private void fire(){
        bulletPoss = transform.position;
        
        if(isDirectionRight){
            bulletPoss += new Vector2(35f, 0.0f);
            bulletList.Add(Instantiate (bullet, bulletPoss, Quaternion.identity, GameObject.FindGameObjectWithTag("Bullets").transform) as GameObject);
            bulletList[bulletList.Count-1].GetComponent<Rigidbody2D>().velocity = new Vector2(1250.0f, 0.0f);
        } else {
            bulletPoss += new Vector2(-35f, 0.0f);
            bulletList.Add(Instantiate (bullet, bulletPoss, Quaternion.identity, GameObject.FindGameObjectWithTag("Bullets").transform) as GameObject);
            bulletList[bulletList.Count-1].GetComponent<Rigidbody2D>().velocity = new Vector2(-1250.0f, 0.0f);
        }
    }

    public void Replay(){
        SceneManager.LoadScene("Game");
    }

}
