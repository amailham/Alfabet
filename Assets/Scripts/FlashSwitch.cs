using UnityEngine;
using Vuforia;

public class FlashSwitch : MonoBehaviour {
    public bool FlashState;
	// Use this for initialization
	void Start () {
        FlashState = false;
    }
	
	// Update is called once per frame
	public void TurnOnOff () {
        if (!FlashState)
        {
            CameraDevice.Instance.SetFlashTorchMode(true);
            FlashState = true;
        }else if (FlashState)
        {
            CameraDevice.Instance.SetFlashTorchMode(false);
            FlashState = false;
        }
	}
}
