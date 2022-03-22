using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public List<GameObject> HappyRockDiff,SecondSongDiff = new List<GameObject>();
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

    public void HappyRock()
    {
        for(int i = 0; i < HappyRockDiff.Count; i++)
        {
            HappyRockDiff[i].SetActive(true);
            //only display difficulty for this song
            SecondSongDiff[i].SetActive(false);
        }
    }
    public void HappyRockEZ()
    {
        SceneManager.LoadScene("HappyRock-easy");
    }

    public void HappyRockHD()
    {
        Debug.Log("Hard version not available yet!");
    }

    public void SecondSong()
    {
        for (int i = 0; i < SecondSongDiff.Count; i++)
        {
            SecondSongDiff[i].SetActive(true);
            //only display difficulty for this song
            HappyRockDiff[i].SetActive(false);
        }
    }
}
