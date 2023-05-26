using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private List<Transform> _spawnPoints = new List<Transform>();
    private float _spawnSpeed = 2.5f;
    private GameObject[] hostileProjectiles;
    private GameObject[] friendlyProjectiles;

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
            _spawnPoints.Add(spawnPoint.transform);
            index++;
        }

        hostileProjectiles = new GameObject[] {
            (GameObject) Resources.Load("Prefabs/Fireball"),
            (GameObject) Resources.Load("Prefabs/Spike"),
        };
        friendlyProjectiles = new GameObject[] {
            (GameObject) Resources.Load("Prefabs/Diamond"),
            (GameObject) Resources.Load("Prefabs/Coin"),
        };
    }

    private void Start()
    {
        StartCoroutine(SpawnProjectiles());
    }

    private Transform ChooseRandomPoint()
    {
        return _spawnPoints[Random.Range(0, _spawnPoints.Count)];
    }

    private GameObject ChooseRandomProjectile()
    {
        return hostileProjectiles[Random.Range(0, hostileProjectiles.Length)];
    }

    private IEnumerator SpawnProjectiles()
    {
        const float spawnDelay = 1.5f;
        yield return new WaitForSeconds(spawnDelay);

        while (true)
        {
            yield return new WaitForSeconds(_spawnSpeed);
            Instantiate(ChooseRandomProjectile(), ChooseRandomPoint());
        }
    }
}
