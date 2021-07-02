using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monstermove : MonoBehaviour
{
    public enum eMonsterState 
    {
        idle,
        chase,
        attack,
        attacked,
        death
    }

    
    
    public GameObject target;

    public eMonsterState state;

    void Start()
    {
       state = eMonsterState.idle;

        target = GameObject.Find("Target");
    }

    // Update is called once per frame
    void Update()
    {
      
        switch (state)
        {
            case eMonsterState.idle:
                Idle();
                break;
            case eMonsterState.chase:
                Chase();
                break;
            case eMonsterState.attack:
                Attack();
                break;
            case eMonsterState.attacked:
                Attacked();
                break;
            case eMonsterState.death:
                Death();
                break;
            default:
                break;
        }
    }

    //�������ϋ� �츮�� ������Ʈ���� ȳ���Ұ� 
    public float findDistance = 5;
    
    public void Idle() 
    {
        //�÷��̾ �����Ÿ��ȿ� ������ chase�� �����ϰ� �ʹ�.
        // 1.���� target�� �Ÿ��� ���ؼ�
        float distance = Vector3.Distance(transform.position, target.transform.position);
       // 2.���� �� �Ÿ��� �����Ÿ����� ������
       if(distance < findDistance)
        {
            // 3.Move���·� �����ϰ� �ʹ�
            state = eMonsterState.chase;
        }
        
    }
    // ���� ������ �� ������Ʈ���� �ؾ� �� ��.
    public float moveSpeed = 1.0f;
    public float attackDistance = 1.0f;
    public void Chase()
    {
        //�÷��̾� �������� �̵��ϴٰ� �÷��̾ ���ݹ��� ������ ������ attack���� �����ϰ� �ʹ�
        // 1.target �������� �̵��ϰ� �ʹ�
        Vector3 targetPostion = target.transform.position - transform.position;
        targetPostion.Normalize();
        transform.position += targetPostion * moveSpeed * Time.deltaTime;

        // 2.���� target������ �Ÿ��� ���ؼ�
        float distance = Vector3.Distance(transform.position, target.transform.position);

        // 3.���� �� �Ÿ��� ���ݰŸ����� ������
       if (distance < attackDistance)
        {
            // 4.attack���·� �����ϰ� �ʹ�
            state = eMonsterState.attack;
        }

    }
    float currentTime;
    float attackTime = 1;
    public void Attack()
    {
        // �����ð����� ������ �ϵ� ���ݽ����� target�� ���ݰŸ� �ۿ� ������ Move ���·� �����ϰ�ʹ� �׷��������� ��� �ݺ�����!
        // 1.�ð��� �帣�ٰ�
        currentTime = Time.deltaTime;
        // 2.����ð��� ���ݽð��� �Ǹ�
        if(currentTime > attackTime) 
        {
            // 3.����ð��� �ʱ�ȭ�ϰ�
            currentTime = 0;
            // 4.�÷��̾ �����ϰ�
            //target.AddDamage();

            // 5.���� target������ �Ÿ��� ���ؼ�
            float distance = Vector3.Distance(transform.position, target.transform.position);
            // 6.���� �� �Ÿ��� ���ݰŸ����� ũ��
            if (distance > attackDistance)
            {
                // 7.move���·� �����ϰ� �ʹ�
                state = eMonsterState.chase;
            }
            

        }

    }

    public void Attacked()
    {
        //�÷��̾�� ���� �޾��� �� �������� ǥ���ϰ�,hp�� 0�� �Ǿ��� �� death�� �����ϰ� �ʹ�
    }

    public void Death()
    {
        //HP�� 0�� �Ǿ��� �� ���͸� ������� �ϰ� �ʹ�
    }
}
