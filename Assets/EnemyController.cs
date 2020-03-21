using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO trigger and normal collider and getting mixed up;

public class EnemyController : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] spawnPoints;

    [SerializeField]
    private int enemyNumberMin = 1;
    [SerializeField]
    private int enemyNumberMax = 5;
    [SerializeField]
    private int currentSpawnPointIndex = 0;
    [SerializeField]
    private float timeBetweenWavesMin = 1;
    [SerializeField]
    private float timeBetweenWavesMax = 10;

    private GameObject[] enemies;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemies();
        Wave();
    }

    // spawn, disable and set parent
    private void SpawnEnemies()
    {
        // TODO pass player gameobject instead of all the enemies looking it up.
        enemies = new GameObject[enemyNumberMax];
        for (int  i = 0;  i < enemyNumberMax;  i++)
        {
            GameObject temp = Instantiate(enemyPrefab, transform.position, transform.rotation);
            temp.SetActive(false);
            temp.transform.parent = transform;
            enemies[i] = temp;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Wave()
    {
        int numberToActivate = Random.Range(enemyNumberMin, enemyNumberMax);

        // invoke next wave
        Invoke("Wave", Random.Range(timeBetweenWavesMin, timeBetweenWavesMax));

        // too many enemies, don't spawn more this time
        if (CountActiveEnemies() >= enemyNumberMax)
        {
            return;
        }

        Debug.Log("Spawning..." + numberToActivate);

        for (int i = 0; i < enemies.Length; i++)
        {
            // if no more to activate, exit method
            if(numberToActivate < 1)
            {
                return;
            }

            // if inactive, place in spawn position and activate
            if(!enemies[i].activeSelf)
            {
                numberToActivate--;
                enemies[i].transform.position = NextSpawnPoint();
                enemies[i].SetActive(true);
                enemies[i].GetComponent<Health>().ResetHealth();
            }
        }
    }

    // Count currently active enemies
    private int CountActiveEnemies()
    {
        int counter = 0;

        for (int i = 0; i < enemyNumberMax; i++)
        {
            if(enemies[i].activeSelf)
            {
                counter++;
            }
        }
        return counter;
    }

    // Round Robin spawnpoint picking
    private Vector3 NextSpawnPoint()
    {
        currentSpawnPointIndex++;
        if(currentSpawnPointIndex > spawnPoints.Length -1)
        {
            currentSpawnPointIndex = 0;
        }

        return spawnPoints[currentSpawnPointIndex].position;
        
    }

    // TODO implement random selection from array of spawwn positions with cooldown info
    private Vector3 RandomSpawnPoint()
    {
        return Vector3.zero;
    }
}
