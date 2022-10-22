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
    /// ���̑��x�ŉE�ɋ����X�N���[��
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
