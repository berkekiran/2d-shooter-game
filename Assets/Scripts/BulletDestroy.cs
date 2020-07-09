using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletDestroy : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other){

        if(other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("Wall"))
            Destroy(this.gameObject);

        if(other.gameObject.CompareTag("Enemy") && !other.gameObject.GetComponent<EnemyController>().destroyed){
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().audioSourceBulletDamage.Play();
            other.gameObject.GetComponent<EnemyController>().enemyHealth -= 1;
            other.gameObject.GetComponent<Animation>().Play("Damage");
            if(other.gameObject.GetComponent<EnemyController>().enemyHealth <= 0){
                other.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                other.gameObject.GetComponent<Image>().CrossFadeAlpha(0, 0.0125f, false);
                other.gameObject.GetComponentInChildren<Text>().CrossFadeAlpha(0, 0.0125f, false);
                if(!other.gameObject.GetComponent<EnemyController>().destroyed)
                    other.gameObject.GetComponent<EnemyController>().PS_Death.Play ();
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().audioSourceBulletDeath.Play();
                if(!other.gameObject.GetComponent<EnemyController>().PS_Death.isEmitting)
                    other.gameObject.GetComponent<EnemyController>().PS_Death.Stop ();
                other.gameObject.GetComponent<EnemyController>().destroyed = true;
                Destroy(other.gameObject, other.gameObject.GetComponent<EnemyController>().PS_Death.main.duration + 0.5f);
                ManagerScript.Instance.Score++;
                UIController.levelUp = true;
            }
            if(!other.gameObject.GetComponent<EnemyController>().destroyed)
                Destroy(this.gameObject);
        }
           
    }
}
