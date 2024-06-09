using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Auth;
using Firebase;
using System.Threading.Tasks;
using UnityEngine.Events;
using System;

public class Authentication : MonoBehaviour
{
    [SerializeField] UserSO user;

    private FirebaseAuth _authReference;

    public UnityEvent OnLogInSuccesful = new UnityEvent();

    public static Action ValidateRegister;

    private void Awake()
    {
        _authReference = FirebaseAuth.GetAuth(FirebaseApp.DefaultInstance);
    }

    public async void SignUp()
    {
        //Debug.Log("Start Register");
        //StartCoroutine(RegisterUser(user.Email, user.Password));
        await RegisterUserAsync(user.Email, user.Password);
    }

    public async void SignIn()
    {
        await SigInWithEmailAsync(user.Email, user.Password);
    }

    public void SignOut()
    {
        LogOut();
    }

    public void LoadNewScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene2");
    }

    //private IEnumerator RegisterUser(string email, string password)
    //{
    //    Debug.Log("Registering");
    //    var registerTask = _authReference.CreateUserWithEmailAndPasswordAsync(email, password);
    //    yield return new WaitUntil(() => registerTask.IsCompleted);

    //    if (registerTask.Exception != null)
    //    {
    //        Debug.LogWarning($"Failed to register task with {registerTask.Exception}");
    //    }
    //    else
    //    {
    //        Debug.Log($"Succesfully registered user {registerTask.Result.User.Email}");
    //        ValidateRegister?.Invoke();
    //    }
    //}

    private async Task RegisterUserAsync(string email, string password)
    {
        Debug.Log("Usando Async");
        Debug.Log("Registering");

        var registerTask = _authReference.CreateUserWithEmailAndPasswordAsync(email, password);

        await registerTask;

        if (registerTask.IsFaulted)
        {
            Debug.LogWarning($"Failed to register user: {registerTask.Exception?.Message}");
        }
        else if (registerTask.IsCompleted)
        {
            Debug.Log($"Successfully registered user {registerTask.Result.User.Email}");
            ValidateRegister?.Invoke();
        }
    }

    //private IEnumerator SignInWithEmail(string email, string password)
    //{
    //    Debug.Log("Loggin In");

    //    var loginTask = _authReference.SignInWithEmailAndPasswordAsync(email, password);
    //    yield return new WaitUntil(() => loginTask.IsCompleted);

    //    if (loginTask.Exception != null)
    //    {
    //        Debug.LogWarning($"Login failed with {loginTask.Exception}");
    //    }
    //    else
    //    {
    //        Debug.Log($"Login succeeded with {loginTask.Result.User.Email}");
    //        OnLogInSuccesful?.Invoke();
    //    }
    //}
    private async Task SigInWithEmailAsync(string email, string password)
    {
        Debug.Log("Loggin In");
        try
        {
            var loginTask = await _authReference.SignInWithEmailAndPasswordAsync(email, password);
            Debug.Log($"Login succeeded with {loginTask.User.Email}");
            OnLogInSuccesful?.Invoke();
        }
        catch (Exception ex)
        {
            Debug.LogWarning($"Login failed: {ex.Message}");
        }
    }

    private void LogOut()
    {
        FirebaseAuth.DefaultInstance.SignOut();
    }
}