using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Define;
public class Object_Direction : Object_Base
{
    [SerializeField] private DirType _dirType;

    public override void OnEffect(PlayerMovement_Base player)
    {
        StartCoroutine(ObjectA(player));
    }

    private IEnumerator ObjectA(PlayerMovement_Base obj)
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
                obj.SetDirection(_dirType);

                yield break;
            }
        }
    }


    public override void OffEffect(PlayerMovement_Base player) { }
    public override void Effect() { }
}
