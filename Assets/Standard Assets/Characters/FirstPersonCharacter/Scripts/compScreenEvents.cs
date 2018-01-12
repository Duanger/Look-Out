using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class compScreenEvents : MonoBehaviour
{
    // Use this for initialization
    private FirstPersonController mousLok;
    private bool compTriggerEntered;
    [SerializeField]
    private int timesCompTriggered;
    [SerializeField]
    private GameObject FPSCharacterController;
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
    private string terminalTextContent;
    [SerializeField]
    private Renderer compScreen;
    [SerializeField]
    private Material screenMat;
    [SerializeField]
    private AudioSource loadingSoundSource;
    [SerializeField]
    private AudioClip loadingSound;

    void Start()
    {
        mousLok = FPSCharacterController.GetComponent<FirstPersonController>();
        introAnimation.loopPointReached += IntroOver;
        terminalText.enabled = false;
        compTriggerEntered = false;
        terminalTextContent = terminalText.text;
        terminalTextContent = "run praxis.sh";
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (!compTriggerEntered)
            {
                compTriggerEntered = true;
                mousLok.ySense = 0;
                mousLok.xSense = 0;
                FPSCharacterController.GetComponentInChildren<Camera>().fieldOfView = 40;
                FPSCharacterController.GetComponent<CharacterController>().height = 1.0f;
                if (timesCompTriggered == 0)
                {
                    introAnimation.enabled = true;
                    timesCompTriggered++;
                }
                if (!computerCamera.enabled)
                {
                    computerCamera.enabled = true;
                }
            }

        }

    }
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            if (timesCompTriggered >= 0)
            {
                compTriggerEntered = false;
                mousLok.ySense = 2f;
                mousLok.xSense = 2f;
                FPSCharacterController.GetComponentInChildren<Camera>().fieldOfView = 60;
                FPSCharacterController.GetComponent<CharacterController>().height = 1.4f;
                computerCamera.enabled = false;
            }
            
        }
    }
    // Update is called once per frame
    private void IntroOver(VideoPlayer intro)
    {
        introAnimation.enabled = false;
        compScreen.material = screenMat;
        terminalText.enabled = true;
        compTriggerEntered = false;
        StartCoroutine(textLoading());
    }
    IEnumerator textLoading()
    {
        foreach (char letter in terminalTextContent.ToCharArray())
        {
            terminalText.text += letter;
            if (loadingSound)
                loadingSoundSource.PlayOneShot(loadingSound);
            yield return 0;
            yield return new WaitForSeconds(0.2f);
        }
    }
    void Update()
    {
        
    }
}
