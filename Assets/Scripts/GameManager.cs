using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class GameManager : MonoBehaviour
{
    private const int titleScreenSceneIndex = 0;
    private const int mainSceneIndex = 1;

    public void LoadMainScene()
    {
        LoadScene(mainSceneIndex);
    }

    public void LoadTitleScreen()
    {
        LoadScene(titleScreenSceneIndex);
    }

    private void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }
}
