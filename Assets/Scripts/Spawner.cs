using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class Spawner : MonoBehaviour
{
    [SerializeField] bool titleScreenMode = false;

    private float _spawnSpeed = 2.25f; // 2.5f base value
    private int[] _LOOT_SPAWN_TIME = { 8, 15 };
    private int _lootSpawnInterval;

    private List<Transform> _spawnPoints = new List<Transform>();
    private GameObject[] _damageProjectiles;
    private GameObject[] _lootProjectiles;

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

        _damageProjectiles = new GameObject[] {
            (GameObject) Resources.Load("Prefabs/Fireball"),
            (GameObject) Resources.Load("Prefabs/Spike"),
        };
        _lootProjectiles = new GameObject[] {
            (GameObject) Resources.Load("Prefabs/Diamond"),
            (GameObject) Resources.Load("Prefabs/Coin"),
        };

        if (titleScreenMode)
        {
            _spawnSpeed = 0.125f;
        }
    }

    private void Start()
    {
        _lootSpawnInterval = Random.Range(_LOOT_SPAWN_TIME[0], _LOOT_SPAWN_TIME[1]);
        StartCoroutine(SpawnProjectiles());
    }

    private Transform ChooseRandomPoint()
    {
        return _spawnPoints[Random.Range(0, _spawnPoints.Count)];
    }

    private GameObject ChooseRandomProjectile(bool isLoot)
    {
        GameObject[] projectiles = isLoot ? _lootProjectiles : _damageProjectiles;
        if (isLoot)
        {
            _lootSpawnInterval = Random.Range(_LOOT_SPAWN_TIME[0], _LOOT_SPAWN_TIME[1]);
        }
        return projectiles[Random.Range(0, projectiles.Length)];
    }

    private IEnumerator SpawnProjectiles()
    {
        const float spawnDelay = 3.5f;
        yield return new WaitForSeconds(spawnDelay);

        int spawnCount = 0;
        while (true)
        {
            yield return new WaitForSeconds(_spawnSpeed);
            bool spawnLoot = spawnCount % _lootSpawnInterval == 0;
            Instantiate(ChooseRandomProjectile(spawnLoot), ChooseRandomPoint());
            spawnCount++;
        }
    }
}
