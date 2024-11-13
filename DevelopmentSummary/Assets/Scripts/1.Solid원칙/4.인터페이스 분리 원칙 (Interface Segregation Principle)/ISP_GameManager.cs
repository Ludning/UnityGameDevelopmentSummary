using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interface_Segregation_Principle
{
    public class ISP_GameManager : MonoBehaviour
    {
        /*
        인터페이스 분리 원칙

        각각의 기능을 하나의 인터페이스에 묶어 구현하지 말고
        여러 인터페이스로 분리하여 구현하는 원칙

        인터페이스를 분리함으로써
        필요한 기능만 상속받아 구현할 수 있고 불필요한 기능의 상속, 구현을 최대한 방지함으로써 객체의 불필요한 책임을 제거함
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
            //움직임 관련 코드
        }

        public void OnStun(int time)
        {
            //기절 관련 코드
        }
    }
}