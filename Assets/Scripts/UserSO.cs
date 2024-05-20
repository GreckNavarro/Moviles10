using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "User", menuName = "ScriptableObjects/User", order = 0)]
public class UserSO : ScriptableObject
{
    [SerializeField] private string email;
    [SerializeField] private string password;


    public string Email { get { return email; } }
    public string Password { get { return password; } }

    public void ChangeEmail(string _email)
    {
        email = _email;
    }
    public void ChangePassword(string _password)
    {
        password = _password;
    }
}
