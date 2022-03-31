using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverWindow : MonoBehaviour
{
    public void OnRestartButtonClicked()
    {
        SceneManager.LoadScene("Level1");
        FindObjectOfType<LevelManager>().ResetGame();
    }
}
