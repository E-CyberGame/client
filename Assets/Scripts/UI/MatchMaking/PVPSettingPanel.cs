using System;
using System.Collections;
using System.Collections.Generic;
using Data;
using Fusion;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class PVPSettingPanel : MonoBehaviour
{
    [SerializeField]
    private Image _mapImage;
    [SerializeField]
    private TextMeshProUGUI _mapTitle;
    [SerializeField]
    private Button _leftButton;
    [SerializeField]
    private Button _rightButton;
    [SerializeField]
    private Toggle _crystal;
    [SerializeField]
    private Toggle _decay;
    
    private int MapSelectionIndex = 0;

    public Action<MapType, bool, bool> ChangeSetting = null;

    //해당 클래스 내에 반드시 존재해야 함.
    //맵 좌우로 움직이는 거.
    //최종 데이터 반환.
    
    public void Start()
    {
        InitView();
        ClickLeftButton(MoveMapLeft);
        ClickRightButton(MoveMapRight);
        OnCrystal(delegate { ChangeSetting?.Invoke(GetCurrentMap().SceneType, _crystal.isOn, _decay.isOn);});
        OnDecay(delegate { ChangeSetting?.Invoke(GetCurrentMap().SceneType, _crystal.isOn, _decay.isOn);});
    }
    
    public void InitView()
    {
        ChangeMap(Database.MapData.GetData(MapSelectionIndex));
        _crystal.isOn = true;
        _decay.isOn = true;
    }

    public void SetData(PVPData data)
    {
        ChangeMap(Database.MapData.GetData(data.SceneType));
        _crystal.isOn = data.Crystal;
        _decay.isOn = data.Decay;
    }

    public void ClickLeftButton(UnityAction action)
    {
        _leftButton.onClick.AddListener(action);
    }
    
    public void ClickRightButton(UnityAction action)
    {
        _rightButton.onClick.AddListener(action);
    }

    public void OnCrystal(UnityAction<bool> action)
    {
        _crystal.onValueChanged.AddListener(action);
    }
    
    public void OnDecay(UnityAction<bool> action)
    {
        _decay.onValueChanged.AddListener(action);
    }

    public PVPData GetGameData()
    {
        return new PVPData(GetCurrentMap().SceneType, _decay.isOn, _crystal.isOn);
    }

    #region Utility Method
    private void MoveMapRight()
    {
        if (MapSelectionIndex == Database.MapData.Count() - 1) MapSelectionIndex = 0;
        else MapSelectionIndex++;
        
        ChangeMap(Database.MapData.GetData(MapSelectionIndex));
    }

    private void MoveMapLeft()
    {
        if (MapSelectionIndex == 0) MapSelectionIndex = Database.MapData.Count() - 1;
        else MapSelectionIndex--;
        
        ChangeMap(Database.MapData.GetData(MapSelectionIndex));
    }
    private MapData GetCurrentMap()
    {
        return Database.MapData.GetData(MapSelectionIndex);
    }
    private void ChangeMap(MapData data)
    {
        _mapImage.sprite = data.CardImage;
        _mapTitle.text = data.SceneType.ToString();
        
        ChangeSetting?.Invoke(GetCurrentMap().SceneType, _crystal.isOn, _decay.isOn);
    }

    #endregion
}
