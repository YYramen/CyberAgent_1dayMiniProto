using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UpStage : MonoBehaviour
{
    [SerializeField, Tooltip("è„è∏Ç∑ÇÈçÇÇ≥")] float _upNum;
    [SerializeField, Tooltip("è¡Ç¶ÇÈÇ‹Ç≈ÇÃéûä‘")] float _time;
    [SerializeField, Tooltip("ìÆÇ´énÇ‹ÇÈÇ‹Ç≈ÇÃíxâÑ")] float _delayTime;
    [SerializeField] string _playerName;

    SpriteRenderer _sp;
    void Start()
    {
        _sp = GetComponent<SpriteRenderer>();
        StageDOTween();
    }

    void Update()
    {
        
    }

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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(_playerName))
        {
            StageDOTween();
        }
    }
}
