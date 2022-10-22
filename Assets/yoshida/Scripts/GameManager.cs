using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// �Q�[���S�̂̊Ǘ����s���R���|�[�l���g
/// </summary>
public class GameManager : MonoBehaviour
{
    public static GameManager Instance = default;

    [SerializeField, Tooltip("�N���A�����X�e�[�W��ۑ�����ϐ�")] int _clearNum = 0;
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
    /// �V�[���̑J�ڂɌĂяo�����֐�
    /// </summary>
    /// <param name="sceneNum">�V�[���̔ԍ�</param>
    public void SceneChange(int sceneNum)
    {

    }

    /// <summary>
    /// �X�e�[�W�J�����ɌĂяo�����֐�
    /// </summary>
    private void EnableStages()
    {

    }

    /// <summary>
    /// �Q�[���V�[���Ɉȍ~�������̊֐�
    /// </summary>
    private void GameStart()
    {

    }

    /// <summary>
    /// �Q�[���I�[�o�[
    /// </summary>
    public void GameOver()
    {

    }

    /// <summary>
    /// �Q�[���N���A
    /// </summary>
    public void GameClear()
    {

    }

    /// <summary>
    /// �Q�[���̃��g���C
    /// </summary>
    private void RetryGame()
    {

    }
}
