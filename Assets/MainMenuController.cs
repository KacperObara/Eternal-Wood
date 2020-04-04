using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public void StartPlaying()
    {
        gameObject.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
