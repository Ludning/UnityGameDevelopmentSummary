using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Solid.Liskov_Substitution_Principle
{
    public class LSP_GameManager : MonoBehaviour
    {
        /*
        리스코프 치환

        부모 객체와 이를 상속받은 객체가 있을 때 부모 객체를 호출하는 동작에서 자식 객체가 부모 객체를 완전히 대체할수 있다는 원칙

        이번 예제처럼 Unit클래스를 상속받은 Player클래스, Monster클래스는 
        Unit클래스의 InitData, InitUI, OnDamage, GetHp함수를 재정의 하고 대체할 수 있게 구현한다
        
        그리고 레벨업 함수는 LSP_Player에서 사용되지만, LSP_Monster, LSP_Boss에서는 사용되지 않는다.
        그러므로 LSP_Unit에 추상메서드로 선언하는것 보다 ILevelUpAble 인터페이스로 분리해서
        자식 객체가 부모 객체를 완전히 대체할수 있도록 하면 리스코프 치환 원칙이 지켜지게 된다.
        */

        [SerializeField] private LSP_Unit _player;
        [SerializeField] private LSP_Unit _monster;
        [SerializeField] private LSP_Unit _boss;

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