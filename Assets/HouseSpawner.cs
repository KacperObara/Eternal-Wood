using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseSpawner : MonoBehaviour
{
    public GameObject HumanPrefab;

    private void Start()
    {
        SpawnHuman();
    }

    public void SpawnHuman()
    {
        AIHuman human = Instantiate(HumanPrefab, transform.position, Quaternion.identity).GetComponent<AIHuman>();
        human.Initialize(this);
        GameObject.FindGameObjectWithTag("GameManager").GetComponent<VillageManager>().Residents.Add(human);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Human"))
        {
            collision.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Human"))
        {
            collision.GetComponent<SpriteRenderer>().enabled = true;
        }
    }

    //IEnumerator SpawnHuman(int time)
    //{
    //    yield return new WaitForSeconds(time);
    //    AIHuman human = Instantiate(HumanPrefab, transform.position, Quaternion.identity).GetComponent<AIHuman>();
    //    human.Initialize(this);
    //    Residents.Add(human);
    //}
}
