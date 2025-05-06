using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dissolve : MonoBehaviour
{
    [SerializeField] private float _dissolveTime = 0.75f;

    private SpriteRenderer _spriteRenderer;
    public Material _material;

    private int _dissolveAmount = Shader.PropertyToID("_DissolveAmount");

    public Coroutine _dissolveCoroutine;
    

    void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _material.SetFloat(_dissolveAmount, 0f);
        // _material = GetComponent<Material>();
    }
    private void Update()
    {
         if(Input.GetKeyDown(KeyCode.G))
        {
            StartCoroutine(Vanish());
        }
    }
    public void CallDissolve()
    {
        _dissolveCoroutine = StartCoroutine(Vanish());
    }
    public IEnumerator Vanish()
    {
        
        float elapsedTime = 0f;
        while (elapsedTime < _dissolveTime)
        {   
            elapsedTime += Time.deltaTime;
            float lerpedDissolve = Mathf.Lerp(0f, 1.1f, (elapsedTime / _dissolveTime));

            _material.SetFloat(_dissolveAmount, lerpedDissolve);

            yield return null;
            
        }
        Destroy(gameObject);
        
    }
}
