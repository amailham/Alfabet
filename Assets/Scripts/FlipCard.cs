using UnityEngine;

public class FlipCard : MonoBehaviour {
    public GameObject SelectedCard;
    public int CardValue, CardIndex;
        
    public void FlipUp(GameObject SelectedCard)
    {
        CardValue = SelectedCard.GetComponent<Cards>().value;
        CardIndex = SelectedCard.GetComponent<Cards>().Index;
        CardComparison compare = GameObject.Find("_CompareCard").GetComponent<CardComparison>();

        if (SelectedCard.GetComponent<Cards>().state == 0)
        {
            SelectedCard.transform.rotation = new Quaternion(0, 0, 0, 0);
            SelectedCard.GetComponent<Cards>().state = 1;

            compare.StoreValue(CardValue, CardIndex);
        }        
    }
    
    public void FlipDown(GameObject SelectedCard)
    {
        CardValue = SelectedCard.GetComponent<Cards>().value;
        CardIndex = SelectedCard.GetComponent<Cards>().Index;

        if (SelectedCard.GetComponent<Cards>().state == 1 && SelectedCard.GetComponent<Cards>().Matched == false)
        {
            SelectedCard.transform.rotation = new Quaternion(0, 180, 0, 0);
            SelectedCard.GetComponent<Cards>().state = 0;
        }
    }

}