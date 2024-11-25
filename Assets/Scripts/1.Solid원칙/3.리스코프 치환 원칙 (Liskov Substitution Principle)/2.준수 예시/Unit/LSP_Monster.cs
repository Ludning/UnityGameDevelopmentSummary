using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Solid.Liskov_Substitution_Principle
{
    public class LSP_Monster : LSP_Unit
    {
        protected override void InitData()
        {
            UnitName = "Monster";
            Level = 10;
            Hp = 1000;
            Damage = 10;
        }
        protected override void InitUI()
        {
            GameObject hpUI = new GameObject();
            hpUI.transform.SetParent(LSP_UIManager.Instance.Canvas.transform, false);
            TextMeshProUGUI text = hpUI.AddComponent<TextMeshProUGUI>();
            text.SetText($"{UnitName} HP : {Hp}");
            text.fontSize = 8;
            text.color = Color.red;
            
            Vector3 uiPosition = Camera.main.WorldToScreenPoint(transform.position);
            hpUI.transform.position = uiPosition;
            
            hpUI.GetComponent<RectTransform>().sizeDelta = new Vector2(50, 20);
            hpUI.transform.localScale = Vector3.one * 10;
            hpText = text;
        }
        public override void OnDamage(int value)
        {
            Hp -= value;
            if (hpText != null)
                hpText.SetText($"{UnitName} HP : {Hp}");
        }
    }
}