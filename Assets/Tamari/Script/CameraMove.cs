using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField, Tooltip("カメラの移動速度")] float _cameraSpeed;
    [SerializeField, Tooltip("カメラが動き始めるまでの遅延時間")] float _delayTime;
    [SerializeField, Tooltip("カメラの終着点")] float _endPosX;
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
    /// 一定の速度で右に強制スクロール
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
