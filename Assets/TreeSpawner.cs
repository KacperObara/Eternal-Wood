using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSpawner : MonoBehaviour
{
    private Tree ActiveTree;
    private ButtonTimer CooldownTimer;

    private Vector3 mousePos;

    public LayerMask LayerMask;

    public void SetCooldownTimer(ButtonTimer buttonTimer)
    {
        this.CooldownTimer = buttonTimer;
    }

    public void SpawnTree(GameObject activeTree)
    {
        if (CooldownTimer == null)
            Debug.LogWarning("Cooldowntimer in TreeSpawner is not set!");

        if (ActiveTree != null)
        {
            Destroy(ActiveTree.gameObject);
        }
        ActiveTree = Instantiate(activeTree, Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity).GetComponent<Tree>();
        ActiveTree.gameObject.layer = LayerMask.NameToLayer("UI");
    }

    private void Update()
    {
        if (ActiveTree != null)
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;

            ActiveTree.transform.position = mousePos;

            Vector2 rayPos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
            if (!Physics2D.Raycast(rayPos, Vector2.zero, 0f, LayerMask))
            {
                ActiveTree.GetComponent<SpriteRenderer>().color = Color.green;
            }
            else
                ActiveTree.GetComponent<SpriteRenderer>().color = Color.red;

            if (Input.GetMouseButtonDown(0))
            {
                rayPos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
                if (!Physics2D.Raycast(rayPos, Vector2.zero, 0f, LayerMask))
                {
                    ActiveTree.GetComponent<SpriteRenderer>().color = Color.white;
                    GameObject.FindGameObjectWithTag("GameManager").GetComponent<GManager>().Trees.Add(ActiveTree);
                    CooldownTimer.StartCooldown();
                    ActiveTree.gameObject.layer = LayerMask.NameToLayer("Prop");
                    ActiveTree.GetComponent<Animator>().SetTrigger("Spawning");
                    ActiveTree.Spawned = true;
                    ActiveTree = null;
                }
            }
        }
    }
}
