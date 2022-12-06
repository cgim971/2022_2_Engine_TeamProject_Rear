using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public abstract class Obstacle_Base : Object_Base
{
    Material material = null;
    [SerializeField] private float _speed = 1f;

    protected override void Awake()
    {
        base.Awake();
        material = transform.GetComponent<MeshRenderer>().material;
    }

    public override void OnEffect(PlayerMovement_Base player)
    {
        Debug.Log("Die");
        GameManager.Instance.sceneManager.Stage("Stage_1");
    }
    public override void OffEffect(PlayerMovement_Base player) { }

    public IEnumerator FadeObject()
    {
        float degree = 0;

        while (true)
        {
            degree += Time.deltaTime * _speed;
            float alpha = Mathf.Sin(degree) / 2 + 0.5f;
            material.SetFloat("_Alpha", alpha);

            yield return null;
        }
    }
}
