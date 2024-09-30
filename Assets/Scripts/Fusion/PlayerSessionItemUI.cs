using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Fusion;

public class PlayerSessionItemUI : NetworkBehaviour
{
    public TMP_Text usernameText, userlevelText;
    public Image avatar, mark;
    public GameObject leaderObj;

    bool isHierarchyChanging = false;

    PlayerObject _player = null;
    PlayerObject Player
    {
        get
        {
            if (_player == null) _player = PlayerRegistry.GetPlayer(Object.InputAuthority);
            return _player;
        }
    }

    private void OnBeforeTransformParentChanged()
    {
        isHierarchyChanging = true;
    }

    private void OnTransformParentChanged()
    {
        isHierarchyChanging = false;
    }

    private void OnDisable()
    {
        if (!isHierarchyChanging && Runner?.IsRunning == true) Runner.Despawn(Object);
    }

    public void Init()
    {
        // Player.OnStatChanged += UpdateStats;
        Player.OnSpectatorChanged += SetPosition;
        // UpdateStats();
    }

    public override void Spawned()
    {
        Debug.Log("Spawned");
        Init();
        SetPosition();
    }

    public override void Despawned(NetworkRunner runner, bool hasState)
    {
        if (Player)
        {
            // Player.OnStatChanged -= UpdateStats;
            Player.OnSpectatorChanged -= SetPosition;
        }
    }

    /*
    void UpdateStats()
    {
        SetUsername(Player.Nickname);
        SetColour(Player.Color);
    }
    */

    void SetPosition()
    {
        transform.SetParent(InterfaceManager.Instance.sessionScreen.getPlayerHolder(), false);
        transform.localScale = Vector3.one;
        Debug.Log(transform.position);
    }

    /*
    public void SetUsername(string name)
    {
        usernameText.text = name;
    }

    public void SetColour(Color col)
    {
        usernameText.color = avatar.color = mark.color = col;
    }

    public void SetLeader(bool set)
    {
        leaderObj.SetActive(set);
    }
    */
}
