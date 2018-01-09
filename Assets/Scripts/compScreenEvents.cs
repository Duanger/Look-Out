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
                introAnimation.enabled = true;
            }

        }

    }
    // Update is called once per frame
    private void IntroOver(VideoPlayer intro)
    {
        if (compTriggerEntered)
        {
            introAnimation.enabled = false;
            compScreen.material = screenMat;
            terminalText.enabled = true;
            compTriggerEntered = false;
            StartCoroutine(textLoading());
        }
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
