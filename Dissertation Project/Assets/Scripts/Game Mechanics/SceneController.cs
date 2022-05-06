using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public List<GameObject> HappyRockDiff,SecondSongDiff = new List<GameObject>();

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

    public void HappyRockNM()
    {
        SceneManager.LoadScene("HappyRock-normal");
    }

    public void HappyRockHD()
    {
        SceneManager.LoadScene("HappyRock-hard");
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

    public void PunkyEZ()
    {
        SceneManager.LoadScene("Punky-easy");
    }

    public void PunkyNM()
    {
        SceneManager.LoadScene("Punky-normal");
    }
}
