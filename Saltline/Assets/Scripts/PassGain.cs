using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassGain : MonoBehaviour {

    public Material mat;
    public Texture gain;
    public Texture pass;
    // Use this for initialization
    public void Start () {
        mat.mainTexture = gain;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
