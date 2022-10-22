using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// �Q�[���S�̂̊Ǘ����s���R���|�[�l���g
/// </summary>
public class GameManager : MonoBehaviour
{
    public static GameManager Instance = default;
    [Tooltip("�O�̃V�[����ۑ����Ă����ϐ�")] static int _beforeSceneNum;

    [SerializeField, Tooltip("�N���A�����X�e�[�W����ۑ�����ϐ�")] int _clearNum = 0;

    [Header("�X�e�[�W�I�����")]
    [SerializeField, Tooltip("�X�e�[�W�P")] GameObject _stageOneButton;
    [SerializeField, Tooltip("�X�e�[�W�Q")] GameObject _stageTwoButton;
    [SerializeField, Tooltip("�X�e�[�W�R")] GameObject _stageThreeButton;

    [Header("�V�[���J��")]
    [SerializeField, Tooltip("�t�F�[�h�C��������I�u�W�F�N�g")] GameObject _fadeInObj;
    [SerializeField, Tooltip("�t�F�[�h�A�E�g������I�u�W�F�N�g")] GameObject _fadeOutObj;

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
    /// �V�[���̑J�ڂɌĂяo�����֐�
    /// </summary>
    /// <param name="sceneNum">�V�[���̔ԍ�</param>
    public void SceneChange(int sceneNum)
    {
        SceneManager.LoadScene(sceneNum);
    }

    /// <summary>
    /// �N���A�����J�E���g���A���ɉ����ăX�e�[�W��\������
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
            Debug.LogError($"{_clearNum}���s���Ȓl�ł�");
        }
    }

    /// <summary>
    /// �Q�[���I�[�o�[
    /// </summary>
    public void GameOver()
    {
        _beforeSceneNum = SceneManager.GetActiveScene().buildIndex;

        // �Q�[���I�[�o�[�V�[����ǂݍ���
    }

    /// <summary>
    /// �Q�[���N���A
    /// </summary>
    public void GameClear()
    {
        // �N���A�����X�e�[�W���X�e�[�W1�ŁA�N���A��������0��������
        if (_clearNum == 0 && SceneManager.GetActiveScene().buildIndex == 1)
        {
            // �N���A�����X�e�[�W�����C���N�������g���ăN���A�V�[����
            _clearNum++;
            Debug.Log(_clearNum);
        }

        // �N���A�����X�e�[�W��2�̏ꍇ
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
    /// �Q�[���̃��g���C
    /// </summary>
    private void RetryGame()
    {
        SceneManager.LoadScene(_beforeSceneNum);
    }
}
