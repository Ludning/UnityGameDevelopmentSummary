using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Observer
{
    //알림 함수
    public void notify();
}

public class ConcreteObserver : Observer
{
    private Subject subject;

    public ConcreteObserver(Subject subject)
    {
        this.subject = subject;
    }
    public void notify()
    {
        Debug.Log("value : " + subject.getValue());
    }
}

public class Subject
{
    private List<Observer> observers;
    private int value;

    public Subject()
    {
        observers = new List<Observer>();
    }

    public int getValue()
    {
        return value;
    }

    //등록
    public void registerObserver(Observer observer)
    {
        observers.Add(observer);
    }

    //해제
    public void unregisterObserver(Observer observer)
    {
        if (observers.Contains(observer))
        {
            observers.Remove(observer);
        }
    }

    //알림
    public void notifyObservers()
    {
        foreach (Observer observer in observers)
        {
            observer.notify();
        }
    }
}