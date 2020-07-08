using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroy : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other){

        if(other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("Wall"))
            Destroy(this.gameObject);

        if(other.gameObject.CompareTag("Enemy")){
            other.gameObject.GetComponent<EnemyController>().enemyHealth -= 1;
            other.gameObject.GetComponent<Animation>().Play("Damage");
            if(other.gameObject.GetComponent<EnemyController>().enemyHealth <= 0){
                Destroy(other.gameObject);
                ManagerScript.Instance.Score++;
                UIController.levelUp = true;
            }
            Destroy(this.gameObject);
        }
           
    }
}
