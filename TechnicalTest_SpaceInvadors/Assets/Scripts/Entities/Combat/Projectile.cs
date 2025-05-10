using System;
using UnityEngine;

namespace Entities.Combat
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private ProjectileConfig _config;

        [NonSerialized] public float Damage;
        
        private void Update()
        {
            var currentPosition = transform.position;
            var forwardMovement = transform.forward * (_config.MoveSpeed * Time.deltaTime);
            var newPosition = currentPosition + forwardMovement;
            
            transform.position = newPosition;
        }

        private void OnTriggerEnter(Collider other)
        {
            var damageableCollider = other.GetComponent<DamageableCollider>();
            if (damageableCollider) damageableCollider.TakeDamage(Damage);
        }
    }
}