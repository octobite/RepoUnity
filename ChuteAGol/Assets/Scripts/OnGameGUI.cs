using UnityEngine;
using System.Collections;
[ExecuteInEditMode()]
public class OnGameGUI : MonoBehaviour {

    public GUISkin mySkin;


    public GUIText nrVento;
    public GUIText score;


    public GameObject wind;
    public Texture setaDireita;
    public Texture setaEsquerda;

    private bool displayDireita = false;
    private bool displayEsquerda = false;


    // Use this for initialization
    void Start() {


    }

    // Update is called once per frame
    void Update() {

    }

    public void showArrow(float windValue) {

        if (windValue > 0) {
            displayDireita = true;
            displayEsquerda = false;
            float value = (windValue) / 10;
            nrVento.text = value.ToString("N2");
        }
        if (windValue < 0) {
            displayDireita = false;
            displayEsquerda = true;

            float value = (windValue * -1) / 10;
            nrVento.alignment = TextAlignment.Center;
            nrVento.text = value.ToString("N2");
        }
    }


    void OnGUI() {
        GUI.skin = mySkin;
        nrVento.pixelOffset = new Vector2((Screen.width / 2), -20);
       
        if (displayDireita) {
            GUI.DrawTexture(new Rect((Screen.width / 2) + 70, 0, 110, 78), setaDireita, ScaleMode.ScaleToFit, true, 0F);
        }
        if (displayEsquerda) {
            GUI.DrawTexture(new Rect((Screen.width / 2) - 120, 0, 110, 78), setaEsquerda, ScaleMode.ScaleToFit, true, 0F);
        }
    }
}
