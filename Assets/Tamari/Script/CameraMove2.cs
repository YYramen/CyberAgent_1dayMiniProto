using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove2 : MonoBehaviour
{
    [SerializeField, Tooltip("カメラの移動速度")] float _cameraSpeed;
    [SerializeField, Tooltip("カメラが動き始めるまでの遅延時間")] float _delayTime;
    [SerializeField, Tooltip("第一中継地点")] float _firstPosX;
    [SerializeField, Tooltip("終着点")] float _endPosX;
    bool _isMove;
    bool _isFirst;
    bool _isSecond;
    void Start()
    {
        _isMove = false;
        StartCoroutine(nameof(SwitchBool));
    }

    void Update()
    {
        if (transform.position.x <= _firstPosX)
        {
            _isFirst = true;
        }
        else if (transform.position.x > _firstPosX)
        {
            _isFirst = false;
            _isSecond = true;
        }
        else if (transform.position.x >= _endPosX)
        {
            _isMove = false;
        }

        if (_isMove)
        {
            if (_isFirst && !_isSecond)
            {
                transform.position += new Vector3(_cameraSpeed * Time.deltaTime, 0);
            }
            else if (!_isFirst && _isSecond)
            {
                transform.position += new Vector3(_cameraSpeed * Time.deltaTime, _cameraSpeed * Time.deltaTime);
            }
        }
        else
        {
            return;
        }

    }


    /// <summary>
    /// 一定の速度で右に強制スクロール
    /// </summary>
    void Move()
    {
        if (_isMove && _isFirst)
        {

        }
        if (_isMove && _isSecond && !_isFirst)
        {
            transform.position += new Vector3(_cameraSpeed + Time.deltaTime, _cameraSpeed * Time.deltaTime, 0);
        }
    }

    IEnumerator SwitchBool()
    {
        yield return new WaitForSeconds(_delayTime);
        _isMove = true;
        _isFirst = true;
    }
}
