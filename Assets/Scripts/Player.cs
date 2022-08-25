using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 100f;    
    [SerializeField] private float _currentHealth;    

    private float _minHealth = 0;

    public float MaxHealth => _maxHealth;
    public event UnityAction<float> HealthGhanged;

    private void Start()
    {        
        _currentHealth = _maxHealth;
    }

    public void Heal(float numberLives)
    {
        _currentHealth = Mathf.Clamp(_currentHealth + numberLives, _minHealth, _maxHealth);
        HealthGhanged.Invoke(_currentHealth);        
    }

    public void TakeDamage(float damage)
    {
        _currentHealth = Mathf.Clamp(_currentHealth - damage, _minHealth, _maxHealth);
        HealthGhanged.Invoke(_currentHealth);
    }
}