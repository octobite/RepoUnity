using UnityEngine;
using System.Collections;

public class TargetBehavior : MonoBehaviour {

    public GUIText score;
    public float valor;
    public Transform particles;



    // Use this for initialization
    void Start() {
        score = GameObject.Find("Score").guiText;
    }

    // Update is called once per frame
    void Update() {

    }

    void OnTriggerEnter() {
        float valorAtual = float.Parse(score.text);
        float valorFinal = valorAtual + valor;
        score.text = valorFinal.ToString();
        print(score.text);
        if (GameObject.Find("Alvo(Clone)")) {
            GameObject alvo = GameObject.Find("Alvo(Clone)");
            Instantiate(particles, alvo.transform.position, alvo.transform.rotation);
            Destroy(GameObject.Find("Alvo(Clone)"), 0.1F);
            Destroy(GameObject.Find("Explosion(Clone)"), 0.7F);
        }

    }

}
