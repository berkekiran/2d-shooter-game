using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroy : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other){

        if(other.gameObject.CompareTag("Ground"))
            Destroy(this.gameObject);

        if(other.gameObject.CompareTag("Enemy")){
           Destroy(other.gameObject);
            ManagerScript.Instance.Score++;
            UIController.levelUp = true;
        }
           
    }
}
