using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TitleAnimation : MonoBehaviour
{
    [SerializeField] private Gradient _gradientColor;
    private TMP_Text _textComponent;

    private void Update()
    {
        if (this._textComponent == null)
            this._textComponent = GetComponent<TMP_Text>();

        UpdateAnimation();
    }

    private void UpdateAnimation()
    {
        // ① メッシュを再生成する（リセット）
        this._textComponent.ForceMeshUpdate(true);
        var textInfo = _textComponent.textInfo;

        // ②頂点データを編集した配列の作成
        var count = Mathf.Min(textInfo.characterCount, textInfo.characterInfo.Length);
        for (int i = 0; i < count; i++)
        {
            var charInfo = textInfo.characterInfo[i];
            if (!charInfo.isVisible)
                continue;

            int materialIndex = charInfo.materialReferenceIndex;
            int vertexIndex = charInfo.vertexIndex;

            // Gradient
            Color32[] colors = textInfo.meshInfo[materialIndex].colors32;

            float timeOffset = -0.5f * i;
            float time1 = Mathf.PingPong(timeOffset + Time.realtimeSinceStartup, 1.0f);
            float time2 = Mathf.PingPong(timeOffset + Time.realtimeSinceStartup - 0.1f, 1.0f);
            colors[vertexIndex + 0] = _gradientColor.Evaluate(time1); // 左下
            colors[vertexIndex + 1] = _gradientColor.Evaluate(time1); // 左上
            colors[vertexIndex + 2] = _gradientColor.Evaluate(time2); // 右上
            colors[vertexIndex + 3] = _gradientColor.Evaluate(time2); // 右下
        }

        // ③ メッシュを更新
        for (int i = 0; i < textInfo.materialCount; i++)
        {
            if (textInfo.meshInfo[i].mesh == null) { continue; }

            textInfo.meshInfo[i].mesh.colors32 = textInfo.meshInfo[i].colors32;
            _textComponent.UpdateGeometry(textInfo.meshInfo[i].mesh, i);
        }
    }
}
