using Microsoft.MixedReality.Toolkit.Experimental.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PasswordCheck : MonoBehaviour
{
    [Header("Password Puzzle")]
    [SerializeField] private NonNativeKeyboard _keyboard;
    [SerializeField] private string _passwordToFind = "";
    private string _enteredPassword = "";
    [SerializeField] private ScriptableEvent _OnFindPassword;

    public void UpdateEnteredPassword()
    {
        _enteredPassword = _keyboard.InputField.text;
        EmptyKeyboardText();
    }

    public void EmptyKeyboardText()
    {
        _keyboard.InputField.text = "";
    }

    public void CheckPassword()
    {
        if(_passwordToFind == _enteredPassword)
        {
            _keyboard.Close();
            Debug.Log("Find Password!!! :)");
            _OnFindPassword.Raise();
        }
        else
        {
            EmptyKeyboardText();    
        }
    }
}
