using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform _playerTs;

    private void LateUpdate()
    {
        transform.position = _playerTs.position;
    }


}
