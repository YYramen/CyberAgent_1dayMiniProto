using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOutController : MonoBehaviour
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
    IEnumerator FadeOut()
    {
        float clearScale = 0f;
        Color currentColor = _startColor;
        while (clearScale < 1f)
        {
            clearScale += _fadeSpeed * Time.deltaTime;
            if (clearScale >= 1f)
            {
                clearScale = 1f;
            }
            currentColor.a = clearScale;
            _fadeImage.color = currentColor;
            yield return null;
        }
    }
}
