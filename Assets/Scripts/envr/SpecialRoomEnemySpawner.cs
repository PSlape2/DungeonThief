using UnityEngine;
using scripts.events;

namespace scripts.envr {
    public class SpecialRoomEnemySpawner : MonoBehaviour {
        
        private Transform[] spawnPoints;

        [SerializeField]
        private Object[] enemies;

        void Start() {
            spawnPoints = transform.GetChild(0).GetComponentsInChildren<Transform>();
            Events.OnRoomChange.AddListener(onRoomEnter);
        }

        void onRoomEnter() {
            if(enemies != null && spawnPoints != null) {
                foreach(Transform trans in spawnPoints) {
                    Instantiate(getRandomEnemy(), trans.position, trans.rotation);
                }
            }
        }

        Object getRandomEnemy() {
            return enemies[Random.Range(0, enemies.Length)];
        }
    }
}