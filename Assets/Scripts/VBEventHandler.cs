using UnityEngine;
using System.Collections;
using Vuforia;

public class VBEventHandler : MonoBehaviour, IVirtualButtonEventHandler {

    // Use this for initialization
    private GameObject vbObject;
    public GameObject model1,model2,model3;
    public AudioClip letterSound,sound1,sound2,sound3;
    public GameObject parent;
    public string vbName;

    private AudioSource source;
    private AudioClip[] sound;
    private GameObject[] model;
    private GameObject spawnedModel;

	void Start () {        
        vbObject = GameObject.Find(vbName);
        vbObject.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);

        source = GetComponent<AudioSource>();
        sound = new AudioClip[] { sound1, sound2, sound3 };
        model = new GameObject[] { model1, model2, model3 };
	}
	
	public void OnButtonPressed(VirtualButtonBehaviour vb)
    {        
        Debug.Log("Button Pressed : " + vb.VirtualButtonName);
        StartCoroutine(PlayAudio());       
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        Debug.Log("Button Released : " + vb.VirtualButtonName);
        GameObject[] models;

        models = GameObject.FindGameObjectsWithTag("Model3D");

        foreach (GameObject model3d in models)
        {
            Destroy(model3d);
        }
    }

    IEnumerator PlayAudio()
    {
        int i = Random.Range(0, 3);

        source.PlayOneShot(letterSound);
        spawnedModel = Instantiate(model[i], transform.position, this.transform.rotation, parent.transform) as GameObject;

        yield return new WaitForSeconds(letterSound.length);        
        source.PlayOneShot(sound[i]);        
    }
}
