using System.Collections;
using System.Collections.Generic;
using System.Net;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Web;
using Web.DTO;

public class Login : MonoBehaviour
{
    [SerializeField] private WebConnection _webConnection;
    
    [SerializeField]
    TMP_InputField _id, _password;

    [SerializeField]
    TextMeshProUGUI _errortext;

    [SerializeField] private GameObject _successScreen;
    [SerializeField] GameObject _errorScreen;

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
        /*else if (_id.text != id_admin)
        {
            // ���̵� DB�� ���� ��
            _errortext.text = "Login Error!\n Invalid ID";
            _errorScreen.SetActive(true); return;
        }
        else if (_password.text != ps_admin)
        {
            // ��й�ȣ�� �ٸ� ��
            _errortext.text = "Login Error!\n Invalid Password";
            _errorScreen.SetActive(true); return;
        }*/
        
        _webConnection.SendPost<LoginResponse>(
            "login", new LoginDTO(_id.text, _password.text),
            s =>
            {
                _successScreen.SetActive(true);
                if (s.userName.userNickname is null) s.userName.userNickname = "SYEON";
                _successScreen.transform.Find("ErrorText").GetComponent<TextMeshProUGUI>().text = "Welcome, " + s.userName.userNickname;
            },
            ()=> {
                _errortext.text = "Login Error!\n Invalid ID or Password";
                _errorScreen.SetActive(true);
            });
    }

    public void moveScene()
    {
        SceneManager.LoadScene("MainRoom");
    }

    public void moveFirstScene()
    {
        SceneManager.LoadScene("CreateCharacter");
    }
}
