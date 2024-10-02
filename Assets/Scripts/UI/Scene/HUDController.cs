using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDController : MonoBehaviour
{
    private UI_HUD _view;

    public void Awake()
    {
        _view = GetComponent<UI_HUD>();
    }
}
