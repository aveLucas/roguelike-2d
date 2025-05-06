using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageFlash : MonoBehaviour
{
    [ColorUsage(true, true)]
    [SerializeField] private Color _flashColor = Color.white;
    [SerializeField] private float _flashTime = 0.25f;
    [SerializeField] private AnimationCurve _flashSpeedCurve;

    private SpriteRenderer _spriteRenderer;
    public Material _material;

    public Coroutine _damageFlashCoroutine;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void CallDamageFlash()
    {
        _damageFlashCoroutine = StartCoroutine(DamageFlasher());
    }

    public IEnumerator DamageFlasher()
    {
        _material.SetColor("_FlashColor", _flashColor);

        float currentFlashAmount = 0f;
        float elapsedTime = 0f;

        while (elapsedTime < _flashTime)
        {
            elapsedTime += Time.deltaTime;

            currentFlashAmount = Mathf.Lerp(1f, _flashSpeedCurve.Evaluate(elapsedTime), (elapsedTime / _flashTime));

            _material.SetFloat("_FlashAmount", currentFlashAmount);   

            yield return null;
        }
    }
}
