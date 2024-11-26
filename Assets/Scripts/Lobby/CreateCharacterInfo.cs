using System.Collections;
using System.Collections.Generic;
using System.IO;
using Data;
using Newtonsoft.Json;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Web;
using Web.DTO;

//최초 캐릭터 생성 data 저장하는 기능...
public class CreateCharacterInfo : MonoBehaviour
{
    [SerializeField] private WebConnection _webConnection;
    [SerializeField] TMP_InputField _id, _password, _name;
    [SerializeField] private Toggle _worker;
    [SerializeField] TextMeshProUGUI _errortext;
    [SerializeField] private GameObject _IDPWScreen, _nameScreen, _errorScreen, _successScreen;
    private string id, password;

    public void moveScene()
    {
        SceneManager.LoadScene("Login");
    }

    public void TryCreateAccount()
    {
        if (_id.text == "" || _id.text == null)
        {
            _errortext.text = "Create Account Error!\n Need ID";
            _errorScreen.SetActive(true); return;
        }
        if (_password.text == "" || _password.text == null)
        {
            _errortext.text = "Create Account Error!\n Need Password";
            _errorScreen.SetActive(true); return;
        }
        id = _id.text;
        password = _password.text;

        _IDPWScreen.SetActive(false);
        _nameScreen.SetActive(true);
    }

    public void createCharacter()
    {
        CharacterType type = CharacterType.Youtuber;
        if (_worker.isOn) type = CharacterType.Worker;
        
        CharacterInfoDTO data = new CharacterInfoDTO(_name.text, type, 1, 1, 0, 0, 0);

        Debug.Log(id + "  " + password);
        Debug.Log(data);

        //웹에다 POST로 저장
        _webConnection.SendPost(
            "register", new RegisterDTO(id, password, _name.text, type),
        s =>
        {
            _successScreen.SetActive(true);
        },
        () => {
            _errortext.text = "Create Account Error!\n Something goes wrong";
            _errorScreen.SetActive(true);
        });
        _successScreen.SetActive(true);
    }
}
