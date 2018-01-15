using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class compScreenEvents : MonoBehaviour
{
    // Use this for initialization
 
    [HideInInspector]public bool compTriggerEntered = false;
    private FirstPersonController mousLok;
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
    [HideInInspector]
    public VideoPlayer introAnimation;
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
        terminalTextContent = terminalText.text;
        terminalTextContent = "run praxis.sh";
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            computerCamera.enabled = true;
            compTriggerEntered = true;
            timesCompTriggered++;

        }

    }
    public IEnumerator disableControls()
    {
        if (timesCompTriggered == 1)
        {
            introAnimation.enabled = true;
        }
        FPSCharacterController.transform.position = new Vector3(0.4915411f, -1.219996f, -13.36155f);
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>().fieldOfView = 40;
        //FPSCharacterController.transform.Rotate(0, -10, 0);
        FPSCharacterController.GetComponent<CharacterController>().height = 1.0f;
        yield return null;
    }
    /*private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            if (compTriggerEntered == true)
            {
                computerCamera.enabled = false;
                compTriggerEntered = false;
            }
            
        }
    }*/
    public IEnumerator enableControls()
    {
        FPSCharacterController.GetComponentInChildren<Camera>().fieldOfView = 60;
        FPSCharacterController.GetComponent<CharacterController>().height = 1.4f;
        yield return null;
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
