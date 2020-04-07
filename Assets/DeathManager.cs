using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathManager : MonoBehaviour
{
    private string KillingHumansText = "Tym razem natura okazała się silniejsza niż człowiek i pozbawiła go możliwości odbudowy...\nCzy dało się coś zrobić?";
    private string HarmonyText = "Natura okazała się silniejsza od człowieka, jednakże mimo jego autodestrukcyjnych zachowań, po raz kolejny wyciągnęła do niego rękę z szansą na życie w harmonii. Odbudowa jest na dobrej drodze.";
    private string DeathText = "Natura uległa pod autodestrukcyjnością człowieka. Zaprzepaścił wszelkie szanse na odbudowę.\nCzy dało się coś zrobić inaczej?";

    public TextMeshProUGUI EndText;
    public TextMeshProUGUI ScoreText;

    public GameObject GamePanel;

    public void UpdateText(int textIndex)
    {
        GamePanel.SetActive(false);
        if (textIndex == 0)
        {
            ScoreText.text = GameObject.FindGameObjectWithTag("GameManager").GetComponent<VillageManager>().Wood.ToString();
            EndText.text = DeathText;
        }
        if (textIndex == 1)
        {
            ScoreText.text = (GameObject.FindGameObjectWithTag("GameManager").GetComponent<VillageManager>().Wood + 2000).ToString();
            EndText.text = KillingHumansText;
        }
        if (textIndex == 2)
        {
            ScoreText.text = (GameObject.FindGameObjectWithTag("GameManager").GetComponent<VillageManager>().Wood + 10000).ToString();
            EndText.text = HarmonyText;
        }
    }

    public void ReturnToMenu()
    {
        Application.LoadLevel(Application.loadedLevel);
        //SceneManager.LoadScene("Game");
    }
}
