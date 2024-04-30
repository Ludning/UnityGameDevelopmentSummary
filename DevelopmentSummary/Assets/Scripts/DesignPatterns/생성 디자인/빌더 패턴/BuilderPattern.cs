using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.Jobs;
using UnityEngine;

namespace BuilderPattern
{
    public class BuilderPattern
    {
        private string playerName;
        private int level;
        private float speed;
        private int maxHp;
        private int hp;
        private int maxMp;
        private int mp;
        private int damage;
        private int defence;

        public BuilderPattern() { }

        public BuilderPattern SetPlayerName(string playerName)
        {
            this.playerName = playerName;
            return this;
        }

        public BuilderPattern SetLevel(int level)
        {
            this.level = level;
            return this;
        }

        public BuilderPattern SetSpeed(float speed)
        {
            this.speed = speed;
            return this;
        }

        public BuilderPattern SetMaxHp(int maxHp)
        {
            this.maxHp = maxHp;
            return this;
        }

        public BuilderPattern SetHp(int hp)
        {
            this.hp = hp;
            return this;
        }

        public BuilderPattern SetMaxMp(int maxMp)
        {
            this.maxMp = maxMp;
            return this;
        }

        public BuilderPattern SetMp(int mp)
        {
            this.mp = mp;
            return this;
        }

        public BuilderPattern SetDamage(int damage)
        {
            this.damage = damage;
            return this;
        }

        public BuilderPattern SetDefence(int defence)
        {
            this.defence = defence;
            return this;
        }

        /// 
        /// Builder가 수집한 파라미터를 이용해 인스턴스화 하는 함수.
        /// 
        public Player Build()
        {
            return new Player(this);
        }
    }

    public class Player
    {
        private int playerName;
        private int level;
        private int speed;
        private int maxHp;
        private int hp;
        private int maxMp;
        private int mp;
        private int damage;
        private int defence;
        private Player(int playerName, int level, int speed, int maxHp, int hp, int maxMp, int mp, int damage, int defence)
        {

        }
    }
}

