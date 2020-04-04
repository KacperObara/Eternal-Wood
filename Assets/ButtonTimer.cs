using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonTimer : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    Image image;
    float timeLeft;
    public float time;

    // Start is called before the first frame update
    void Awake()
    {
        image = GetComponent<Image>();
    }

    public void StartCooldown()
    {
        GetComponent<Button>().interactable = false;
        timeLeft = time;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeLeft <= 0)
        {
            GetComponent<Button>().interactable = true;
            image.fillAmount = 1;
        }
            
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            image.fillAmount = timeLeft / time;
        }
    }

    public TextMeshProUGUI desc;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (time == 1)
            desc.text = "Zwykłe, słabe drzewo";
        if (time == 2)
            desc.text = "Trudne do ścięcia drzewo";
        if (time == 7)
            desc.text = "Pożeracz ludzi";
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        desc.text = "";
    }
}
