using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public List<GameObject> HappyRockDiff,PunkyDiff = new List<GameObject>();

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

    public void CreditsBTN()
    {
        SceneManager.LoadScene("Credits");
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
            PunkyDiff[i].SetActive(false);
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

    public void Punky()
    {
        for (int i = 0; i < PunkyDiff.Count; i++)
        {
            PunkyDiff[i].SetActive(true);
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

    public void PunkyHD()
    {
        SceneManager.LoadScene("Punky-hard");
    }
}
