using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Define;
using static Define.Direction;
using static Define.Gravity;

public class PlayerController : MonoBehaviour
{
    #region Property
    public CustomGravity CustomGravity => _customGravity;
    public SpeedManager SpeedManager => _speedManager;
    public Rigidbody Rigidbody => _rigidbody;

    public Vector3 Dir => _dir;
    public Vector3 Gravity => _gravity;
    #endregion

    private CustomGravity _customGravity = null;
    private SpeedManager _speedManager = null;
    private Rigidbody _rigidbody = null;

    // 플레이어 진행 방향
    private Vector3 _dir = Vector3.zero;
    [SerializeField] private DirType _gravityType;

    // 플레이어 중력 방향
    private Vector3 _gravity = Vector3.zero;
    [SerializeField] private DirType _dirType;

    // 플레이어 방향에 맞게 회전 할 트랜스폼
    private Transform _rotateTs = null;

    private void Awake() => Init();

    void Init()
    {
        _customGravity = GetComponent<CustomGravity>();
        _speedManager = GetComponent<SpeedManager>();
        _rigidbody = GetComponent<Rigidbody>();

        _rotateTs = transform.Find("RotateObj");

        SetGravity(_gravityType);
        SetDir(_dirType);
    }

    [ContextMenu("asdf")]
    private void DebugText()
    {
        Debug.Log(Vector3.Max(Vector3.back, Vector3.zero));
        Debug.Log(Vector3.Max(Vector3.forward, Vector3.zero));
        Debug.Log(Vector3.Dot(Vector3.left, Vector3.zero));
        Debug.Log(Vector3.Dot(Vector3.right, Vector3.zero));
    }

    // 중력을 변경
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

    // 방향을 변경
    public void SetDir(DirType dirType)
    {
        _dirType = dirType;
        _dir = GetDirection(dirType);

        RotateObj();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) RotateObj();
    }

    private Vector3 VectorAbs(Vector3 value)
    {
        return new Vector3(Mathf.Abs(value.x), Mathf.Abs(value.y), Mathf.Abs(value.z));
    }

    // 중력과 방향을 이용하여 바라보는 오브젝트를 회전
    public void RotateObj()
    {
        _dir = GetDirection(_dirType);
        _gravity = _customGravity.SetGravity(_gravityType);
        _rotateTs.transform.rotation = Quaternion.identity;
        // 0 -1 1  0   0   0
        // 0 1 1   0   180 0
        // 1 0 1   0   0   90
        // 1 0 -1  180 0   90
        // 1 -1 0  0   90  0    
        // 0 1 0 -1 0 0
        _rotateTs.transform.forward = _dir;

        //if(_dir == Vector3.up)
        //{
        //    _rotateTs.transform.rotation = Quaternion.Euler(-90f, 0f, 90f);
        //}
        //else if(_dir == Vector3.down)
        //{
        //    _rotateTs.transform.rotation = Quaternion.Euler(90f, 0f, 90f);
        //}
        if (Vector3.Max(_gravity, Vector3.zero) == Vector3.zero)
        {
            Quaternion rotate = Quaternion.AngleAxis(0f + (-_gravity.x * 90f + 180f), _dir);
            //Vector3 euler = rotate.eulerAngles;
            //euler.z += _dir.y * 90f;

            _rotateTs.transform.Rotate(rotate.eulerAngles);
            //_rotateTs.transform.Rotate(euler);
        }
        else
        {
            Quaternion rotate = Quaternion.AngleAxis(180f + (_gravity.x * 90f + 180f), _dir);
            //Vector3 euler = rotate.eulerAngles;
            //euler.z += _dir.y * 90f;

            _rotateTs.transform.Rotate(rotate.eulerAngles);

        }


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

}
