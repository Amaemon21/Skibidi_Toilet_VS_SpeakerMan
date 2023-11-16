using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Space()]
    [SerializeField] private int MaxEnemy = 5;
    [SerializeField] private float SpawnDelay = 2f;
    
    [Space(5)]
    [SerializeField] private List<GameObject> EnemyPrefab = new();
    [SerializeField] private List<Transform> spawnList = new(16);

    static public int _currentEnemy = 0;

    private GameObject _parent;
    public GameObject Parent => _parent;

    private void Start()
    {
        _parent = new();
        StartCoroutine(Spawner());
    }

    public void AddMaxEnemy(int value)
    {
        MaxEnemy += value;
    }

    public void AddMaxEnemy(int valueEnemy, float valueDelay)
    {
        MaxEnemy += valueEnemy;

        if (SpawnDelay > 0)
        {
            SpawnDelay -= valueDelay;
        }
    }

    IEnumerator Spawner()
    {
        while (true)
        {
            if (_currentEnemy <= MaxEnemy)
            {
                Transform Rand = spawnList[Random.Range(0, spawnList.Count)];

                Instantiate(EnemyPrefab[0], Rand.position, Quaternion.identity, _parent.transform);
                _currentEnemy++;
            }
            else
            {
                Debug.Log("MaxEnemy!!!");
            }

            yield return new WaitForSeconds(SpawnDelay);
        }
    }
}