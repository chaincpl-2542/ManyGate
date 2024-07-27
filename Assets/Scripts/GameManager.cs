using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject cardContainer;
    [SerializeField] private GameObject cardPrefab;
    [SerializeField] private Sprite[] imagesObject;
    [SerializeField] private List<Card> currentCardList;
    private bool isStart;
    private bool timerRunning = false;
    private Card card_First;
    private Card card_Second;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isStart)
        {
            if(currentCardList.Count == 0)
            {
                EndGame();
            }
        }
    }

     public void GenerateCard(int cardTotal)
    {
        for(int i = 0; i < cardTotal; i++)
        {
            GameObject _card = Instantiate(cardPrefab,cardContainer.transform.position,Quaternion.identity);
            _card.transform.SetParent(cardContainer.transform);
            _card.transform.localScale = new Vector3(1, 1, 1);
            _card.name = ("Card " + (i + 1));
        }

        SetCardObject();
    }

    public void SetCardObject()
    {
        List<GameObject> cardRandomList = new List<GameObject>();
        foreach(Card child in cardContainer.transform.GetComponentsInChildren<Card>())
        {
            currentCardList.Add(child);
            cardRandomList.Add(child.gameObject);
        }
    
        List<Sprite> remainingSprites = new List<Sprite>(imagesObject);
        for (int i = 0; i < currentCardList.Count; i++)
        {
            if (cardRandomList.Count == 0)
            {
                break;
            }

            int randomSpriteNum = Random.Range(0, remainingSprites.Count);
            
            for (int j = 0; j < 2; j++)
            {
                int randomCardNum = Random.Range(0, cardRandomList.Count);
                
                cardRandomList[randomCardNum].GetComponent<Card>().SetCardObject(remainingSprites[randomSpriteNum],i);
                cardRandomList.RemoveAt(randomCardNum);
            }
            remainingSprites.RemoveAt(randomSpriteNum);
        }
    }
    
    public void GetCard(Card selectedCard)
    {
        if(!card_First)
        {
            GetFirstCard(selectedCard);
        }
        else
        {
            GetSecondCard(selectedCard);
        }
    }
    private void GetFirstCard(Card selectedCard)
    {
        card_First = selectedCard;
    }
    private void GetSecondCard(Card selectedCard)
    {
        card_Second = selectedCard;
    }

    public void EndGame()
    {
        isStart = false;
        timerRunning = false;
        //textFinalScore.text = "Score : " + score.ToString();
        //SaveScore(score,difficultMode);
        //finalScore.SetActive(true);
    }
}
