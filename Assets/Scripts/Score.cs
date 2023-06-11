using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    /*public static Score instance;

    private const string RANKING_KEY = "Ranking";
    private const int MAX_RANKING_COUNT = 10;

    private List<int> rankingList;

    private void Awake()
    {
        if (instance == null)
            instance = this;

        rankingList = new List<int>();
    }

    private void Start()
    {
        LoadRanking();
    }

    private void LoadRanking()
    {
        rankingList.Clear();

        if (PlayerPrefs.HasKey(RANKING_KEY))
        {
            string rankingData = PlayerPrefs.GetString(RANKING_KEY);
            string[] rankingArray = rankingData.Split(',');

            foreach (string rank in rankingArray)
            {
                int score = int.Parse(rank);
                rankingList.Add(score);
            }
        }
    }

    private void SaveRanking()
    {
        string rankingData = string.Join(",", rankingList.ToArray());
        PlayerPrefs.SetString(RANKING_KEY, rankingData);
        PlayerPrefs.Save();
    }

    public void UpdateRanking(int score)
    {
        rankingList.Add(score);
        rankingList.Sort();
        rankingList.Reverse();

        if (rankingList.Count > MAX_RANKING_COUNT)
            rankingList.RemoveAt(rankingList.Count - 1);

        SaveRanking();
    }

    public List<int> GetRankingList()
    {
        return rankingList;
    }*/
}
