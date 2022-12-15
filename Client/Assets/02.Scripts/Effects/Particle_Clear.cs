using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Particle_Clear : MonoBehaviour
{
    Material _material;
    float _intensity = 4;

    private void Start()
    {
        _material = GetComponent<Renderer>().material;
    }

    private void OnEnable()
    {
        StartCoroutine(Clear());
    }

    private IEnumerator Clear()
    {
        yield return null;
        while (true)
        {
            _material.SetColor("_Color", Color.red * Mathf.Pow(2.0f, _intensity));
            yield return new WaitForSeconds(0.4f);
            _material.SetColor("_Color", Color.blue * Mathf.Pow(2.0f, _intensity));
            yield return new WaitForSeconds(0.4f);
            _material.SetColor("_Color", Color.white * Mathf.Pow(2.0f, _intensity));
            yield return new WaitForSeconds(0.4f);
        }
    }

}
