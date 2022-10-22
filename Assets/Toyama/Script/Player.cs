using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField, Tooltip("歩く速さ")] float _speed = 0f;
    [SerializeField, Tooltip("ジャンプの高さ")] float _jumpPower = 15f;
    [SerializeField, Tooltip("空中の速さ")] float _airSpeed = 2f;
    [SerializeField,Tooltip("ジャンプ音")] AudioClip _se;

    private float _h = 0f;
    private Rigidbody2D _rb2d;
    private Vector2 _dir = new Vector2(0, 0);
    private Animator _anim;
    private bool _isAir = false;
    private AudioSource _as;

    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _as = GetComponent<AudioSource>();
        if(_se == null)
        {
            Debug.LogError("ジャンプ音確認");
        }
    }

    void Update()
    {
        Move();
    }

    /// <summary>
    /// プレイヤーの移動
    /// </summary>
    private void Move()
    {
        _h = Input.GetAxisRaw("Horizontal");
        if (_h > 0)
        {
            transform.localScale = new Vector2(1, 1);
            _anim.SetBool("Move", true);
        }
        else if (_h < 0)
        {
            transform.localScale = new Vector2(-1, 1);
            _anim.SetBool("Move", true);
        }
        else
        {
            _anim.SetBool("Move", false);
        }

        Vector2 dir = new Vector2(_h, 0);
        //Vector2 b = dir.normalized * _speed;
        if (_isAir)
        {
            Vector2 b = dir.normalized * _speed / _airSpeed;
            b.y = _rb2d.velocity.y;
            _rb2d.velocity = b;
        }
        else
        {
            Vector2 b = dir.normalized * _speed;
            b.y = _rb2d.velocity.y;
            _rb2d.velocity = b;
        }

        if (Input.GetButtonDown("Jump") && !_isAir)
        {
            _as.PlayOneShot(_se);
            _isAir = true;
            _rb2d.velocity = Vector2.zero;
            _rb2d.AddForce(transform.up * _jumpPower, ForceMode2D.Impulse);
            _anim.SetBool("Jump", true);

        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            _isAir = false;
            _anim.SetBool("Jump", false);
        }
    }

    /// <summary>
    /// 死ぬ判定
    /// </summary>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Dead")
        {
            GameManager.Instance.GameOver();
        }
        if(collision.gameObject.tag == "Finish")
        {
            GameManager.Instance.GameClear();
        }
    }
}
