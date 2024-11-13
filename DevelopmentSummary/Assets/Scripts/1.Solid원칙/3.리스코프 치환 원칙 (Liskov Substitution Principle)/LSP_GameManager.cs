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
        Unit클래스의 Init, OnDamage, GetHp함수를 재정의 하고 대체할 수 있게 구현한다
        */

        [SerializeField]
        GameObject playerObject;
        [SerializeField]
        GameObject monsterObject;
        [SerializeField]
        GameObject bossObject;
        [SerializeField]
        Canvas canvas;

        LSP_Unit player;
        LSP_Unit monster;
        LSP_Unit boss;

        private void Start()
        {
            player = playerObject.AddComponent<LSP_Player>();
            InitHPText(player);
            monster = monsterObject.AddComponent<LSP_Monster>();
            InitHPText(monster);
            boss = bossObject.AddComponent<LSP_Boss>();
            InitHPText(boss);
        }
        private void InitHPText(LSP_Unit unit)
        {
            GameObject go = new GameObject();
            go.transform.SetParent(canvas.transform, false);
            TextMeshProUGUI text = go.AddComponent<TextMeshProUGUI>();
            text.SetText(unit.GetHp());
            text.fontSize = 8;
            go.transform.position = unit.transform.position;
            go.GetComponent<RectTransform>().sizeDelta = new Vector2(50, 20);
            unit.hpText = text;
        }

        public void AttackMonsterAction()
        {
            monster.OnDamage(player.Damage);
            monster.hpText.SetText(monster.GetHp());
        }
        public void AttackBossAction()
        {
            boss.OnDamage(player.Damage);
            boss.hpText.SetText(boss.GetHp());
        }
    }
}