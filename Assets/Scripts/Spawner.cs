using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float startTimeBtwSpawn;
    private float timeBtwSpawn;
    private short lastMultiplier = 0;

    public GameObject[] enemies;

    private void Update()
    {
        if (timeBtwSpawn <= 0)
        {
            short currentMultiplier = (short)(Score.scoreValue / 100);
            if (currentMultiplier != lastMultiplier)
            {
                float decreaseAmount = 0.1f * currentMultiplier;
                startTimeBtwSpawn = Mathf.Max(startTimeBtwSpawn - decreaseAmount, 0.1f);
                lastMultiplier = currentMultiplier;
            }

            Instantiate(enemies[Random.Range(0, enemies.Length)], transform.position, Quaternion.identity);
            timeBtwSpawn = startTimeBtwSpawn;
        }
        else
        {
            timeBtwSpawn -= Time.deltaTime;
        }
    }
}