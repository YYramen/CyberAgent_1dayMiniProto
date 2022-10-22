using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove2 : MonoBehaviour
{
    [SerializeField, Tooltip("�J�����̈ړ����x")] float _cameraSpeed;
    [SerializeField, Tooltip("�J�����������n�߂�܂ł̒x������")] float _delayTime;
    [SerializeField, Tooltip("��ꒆ�p�n�_")] float _firstPosX;
    [SerializeField, Tooltip("�I���_")] float _endPosX;
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
        Debug.Log(_isMove);
        if (transform.position.x <= _firstPosX)
        {
            _isFirst = true;
        }
        else if (transform.position.x > _firstPosX)
        {
            _isFirst = false;
            _isSecond = true;
        }
        if (transform.position.x >= _endPosX)
        {
            _isMove = false;
            _isFirst = false;
            _isSecond = false;
        }
        if (_isMove && _isFirst && !_isSecond)
        {
            transform.position += new Vector3(_cameraSpeed * Time.deltaTime, 0);
        }
        else if (_isMove && !_isFirst && _isSecond)
        {
            transform.position += new Vector3(_cameraSpeed * Time.deltaTime, _cameraSpeed * Time.deltaTime);
        }
    }
    IEnumerator SwitchBool()
    {
        yield return new WaitForSeconds(_delayTime);
        _isMove = true;
        _isFirst = true;
    }
}
