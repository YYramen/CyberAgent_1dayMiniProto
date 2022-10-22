using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField, Tooltip("�J�����̈ړ����x")] float _cameraSpeed;
    [SerializeField, Tooltip("�J�����������n�߂�܂ł̒x������")] float _delayTime;
    [SerializeField, Tooltip("�J�����̏I���_")] float _endPosX;
    bool _isMove;
    void Start()
    {
        _isMove = false;
        StartCoroutine(nameof(SwitchBool));
    }

    void Update()
    {
        Move();
        if(gameObject.transform.position.x > _endPosX)
        {
            _isMove = false;
        }
    }

    /// <summary>
    /// ���̑��x�ŉE�ɋ����X�N���[��
    /// </summary>
    void Move()
    {
        if(_isMove)
        {
            transform.position += new Vector3(_cameraSpeed * Time.deltaTime, 0, 0);
        }
    }

    IEnumerator SwitchBool()
    {
        yield return new WaitForSeconds(_delayTime);
        _isMove = true;
    }
}
