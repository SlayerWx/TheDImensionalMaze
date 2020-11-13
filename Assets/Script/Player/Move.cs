using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Move : MonoBehaviour
{
    Rigidbody2D myRigid;
    [SerializeField] private float speed;
    void Start() 
    {
        Input.gyro.enabled = true;
        myRigid = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        MyMove();
    }

    void OnGUI()
    {
        GUI.skin.label.fontSize = Screen.width / 40;

        GUILayout.Label("Orientation: " + Screen.orientation);
        GUILayout.Label("input.gyro.attitude: " + Input.gyro.attitude);
        GUILayout.Label("iphone width/font: " + Screen.width + " : " + GUI.skin.label.fontSize);
        GUILayout.Label("Qx: " + ((int)(Input.gyro.attitude.x * 100))*0.01f);
        GUILayout.Label("Qy: " + ((int)(Input.gyro.attitude.y * 100))*0.01f);
        GUILayout.Label("Ax: " + Input.acceleration.x);
        GUILayout.Label("Ay: " + Input.acceleration.y);
    } 
    void MyMove()
    {
        myRigid.velocity = new Vector2((Input.acceleration.x * speed) * Time.deltaTime, 
                                       (Input.acceleration.y * speed) * Time.deltaTime);
        myRigid.velocity = new Vector2((Input.GetAxis("Horizontal") * speed) * Time.deltaTime,
                                       (Input.GetAxis("Vertical") * speed) * Time.deltaTime);


    }
}
