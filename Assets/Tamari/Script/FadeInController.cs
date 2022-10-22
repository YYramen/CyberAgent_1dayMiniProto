using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInController : MonoBehaviour
{
    [Tooltip("フェードスピード")]
    [SerializeField]
    private float _fadeSpeed = 1f;
    [Tooltip("フェードする画像")]
    [SerializeField]
    private Image _fadeImage = default;
    [Tooltip("開始時の色")]
    [SerializeField]
    private Color _startColor = Color.black;

    [SerializeField] string _name;
    void Start()
    {
        StartCoroutine(_name);
    }
    IEnumerator FadeIn()
    {
        float clearScale = 1f;
        Color currentColor = _startColor;
        while (clearScale > 0f)
        {
            clearScale -= _fadeSpeed * Time.deltaTime;
            if (clearScale <= 0f)
            {
                clearScale = 0f;
            }
            currentColor.a = clearScale;
            _fadeImage.color = currentColor;
            yield return null;
        }
    }
}
