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

//최초 캐릭터 생성 data 저장하는 기능...
public class CreateCharacterInfo : MonoBehaviour
{
    [SerializeField] private WebConnection _webConnection;
    [SerializeField] TMP_InputField _name;
    [SerializeField] private Toggle _worker;
    
    public void moveScene()
    {
        SceneManager.LoadScene("MainRoom");
    }

    public void createCharacter()
    {
        CharacterType type = CharacterType.Youtuber;
        if (_worker.isOn) type = CharacterType.Worker;
        
        CharacterInfoDTO data = new CharacterInfoDTO(_name.text, type, 1, 1, 0, 0, 0);
        //웹에다 POST로 저장
    }
}
