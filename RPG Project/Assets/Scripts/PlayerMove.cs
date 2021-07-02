using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float rotateSpeed = 10.0f;


    private Vector3 movePos = Vector3.zero;
    private Vector3 moveDir = Vector3.zero;


    void Start()
    {
        
    }

    void Update()
    {
        // ĳ���� �̵�
        if (Input.GetMouseButtonDown(1))
        {

            // ī�޶󿡼� ������ ���콺 Ŭ���� ���� �����Ѵ�. 
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // ���� ������ �浹�ϴ� ��ü�� �ִ��� �Ǻ��Ѵ�.   
            if (Physics.Raycast(ray, out RaycastHit raycastHit))
            {
                movePos = raycastHit.point;
                moveDir = movePos - transform.position;
                //print(raycastHit.point);
            }
        }

        // ���� ����� ��ǥ ������ �̿��� ȸ���ϰ����ϴ� ������ ���Ѵ�.  
        Vector3 newDir = Vector3.RotateTowards(transform.forward, moveDir, rotateSpeed * Time.deltaTime, 0.0f);

        transform.rotation = Quaternion.LookRotation(newDir);
        transform.position = Vector3.MoveTowards(transform.position, movePos+new Vector3(0,1,0), moveSpeed * Time.deltaTime);

            
    }


}

