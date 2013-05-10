using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    public GameObject gameController;
    public Transform targetPrefab;
    
    // Use this for initialization
    void Start() {
        ResetTargets();
    }

    // Update is called once per frame
    void Update() {

    }

    public void ResetTargets() {
        if (GameObject.Find("Alvo(Clone)")) {
            Destroy(GameObject.Find("Alvo(Clone)"));
        }
        TargetGenerator tg = gameController.GetComponent<TargetGenerator>();
        GameObject spawPoint = tg.getRandomTarget();
        Instantiate(targetPrefab, spawPoint.transform.position, spawPoint.transform.rotation);
    }

}
