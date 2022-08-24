using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Player _player;
    [SerializeField] private float _maxDelta = 0.5f;

    private void OnEnable()
    {
        _player.OnHealthGhanged += StartSetHealth;
    }

    private void OnDisable()
    {
        _player.OnHealthGhanged -= StartSetHealth;
    }

    private void Start()
    {
        SetMaxHealth(_player.MaxHealth);
    }

    private void SetMaxHealth(float health)
    {
        _slider.maxValue = health;
        _slider.value = health;
    }

    private void StartSetHealth(float health)
    {
        StartCoroutine(SetHealth(health));
    }

    private IEnumerator SetHealth(float health)
    {
        while(_slider.value != health)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, health, _maxDelta);
            yield return null;
        }        
    }
}