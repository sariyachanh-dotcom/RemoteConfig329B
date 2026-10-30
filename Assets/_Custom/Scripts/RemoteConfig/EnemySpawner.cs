using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float enemySpawnRate = .3f;
    public int enemylifeTime = 10;

    float timeToSpawn;
    public Transform[] spawnPoints;
    public GameObject enemyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        timeToSpawn = Time.time + 1f / enemySpawnRate;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= timeToSpawn)
        {
            Spawn();
            timeToSpawn = Time.time +1f /enemySpawnRate;
        }
    }

    void Spawn()
    {
        int pointIndex = Random.Range(0, spawnPoints.Length);
        Vector3 pos = spawnPoints[pointIndex].position;   

        GameObject go = Instantiate(enemyPrefab,pos,Quaternion.identity);
        go.GetComponent<Unit>().lifeTime = enemylifeTime;
    }
}
