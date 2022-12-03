using Define;
using static Define.Direction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    #region Property
    public CustomGravity CustomGravity => _customGravity;
    public SpeedManager SpeedManager => _speedManager;
    public Rigidbody Rigidbody => _rigidbody;
    public Transform FollowObjTs => _followObjTs;
    #endregion

    [SerializeField] private PlayerModeType _currentPlayerMode = PlayerModeType.NONE;
    private Dictionary<PlayerModeType, PlayerMovement_Base> _playerModeTypeDictionary = new Dictionary<PlayerModeType, PlayerMovement_Base>();

    private CustomGravity _customGravity;
    private SpeedManager _speedManager;
    private Rigidbody _rigidbody;
    private Transform _followObjTs;

    private Vector3 _up = Vector3.up;
    public Vector3 Up => _up;
    private Vector3 _dir = Vector3.zero;
    public Vector3 Dir => _dir;
    [SerializeField] private DirType _dirType;



    private void Awake() => Init();

    void Init()
    {
        _customGravity = GetComponent<CustomGravity>();
        _speedManager = GetComponent<SpeedManager>();
        _rigidbody = GetComponent<Rigidbody>();
        _followObjTs = transform?.Find("FollowObject");

        GetPlayerModeDictionary();
    }

    void GetPlayerModeDictionary()
    {
        _playerModeTypeDictionary.Clear();

        _playerModeTypeDictionary.Add(PlayerModeType.CUBE, transform.Find("Cube")?.GetComponent<PlayerMovement_Base>());
        _playerModeTypeDictionary.Add(PlayerModeType.SHIP, transform.Find("Ship")?.GetComponent<PlayerMovement_Base>());
        _playerModeTypeDictionary.Add(PlayerModeType.UFO, transform.Find("Ufo")?.GetComponent<PlayerMovement_Base>());
    }

    private void Start()
    {
        SetDirection(_dirType);

        SetPlayerMode(_currentPlayerMode);

        SetGravity(_customGravity.GravityType);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            SetPlayerMode(PlayerModeType.SHIP);
        }
    }

    public void SetPlayerMode(PlayerModeType playerMode)
    {
        if (_playerModeTypeDictionary.TryGetValue(_currentPlayerMode, out PlayerMovement_Base currentMode))
        {
            if (currentMode.gameObject.activeSelf)
                currentMode.gameObject.SetActive(false);
        }
        // To do : 플레이어 모드 지정
        if (_playerModeTypeDictionary.TryGetValue(playerMode, out PlayerMovement_Base mode))
        {
            if (!mode.gameObject.activeSelf)
            {
                mode.gameObject.SetActive(true);
            }

            mode.UseInit();
        }
        else
        {
            Debug.LogError($"Error Not has key {playerMode}");
        }
    }

    public void SetFollowObj(Vector3 newPos, Vector3 newRot)
    {
        // To do : 카메라가 회전 부드럽게 플레이어를 중심으로 돌면서
        _followObjTs.DOLocalMove(newPos, 1f);
        _followObjTs.DORotate(newRot, 1f);
    }
    public void SetDirection(DirType dirType = DirType.NONE)
    {
        _dirType = dirType;
        _dir = GetDirection(dirType);
    }
    public void SetGravity(DirType gravityType)
    {
        _customGravity.SetGravity(gravityType);
        _up = _customGravity.GravityDir * (-1);

        _playerModeTypeDictionary[_currentPlayerMode]?.SetGravity();
    }
}
