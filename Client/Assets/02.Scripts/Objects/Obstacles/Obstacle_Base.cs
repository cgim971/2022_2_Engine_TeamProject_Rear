using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public abstract class Obstacle_Base : Object_Base
{
    public override void OnEffect(PlayerMovement_Base player)
    {
        Debug.Log("Die");
        SceneManager.LoadScene("Stage_1");
    }
    public override void OffEffect(PlayerMovement_Base player) { }

    public IEnumerator ChangeAlpha()
    {
        while (true)
        {
            transform.GetComponent<MeshRenderer>().material.DOFade(1f, 1f);
            transform.GetComponent<MeshRenderer>().material.DOFade(0f, 1f);
            yield return null;
        }
    }


}
