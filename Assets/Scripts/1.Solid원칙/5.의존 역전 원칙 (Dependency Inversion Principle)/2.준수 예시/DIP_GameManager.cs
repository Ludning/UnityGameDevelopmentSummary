using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DIP_GameManager : MonoBehaviour
{
    /*
    의존 역전 원칙
    
    클라이언트가 상속관계로 이루어진 모듈을 사용할 때
    하위 모듈을 직접 인스턴스를 가져다 사용하는것을 지양하는것이 의존 역전 원칙이다

    그렇게 할 경우 하위 모듈의 구체적인 내용에 클라이언트가 의존하게 되어 
    하위 모듈에 변화가 있을 때마다 클라이언트나 상위 모듈의 코드를 자주 수정하여야 하기 때문
    */
    Unit player;
    Unit monster;
    Unit boss;

    private void Start()
    {
        player = new DIP_Player();
        monster = new DIP_Monster();
        boss = new DIP_Boss();
    }
    public void Attack()
    {
        monster.OnDamage(100);
    }
}

public interface Unit
{
    public void OnDamage(int value);
}
public class DIP_Player : Unit
{
    public void OnDamage(int value)
    {
    }
}
public class DIP_Monster : Unit
{
    public void OnDamage(int value)
    {
    }
}
public class DIP_Boss : Unit
{
    public void OnDamage(int value)
    {
    }
}

