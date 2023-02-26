using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLoader : MonoBehaviour
{
    //singleton declaration
    private static SceneLoader _instance = null;
    public static SceneLoader Instance { get => _instance; }

    private AsyncOperation async;

    private void Awake()
    {
        //singleton
        if (_instance == null)
        {
            _instance = this;
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void LoadMain()
    {
        StartCoroutine(LoadMainMenu());
    }

    IEnumerator LoadMainMenu()
    {
        if (async == null)
        {
            SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
            async = SceneManager.LoadSceneAsync(0);
            async.allowSceneActivation = true;
        }
        yield return null;
    }

    public void NewGame()
    {
        GameManager.Instance.level = 0;
        PlayerPrefs.SetInt("level", 0);
        PlayerPrefs.Save();
        GameManager.Instance.PauseOrPlay();
        StartCoroutine(LoadMainScene());
    }

    IEnumerator LoadMainScene()
    {
        if (async == null)
        {
            SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
            async = SceneManager.LoadSceneAsync(2);
            async.allowSceneActivation = true;
        }
        yield return null;
    }

    public void LoadArenaScene()
    {
        if(SceneManager.GetActiveScene().buildIndex != 3)
        {
            StartCoroutine(LoadArena());
        }
    }
    IEnumerator LoadArena()
    {
        if (async == null)
        {
            SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
            async = SceneManager.LoadSceneAsync(3);
            async.allowSceneActivation = true;
        }
        yield return null;
    }

    public bool IsArenaScene()
    {
        return SceneManager.GetActiveScene().buildIndex == 3;
    }

    public void LoadNextScene()
    {
        StartCoroutine(LoadNext());
    }

    IEnumerator LoadNext()
    {
        if (async == null)
        {
            Scene currentScene = SceneManager.GetActiveScene();
            async = SceneManager.LoadSceneAsync(currentScene.buildIndex + 1);
            async.allowSceneActivation = true;
        }
        yield return null;
    }

    public void ReLoadScene()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        StartCoroutine(ReLoad());
    }

    IEnumerator ReLoad()
    {
        if (async == null)
        {
            Scene currentScene = SceneManager.GetActiveScene();
            async = SceneManager.LoadSceneAsync(currentScene.buildIndex);
            async.allowSceneActivation = true;
        }
        yield return null;
    }

    
}
