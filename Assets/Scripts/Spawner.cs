using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    List<Vector2> spawnPoints = new List<Vector2>();
    private float spawnSpeed = 2.5f;

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
            spawnPoints.Add(spawnPoint.transform.position);
            index++;
        }
    }

    private void Update()
    {

    }

    private Vector2 ChooseRandomPoint()
    {
        return spawnPoints[Random.Range(0, spawnPoints.Count)];
    }

    private IEnumerator SpawnProjectiles()
    {
        const float spawnDelay = 1.5f;
        yield return new WaitForSeconds(spawnDelay);

        while (true)
        {
            yield return new WaitForSeconds(spawnSpeed);
            // Instantiate()
        }
    }
}
