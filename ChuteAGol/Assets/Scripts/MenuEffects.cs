using UnityEngine;
using System.Collections;

public class MenuEffects : MonoBehaviour {

    void OnMouseEnter() {
        renderer.material.color = Color.white;
    }
    void OnMouseExit() {
        renderer.material.color = Color.black;
    }
}
