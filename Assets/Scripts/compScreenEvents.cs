using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class compScreenEvents : MonoBehaviour
{

    // Use this for initialization
    private bool compTriggerEntered;

    [SerializeField]
    private Camera computerCamera;
    [SerializeField]
    private RenderTexture renderText;
    [SerializeField]
    private GameObject desker;
    [SerializeField]
    private VideoPlayer introAnimation;
    [SerializeField]
    private Text terminalText;

    void Start()
    {
        computerCamera.targetTexture = null;
        compTriggerEntered = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetButtonDown("Fire1"))
            {
                if (!compTriggerEntered)
                {
                    compTriggerEntered = true;
                    computerCamera.targetTexture = renderText;
                }
            }
            if (!Input.GetButtonDown("Fire1"))
            {
                compTriggerEntered = false;
            }

        }

    }
    // Update is called once per frame
    void Update()
    {
        if (!introAnimation.isPlaying && )
        {

        }
    }
}
