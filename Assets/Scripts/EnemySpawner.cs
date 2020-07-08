using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyWalk;
    public GameObject enemyJump;
    public List<GameObject> enemyIns;
    public Transform[] enemySpawnPoints;
    public int spawnIndex;

    void Start()
    {
        EnemySpawn();
    }

    void Update() {
        
    }

    void EnemySpawn(){
        for(spawnIndex=0; spawnIndex < enemySpawnPoints.Length; spawnIndex++){
            if(enemySpawnPoints [spawnIndex].CompareTag("EnemyWalkSpawnPoint"))
                enemyIns.Add(Instantiate (enemyWalk, new Vector3(enemySpawnPoints [spawnIndex].position.x, enemySpawnPoints [spawnIndex].position.y, 0f), Quaternion.identity, GameObject.FindGameObjectWithTag("Enemies").transform) as GameObject);
            else if(enemySpawnPoints [spawnIndex].CompareTag("EnemyJumpSpawnPoint"))
                enemyIns.Add(Instantiate (enemyJump, new Vector3(enemySpawnPoints [spawnIndex].position.x, enemySpawnPoints [spawnIndex].position.y, 0f), Quaternion.identity, GameObject.FindGameObjectWithTag("Enemies").transform) as GameObject);
        }
    }

}
