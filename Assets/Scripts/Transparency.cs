using System.Collections;
using UnityEngine;


[RequireComponent(typeof(Renderer))]

public class Transparency : MonoBehaviour
{
    private Renderer _renderer;

    private float _minAlpha = 0;
    private float _maxAlpha = 1;
    private float _deltaTime = 0.1f;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void OnEnable()
    {
        SetAlpha(_maxAlpha);
    }

    public void FaidInTime(float time)
    {
        StartCoroutine(StartFaiding(time));
    }

    private void SetAlpha(float alpha)
    {
        Color color = _renderer.material.color;
        color.a = Mathf.Clamp01(alpha);
        _renderer.material.color = color;
    }

    private IEnumerator StartFaiding(float faidTime)
    {
        WaitForSeconds wait = new WaitForSeconds(_deltaTime);
        float startAlpha = _renderer.material.color.a;
        float timeSpend = 0;

        while (timeSpend < faidTime)
        {
            timeSpend += _deltaTime;
            yield return wait;
            float newAlpha = Mathf.Lerp(startAlpha, _minAlpha, timeSpend / faidTime);
            SetAlpha(newAlpha);
        }
    }
}
