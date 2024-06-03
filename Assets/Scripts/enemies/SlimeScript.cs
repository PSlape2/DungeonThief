using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using scripts.events;

namespace scripts.enemies {
    public class SlimeScript : MonoBehaviour
    {
        [SerializeField]
        private float SlimeSpeed = 0.5f;

        private Transform _transform;
        private Transform _playerTransform;
        // Start is called before the first frame update
        void Start()
        {
            _transform = GetComponent<Transform>();
            _playerTransform = GameObject.Find("Player").GetComponent<Transform>();
        }

        // Update is called once per frame
        void Update()
        {
            _transform.position = Vector2.Lerp(_transform.position, _playerTransform.position, Time.deltaTime * SlimeSpeed);
        }

        void OnCollisionEnter2D(Collision2D col) {
            if(col.gameObject.CompareTag("Player")) {
                Events.OnPlayerHit.Invoke(gameObject);
            }
        }
    }
}
