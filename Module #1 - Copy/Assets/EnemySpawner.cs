using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject enemy;
    public Transform enemySpawner;
    float timer = 0f;
    float spawnTime = 5f;
    void Start()
    {
       
        

    }

    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;

        if (timer > spawnTime)
        {
            Instantiate(enemy, enemySpawner.position, Quaternion.identity);
            timer = 0f;
        }
    }

   

}
