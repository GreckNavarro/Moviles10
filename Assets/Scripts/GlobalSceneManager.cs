using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GlobalSceneManager : SingletonPersistent<GlobalSceneManager>
{


    //Guardar todos los objetos dentro de un GO vacío para poder activarlos y desactivarlos. 
    //También es importante en este código que los objetos tengan el mismo nombre que las escenas, para que se pueda desactivar los objetos.

    [SerializeField] GameObject sceneGO;

   
    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }
    public void LoadSceneAdditive(string name)
    {
        SceneManager.LoadSceneAsync(name, LoadSceneMode.Additive);
    }
    public void LoadSceneAdditiveAndHideObjects(string name)
    {
        LoadSceneAdditive(name);
        DescargarObjectsScene(name);
    }
    public void UnloadSceneAsync(string name)
    {
        SceneManager.UnloadSceneAsync(name);
    }
    public void DescargarObjectsScene(string name)
    {
        GameObject sceneGO = GameObject.Find(name);
        sceneGO.SetActive(false);
    }
    public void CargarObjetosScena(string name)
    {
        GameObject sceneGO = GameObject.Find(name);
        sceneGO.SetActive(true);
    }
   
    public void ExitGame()
    {
        Application.Quit();
    }
}
