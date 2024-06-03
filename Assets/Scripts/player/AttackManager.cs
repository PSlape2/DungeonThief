using UnityEngine;
using System.Collections;
using scripts.enemies;

namespace scripts.player {
    public class AttackManager : MonoBehaviour {
        public Transform _weaponTransform;

        private Animator _animator;

        public float Radius = 1f;

        public void Start() {
            _weaponTransform = GetComponent<Transform>().GetChild(0);
            _animator = GetComponent<Animator>();
            StartCoroutine(attackCoroutine());
        }

        private IEnumerator attackCoroutine() {
            for(;;) {
                if(Input.GetButton("Jump")) {
                    _animator.SetBool("isAttacking", true);
                    Collider2D[] colliders = Physics2D.OverlapCircleAll(_weaponTransform.position, Radius, LayerMask.GetMask("Enemy"));
                    foreach(Collider2D collider in colliders) 
                    {
                        Debug.Log("Hit Registered");
                        collider.gameObject.SendMessage("takeDamage", 1);
                    }
                    yield return new WaitForSeconds(0.5f);
                } else {
                    _animator.SetBool("isAttacking", false);
                    yield return null;
                }
            }
            
        } 
    }
}