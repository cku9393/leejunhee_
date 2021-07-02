using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float rotateSpeed = 10.0f;

    private Vector3 movePos = Vector3.zero;
    private Vector3 moveDir = Vector3.zero;

    public Vector3 Point;
    void Update()
    {
        // ĳ���� �̵�
        if (Input.GetMouseButtonDown(1))
        {

            // ī�޶󿡼� ������ ���콺 Ŭ���� ���� �����Ѵ�. 
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit raycastHit;

            // ���� ������ �浹�ϴ� ��ü�� �ִ��� �Ǻ��Ѵ�.   
            if (Physics.Raycast(ray, out raycastHit))
            {
                Point = raycastHit.point;
                movePos = raycastHit.point;
                //moveDir = movePos - transform.position;
                //moveDir.y = 0;
                //moveDir.Normalize();
                //print(raycastHit.point);
            }
        }

        if (Point != Vector3.zero)
        {
            moveDir = Point - transform.position;
            moveDir.y = 0;
            moveDir.Normalize();
            // ���� ����� ��ǥ ������ �̿��� ȸ���ϰ����ϴ� ������ ���Ѵ�.  
            //Vector3 newDir = Vector3.RotateTowards(transform.forward, moveDir, rotateSpeed * Time.deltaTime, 0.0f);

            transform.rotation = Quaternion.LookRotation(moveDir);
            //transform.position = Vector3.MoveTowards(transform.position, movePos+new Vector3(0,1,0), moveSpeed * Time.deltaTime);
            transform.position += moveDir * moveSpeed * Time.deltaTime;

            Vector3 temp = new Vector3(transform.position.x, 0, transform.position.z);

            if ((Point - temp).magnitude < 0.1)
            {
                Point = Vector3.zero;
            }
        }
    }




    private void OnCollisionEnter(Collision collision)
    {
        string objectName = collision.collider.name;

        if (objectName.Contains("Enemy") || objectName.Contains("Tree") || objectName.Contains("Cube"))
        {
            Point = Vector3.zero;
        }
    }

}

