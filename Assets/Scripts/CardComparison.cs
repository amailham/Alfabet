using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CardComparison : MonoBehaviour {

    public GameObject SelectedCard1, SelectedCard2;
    public Text MatchText;
    public int CardValue1, CardValue2;
    public int CardIndex1, CardIndex2;
    public int NumberofMatch;
    AudioClip matched;
    public AudioSource source;

    private void Start()
    {
        NumberofMatch = 4;
        MatchText.text = NumberofMatch + " Pasang Kartu Lagi";
        source = GetComponent<AudioSource>();
        matched = Resources.Load("Matched_Card") as AudioClip;
    }

    public void StoreValue(int value, int index)
    {
        if (CardValue1 <= 0)
        {
            CardValue1 = value;
            CardIndex1 = index;
        }
        else if (CardValue1 > 0)
        {
            CardValue2 = value;
            CardIndex2 = index;
            CompareCard();
        }
    }
	
	void CompareCard()
    {
        
        SelectedCard1 = GameObject.Find("CardList_" + CardIndex1);
        SelectedCard2 = GameObject.Find("CardList_" + CardIndex2);

        if (CardValue1 == CardValue2)
        {
            SelectedCard1.GetComponent<Cards>().Matched = true;
            SelectedCard2.GetComponent<Cards>().Matched = true;

            NumberofMatch--;
            MatchText.text = NumberofMatch + " Pasang Kartu Lagi";

            ClearValue();

            if (NumberofMatch == 0)
            {
                SceneManager.LoadScene("Win");
            }

            source.PlayOneShot(matched);
        }
        else
        {
            StartCoroutine(Pause(SelectedCard1, SelectedCard2));
            ClearValue();            
        }
    }

    void ClearValue()
    {
        CardValue1 = 0;
        CardValue2 = 0;
    }

    IEnumerator Pause(GameObject Card1, GameObject Card2)
    {
        FlipCard flipManager = GameObject.Find("FlipCardFunction").GetComponent<FlipCard>();

        yield return new WaitForSeconds(0.5f);
        flipManager.FlipDown(Card1);
        flipManager.FlipDown(Card2);
    }        
}
