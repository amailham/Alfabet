using System.Collections;
using UnityEngine;
using Vuforia;

public class InfoHuruf : MonoBehaviour, ITrackableEventHandler {

    public AudioClip letter, sound;
    private AudioSource source;
    private TrackableBehaviour mTrackableBehaviour;    
    public Texture btntexture;
    private bool mShowGUIButton = false;

    // Use this for initialization
    void Start()
    {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }

        source = GetComponent<AudioSource>();
    }

    public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED || newStatus == TrackableBehaviour.Status.TRACKED)
        {
            mShowGUIButton = true;
        }
        else
        {
            mShowGUIButton = false;
        }
    }

    void OnGUI()
    {
        float rx = Screen.width - (Screen.width * 30 / 100);
        float ry = Screen.height - (Screen.height * 40 / 100);
        float BtnSize = Screen.width / 5;
        Rect mButtonRect = new Rect(rx, ry, BtnSize, BtnSize);       
        btntexture = Resources.Load("textures/PlayBtn") as Texture;

        if (!btntexture) // This is the button that triggers AR and UI camera On/Off
        {
            Debug.LogError("Please assign a texture on the inspector");
            return;
        }

        if (mShowGUIButton)
        {
            
            // draw the GUI button
            if (GUI.Button(mButtonRect, btntexture))
            {
                // do something on button click
                Debug.Log("Sound Played");
                StartCoroutine(PlaySound());
            }
        }
    }

    public IEnumerator PlaySound()
    {        
        source.PlayOneShot(letter);

        yield return new WaitForSeconds(letter.length);
        source.PlayOneShot(sound);
    }
} 