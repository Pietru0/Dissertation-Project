using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void ModeSelectBTN()
    {
        SceneManager.LoadScene("Mode Select");
    }

        public void MenuBTN()
    {
        SceneManager.LoadScene("Menu");
    }
    public void InstructionsBTN()
    {
        SceneManager.LoadScene("Instructions");
    }

    public void SongSelectBTN()
    {
        SceneManager.LoadScene("Song Selection");
    }

    public void LearningBTN()
    {
        SceneManager.LoadScene("Learning");
        //not sure if I want to include this yet, but it's here just incase I do
    }
    public void QuitBTN()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }
}
