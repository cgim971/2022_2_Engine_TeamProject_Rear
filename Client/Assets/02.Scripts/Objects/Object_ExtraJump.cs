using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_ExtraJump : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponentInParent<PlayerMovement_Base>().ExtraJump++;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponentInParent<PlayerMovement_Base>().ExtraJump = 0;
        }
    }
}
