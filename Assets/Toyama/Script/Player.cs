using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float _speed = 0f;
    [SerializeField] float _jumpPower = 15f;
    private float _h = 0f;
    private Rigidbody2D _rb2d;
    private Vector2 _dir = new Vector2(0, 0);
    private Animator _anim;
    private int _jumpCount = 0;

    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }

    void Update()
    {
        Move();
    }

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
        Vector2 b = dir.normalized * _speed;
        b.y = _rb2d.velocity.y;
        _rb2d.velocity = b;

        if (Input.GetButtonDown("Jump") && _jumpCount < 1)
        {
            _rb2d.velocity = Vector2.zero;
            _rb2d.AddForce(transform.up * _jumpPower, ForceMode2D.Impulse);
            _anim.SetBool("Jump", true);
            _jumpCount++;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            _jumpCount = 0;
            _anim.SetBool("Jump", false);
        }
    }
}
