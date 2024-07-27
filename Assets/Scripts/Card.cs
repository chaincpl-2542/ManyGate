using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : CardBase
{
    public override void OnClick()
    {
        base.OnClick();
        GameObject.Find("GameManager").GetComponent<SoundManager>().PlayCardSound();
    }
}
