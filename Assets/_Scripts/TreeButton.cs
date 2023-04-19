using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using SuperPupSystems.Manager;
using SuperPupSystems.Helper;

public class TreeButton : MonoBehaviour
{
    public SO_Trees tree;
    private int cost;
    private float time;
    private int treeLevel;
    public Timer treeTimer;

    public Image treeImage;
    public TMP_Text costText;
    public TMP_Text levelText;
    public TMP_Text timeText;
    public Slider progressSlider;

    public void Start()
    {
        treeImage.sprite = tree.treeSprite;
        costText.text = "$" + tree.baseCost;
        levelText.text = treeLevel.ToString();
        treeLevel = 1;
        cost = tree.baseCost;
        time = tree.baseTime;
        timeText.text = "0:0" + time;
        SetMaxProgress();

        WalletManager.Instance.Earn(50);
    }

    public void TreeAction()
    {
        treeTimer.StartTimer(time, treeTimer.AutoRestart);
    }

    public void Buy()
    {
        if(WalletManager.Instance.ICanAfford(cost))
        {
            WalletManager.Instance.Pay(cost);
            treeLevel++;
            Debug.Log("Cost" + cost);
            Debug.Log("Coin" + WalletManager.Instance.Coin);
        }
    }

    public void Update()
    {
        levelText.text = treeLevel.ToString();
        timeText.text = "0:0" + (int)treeTimer.TimeLeft;
        SetProgress();
    }

    public void SetProgress()
    {
        progressSlider.value = time - treeTimer.TimeLeft;
    }
    
    public void SetMaxProgress()
    {
        progressSlider.maxValue = time;
        progressSlider.value = treeTimer.TimeLeft;
    }
}
