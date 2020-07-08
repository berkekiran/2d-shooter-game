using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    public int enemyHealth = 2;
    public Text enemyHealthText;
    private float speed = 500.0f;
    private float jump = 350.0f;
    public Transform player;
    private bool allowJump = true;
    private bool inAir = true;
    public bool ableToJump = false;

    void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player")[0].transform;
    }

    void Update()
    {
        enemyHealthText.text = enemyHealth.ToString();   
    }

    void FixedUpdate(){   
        if(Vector2.Distance(transform.position, player.position) < 300f){
            Vector2 direction = (player.transform.position - transform.position).normalized;
            this.GetComponent<Rigidbody2D>().velocity = new Vector2 (direction.x * speed, this.GetComponent<Rigidbody2D>().velocity.y);

            if(!inAir && allowJump && ableToJump){
                StartCoroutine(JumpRate());
            }
        }
    }

    IEnumerator JumpRate(){
        inAir = true;
        allowJump = false;
        this.GetComponent<Rigidbody2D>().AddForce(new Vector2(this.GetComponent<Rigidbody2D>().velocity.x, jump), ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.2f);
        allowJump = true;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Ground")){
            inAir = false;
        }

        if(other.gameObject.CompareTag("Player"))
            SceneManager.LoadScene("ReplayMenu");  

    }
}
