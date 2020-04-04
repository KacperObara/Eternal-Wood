using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyboardShortcuts : MonoBehaviour
{
    private TreeSpawner treeSpawner;

    public Button Tree1;
    public Button Tree2;
    public Button Tree3;

    private void Start()
    {
        treeSpawner = GameObject.FindGameObjectWithTag("GameManager").GetComponent<TreeSpawner>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
        {
            if (Tree1.interactable == true && Tree1.isActiveAndEnabled)
                Tree1.onClick.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
        {
            if (Tree2.interactable == true && Tree2.isActiveAndEnabled)
                Tree2.onClick.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3))
        {
            if (Tree3.interactable == true && Tree3.isActiveAndEnabled)
                Tree3.onClick.Invoke();
        }
    }
}
