using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Object_Base : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnEffect(other?.GetComponentInParent<PlayerMovement_Base>());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OffEffect(other?.GetComponentInParent<PlayerMovement_Base>());
        }
    }

    public abstract void OnEffect(PlayerMovement_Base player);
    public abstract void OffEffect(PlayerMovement_Base player);

    public abstract void Effect();
}
