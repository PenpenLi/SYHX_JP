﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleInfoManager : Assitant<BattleManager>
{
    public BattleInfoManager(BattleManager bm) : base(bm) { }
    //每回合抽卡数量
    private int drawCountPerTurn = 5;
    public int DrawCountPerTurn => drawCountPerTurn;
    //回合数计数器
    public int TurnCount { get; set; }
    //能量值计数器
    public int currentEP { get; private set; }
    public int maxEP { get; private set; }
    public int moreEP { get; private set; }
    public CardType currentType { get; private set; }
    public int cardConnectionCount { get; private set; }

    public void AddTurn()
    {
        TurnCount++;
    }
    /// <summary>
    /// 回复能量值的方法
    /// </summary>
    public void EnergyPointRegain()
    {
        //当前能量=上限
        currentEP = maxEP;

        //若有额外恢复值，再继续添加
        if (moreEP > 0)
        {
            currentEP += moreEP;
            moreEP = 0;
        }
    }

    public void ChangeEnergy(int ep)
    {
        currentEP += ep;
    }
    /// <summary>
    /// 在下一回合回复额外能量值的方法
    /// </summary>
    /// <param name="count"></param>
    public void RegainMoreEnergyPointNextTurn(int count)
    {
        moreEP = count;
    }
    public void CalculateConnection(CardType type, int count)
    {
        if (type == CardType.连接技)
        {
            this.cardConnectionCount += count;
            return;
        }
        currentType = type;
        cardConnectionCount = currentType == type ? cardConnectionCount + count : 0;
    }
    public void ResetCardType()
    {
        currentType = CardType.连接技;
    }

    public void ResetConnection()
    {
        cardConnectionCount = 0;
    }


}
