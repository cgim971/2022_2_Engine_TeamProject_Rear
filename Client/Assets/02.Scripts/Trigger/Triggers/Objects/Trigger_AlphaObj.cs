using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_AlphaObj : Trigger_Base
{
    private void Start()
    {
        StartCoroutine(FadeObject());
    }

    public IEnumerator FadeObject()
    {
        float degree = 0;
        while (true)
        {
            degree += Time.deltaTime;
            float alpha = Mathf.Sin(degree) / 2 + 0.5f;
            _material.SetFloat("_Alpha", alpha);

            yield return null;
        }
    }

    public override void Trigger() { }
    public override void OffTrigger() { }
}
