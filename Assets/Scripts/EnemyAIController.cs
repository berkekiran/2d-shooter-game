using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyAIController : MonoBehaviour
{
    private float speed = 650.0f;
    private float jump = 575.0f;
    public Transform player;
    private bool isJumping = false;

    void Start()
    {
        
    }

    void FixedUpdate()
    {   
        if(Vector2.Distance(transform.position, player.position) < 500f){
            Vector2 direction = (player.transform.position - transform.position).normalized;
            this.GetComponent<Rigidbody2D>().velocity = new Vector2 (direction.x * speed, this.GetComponent<Rigidbody2D>().velocity.y);

            if(isJumping){
                this.GetComponent<Rigidbody2D>().AddForce(new Vector2(this.GetComponent<Rigidbody2D>().velocity.x, jump), ForceMode2D.Impulse);
                isJumping = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Ground")){
            isJumping = true;
        }
        if(other.gameObject.CompareTag("Player")){
            SceneManager.LoadScene("ReplayMenu");
        }
    }
}
