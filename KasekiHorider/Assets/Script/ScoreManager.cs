using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager {
    private static int score = 0;
    private static readonly int SCORE_SIZE = 10;
    private static readonly string SCORE_KEY = "TakaraHorida.Score";
    private static List<int> scoreList = new List<int>();

    /// <summary>
    /// 現時点でもっとも高いスコアを表示します。
    /// </summary>
    public static int highScore {
        get {
            if(scoreList.Count == 0)
            {
                return score;
            }
            return Mathf.Max(score, scoreList[0]);
        }
    }

    public static void ResetScore(){
        score = 0;
    }

    public static void  IncrementScore (int point) {
        score += point;
    }

    public static int GetScore (){
        return score;
    }

    /// <summary>
    /// スコアを文字列へ。
    /// </summary>
    /// <returns></returns>
    public static string ScoreToString()
    {
        var str = new System.Text.StringBuilder();
        for(int i=0; i<SCORE_SIZE; i++)
        {
            str.AppendLine((i + 1) + "位: " + scoreList[i]);
        }
        return str.ToString();
    }

    private static string GenerateKey(int i)
    {
        return SCORE_KEY + "[" + i + "]";
    }

    /// <summary>
    /// デバッグ用にランダムな結果を設定します。
    /// </summary>
    public static void DebugRandom()
    {
        scoreList.Clear();
        for(int i=0; i<SCORE_SIZE; i++)
        {
            scoreList.Add(Random.Range(1, 10));
        }
        SortList();
    }

    /// <summary>
    /// スコアを読み込みます。
    /// </summary>
    public static void Load()
    {
        scoreList.Clear();
        for(int i=0; i<SCORE_SIZE; i++)
        {
            var data = PlayerPrefs.GetInt(GenerateKey(i), 0);
            scoreList.Add(data);
        }
        SortList();
    }

    /// <summary>
    /// 現在のスコアをランキングに追加します。
    /// </summary>
    public static void Save()
    {
        scoreList.Add(score);
        SortList();
        for (int i = 0; i < scoreList.Count; i++)
        {
            Debug.Log("Score " + i + " " + scoreList[i]);
        }
        while (scoreList.Count > SCORE_SIZE)
        {
            scoreList.RemoveAt(scoreList.Count - 1);
        }
        for(int i=0; i<scoreList.Count; i++)
        {
            var key = GenerateKey(i);
            PlayerPrefs.SetInt(key, scoreList[i]);
        }
        PlayerPrefs.Save();
    }

    private static void SortList()
    {
        scoreList.Sort();
        scoreList.Reverse();
    }
}
