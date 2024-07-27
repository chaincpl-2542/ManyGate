using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CardBase : MonoBehaviour
{
    private GameManager gameManager;
    [SerializeField] private Image cardImage;
    [SerializeField] private GameObject cardClose;
    [SerializeField] private GameObject cardParent;
    private int cardIndex;
    private bool isOpen;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        StartCoroutine(ShowCard());
    }
    
    // Update is called once per frame
    void Update()
    {
        UpdateCondition();
    }

    public virtual void UpdateCondition()
    {
        if(isOpen)
        {
            cardClose.SetActive(false);
        }
        else
        {
            cardClose.SetActive(true);
        }
    }

    public virtual void OnClick()
    {
        if(!isOpen)
        {
            //gameManager.GetCard(this);
            isOpen = true;
        }
    }

    public void SetCardObject(Sprite _object, int _index)
    {
        cardImage.sprite = _object;
        cardIndex = _index;
    }
    public void CardReset()
    {
        StartCoroutine(DelayReset());
    }

    IEnumerator DelayReset()
    {
        yield return new WaitForSeconds(0.5f);
        isOpen = false;
    }

    public void HideCard()
    {
        StartCoroutine(DelayHide());
    }
    IEnumerator DelayHide()
    {
        yield return new WaitForSeconds(0.5f);
        cardParent.SetActive(false);
        
    }

    IEnumerator ShowCard()
    {
        yield return new WaitForSeconds(3);
        //yield return new WaitForSeconds(gameManager.delayStartTime);
        isOpen = false;
    }
}
