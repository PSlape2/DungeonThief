using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using scripts.events;
using System;

namespace scripts.player
{
    public class PlayerScript : MonoBehaviour
    {
        public float DeadZone = 0.1f;
        public float AccelUnitsPerSecondSquared = 256f;
        public float MaxSpeedUnitsPerSecond = 200f;
        public float KnockbackSpeed = 5f;

        public float DashSpeed = 20f;

        private bool knockingBack = false;

        Rigidbody2D _rigidbody;
        Animator _animator;
        Vector2 appliedVelocity;
        Vector2 lastDirection;


        public void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
            Events.OnPlayerHit.AddListener(onHit);
        }

        public void Update()
        {
            if(!knockingBack) {
                appliedVelocity = Vector2.zero;

                appliedVelocity.x = applyDeadzone(Input.GetAxis("Horizontal"));
                appliedVelocity.y = applyDeadzone(Input.GetAxis("Vertical"));

                appliedVelocity *= AccelUnitsPerSecondSquared;

                _rigidbody.velocity = appliedVelocity;

                if(appliedVelocity != Vector2.zero) {
                    lastDirection = appliedVelocity.normalized;
                }

                if(Input.GetKey("right shift") || Input.GetKey("left shift")) {
                    StartCoroutine(knockBackCoroutine(lastDirection * DashSpeed, DashSpeed / 2.0f));
                }

            }
            updateAnimator();
            
        }

        private float applyDeadzone(float value)
        {
            if (Mathf.Abs(value) > DeadZone)
            {
                return value;
            }
            else
            {
                return 0;
            }
        }

        private float applyDeadzone(float value, float deadZone)
        {
            if (Mathf.Abs(value) > deadZone)
            {
                return value;
            }
            else
            {
                return 0;
            }
        }

        void onHit(GameObject incomingObject) {
            if(incomingObject) {
                float angle = Vector2.SignedAngle(incomingObject.GetComponent<Transform>().position, _rigidbody.position);
                Vector2 hitMovement = polarToVector2(angle, KnockbackSpeed);
                StartCoroutine(knockBackCoroutine(hitMovement, 1.5));
            }
        }

        IEnumerator knockBackCoroutine(Vector2 vector, double threshold) {
            knockingBack = true;
            _rigidbody.velocity = vector;
            while(_rigidbody.velocity.magnitude > threshold) {
                yield return null;
            }
            knockingBack = false;
        }

        public static Vector2 polarToVector2(float angle, float magnitude) {
            return new Vector2(
                magnitude * Mathf.Cos(angle * Mathf.Deg2Rad),
                magnitude * Mathf.Sin(angle * Mathf.Deg2Rad)
            );
        }

        private void updateAnimator() {
            _animator.SetFloat("xVel", _rigidbody.velocity.x);
            _animator.SetFloat("xSpeed", Mathf.Abs(_rigidbody.velocity.x));
            _animator.SetFloat("yVel", _rigidbody.velocity.y);
            _animator.SetBool("isFacingRight", (_rigidbody.velocity.x != 0) ? _rigidbody.velocity.x >= 0 : lastDirection.x >= 0);
            _animator.SetBool("isFacingDown", _rigidbody.velocity.y != 0 ? _rigidbody.velocity.y <= 0 : lastDirection.y <= 0);
        }

    }
}
