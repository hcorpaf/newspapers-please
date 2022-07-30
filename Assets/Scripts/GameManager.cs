using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    int politicsStat;
    int moneyStat;
    int trueStat;

    public string verb;
    public GameObject verbObject;
    public List<string> verbList = new List<string>();
    //int[] verb;

    private void Start()
    {
        instance = this;
    }

    public void PublishNewsPaper(int _politics, int _money, int _true)
    {
        politicsStat += _politics;
        moneyStat += _money;
        trueStat += _true;
    }

    public void EditNewsPaper(string _verb,GameObject _verbObject)
    {
        verb = _verb;
        verbObject = _verbObject;
    }

}
