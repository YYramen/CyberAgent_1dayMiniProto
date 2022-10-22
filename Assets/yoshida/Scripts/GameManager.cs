using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// ゲーム全体の管理を行うコンポーネント
/// </summary>
public class GameManager : MonoBehaviour
{
    public static GameManager Instance = default;
    [Tooltip("前のシーンを保存しておく変数")] static int _beforeSceneNum;

    [SerializeField, Tooltip("クリアしたステージ数を保存する変数")] int _clearNum = 0;

    [Header("ステージ選択画面")]
    [SerializeField, Tooltip("ステージ１")] GameObject _stageOneButton;
    [SerializeField, Tooltip("ステージ２")] GameObject _stageTwoButton;
    [SerializeField, Tooltip("ステージ３")] GameObject _stageThreeButton;

    [Header("シーン遷移")]
    [SerializeField, Tooltip("フェードインさせるオブジェクト")] GameObject _fadeInObj;
    [SerializeField, Tooltip("フェードアウトさせるオブジェクト")] GameObject _fadeOutObj;

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

    private void Start()
    {
        CountClearNum();
    }

    /// <summary>
    /// シーンの遷移に呼び出される関数
    /// </summary>
    /// <param name="sceneNum">シーンの番号</param>
    public void SceneChange(int sceneNum)
    {
        SceneManager.LoadScene(sceneNum);
    }

    /// <summary>
    /// クリア数をカウントし、数に応じてステージを表示する
    /// </summary>
    private void CountClearNum()
    {
        if (_clearNum == 0)
        {
            _stageTwoButton.SetActive(false);
            _stageThreeButton.SetActive(false);
        }
        else if (_clearNum == 1)
        {
            _stageTwoButton.SetActive(true);
            _stageThreeButton.SetActive(false);
        }
        else if (_clearNum == 2)
        {
            _stageTwoButton.SetActive(true);
            _stageThreeButton.SetActive(true);
        }
        else
        {
            Debug.LogError($"{_clearNum}が不正な値です");
        }
    }

    /// <summary>
    /// ゲームオーバー
    /// </summary>
    public void GameOver()
    {
        _beforeSceneNum = SceneManager.GetActiveScene().buildIndex;

        // ゲームオーバーシーンを読み込む
    }

    /// <summary>
    /// ゲームクリア
    /// </summary>
    public void GameClear()
    {
        // クリアしたステージがステージ1で、クリアした数が0だったら
        if (_clearNum == 0 && SceneManager.GetActiveScene().buildIndex == 1)
        {
            // クリアしたステージ数をインクリメントしてクリアシーンへ
            _clearNum++;
            Debug.Log(_clearNum);
        }

        // クリアしたステージが2の場合
        if (_clearNum == 1 && SceneManager.GetActiveScene().buildIndex == 2)
        {
            _clearNum++;
            Debug.Log(_clearNum);
        }

        if (_clearNum == 2 && SceneManager.GetActiveScene().buildIndex == 3)
        {
            Debug.Log(_clearNum);
        }
    }

    /// <summary>
    /// ゲームのリトライ
    /// </summary>
    private void RetryGame()
    {
        SceneManager.LoadScene(_beforeSceneNum);
    }
}
