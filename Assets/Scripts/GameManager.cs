using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class GameManager : MonoBehaviour
{
    private Dictionary<string, int> scenes = new Dictionary<string, int>();

    private void Awake()
    {
        scenes.Add("TitleScreen", 0);
        scenes.Add("Main", 1);
        scenes.Add("HowToPlay", 2);
        scenes.Add("RetryMenu", 3);
    }

    #region Load Methods

    public void LoadMainScene()
    {
        GameState gameState = FindObjectOfType<GameState>();
        if (gameState != null)
        {
            gameState.ResetState();
        }
        LoadScene(scenes["Main"]);
    }

    public void LoadTitleScreen() => LoadScene(scenes["TitleScreen"]);
    public void LoadHowToPlay() => LoadScene(scenes["HowToPlay"]);
    public void LoadRetryMenu() => LoadScene(scenes["RetryMenu"]);
    private void LoadScene(int index) => SceneManager.LoadScene(index);

    #endregion
}
