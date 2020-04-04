using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillageManager : MonoBehaviour
{
    [SerializeField]
    private int _wood;
    public  int Wood
    {
        get { return _wood; }
        set { _wood = value; }
    }

    public List<AIHuman> Residents;

    // int villagersGoodwill
}
