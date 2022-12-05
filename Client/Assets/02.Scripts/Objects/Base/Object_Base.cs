using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Object_Base : MonoBehaviour
{
    bool _isUse = false;
    [SerializeField] private bool _isMore = false;

    private void Awake()
    {
        this.GetComponent<Collider>().isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !_isUse)
        {
            _isUse = true;
            OnEffect(other.GetComponentInParent<PlayerMovement_Base>());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OffEffect(other.GetComponentInParent<PlayerMovement_Base>());

            if (_isMore) _isUse = false;
        }
    }

    public abstract void OnEffect(PlayerMovement_Base player);
    public abstract void OffEffect(PlayerMovement_Base player);

    public abstract void Effect();

    protected IEnumerator ObjectCenter(PlayerMovement_Base obj, Action Callback)
    {
        Vector3 value = Vector3.zero;
        float distance = 0f;

        while (true)
        {
            yield return null;

            value = obj.GetComponentInChildren<Collider>().bounds.center - this.transform.position;
            distance = Mathf.Abs(value.magnitude);

            if (distance <= 0.52f)
            {
                obj.transform.parent.position = this.transform.position;
                Callback(); 

                yield break;
            }
        }
    }

}
