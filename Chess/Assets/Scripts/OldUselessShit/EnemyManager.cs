using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyManager : MonoBehaviour
{

    [SerializeField]
    GameObject enemyPrefab;

    [SerializeField]
    GameObject coinPrefab;

    [SerializeField]
    int numEnemies;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numEnemies; i++)
        {
            SpawnEnemy();
            SpawnCoin();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemy()
    {
        //~~Activity 2: Spawn enemies here!
    }

    void SpawnCoin()
    {
        //~~Optional: Spawn coins here
    }
}
