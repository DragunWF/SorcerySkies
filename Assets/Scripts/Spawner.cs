using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    List<Transform> spawnPoints = new List<Transform>();
    private float spawnSpeed = 2.5f;
    private GameObject[] projectiles;

    private void Awake()
    {
        int index = 1;
        while (true)
        {
            GameObject spawnPoint = GameObject.Find(string.Format("Point_{0}", index));
            if (spawnPoint == null)
            {
                break;
            }
            spawnPoints.Add(spawnPoint.transform);
            index++;
        }

        projectiles = new GameObject[] {
            (GameObject) Resources.Load("")
        };
    }

    private void Start()
    {
        StartCoroutine(SpawnProjectiles());
    }

    private Transform ChooseRandomPoint()
    {
        return spawnPoints[Random.Range(0, spawnPoints.Count)];
    }

    private GameObject ChooseRandomProjectile()
    {
        return projectiles[Random.Range(0, projectiles.Length)];
    }

    private IEnumerator SpawnProjectiles()
    {
        const float spawnDelay = 1.5f;
        yield return new WaitForSeconds(spawnDelay);

        while (true)
        {
            yield return new WaitForSeconds(spawnSpeed);
            // Instantiate(ChooseRandomProjectile(), ChooseRandomPoint());
        }
    }
}
