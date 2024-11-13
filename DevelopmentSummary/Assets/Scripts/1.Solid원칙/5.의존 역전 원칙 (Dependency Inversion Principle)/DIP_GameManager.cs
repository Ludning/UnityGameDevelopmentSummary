using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DIP_GameManager : MonoBehaviour
{
    /*
    ���� ���� ��Ģ
    
    Ŭ���̾�Ʈ�� ��Ӱ���� �̷���� ����� ����� ��
    ���� ����� ���� �ν��Ͻ��� ������ ����ϴ°��� �����ϴ°��� ���� ���� ��Ģ�̴�

    �׷��� �� ��� ���� ����� ��ü���� ���뿡 Ŭ���̾�Ʈ�� �����ϰ� �Ǿ� 
    ���� ��⿡ ��ȭ�� ���� ������ Ŭ���̾�Ʈ�� ���� ����� �ڵ带 ���� �����Ͽ��� �ϱ� ����
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

