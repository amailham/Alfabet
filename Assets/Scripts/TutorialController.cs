using UnityEngine;

public class TutorialController : MonoBehaviour {

    GameObject scan;
    GameObject GameTuts;
    GameObject parent;
    GameObject Showlayer;

    public int Layer;

    // Use this for initialization
    void Awake () {
        scan = Resources.Load("prefabs/ScanMarker") as GameObject;        
        GameTuts = Resources.Load("prefabs/GameTutorial") as GameObject;
        parent = GameObject.Find("Canvas");

        Layer = 0;
        ShowLayer(Layer);
    }
	
	// Update is called once per frame
	public void NextLayer () {
        if (Layer >= 1)        
            Layer = 0;        
        else
            Layer++;

        ShowLayer(Layer);
	}

    public void PreviousLayer()
    {
        if (Layer <= 0)
            Layer = 1;
        else
            Layer--;

        ShowLayer(Layer);
    }

    void ShowLayer(int i)
    {
        GameObject.Destroy(Showlayer);

        switch (i)
        {
            default:
            case (0):
                Showlayer =  Instantiate(scan, parent.transform);
                break;
            case (1):                                
                Showlayer = Instantiate(GameTuts, parent.transform);
                break;
        }
    }
}
