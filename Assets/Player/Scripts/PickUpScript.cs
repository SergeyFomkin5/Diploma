using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PickUpScript : MonoBehaviour
{

    public GameObject player;
    public Transform holdPos;
    //if you copy from below this point, you are legally required to like the video
    public float throwForce = 500f; //force at which the object is thrown at
    public float pickUpRange = 5f; //how far the player can pickup the object from
    private float rotationSensitivity = 1f; //how fast/slow the object is rotated in relation to mouse movement
    [SerializeField] private GameObject heldObj; //object which we pick up
    [SerializeField] private Rigidbody heldObjRb; //rigidbody of object we pick up
    private bool canDrop = true; //this is needed so we don't throw/drop object when rotating the object
    private int LayerNumber; //layer index
    private Vector3 velocity = Vector3.zero; // ��� �������� ������� ��������


    //Reference to script which includes mouse movement of player (looking around)
    //we want to disable the player looking around when rotating the object
    //example below 
    Player_CameraRotation mouseLookScript;

    public string[] pickUpArray;
    void Start()
    {
        LayerNumber = LayerMask.NameToLayer("HoldObject"); //if your holdLayer is named differently make sure to change this ""

        mouseLookScript = GetComponent<Player_CameraRotation>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) //change E to whichever key you want to press to pick up
        {
            //Debug.Log('E');
            if (heldObj == null) //if currently not holding anything
            {
                //perform raycast to check if player is looking at object within pickuprange
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickUpRange))
                {
                    string objectName = hit.transform.gameObject.name;
                    //make sure pickup tag is attached
                    if (pickUpArray.Contains(objectName))
                    {
                        //pass in object hit into the PickUpObject function
                        PickUpObject(hit.transform.gameObject);
                    }
                }
            }
            else
            {
                if(canDrop == true)
                {
                    StopClipping(); //prevents object from clipping through walls
                    DropObject();
                }
            }
        }
        if (heldObj != null) //if player is holding object
        {
            MoveObject(); //keep object position at holdPos
            RotateObject();
            if (Input.GetKeyDown(KeyCode.Mouse0) && canDrop == true) //Mous0 (leftclick) is used to throw, change this if you want another button to be used)
            {
                StopClipping();
                ThrowObject();
            }

        }
    }
    void PickUpObject(GameObject pickUpObj)
    {
        if (pickUpObj.GetComponent<Rigidbody>()) // ���������, ��� ���� Rigidbody
        {
            heldObj = pickUpObj;
            heldObjRb = pickUpObj.GetComponent<Rigidbody>();
            heldObjRb.isKinematic = false; // �� ��������� ������
            heldObjRb.useGravity = false; // ��������� ���������� �� ����� ���������
            heldObjRb.constraints = RigidbodyConstraints.FreezeRotation; // ������������� �������� ��� ������������

            heldObj.layer = LayerNumber; // ���������� ���� ���������

            Physics.IgnoreCollision(heldObj.GetComponent<Collider>(), player.GetComponent<Collider>(), true);
        }
    }

    void DropObject()
    {
        // �������� ���������� �������
        heldObjRb.useGravity = true;

        // ��������� ������� ����� ����������������� � �������
        Physics.IgnoreCollision(heldObj.GetComponent<Collider>(), player.GetComponent<Collider>(), false);

        heldObj.layer = 0; // ������� ������ �� ����������� ����
        heldObjRb.isKinematic = false; // ��������� ���������� ��������
        heldObjRb.constraints = RigidbodyConstraints.None; // ����� ����������� �� ��������
        heldObj.transform.parent = null; // ������� ������������ ������
        heldObj = null; // �������� ������ �� ������
    }

    private void FixedUpdate()
    {
        if (heldObj != null && heldObjRb != null)
        {
            MoveObject();
        }
    }

    void MoveObject()
    {
        Vector3 targetPosition = holdPos.position; // �������� ������� �������
        heldObj.transform.position = Vector3.SmoothDamp(heldObj.transform.position, targetPosition, ref velocity, 0.1f); // 0.1f - ����� ���������
    }

    void RotateObject()
    {
        if (Input.GetKey(KeyCode.R))//hold R key to rotate, change this to whatever key you want
        {
            canDrop = false; //make sure throwing can't occur during rotating

            //disable player being able to look around
            mouseLookScript.SensY = 0f;
            mouseLookScript.SensX = 0f;

            float XaxisRotation = Input.GetAxis("Mouse X") * rotationSensitivity;
            float YaxisRotation = Input.GetAxis("Mouse Y") * rotationSensitivity;
            //rotate the object depending on mouse X-Y Axis
            // �������� ����/����� (���������� ��� Y)
            heldObj.transform.Rotate(Vector3.up, -XaxisRotation, Space.World);

            // �������� �����/����� (���������� ��� Z)
            heldObj.transform.Rotate(Vector3.forward, YaxisRotation, Space.World);
        }
        else
        {
            //re-enable player being able to look around
            mouseLookScript.SensY = 500f;
            mouseLookScript.SensX = 500f;

            canDrop = true;
        }
    }
    void ThrowObject()
    {
        // �������� ���������� �������
        heldObjRb.useGravity = true;

        // ��������� ������� ����� ����������������� � �������
        Physics.IgnoreCollision(heldObj.GetComponent<Collider>(), player.GetComponent<Collider>(), false);

        heldObj.layer = 0; // ������� ������ �� ����������� ����
        heldObjRb.isKinematic = false; // ��������� ���������� ��������
        heldObjRb.constraints = RigidbodyConstraints.None; // ����� ����������� �� ��������
        heldObj.transform.parent = null; // ������� ������������ ������

        // ��������� ���� ������
        heldObjRb.AddForce(transform.forward * throwForce);

        // ���������� ������
        heldObj = null;
    }
    void StopClipping()
    {
        RaycastHit hit;
        if (Physics.Raycast(holdPos.position, -transform.forward, out hit, 0.5f)) // ���������� 0.5 � ��������� ��� ������� �������
        {
            // ���� ���������� �����������, ����������� ������ ���� ������ �� ����
            heldObj.transform.position = hit.point + transform.forward * 0.2f; // ��������� ���������� �� 0.2f ��� ������
        }
    }



}
