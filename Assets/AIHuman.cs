using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIHuman : MonoBehaviour
{
    private GManager gManager;
    private VillageManager villageManager;

    private HouseSpawner house;
    public Tree tree;

    private Animator animator;

    Vector3 targetPos;

    public enum State
    {
        InHouse,
        MovingToTree,
        Gathering,
        MovingToHouse
    }

    public State state;

    public int WalkingSpeed;

    public int heldWood;

    public bool isAnimating = false;

    public AudioClip FallingTree;
    public AudioClip TreeHit;

    private void Awake()
    {
        gManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GManager>();
        villageManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<VillageManager>();
        animator = GetComponent<Animator>();
    }

    public void Initialize(HouseSpawner house)
    {
        this.house = house;
        state = State.InHouse;
    }

    // Function called by KeyEvent in animation
    public void OnTreeHit()
    {
        AudioSource.PlayClipAtPoint(TreeHit, tree.transform.position);
        tree.GetComponent<Animator>().SetTrigger("Hit");
    }

    // Function called by KeyEvent in animation
    public void OnEndAnimation()
    {
        if (tree.Hardness > 0)
        {
            tree.Hardness--;
            animator.Play("ChoppingAnimation");
        }
        else
        {
            isAnimating = false;
            gManager.RemoveTree(tree);
            AudioSource.PlayClipAtPoint(FallingTree, tree.transform.position);
        }
    }

    public bool facingRight = true;

    private void Flip()
    {
        facingRight = !facingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void Update()
    {
        if (isAnimating)
            return;

        if (facingRight == true && targetPos.x < transform.position.x)
        {
            Flip();
        }
        if (facingRight == false && targetPos.x > transform.position.x)
        {
            Flip();
        }

        switch (state)
        {
            case State.InHouse:
                villageManager.Wood += heldWood;
                heldWood = 0;
                if (gManager.Trees.Count > 0)
                {
                    tree = ReserveClosestTree();
                    state = State.MovingToTree;
                    targetPos = tree.transform.position;
                }
                break;
            case State.MovingToTree:
                break;
            case State.Gathering:
                heldWood++;
                //tree.GetComponent<AudioSource>().Play();
                animator.Play("ChoppingAnimation");
                isAnimating = true;
                state = State.MovingToHouse;
                targetPos = house.transform.position;
                break;
            case State.MovingToHouse:
                
                break;
        }


        if (Vector2.Distance(transform.position, targetPos) > 0.1f)
        {
            animator.SetBool("Moving", true);
            float step = WalkingSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPos, step);
        }
        else
        {
            animator.SetBool("Moving", false);
            if (state == State.MovingToTree)
            {
                state = State.Gathering;
            }
            else if (state == State.MovingToHouse)
            {
                state = State.InHouse;
            }
        }
    }

    private Tree ReserveClosestTree()
    {
        Tree tree = FindClosestTree();

        gManager.ReserveTree(tree);

        return tree;
    }

    private Tree FindClosestTree()
    {
        Tree tree = gManager.Trees[0];

        for (int i = 0; i < gManager.Trees.Count; i++)
        {
            if ((gManager.Trees[i].transform.position - transform.position).magnitude
              < (tree.transform.position - transform.position).magnitude)
            {
                tree = gManager.Trees[i];
            }
        }

        return tree;
    }
}
