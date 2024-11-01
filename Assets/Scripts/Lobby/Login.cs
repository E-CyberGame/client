using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour
{
    [SerializeField]
    TMP_InputField _id, _password;

    [SerializeField]
    TextMeshProUGUI _errortext;

    [SerializeField]
    GameObject _errorScreen;

    public void TryLogin()
    {
        if (_id.text == "" || _id.text == null)
        {
            _errortext.text = "Login Error!\n Need ID";
            _errorScreen.SetActive(true); return;
        }
        else if (_password.text == "" || _password.text == null)
        {
            _errortext.text = "Login Error!\n Need Password";
            _errorScreen.SetActive(true); return;
        }
        else if (false)
        {
            // ���̵� DB�� ���� ��
            _errortext.text = "Login Error!\n Invalid ID";
            _errorScreen.SetActive(true); return;
        }
        else if (false)
        {
            // ��й�ȣ�� �ٸ� ��
            _errortext.text = "Login Error!\n Invalid Password";
            _errorScreen.SetActive(true); return;
        }
        moveScene();
    }

    void moveScene()
    {
        SceneManager.LoadScene("MainRoom");
    }
}
