using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �{�^���ɃA�^�b�`���Ďg���R���|�[�l���g
/// </summary>
public class Button : MonoBehaviour
{
    GameManager _gameMan;

    [SerializeField, Tooltip("��������̃p�l��")] GameObject _instructionPanel;
    [SerializeField, Tooltip("�N���W�b�g�̃p�l��")] GameObject _creditPanel;

    /// <summary>
    /// ��������̃p�l����\��
    /// </summary>
    public void ShowInstruction()
    {
        _instructionPanel.SetActive(true);
    }

    /// <summary>
    /// �N���W�b�g�̉�ʂ�\��
    /// </summary>
    public void ShowCredit()
    {
        _creditPanel.SetActive(true);
    }

    /// <summary>
    /// ���j���[��ʂɖ߂�
    /// </summary>
    public void ReturnMenu()
    {
        _instructionPanel.SetActive(false);
        _creditPanel.SetActive(false);
    }
}
