using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DownStage : MonoBehaviour
{
    [SerializeField, Tooltip("下降する高さ")] float _downNum;
    [SerializeField, Tooltip("消えるまでの時間")] float _time;
    [SerializeField, Tooltip("動き始まるまでの遅延")] float _delayTime;
    [SerializeField] string _playerName;

    SpriteRenderer _sp;
    void Start()
    {
        _sp = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        
    }

    /// <summary>
    /// 下降する床
    /// </summary>
    void StageDOTween()
    {
        var sequence = DOTween.Sequence();
        sequence
            .Append(gameObject.transform.DOLocalMoveY(_downNum, _time)).SetRelative(true)
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
            StageDOTween();
        }
    }
}
