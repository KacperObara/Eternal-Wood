using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GManager : MonoBehaviour
{
    private float _time;
    public float Time
    {
        get { return _time; }
        set { _time = value; }
    }

    private float _worldTime;
    public float WorldTime
    {
        get { return _worldTime; }
        set { _worldTime = value; }
    }

    public List<Tree> Trees;
    private List<Tree> ReservedTrees = new List<Tree>();

    public GameObject DeathMenu;


    bool ending = false;
    private void Update()
    {
        if (Time > 220 && ending == false && GameObject.FindGameObjectWithTag("eater") == null)
        {
            OnHarmony();
            ending = true;
        }
    }

    public void ReserveTree(Tree tree)
    {
        ReservedTrees.Add(tree);
        Trees.Remove(tree);
    }

    public void RemoveTree(Tree tree)
    {
        ReservedTrees.Remove(tree);
        tree.GetComponent<Animator>().SetTrigger("Death");
        //Destroy(tree.gameObject);
        if (ReservedTrees.Count <= 1 && Trees.Count <= 1 && ending == false)
        {
            OnTreesDestroyed();
        }
    }

    public void RemoveHuman(AIHuman human)
    {
        GetComponent<VillageManager>().Residents.Remove(human);
        Destroy(human.gameObject);
        if (Time > 10f && GetComponent<VillageManager>().Residents.Count == 0 && ending == false)
        {
            OnHumansDestroyed();
        }
    }

    public void OnTreesDestroyed()
    {
        ending = true;
        DeathMenu.GetComponent<DeathManager>().UpdateText(0);
        DeathMenu.SetActive(true);
    }

    public void OnHumansDestroyed()
    {
        ending = true;
        DeathMenu.GetComponent<DeathManager>().UpdateText(1);
        DeathMenu.SetActive(true);
    }

    public void OnHarmony()
    {
        ending = true;
        DeathMenu.GetComponent<DeathManager>().UpdateText(2);
        DeathMenu.SetActive(true);
    }
}
