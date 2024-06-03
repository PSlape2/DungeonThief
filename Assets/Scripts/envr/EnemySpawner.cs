using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using scripts.events;

namespace scripts.envr 
{
    public class EnemySpawner : MonoBehaviour
    {
        private Object _spawnLocationPrefab;
        private GameObject[] _spawnLocations;
        private Object[] _enemyPrefabs;

        private Transform _roomTransform;

        [SerializeField]
        private int minSpawnPoints = 0;

        [SerializeField]
        private int maxSpawnPoints = 4;

        private int numSpawnPoints;


        // Start is called before the first frame update
        void Start()
        {
            _roomTransform = GetComponent<Transform>();
            _spawnLocationPrefab = Resources.Load("Prefabs/EnemySpawnPoint");

            numSpawnPoints = Random.Range(minSpawnPoints, maxSpawnPoints);
            _spawnLocations = new GameObject[numSpawnPoints];

            _enemyPrefabs = Resources.LoadAll("Prefabs/Enemies");

            for (int i = 0; i < numSpawnPoints; i++)
            {
                Vector3 spawnLoc = new Vector3(
                    _roomTransform.position.x + Random.Range(-9, 9),
                    _roomTransform.position.y + Random.Range(-4, 4),
                    0
                );

                _spawnLocations[i] = (GameObject) Instantiate(
                    _spawnLocationPrefab,
                    spawnLoc,
                    Quaternion.identity,
                    _roomTransform
                );
            }

            Events.OnRoomChange.AddListener(spawnEnemies);
        }

        // Implement a wait for seconds.
        void spawnEnemies()
        {
            Debug.Log("Spawning enemies...");
            for (int i = 0; i < numSpawnPoints; i++)
            {
                Instantiate(
                    _enemyPrefabs[i % _enemyPrefabs.Length],
                    _spawnLocations[i].transform.position,
                    Quaternion.identity
                );
            }
        }
    }
}