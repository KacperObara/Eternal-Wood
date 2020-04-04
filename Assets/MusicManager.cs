using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public void ChangeMusicVolume(float volume)
    {
        GameObject.FindGameObjectWithTag("GameManager").GetComponent<AudioSource>().volume = volume;
    }
}
