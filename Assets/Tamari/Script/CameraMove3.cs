using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove3 : MonoBehaviour
{
    [SerializeField, Tooltip("カメラの移動速度")] float _cameraSpeed;
    [SerializeField, Tooltip("x方向のカメラ抑制速度")] float _secondControlXSpeed;
    [SerializeField, Tooltip("y方向のカメラ抑制速度")] float _secondControlYSpeed;
    [SerializeField, Tooltip("x方向のカメラ抑制速度")] float _thirdControlXSpeed;
    [SerializeField, Tooltip("y方向のカメラ抑制速度")] float _thirdControlYSpeed;
    [SerializeField, Tooltip("カメラが動き始めるまでの遅延時間")] float _delayTime;
    [SerializeField, Tooltip("第一中継地点")] float _firstPosX;
    [SerializeField, Tooltip("第二中継地点")] float _secondPosX;
    [SerializeField, Tooltip("終着点")] float _endPosY;
    bool _isMove;
    bool _isFirst;
    bool _isSecond;
    bool _isThird;
    bool _half;
    void Start()
    {
        _isMove = false;
        _half = false;
        StartCoroutine(nameof(SwitchBool));
    }

    void Update()
    {
        if (transform.position.x <= _firstPosX)
        {
            _isFirst = true;
        }
        else if (transform.position.x > _firstPosX && transform.position.x <= _secondPosX)
        {
            //_isFirst = false;
            _isSecond = true;
        }
        //else if (transform.position.x <= _secondPosX && transform.position.x >= _firstPosX)
        //{
        //    _isFirst = false;
        //    _isSecond = true;
        //}
        else if(transform.position.x > _secondPosX) //&& transform.position.x <= _endPosX)
        {
            //_isFirst = false;
            //_isSecond = true;
            _isThird = true;
            _half = true;
        }
        else if (transform.position.y >= _endPosY)
        {
            _isMove = false;
            _half = false;
            _isFirst = false;
            _isSecond = false;
            _isThird = false;
        }
        if (_isMove && !_half && _isFirst && !_isSecond && !_isThird)
        {
            transform.position += new Vector3(_cameraSpeed * Time.deltaTime, 0);
        }
        else if (_isMove && !_half && _isFirst && _isSecond && !_isThird)
        {
            transform.position += new Vector3((_cameraSpeed + _secondControlXSpeed) * Time.deltaTime, (_cameraSpeed + _secondControlYSpeed) * Time.deltaTime);
        }
        else if(_isMove && _half && _isFirst && _isSecond && _isThird)
        {
            transform.position += new Vector3((_cameraSpeed + _thirdControlXSpeed) * Time.deltaTime, (_cameraSpeed + _thirdControlYSpeed) * Time.deltaTime);
        }
        else if(!_isMove && !_half && !_isFirst && !_isSecond && !_isThird)
        {
            transform.position = new Vector3(0, 0, 0);
        }
    }
    IEnumerator SwitchBool()
    {
        yield return new WaitForSeconds(_delayTime);
        _isMove = true;
        _isFirst = true;
    }
}


