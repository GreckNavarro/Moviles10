using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonsController : MonoBehaviour
{
    public TMP_InputField textLogin;
    public TMP_InputField textLoginPassword;

    public TMP_InputField textRegister;
    public TMP_InputField textRegisterPassword;


    private void OnEnable()
    {
        Authentication.ValidateRegister += RegisterValidate;
    }
    private void OnDisable()
    {
        Authentication.ValidateRegister -= RegisterValidate;

    }
    public void EnterRegister()
    {
        textRegister.text = "";
        textRegisterPassword.text = "";
    }

    public void OnEnterLogin()
    {
        textLogin.text = "";
        textLoginPassword.text = "";
    }


    public GameObject returnpanel;
    private void RegisterValidate()
    {
        returnpanel.SetActive(false);
    }
    public void ReturnLobby()
    {
        GlobalSceneManager.Instance.UnloadSceneAsync("Downloads");
    }
}
