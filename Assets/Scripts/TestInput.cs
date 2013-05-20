using UnityEngine;
using System.Collections;

public class TestInput : MonoBehaviour {

    public GameObject cannon;
    public GameObject ball;
    public bool isDragging = false;
    

    // Use this for initialization
    void Start() {





    }



    // Update is called once per frame
    void Update() {

        if (Input.GetMouseButtonDown(0)) {
            isDragging = true;
        }

        if (Input.GetMouseButtonUp(0)) {
            isDragging = false;
            //ball.transform.rotation = cannon.transform.rotation;
            launchBall();

        }

        if (isDragging) {
            float speedX = Input.GetAxisRaw("Mouse X") * Time.deltaTime;

            cannon.transform.Rotate(0, speedX * 500, 0);
            float speedY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime;
            cannon.transform.Rotate((speedY * 500) * -1, 0, 0);
        }

    }


    void launchBall() {
        ball.rigidbody.AddForce(cannon.transform.forward * 1000, ForceMode.Acceleration);
        //ball.rigidbody.AddTorque(30, 30, 30);
    }

}
