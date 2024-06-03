using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace scripts.enemies {
    public class EnemyDataManager : MonoBehaviour
    {
        [SerializeField]
        private float Health = 0;

        // Update is called once per frame
        void Update()
        {
            if(Health <= 0) {
                Destroy(gameObject);
            }
        }

        public void takeDamage(float damage) {
            Health -= damage;
        }
    }
}
