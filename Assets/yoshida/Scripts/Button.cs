using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ボタンにアタッチして使うコンポーネント
/// </summary>
public class Button : MonoBehaviour
{
    GameManager _gameMan;

    [SerializeField, Tooltip("操作説明のパネル")] GameObject _instructionPanel;
    [SerializeField, Tooltip("クレジットのパネル")] GameObject _creditPanel;

    /// <summary>
    /// 操作説明のパネルを表示
    /// </summary>
    public void ShowInstruction()
    {
        _instructionPanel.SetActive(true);
    }

    /// <summary>
    /// クレジットの画面を表示
    /// </summary>
    public void ShowCredit()
    {
        _creditPanel.SetActive(true);
    }

    /// <summary>
    /// メニュー画面に戻る
    /// </summary>
    public void ReturnMenu()
    {
        _instructionPanel.SetActive(false);
        _creditPanel.SetActive(false);
    }
}
