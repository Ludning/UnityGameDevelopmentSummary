using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Liskov_Substitution_Principle
{
    public class LSP_GameManager : MonoBehaviour
    {
        /*
        �������� ġȯ

        �θ� ��ü�� �̸� ��ӹ��� ��ü�� ���� �� �θ� ��ü�� ȣ���ϴ� ���ۿ��� �ڽ� ��ü�� �θ� ��ü�� ������ ��ü�Ҽ� �ִٴ� ��Ģ

        �̹� ����ó�� UnitŬ������ ��ӹ��� PlayerŬ����, MonsterŬ������ 
        UnitŬ������ Init, OnDamage, GetHp�Լ��� ������ �ϰ� ��ü�� �� �ְ� �����Ѵ�
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