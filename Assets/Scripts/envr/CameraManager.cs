using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using scripts.events;

namespace scripts.envr
{
    public class CameraManager : MonoBehaviour
    {

        private Transform _transform;
        private Transform _cameraRoomTransform;
        private Collider2D _collider;

        public void Start()
        {
            _transform = GetComponent<Transform>();
            _collider = GetComponent<BoxCollider2D>();
            _cameraRoomTransform = _transform.GetChild(0);
        }

        public void OnTriggerEnter2D(Collider2D colliderHit)
        {
            if (colliderHit.gameObject.CompareTag("Player"))
            {
                Events.OnRoomChange.Invoke();
                StartCoroutine(EnterRoom());
            }
        }

        public IEnumerator EnterRoom()
        {
            while(Camera.main.transform.position != _cameraRoomTransform.position)
            {
                Camera.main.transform.position = Vector3.Lerp(
                    Camera.main.transform.position,
                    _cameraRoomTransform.position,
                    1f / Time.deltaTime
             );
                yield return null;
            }
        }
    }
}

