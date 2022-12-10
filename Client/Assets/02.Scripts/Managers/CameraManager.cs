using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
    private PlayerController _playerController;

    // To do : Priority �� �������� ������
    [SerializeField] private CinemachineVirtualCamera _followPlayerCam;
    [SerializeField] private CinemachineVirtualCamera _deathCam;

    private void Awake()
    {
        _playerController = FindObjectOfType<PlayerController>();
    }

    public void OnDeath()
    {
        SetDeathCamPos(_playerController.FollowTs.position, _playerController.FollowTs.rotation);
        DeathCam();
    }

    public void SetDeathCamPos(Vector3 playerPos, Quaternion playerRot)
    {
        _deathCam.transform.position = playerPos;
        _deathCam.transform.rotation = playerRot;
    }

    public void DeathCam()
    {
        _followPlayerCam.Priority = 0;
        _deathCam.Priority = 10;
    }
}
