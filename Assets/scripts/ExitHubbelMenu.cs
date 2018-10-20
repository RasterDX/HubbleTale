using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitHubbelMenu : MonoBehaviour {

    public GameObject HubbelPannel;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
    }

    void OnMouseDown()
    {
        Time.timeScale = 1;
        HubbelPannel.SetActive(false);
    }
}
