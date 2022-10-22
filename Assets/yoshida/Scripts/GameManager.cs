using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// ゲーム全体の管理を行うコンポーネント
/// </summary>
public class GameManager : MonoBehaviour
{
    public static GameManager Instance = default;

    [SerializeField, Tooltip("クリアしたステージを保存する変数")] int _clearNum = 0;
    public int ClearNum { get => _clearNum; set => _clearNum = value; }

    private void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    /// <summary>
    /// シーンの遷移に呼び出される関数
    /// </summary>
    /// <param name="sceneNum">シーンの番号</param>
    public void SceneChange(int sceneNum)
    {

    }

    /// <summary>
    /// ステージ開放時に呼び出される関数
    /// </summary>
    private void EnableStages()
    {

    }

    /// <summary>
    /// ゲームシーンに以降した時の関数
    /// </summary>
    private void GameStart()
    {

    }

    /// <summary>
    /// ゲームオーバー
    /// </summary>
    public void GameOver()
    {

    }

    /// <summary>
    /// ゲームクリア
    /// </summary>
    public void GameClear()
    {

    }

    /// <summary>
    /// ゲームのリトライ
    /// </summary>
    private void RetryGame()
    {

    }
}
