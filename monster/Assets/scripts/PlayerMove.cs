using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    void Start()
    {
        //dashspeed = moveSpeed;

    }

    // Update is called once per frame
    void Update()
    {
        // ������� ���� �¿� �Է� ���� �޾ƿ´�.
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        float moveSpeed = 5.0f;

        // ���� �Է°��� ���� ������ ����� �ʹ�.
        Vector3 direction = new Vector3(h, v, 0);
        direction.Normalize();
        // ���� ���� shift ��ư�� ������...
        if (Input.GetKey(KeyCode.LeftShift))
        {
            //���ǵ带 �ι��
            moveSpeed = moveSpeed * 2;
        }
        //if (Input.GetKeyDown(KeyCode.LeftShift))
        // {
        //���ǵ带 �ι��
        //dashspeed = moveSpeed * 2;
        // }
        //�׷��� �ʰ�, ���� Shift ��ư�� ����...
        // else if (Input.GetKeyUp(KeyCode.LeftShift))
        //{
        //moveSpeed = moveSpeed;
        //}
        print(moveSpeed);
        //�� �������� �̵��� �ϰڴ�
        //p=p0+vt
        transform.position += direction * moveSpeed * Time.deltaTime;
        //transform.position += direction * dashSpeed * Time.deltaTime;



    }
}