using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController : MonoBehaviour
{
    [SerializeField, Tooltip("�X�e�[�W�̑��x")] float _stageSpeed;
    Rigidbody2D _rb;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();        
    }
    void Update()
    {

        //�����ŃX�e�[�W������
        _rb.velocity = new Vector2(_stageSpeed, _rb.velocity.y);
    }
}
