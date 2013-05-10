using UnityEngine;
using System.Collections;

public class WindBehavior : MonoBehaviour {

    public float speedX = 0;
    public float speedY = 0;
    public float speedZ = 0;
    public GameObject[] objectsAfected;
    private bool ballEnabled;
    public GameObject guiObject;


    // Use this for initialization
    void Start() {
        ballEnabled = false;
        resetWind();
    }

    public void resetWind() {
        speedX = generateRandomWind();
        OnGameGUI gui = guiObject.GetComponent<OnGameGUI>();
        gui.showArrow(speedX);
    }

    public void enableBall(bool value) {
        ballEnabled = value;
    }

    void FixedUpdate() {
        foreach (GameObject obj in objectsAfected) {
            if (obj.name.Equals("Ball")) {
                if (!ballEnabled) {
                    continue; // gambiarra para não rolar a bola enquanto ela não for chutada
                }
            }
            obj.rigidbody.AddForce(new Vector3(speedX, speedY, speedZ));
        }
    }


    public float generateRandomWind() {
        float num1 = Random.Range(20F, 30F);
        float num2 = Random.Range(-30F, -20F);

        float[] array = { num1, num2 };

        int randomNumber = Random.Range(0, 100);
        int index;
        if ((randomNumber % 2) == 0) {
            index = 1;
        } else {
            index = 0;
        }

        return array[index];
    }


    // Update is called once per frame
    void Update() {

    }
}
