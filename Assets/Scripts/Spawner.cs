using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    List<Vector2> spawnPoints = new List<Vector2>();

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
}
