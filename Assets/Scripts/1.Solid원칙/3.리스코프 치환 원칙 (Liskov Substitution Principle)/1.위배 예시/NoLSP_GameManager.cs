using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Solid.Liskov_Substitution_Principle
{
    public class NoLSP_GameManager : MonoBehaviour
    {
        /*
        리스코프 치환 위배
        
        NoLSP_Unit 스크립트의 OnLevelUp함수를 NoLSP_Player는 override하여 내부 구현을 했지만
        NoLSP_Monster와 NoLSP_Boss는 override를 했으나 내부 구현을 하지 않아 
        자식 객체가 부모 객체를 완전히 대체할수 있다는 리스코프 치환 원칙을 위배하게 된다.
        */

        [SerializeField] private NoLSP_Unit _player;
        [SerializeField] private NoLSP_Unit _monster;
        [SerializeField] private NoLSP_Unit _boss;

        public void AttackMonsterAction()
        {
            _monster.OnDamage(_player.Damage);
        }
        public void AttackBossAction()
        {
            _boss.OnDamage(_player.Damage);
        }
    }
}