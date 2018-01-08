using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bedEvent : MonoBehaviour {
    [SerializeField]
    private GameObject bed;
    
    void Start () {
     
    }
    private void OnTriggerEnter(Collider other)
    {
        if (Input.GetAxisRaw("Fire1") != 0)
        {
           
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
}
