using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapPainter : MonoBehaviour
{
    private Color islandColor = new Color(1, 1, 1);
    private Color waterColor = new Color(1, 1, 1);

    public Tilemap IslandTilemap;
    public Tilemap IslandHelperTilemap;
    public Tilemap WaterTilemap;

    private AudioSource Music;

    private GManager gManager;
    private VillageManager villageManager;

    private void Awake()
    {
        gManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GManager>();
        villageManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<VillageManager>();
        Music = GameObject.FindGameObjectWithTag("GameManager").GetComponent<AudioSource>();
    }

    private void Update()
    {
        islandColor.g = Mathf.Lerp(1f, 0.55f, ((float)villageManager.Wood / 200));
        islandColor.b = Mathf.Lerp(1f, 0f, ((float)villageManager.Wood / 200));
        IslandTilemap.color = islandColor;
        IslandHelperTilemap.color = islandColor;

        waterColor.g = Mathf.Lerp(1f, 0.63f, ((float)villageManager.Wood / 200));
        waterColor.b = Mathf.Lerp(1f, 0f, ((float)villageManager.Wood / 200));
        WaterTilemap.color = waterColor;

        Music.pitch = Mathf.Lerp(1f, 0.6f, ((float)villageManager.Wood / 200));
    }
}
