using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 500.0f;
    private float jump = 500.0f;
    public Rigidbody2D playerRigidbody2D;
    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;
    public GameObject bullet;
    public List<GameObject> bulletList;
    private Vector2 bulletPoss;
    private bool allowfire = true;
    private bool allowJump = true;
    private bool inAir = true;
    private Vector3 mousePosition;
    private Vector2 mouseDirection;

    void Start()
    {
        playerRigidbody2D = this.GetComponent<Rigidbody2D>();
        ManagerScript.Instance.Score = 0;
        ManagerScript.Instance.Level = 0;     
        UIController.levelUp = false;
    }

    void Update(){

        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseDirection = (Vector2)((mousePosition - transform.position));
        mouseDirection.Normalize ();

        float directionX = Input.GetAxis ("Horizontal") * speed;
        playerRigidbody2D.velocity = new Vector2(directionX, playerRigidbody2D.velocity.y);
        
        if(Input.GetButtonDown("Jump") && !inAir && allowJump){
            StartCoroutine(JumpRate());
        }

        Camera.main.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, Camera.main.transform.position.z);

        if(Input.GetButtonDown("Fire1") && allowfire){
            StartCoroutine(FireRate());
        }

        if(bulletList.Count >= 1)
            for(int x = 0; x < bulletList.Count; x++)
                if (bulletList[x] == null)
                    bulletList.Remove((bulletList[x]));
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Ground")){
            inAir = false;
        }
        if(other.gameObject.CompareTag("Exit")){
            SceneManager.LoadScene("ReplayMenu");
        }
    }

    IEnumerator FireRate(){
        allowfire = false;
        fire();
        yield return new WaitForSeconds(0.1f);
        allowfire = true;
    }

    IEnumerator JumpRate(){
        inAir = true;
        allowJump = false;
        playerRigidbody2D.AddForce(new Vector2(playerRigidbody2D.velocity.x, jump), ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.2f);
        allowJump = true;
    }

    private void fire(){        

        bulletList.Add(Instantiate (bullet, transform.position, Quaternion.identity, GameObject.FindGameObjectWithTag("Bullets").transform) as GameObject);

        bulletList[bulletList.Count-1].GetComponent<Rigidbody2D>().velocity = mouseDirection * 1250f;
    }

    public void Replay(){
        SceneManager.LoadScene("Game");
    }

}
