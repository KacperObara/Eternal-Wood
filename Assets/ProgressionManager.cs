using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressionManager : MonoBehaviour
{
    private GManager gManager;
    private VillageManager villageManager;
    public Timer timer;

    public GameObject housePrefab;

    public List<HouseSpawner> houses;

    public List<GameObject> TreeSpawners = new List<GameObject>();

    public AudioClip NewTreeButtonSound;

    private void Start()
    {
        gManager = GetComponent<GManager>();
        villageManager = GetComponent<VillageManager>();
    }

    int difficulty = 0;
    private float startTime;
    private float worldTime;

    private void Update()
    {
        if (gManager.WorldTime > 2f && difficulty == 0)
        {
            TreeSpawners[0].SetActive(true);
            AudioSource.PlayClipAtPoint(NewTreeButtonSound, Camera.main.transform.position, 1f);
            ++difficulty;
        }
        if (difficulty == 1 && gManager.Trees.Count >= 4)
        {
            timer.InitializeTimer();
            ++difficulty;
        }
        if (gManager.Time > 3 && difficulty == 2)
        {
            houses[0].gameObject.SetActive(true);
            timer.InitializeTimer();
            ++difficulty;
        }
        if (gManager.Time > 8 && difficulty == 3 && villageManager.Wood > 3)
        {
            houses[0].SpawnHuman();
            TreeSpawners[1].SetActive(true);
            AudioSource.PlayClipAtPoint(NewTreeButtonSound, Camera.main.transform.position, 1f);
            ++difficulty;
        }
        if (gManager.Time > 16 && difficulty == 4 && villageManager.Wood > 7)
        {
            houses[0].SpawnHuman();
            ++difficulty;
        }
        if (gManager.Time > 24 && difficulty == 5 && villageManager.Wood > 11)
        {
            houses[1].gameObject.SetActive(true);
            ++difficulty;
        }
        if (gManager.Time > 32 && difficulty == 6 && villageManager.Wood > 16)
        {
            houses[1].SpawnHuman();
            ++difficulty;
            TreeSpawners[2].SetActive(true);
            AudioSource.PlayClipAtPoint(NewTreeButtonSound, Camera.main.transform.position, 1f);
        }
        if (gManager.Time > 40 && difficulty == 7 && villageManager.Wood > 20)
        {
            houses[1].SpawnHuman();
            ++difficulty;
        }
        if (gManager.Time > 45 && difficulty == 8 && villageManager.Wood > 25)
        {
            houses[2].gameObject.SetActive(true);
            ++difficulty;
        }
        if (gManager.Time > 50 && difficulty == 9 && villageManager.Wood > 30)
        {
            houses[2].SpawnHuman();
            houses[0].SpawnHuman();
            ++difficulty;
        }
        if (gManager.Time > 55 && difficulty == 10 && villageManager.Wood > 35)
        {
            houses[2].SpawnHuman();
            ++difficulty;
        }
        if (gManager.Time > 58 && difficulty == 11 && villageManager.Wood > 40)
        {
            houses[3].gameObject.SetActive(true);
            ++difficulty;
        }
        if (gManager.Time > 64 && difficulty == 12 && villageManager.Wood > 45)
        {
            houses[3].SpawnHuman();
            houses[1].SpawnHuman();
            ++difficulty;
        }
        if (gManager.Time > 67 && difficulty == 13 && villageManager.Wood > 50)
        {
            houses[3].SpawnHuman();
            houses[2].SpawnHuman();
            houses[1].SpawnHuman();
            ++difficulty;
        }
        if (gManager.Time > 70 && difficulty == 14 && villageManager.Wood > 50)
        {
            houses[3].SpawnHuman();
            houses[2].SpawnHuman();
            ++difficulty;
        }
        if (gManager.Time > 80 && difficulty == 15 && villageManager.Wood > 55)
        {
            houses[2].SpawnHuman();
            houses[0].SpawnHuman();
            ++difficulty;
        }
    }
}
