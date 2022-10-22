using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UpStage : MonoBehaviour
{
    [SerializeField, Tooltip("上昇する高さ")] float _upNum;
    [SerializeField, Tooltip("消えるまでの時間")] float _time;
    [SerializeField, Tooltip("動き始まるまでの遅延")] float _delayTime;
    [SerializeField,Tooltip("SE")] AudioClip _clip;
    [SerializeField] string _playerName;

    AudioSource _audioSource;
    SpriteRenderer _sp;
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _sp = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        
    }

    /// <summary>
    /// 上昇する床
    /// </summary>
    void StageDOTween()
    {
        var sequence = DOTween.Sequence();
        sequence
            .Append(gameObject.transform.DOLocalMoveY(_upNum, _time)).SetRelative(true)
            .Join(_sp.DOFade(-1.0f, _time)).SetDelay(_delayTime)
            .OnComplete(Destroy);
    }
    void Destroy()
    {
        Destroy(gameObject);
    }
    /// <summary>
    /// プレイヤーが乗ったら下降開始
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(_playerName))
        {
            _audioSource.PlayOneShot(_clip);
            StageDOTween();
        }
    }
}
