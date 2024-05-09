using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private InputAction inputAction;
    private InputActionAsset inputActionAsset;

    private void Start()
    {
        inputActionAsset = GetComponent<InputActionAsset>();
    }

    public void ChangeKeyBinding()
    {

    }

    void SaveUserRebinds(PlayerInput player)
    {
        var rebinds = player.actions.SaveBindingOverridesAsJson();
        PlayerPrefs.SetString("rebinds", rebinds);
    }

    void LoadUserRebinds(PlayerInput player)
    {
        var rebinds = PlayerPrefs.GetString("rebinds");
        player.actions.LoadBindingOverridesFromJson(rebinds);
    }
}
