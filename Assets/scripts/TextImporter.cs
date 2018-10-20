using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextImporter : MonoBehaviour {

    public GameObject textBox;

    public Text myText;

    public TextAsset textfile;
    public string[] textLines;

    public PlayerController player;

	// Use this for initialization
	void Start () {
        player = FindObjectOfType<PlayerController>();
	    if(textfile != null)
        {
            textLines = textfile.text.Split('\n');
        }	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
