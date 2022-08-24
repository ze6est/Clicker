using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 100f;
    [SerializeField] private float _maxDelta = 10f;
    [SerializeField] private float _currentHealth;
    [SerializeField] private HealthBar _healthBar;
    [SerializeField] private Button _buttonHealing;
    [SerializeField] private Button _buttonDamage;

    private float _minHealth = 0;

    public float MaxHealth => _maxHealth;
    public UnityAction<float> OnHealthGhanged;

    private event UnityAction OnClickHealing
    {
        add => _buttonHealing.onClick.AddListener(value);
        remove => _buttonHealing.onClick.RemoveListener(value);
    }

    private event UnityAction OnClickDamage
    {
        add => _buttonDamage.onClick.AddListener(value);
        remove => _buttonDamage.onClick.RemoveListener(value);
    }

    private void OnEnable()
    {
        OnClickHealing += IncreaseHealth;
        OnClickDamage += DecreaseHealth;
    }

    private void OnDisable()
    {
        OnClickHealing -= IncreaseHealth;
        OnClickDamage -= DecreaseHealth;
    }

    private void Start()
    {        
        _currentHealth = _maxHealth;
    }

    private void IncreaseHealth()
    {
        if (_currentHealth < _maxHealth)
        {
            _currentHealth += _maxDelta;
            OnHealthGhanged.Invoke(_currentHealth);
        }
    }

    private void DecreaseHealth()
    {
        if (_currentHealth > _minHealth)
        {
            _currentHealth -= _maxDelta;
            OnHealthGhanged.Invoke(_currentHealth);
        }            
    }
}