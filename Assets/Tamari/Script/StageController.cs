using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController : MonoBehaviour
{
    [SerializeField, Tooltip("ステージの速度")] float _stageSpeed;
    Rigidbody2D _rb;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();        
    }
    void Update()
    {

        //自動でステージが動く
        _rb.velocity = new Vector2(_stageSpeed, _rb.velocity.y);
    }
}
