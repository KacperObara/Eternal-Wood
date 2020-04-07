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

    public GameObject Instructions;
    public GameObject Menu;

    public void ShowInstructions()
    {
        Instructions.SetActive(true);
        Menu.SetActive(false);
    }

    public void HideInstructions()
    {
        Instructions.SetActive(false);
        Menu.SetActive(true);
    }
}
