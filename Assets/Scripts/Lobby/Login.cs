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

    private string id_admin = "admin";
    private string ps_admin = "admin";

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
        else if (_id.text != id_admin)
        {
            // 아이디가 DB에 없을 시
            _errortext.text = "Login Error!\n Invalid ID";
            _errorScreen.SetActive(true); return;
        }
        else if (_password.text != ps_admin)
        {
            // 비밀번호가 다를 시
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
