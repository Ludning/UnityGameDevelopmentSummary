using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SRP_Statue : MonoBehaviour
{

    int hp;
    public int HP {  get; private set; }

    int mp;
    public int MP { get; private set; }

    int attack;
    public int Attack { get; private set; }

    int defence;
    public int Defence {  get; private set; }
    SRP_Player player;
    private void Awake()
    {
        player = GetComponent<SRP_Player>();
    }
}
