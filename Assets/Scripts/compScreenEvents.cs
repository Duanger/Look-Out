using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class compScreenEvents : MonoBehaviour
{

    // Use this for initialization
    [SerializeField]
    private Camera computerCamera;
    [SerializeField]
    private RenderTexture renderText;
    private bool compTriggerEntered = false;

    void Start()
    {
        computerCamera.targetTexture = null;

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetAxis("Fire1") != 0)
            {
                if (!compTriggerEntered)
                {
                    compTriggerEntered = true;
                    computerCamera.targetTexture = renderText;
                }
                
            }
            if (Input.GetAxis("Fire1") == 0)
            {
                compTriggerEntered = false;
            }
        }

    }
    // Update is called once per frame
    void Update()
    {

    }
}
