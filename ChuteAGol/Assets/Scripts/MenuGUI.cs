using UnityEngine;
using System.Collections;

public class MenuGUI : MonoBehaviour {

    public GUISkin menuSkin;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    void OnGUI() {
        GUI.skin = menuSkin;

    }

}
