using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeEater : Tree
{
    public AudioClip TreeEaterDeathSound;
    public AudioClip EatingSound;

    private bool used = false;

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("Human") && Spawned == true && used == false && col.GetComponent<AIHuman>().tree == this)
        {
            used = true;
            GameObject.FindGameObjectWithTag("GameManager").GetComponent<GManager>().RemoveHuman(col.gameObject.GetComponent<AIHuman>());
            AudioSource.PlayClipAtPoint(EatingSound, Camera.main.transform.position, 0.3f);
            GetComponent<Animator>().Play("TreeEaterEating");
            StartCoroutine("Dying");
        }
    }

    private IEnumerator Dying()
    {
        yield return new WaitForSeconds(1.5f);
        AudioSource.PlayClipAtPoint(TreeEaterDeathSound, Camera.main.transform.position, 1f);
        GetComponent<Animator>().SetTrigger("Death");
    }
}


