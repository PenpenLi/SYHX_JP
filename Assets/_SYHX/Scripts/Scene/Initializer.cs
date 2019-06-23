﻿using UnityEngine;
using System.Collections.Generic;
using SYHX.AbnormalStatus;
using SYHX.Cards;

public class Initializer : SingletonMonoBehaviour<Initializer>
{
    [SerializeField] public List<AbnormalStatusSource> asSource;
    [SerializeField] public List<CardSource> cSource;

    protected override void UnityAwake()
    {
        GameObject.DontDestroyOnLoad(this);
        foreach (var card in cSource)
        {
            card.Init();
        }
        foreach (var abnormal in asSource)
        {
            abnormal.Init();
        }
    }
}