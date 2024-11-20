using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Solid.Single_Responsiblity_Principle
{
    public class SRP_Statue : MonoBehaviour
    {
        private int _hp;
        public int HP => _hp;

        private int _mp;
        public int MP => _mp;

        private int _attack;
        public int Attack => _attack;

        private int _defence;
        public int Defence => _defence;
        
        SRP_Player player;
        private void Awake()
        {
            player = GetComponent<SRP_Player>();
        }
    }
}