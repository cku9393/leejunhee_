using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public int attackDamage = 10;
    public float attackRange = 3.0f;
    Transform enemy;
    PlayerMove playerMove;

    void Start()
    {
        playerMove = GetComponent<PlayerMove>();
        enemy = GameObject.Find("Enemy").transform;
    }

    void Update()
    {
        // ĳ���� �Ϲݰ���
        if (Input.GetMouseButtonDown(0))
        {
            playerMove.Point = Vector3.zero;
           
            // ���̸� �����ϰ� ī�޶� ���� �������� �߻��ϰ� �ʹ�.

            // 1. ���̸� �����Ѵ�.
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // 2. ���̰� �ε�ģ ����� ������ ���� ������ �����Ѵ�.
            RaycastHit hitinfo;

            // 3. ���̸� �߻��Ѵ�.
            if (Physics.Raycast(ray, out hitinfo))
            {
                // �ε��� ����� �̸��� �ֿܼ� ����Ѵ�.
                //print(hitinfo.transform.name);
                    
                if (hitinfo.transform.name.Contains("Enemy"))
                {
                    // ���1) �ε��� ����� Enemy��� EnemyFSM ������Ʈ�� �����ͼ�, Damaged �Լ��� �����Ѵ�.

                    if (Vector3.Distance(enemy.position, transform.position) < attackRange)
                    {
                        // EnemyFSM ������Ʈ�� �����ͼ�, Damaged �Լ��� �����Ѵ�.
                        EnemyHP efsm = hitinfo.transform.GetComponent<EnemyHP>();
                        efsm.Damaged(attackDamage);
                    }
                }
            }
            
        }
    }
}
