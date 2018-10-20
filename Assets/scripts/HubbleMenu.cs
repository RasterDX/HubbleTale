using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HubbleMenu : MonoBehaviour {

    public GameObject HubbelPannel;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

    void OnMouseDown()
    {
        Time.timeScale = 0;
        HubbelPannel.SetActive(true);
        Debug.Log("Pause");
    }
}
