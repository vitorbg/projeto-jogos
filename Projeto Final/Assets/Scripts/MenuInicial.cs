﻿using UnityEngine;
using System.Collections;

public class MenuInicial : MonoBehaviour {

    public string cena;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Jump"))
        {
            Application.LoadLevel(cena);
        }
    }
}
