using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interface_Segregation_Principle
{
    public class ISP_GameManager : MonoBehaviour
    {
        /*
        �������̽� �и� ��Ģ

        ������ ����� �ϳ��� �������̽��� ���� �������� ����
        ���� �������̽��� �и��Ͽ� �����ϴ� ��Ģ

        �������̽��� �и������ν�
        �ʿ��� ��ɸ� ��ӹ޾� ������ �� �ְ� ���ʿ��� ����� ���, ������ �ִ��� ���������ν� ��ü�� ���ʿ��� å���� ������
        */
    }
    public interface IDamageable
    {
        public void OnDamage(int value);
    }
    public interface IStunable
    {
        public void OnStun(int time);
    }
    public interface IMoveable
    {
        public void OnMove(Vector2 dir);
    }
    public class ISP_Player : IDamageable, IStunable, IMoveable
    {
        int hp = 100000;
        public void OnDamage(int value)
        {
            hp -= value;
        }

        public void OnMove(Vector2 dir)
        {
            //������ ���� �ڵ�
        }

        public void OnStun(int time)
        {
            //���� ���� �ڵ�
        }
    }
}