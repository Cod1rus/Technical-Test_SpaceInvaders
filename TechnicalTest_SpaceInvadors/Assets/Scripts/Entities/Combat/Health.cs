using System;
using UnityEngine;

namespace Entities.Combat
{
    public class Health : MonoBehaviour
    {
        private float _maxHealth;
        private float _currentHealth;

        public event Action Die;
        
        public void Init(float maxHealth)
        {
            _maxHealth = maxHealth;
            _currentHealth = maxHealth;
        }

        public void TakeDamage(float damage)
        {
            _currentHealth -= damage;
            
            if (_currentHealth <= 0) Die?.Invoke();
        }

        public void ResetHealth()
        {
            _currentHealth = _maxHealth;
        }
    }
}