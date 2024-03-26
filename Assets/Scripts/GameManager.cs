using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject endScreen;
    
    public void GameOver(){
        Time.timeScale = 0f;
        endScreen.SetActive(true);
    }

    public void PlayAgain(){
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainLevel");
    }
}
