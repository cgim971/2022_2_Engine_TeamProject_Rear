using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
    private PlayerController _playerController;

    // To do : Priority 값 조정으로 따지기
    [SerializeField] private CinemachineVirtualCamera _followPlayerCam;
    [SerializeField] private CinemachineVirtualCamera _eventCam;

    private CinemachineVirtualCamera _currentCam;

    private void Awake()
    {
        _playerController = FindObjectOfType<PlayerController>();
        _currentCam = _followPlayerCam;
    }

    public void OnEvent()
    {
        SetCamPos(_playerController.FollowTs.position, _playerController.FollowTs.rotation);
        SetCam(_eventCam);
    }

    public void SetCamPos(Vector3 playerPos, Quaternion playerRot)
    {
        _eventCam.transform.position = playerPos;
        _eventCam.transform.rotation = playerRot;
    }

    public void SetCam(CinemachineVirtualCamera camera)
    {
        _currentCam.Priority = 0;
        _currentCam = camera;
        _currentCam.Priority = 10;
    }
}
