using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Define;
using static Define.Direction;
using static Define.Gravity;

public class PlayerController : MonoBehaviour
{
    #region Public Property
    public CustomGravity CustomGravity => _customGravity;
    public SpeedManager SpeedManager => _speedManager;
    public SizeManager SizeManager => _sizeManager;
    public Rigidbody Rigidbody => _rigidbody;

    public PlayerModeType CurrentPlayerMode => _currentPlayerMode;

    public Vector3 Dir => _dir;
    public Vector3 Gravity => _gravity;

    public Transform FollowTs => _followTs;
    #endregion

    private CustomGravity _customGravity = null;
    private SpeedManager _speedManager = null;
    private SizeManager _sizeManager = null;
    private Rigidbody _rigidbody = null;

    // 현재 플레이어 모드
    [SerializeField] private PlayerModeType _currentPlayerMode;
    private Dictionary<PlayerModeType, PlayerMode> _playerModeTypeDictionary = new Dictionary<PlayerModeType, PlayerMode>();

    // 플레이어 진행 방향
    private Vector3 _dir = Vector3.zero;
    [SerializeField] private DirType _gravityType;

    // 플레이어 중력 방향
    private Vector3 _gravity = Vector3.zero;
    [SerializeField] private DirType _dirType;

    // 플레이어 방향에 맞게 회전 할 트랜스폼
    private Transform _rotateTs = null;
    // 플레이어를 따라가는 카메라의 
    private Transform _followTs = null;

    private void Awake() => Init();

    void Init()
    {
        _customGravity = GetComponent<CustomGravity>();
        _speedManager = GetComponent<SpeedManager>();
        _sizeManager = GetComponent<SizeManager>();
        _rigidbody = GetComponent<Rigidbody>();

        _rotateTs = transform.Find("RotateObj");
        _followTs = transform.Find("FollowObj");

        InitPlayerMode();

        SetGravity(_gravityType);
        SetDir(_dirType);
    }

    private void Start()
    {
        SetPlayerMode(_currentPlayerMode);
    }

    #region Player Method
    private void InitPlayerMode()
    {
        _playerModeTypeDictionary.Add(PlayerModeType.CUBE, new PlayerMode(_rotateTs.Find("Cube")));
        _playerModeTypeDictionary.Add(PlayerModeType.UFO, new PlayerMode(_rotateTs.Find("Ufo")));
        _playerModeTypeDictionary.Add(PlayerModeType.SHIP, new PlayerMode(_rotateTs.Find("Ship")));
        _playerModeTypeDictionary.Add(PlayerModeType.ROBOT, new PlayerMode(_rotateTs.Find("Robot")));
        _playerModeTypeDictionary.Add(PlayerModeType.WAVE, new PlayerMode(_rotateTs.Find("Wave")));
        _playerModeTypeDictionary.Add(PlayerModeType.SPIDER, new PlayerMode(_rotateTs.Find("Spider")));
    }

    public void SetPlayerMode(PlayerModeType playerModeType)
    {
        if (_playerModeTypeDictionary.TryGetValue(playerModeType, out PlayerMode playerMode))
        {
            PlayerMode currentPlayerMode = _playerModeTypeDictionary[_currentPlayerMode];
            currentPlayerMode.SetActive(false);
            _currentPlayerMode = playerModeType;
            playerMode.SetActive(true);
            playerMode._playerMode.UseInit();
        }
    }
    #endregion

    #region Trigger Method
    #region Gravity Method
    public void SetGravity(DirType gravityType)
    {
        _gravityType = gravityType;
        _gravity = _customGravity.SetGravity(_gravityType);
    }

    public void ReverseGravity()
    {
        _gravityType = GetReverseGravityType(_gravityType);
        _gravity = _customGravity.SetGravity(_gravityType);
    }
    #endregion

    #region Dir Method
    public void SetDir(DirType dirType)
    {
        _dirType = dirType;
        _dir = GetDirection(dirType);

        RotateObj();
    }
    public void ReverseDir()
    {
        _dirType = GetReverseDirType(_dirType);
        SetDir(_dirType);
    }
    #endregion

    #region Jump Method
    public void Jump()
    {
        if (_playerModeTypeDictionary.TryGetValue(_currentPlayerMode, out PlayerMode playerMode))
        {
            playerMode._playerMode.Jump();
        }
    }
    // 여러 번 점프 코드 작성해야함
    public void ExtraJump(bool isExtraJump = true)
    {
        if (_playerModeTypeDictionary.TryGetValue(_currentPlayerMode, out PlayerMode playerMode))
        {
            playerMode._playerMode.SetIsExtraJump(isExtraJump);
        }
    }
    #endregion

    #region Camera Method
    public void SetCameraPos(Vector3 pos)
    {
        _followTs.DOLocalMove(pos, 0.1f);
    }
    public void SetCameraRot(Quaternion rot)
    {
        _followTs.DORotateQuaternion(rot, 0.1f);
    }
    #endregion
    #endregion

    #region 회전하기.. 가는 방향으로
    [ContextMenu("asdf")]
    private void DebugText()
    {
        Debug.Log(Vector3.Max(Vector3.back, Vector3.zero));
        Debug.Log(Vector3.Max(Vector3.forward, Vector3.zero));
        Debug.Log(Vector3.Dot(Vector3.left, Vector3.zero));
        Debug.Log(Vector3.Dot(Vector3.right, Vector3.zero));
    }

    private void Update()
    {
        // Test code
        //if (Input.GetKeyDown(KeyCode.Space)) RotateObj();
        //if (Input.GetKeyDown(KeyCode.Space)) SetPlayerMode(PlayerModeType.SHIP);
    }

    // 중력과 방향을 이용하여 바라보는 오브젝트를 회전
    public void RotateObj()
    {
        _dir = GetDirection(_dirType);
        _gravity = _customGravity.SetGravity(_gravityType);

        //_rotateTs.transform.localRotation = Quaternion.identity;

        // 0 -1 1  0   0   0
        // 0 1 1   0   180 0
        // 1 0 1   0   0   90
        // 1 0 -1  180 0   90
        // 1 -1 0  0   90  0    
        // 0 1 0 -1 0 0

        {
            // 중력             방향           원하는 결과
            //down(0,-1,0)      앞 (0,0,1)   (0,0,0)
            //down(0,-1,0)      뒤 (0,0,-1)  (0,180,0)
            //down(0,-1,0)      왼 (-1,0,0)  (0,-90,0)
            //down(0,-1,0)      오 (1,0,0)   (0,90,0)

            // up(0,1,0)        앞 (0,0,1)  (0,0,180)
            // up(0,1,0)        뒤 (0,0,-1)  (0,180,180)
            // up(0,1,0)        왼 (-1,0,0)  (0,90,180)
            // up(0,1,0)        오 (1,0,0)  (0,-90,180)

            //left(-1,0,0)      앞 (0,0,1)  (0,0,-90)
            //left(-1,0,0)      뒤 (0,0,-1) (180,0,-90)
            //left(-1,0,0)      위 (0,1,0)  (-90,0,-90)
            //left(-1,0,0)      아래 (0,-1,0) (90,0,-90)

            //right(1,0,0)      앞 (0,0,1)  (0,0,90)
            //right(1,0,0)      뒤 (0,0,-1)  (180,0,90)
            //right(1,0,0)      위 (0,1,0)  (-90,0,90)
            //right(1,0,0)      아래 (0,-1,0)  (90,0,90)

            //forward(0,0,1)    위 (0,0,1)  (-90,0,0)
            //forward(0,0,1)    아래 (0,0,-1) (90,-90,90)
            //forward(0,0,1)    왼 (-1,0,0)  (0,-90,90)
            //forward(0,0,1)    오 (1,0,0) (180,-90,90)

            //backward(0,0,-1)  위 (0,1,0)  (-90,90,90)
            //backward(0,0,-1)  아래 (0,-1,0) (90,0,0)
            //backward(0,0,-1)  왼 (-1,0,0)  (180,90,90)
            //backward(0,0,-1)  오 (1,0,0)  (0,90,90)
        }

        Vector3 cross = Vector3.Cross(_gravity, _dir);
        _rotateTs.transform.forward = cross;


        //_rotateTs.transform.forward = _dir;

        //_rotateTs.transform.localRotation = Quaternion.LookRotation(_dir);
        //_rotateChild.transform.localRotation = Quaternion.LookRotation(_gravity);

        //_rotateChild.transform.up = -_gravity;
        //_rotateTs.transform.localRotation = Quaternion.LookRotation(_dir);

        //if(_dir == Vector3.up)
        //{
        //    _rotateTs.transform.rotation = Quaternion.Euler(-90f, 0f, 90f);
        //}
        //else if(_dir == Vector3.down)
        //{
        //    _rotateTs.transform.rotation = Quaternion.Euler(90f, 0f, 90f);
        //}
        //if(_gravity == Vector3.forward)
        //{
        //    _gravity *= -1f;
        //}
        //if (Vector3.Max(_gravity, Vector3.zero) == Vector3.zero)
        //{
        //    Quaternion rotate = Quaternion.AngleAxis(180f + (_gravity.x * 90f + 180f), _dir);
        //    //Vector3 euler = rotate.eulerAngles;
        //    //euler.z -= _gravity.z * 90f;

        //    _rotateTs.transform.Rotate(rotate.eulerAngles);
        //    //_rotateTs.transform.Rotate(euler);
        //}
        //else
        //{
        //    Quaternion rotate = Quaternion.AngleAxis(0f + (-_gravity.x * 90f + 180f), _dir);
        //    //Vector3 euler = rotate.eulerAngles;
        //    //euler.z = _gravity.z * 90f;

        //    _rotateTs.transform.Rotate(rotate.eulerAngles);
        //    //_rotateTs.transform.Rotate(euler);

        //}


        //Debug.Log(_dir + " " + _rotateTs.transform.forward);


        //Quaternion rotate = Quaternion.identity;


        {
            //if (_gravityType == DirType.DOWN)
            //{
            //    if (_dirType == DirType.FORWARD)
            //    {
            //        rotate = Quaternion.identity;
            //    }
            //    else if (_dirType == DirType.BACKWARD)
            //    {
            //        rotate = Quaternion.Euler(Vector3.up * 180);
            //    }
            //    else if (_dirType == DirType.LEFT)
            //    {
            //        rotate = Quaternion.Euler(Vector3.up * -90);
            //    }
            //    else if (_dirType == DirType.RIGHT)
            //    {
            //        rotate = Quaternion.Euler(Vector3.up * 90);
            //    }
            //}
            //else if (_gravityType == DirType.UP)
            //{
            //    // Vector3.forward == 0, 0, 1
            //    if (_dirType == DirType.FORWARD)
            //    {
            //        rotate = Quaternion.Euler(Vector3.forward * 180);
            //    }
            //    else if (_dirType == DirType.BACKWARD)
            //    {
            //        rotate = Quaternion.Euler(Vector3.up * 180 + Vector3.forward * 180);
            //    }
            //    else if (_dirType == DirType.LEFT)
            //    {
            //        rotate = Quaternion.Euler(Vector3.up * -90 + Vector3.forward * 180);
            //    }
            //    else if (_dirType == DirType.RIGHT)
            //    {
            //        rotate = Quaternion.Euler(Vector3.up * 90 + Vector3.forward * 180);
            //    }
            //}
            //else if (_gravityType == DirType.LEFT)
            //{
            //    if (_dirType == DirType.FORWARD)
            //    {
            //        rotate = Quaternion.Euler(Vector3.forward * -90);
            //    }
            //    else if (_dirType == DirType.BACKWARD)
            //    {
            //        rotate = Quaternion.Euler(Vector3.right * 180 + Vector3.forward * -90);
            //    }
            //    else if (_dirType == DirType.UP)
            //    {
            //        rotate = Quaternion.Euler(Vector3.right * -90 + Vector3.forward * -90);
            //    }
            //    else if (_dirType == DirType.DOWN)
            //    {
            //        rotate = Quaternion.Euler(Vector3.right * 90 + Vector3.forward * -90);
            //    }
            //}
            //else if (_gravityType == DirType.RIGHT)
            //{
            //    if (_dirType == DirType.FORWARD)
            //    {
            //        rotate = Quaternion.Euler(Vector3.forward * 90);
            //    }
            //    else if (_dirType == DirType.BACKWARD)
            //    {
            //        rotate = Quaternion.Euler(Vector3.right * 180 + Vector3.forward * 90);
            //    }
            //    else if (_dirType == DirType.UP)
            //    {
            //        rotate = Quaternion.Euler(Vector3.right * -90 + Vector3.forward * 90);
            //    }
            //    else if (_dirType == DirType.DOWN)
            //    {
            //        rotate = Quaternion.Euler(Vector3.right * 90 + Vector3.forward * 90);
            //    }
            //}
            //else if (_gravityType == DirType.FORWARD)
            //{
            //    if (_dirType == DirType.UP)
            //    {
            //        rotate = Quaternion.Euler(new Vector3(-90, -90, 90));
            //    }
            //    else if (_dirType == DirType.DOWN)
            //    {
            //        rotate = Quaternion.Euler(new Vector3(90, -90, 90));
            //    }
            //    else if (_dirType == DirType.LEFT)
            //    {
            //        rotate = Quaternion.Euler(new Vector3(-180, 90, -90));
            //    }
            //    else if (_dirType == DirType.RIGHT)
            //    {
            //        rotate = Quaternion.Euler(new Vector3(-180, -90, 90));
            //    }
            //}
            //else if (_gravityType == DirType.BACKWARD)
            //{
            //    if (_dirType == DirType.UP)
            //    {
            //        rotate = Quaternion.Euler(new Vector3(-90, -180, 0));
            //    }
            //    else if (_dirType == DirType.DOWN)
            //    {
            //        rotate = Quaternion.Euler(new Vector3(90, -270, 90));
            //    }
            //    else if (_dirType == DirType.LEFT)
            //    {
            //        rotate = Quaternion.Euler(new Vector3(180, -270, 90));
            //    }
            //    else if (_dirType == DirType.RIGHT)
            //    {
            //        rotate = Quaternion.Euler(new Vector3(360, -270, 90));
            //    }
            //}

            //Debug.Log(rotate.eulerAngles);
            //_rotateTs.DORotateQuaternion(rotate, 0.2f);
        }
    }
    #endregion
}

public class PlayerMode
{
    public PlayerMode() { }
    public PlayerMode(Transform playerModeTs)
    {
        _playerModeTs = playerModeTs;
        _playerModeObj = _playerModeTs.gameObject;
        _playerMode = _playerModeTs.GetComponent<PlayerMode_Base>();
        _playerMode.Init();
        _playerModeObj.SetActive(false);
    }

    public void SetActive(bool isActive) => _playerModeObj.SetActive(isActive);

    public Transform _playerModeTs;
    public GameObject _playerModeObj;
    public PlayerMode_Base _playerMode;
}