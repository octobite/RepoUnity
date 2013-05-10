using UnityEngine;
using System.Collections;

public class TargetGenerator : MonoBehaviour {

    public GameObject[] spawPoints;



    public GameObject getRandomTarget() {
        int randomNum = Random.Range(0, 6);
        return spawPoints[randomNum];

    }

}
