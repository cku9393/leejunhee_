using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    int healthPoint = 50;
    public int maxHP = 50;

    void Start()
    {
        healthPoint = maxHP;
    }

    void Update()
    {
        
    }

    public void Damaged(int value)
    {
        healthPoint = Mathf.Max(healthPoint - value, 0);
        print("���� ���� ü�� : " + healthPoint);
    }
}
