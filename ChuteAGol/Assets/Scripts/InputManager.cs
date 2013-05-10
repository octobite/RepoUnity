using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

    private int number = 0;
    public GameObject ball;
    public GameObject camera;
    public GameObject cannon;

    private Quaternion cameraOrigem;
    private Quaternion bolaOrigem;
    private Quaternion cannonOrigem;
    private Vector3 cannonPos;
    private Vector3 bolaPos;

    public GameObject wind;
    public float forcaChute = 1200;


    public GameObject gc;


    private string name = "";

    private float x1;
    private float y1;
    private float x2;
    private float y2;
    private bool liberado;
    public bool isDragging = false;
    bool altPressed = false;
    bool inputDisabled = false;

    public float sensividadeX = 300;
    public float sensividadeY = 150;




    private WindBehavior windBehave;

    //Aqui é tudo teste
    private Vector3 initialAngles;
    private Vector3 curAngles;

    /*
     *  I have to save the object cliqued information. 
     * 
    */

    // Use this for initialization
    void Start() {
        cameraOrigem = camera.transform.rotation;
        bolaOrigem = ball.transform.rotation;
        bolaPos = ball.transform.position;
        cannonOrigem = cannon.transform.rotation;
        cannonPos = cannon.transform.position;
        forcaChute = 1200;
        windBehave = wind.GetComponent<WindBehavior>();

        //Aqui é tudo teste
        initialAngles = cannon.transform.eulerAngles;
        curAngles = Vector3.zero;


    }

    // Update is called once per frame
    void Update() {



        if (Input.GetKey(KeyCode.X)) {

            if (liberado) {
                Restart();

            }
        }




        if (!inputDisabled) {

            if (Input.GetMouseButtonDown(0)) {
                isDragging = true;
            }

            if (Input.GetMouseButtonUp(0)) {
                isDragging = false;
                ball.transform.rotation = cannon.transform.rotation;
                launchBall();

            }

            if (isDragging) {
                float speedX = Input.GetAxisRaw("Mouse X") * Time.deltaTime;
                curAngles.y += speedX * sensividadeX;

                float speedY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime;
                curAngles.x += (speedY * sensividadeY) * -1;

                // limit the angles:
                curAngles.x = Mathf.Clamp(curAngles.x, -38, 0);
                curAngles.y = Mathf.Clamp(curAngles.y, -45, 45);
                // update the object rotation:
                cannon.transform.eulerAngles = initialAngles + curAngles;
            }

        }

    }

    void launchBall() {
        ball.rigidbody.AddForce(cannon.transform.forward * forcaChute, ForceMode.Acceleration);
        ball.rigidbody.AddTorque(30, 30, 30);

        SmoothLookAt otherScript = camera.GetComponent<SmoothLookAt>();
        otherScript.initializeCamera();

        windBehave.enableBall(true);
        StartCoroutine(WaitAndStopWind(0.8F));

        ball.GetComponent<TrailRenderer>().enabled = true;
        this.liberado = true;
        StartCoroutine(WaitAndRestart(5));
    }

    private void Restart() {
        StopAllCoroutines();

        liberado = false;
        ball.rigidbody.velocity = Vector3.zero;
        ball.rigidbody.angularVelocity = Vector3.zero;
        ball.transform.position = bolaPos;
        cannon.transform.rotation = cannonOrigem;
        cannon.transform.position = cannonPos;

        initialAngles = cannon.transform.eulerAngles;
        curAngles = Vector3.zero;

        SmoothLookAt otherScript = camera.GetComponent<SmoothLookAt>();
        otherScript.stopCamera();
        camera.transform.rotation = cameraOrigem;
        ball.transform.rotation = bolaOrigem;

        windBehave.enableBall(false);
        windBehave.resetWind();
        ball.GetComponent<TrailRenderer>().enabled = false;
        altPressed = false;
        inputDisabled = false;
        GameController gameController = gc.GetComponent<GameController>();
        gameController.ResetTargets();

    }

    IEnumerator WaitAndStopWind(float waitTime) {
        yield return new WaitForSeconds(waitTime);

        windBehave.enableBall(false);
    }

    IEnumerator WaitAndRestart(float waitTime) {
        yield return new WaitForSeconds(waitTime);
        Restart();

    }


}
