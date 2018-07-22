using UnityEngine;

public class SetCards : MonoBehaviour
{    
    public int totalCards;

    private int CardsValue;
    GameObject[] face, card;
    Renderer[] renderFace;    

    // Use this for initialization
    void Awake()
    {
        face = new GameObject[totalCards];
        renderFace = new Renderer[totalCards];
        card = new GameObject[totalCards];
        int[] a = { 0, 1, 2, 3, 4, 5, 6, 7 };

        for (int i = 0; i < totalCards - 1; i += 2)
        {
            int j = i + 1;
            CardsValue = Random.Range(1, 26);
            Material mat = Resources.Load("materials/Card_" + CardsValue) as Material;

            SetCardProperties(i, j, CardsValue, mat);            
        }
                
        Shuffle(a);
    }

    private void SetCardProperties(int i, int j, int value, Material mat)
    {
        //Membuat dua pasang kartu
        face[i] = GameObject.Find("Face_" + i);
        face[j] = GameObject.Find("Face_" + j);

        renderFace[i] = face[i].GetComponent<MeshRenderer>();
        renderFace[j] = face[j].GetComponent<MeshRenderer>();

        renderFace[i].sharedMaterial = mat;
        renderFace[j].sharedMaterial = mat;

        //Membalik setiap kartu
        card[i] = GameObject.Find("CardList_" + i);
        card[j] = GameObject.Find("CardList_" + j);

        card[i].transform.rotation = new Quaternion(0, 180, 0, 0);
        card[j].transform.rotation = new Quaternion(0, 180, 0, 0);

        //Memberikan nilai
        card[i].GetComponent<Cards>().value = value;
        card[j].GetComponent<Cards>().value = value;
        card[i].GetComponent<Cards>().Index = i;
        card[j].GetComponent<Cards>().Index = j;
    }

    void Shuffle(int[] array)
    {
        int n = array.Length;
        for (int i = n - 1; i >= 0; i--)
        {
            int r = Random.Range(0, i) ;
            int t = array[r];
            array[r] = array[i];
            array[i] = t;

            GameObject GetCard = GameObject.Find("CardBtn_" + i);
            GameObject Position = GameObject.Find("Pos_" + array[i]);
            GetCard.transform.SetParent(Position.transform);
            GetCard.transform.localPosition = new Vector2(0, 0);
        }
    }

}