﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SYHX.Cards;

public class DungeonUI : MonoBehaviour
{
    public GameObject DeckInformationUI;
    public Text HpCount;
    public Text FloorCount;
    public Text DataChipCount;
    public Text ScoreCount;
    public Text NextRewardScoreCount;

    public Image Avatar;

    public Slider HpSlider;

    // Start is called before the first frame update
    void Start()
    {
        RefreshUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RefreshUI()
    {
        HpCount.text = CharacterInDungeon.Ins.currentHp + " / " + CharacterInDungeon.Ins.maxHp;
        HpSlider.maxValue = CharacterInDungeon.Ins.maxHp;
        HpSlider.value = CharacterInDungeon.Ins.currentHp;
        FloorCount.text = "Area " + DungeonManager.Ins.Floor;
        DataChipCount.text = DungeonManager.Ins.dataChip.count + "";
        ScoreCount.text = DungeonManager.Ins.score + "";
        NextRewardScoreCount.text = "距下级奖励："+"";
    }

    public void OnDeckBtnClick()
    {
        DungeonManager.Ins.Disable();
        GameObject go = Instantiate(DeckInformationUI,transform.parent);
        go.GetComponent<DeckInformationUI>().LoadDeckInfomation(CharacterInDungeon.Ins.Deck,true);
    }
}
