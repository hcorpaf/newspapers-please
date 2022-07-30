using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    public int maxLevelValue=10;
    int pressureLevel=0;
    int moneyLevel=5;
    int credibilityLevel=5;
    int elisaStrikes=0;
    bool lastLevelCompleted=false;

    public string verb;
    public GameObject verbObject;
    public List<string> verbList = new List<string>();
    //int[] verb;

    private void Start()
    {
        instance = this;
    }

    public void PublishNewsPaper(int _politics, int _money, int _true, int _elisaStrike)
    {
        pressureLevel += _politics;
        moneyLevel += _money;
        credibilityLevel += _true;
        elisaStrikes += _elisaStrike;
    }

    public void EditNewsPaper(string _verb,GameObject _verbObject)
    {
        verb = _verb;
        verbObject = _verbObject;
    }

    public void CompletedGame()
    {
        lastLevelCompleted=true;
    }
    
    // Gestionar finales en funcion de los valores de los niveles de las métricas
    public CriticalEndings(){
        if (moneyLevel <= 0){
            // Final por pérdida de dinero: quiebra del periódico
            if (allTrue) AllwaysTrueEnding(); // Despido con conciencia tranquila
            else LowMoneyEnding();
        } else if (credibilityLevel <= 0){
            // Final por pérdida de credibilidad: despido del periódico
            LowCredibilityEnding();
        } else if (pressureLevel >= maxLevelValue){
            // Final por ganancia de presión: Muerte misteriosa en un accidente y reemplazo en el periódico
            HighPressureEnding();
        }
    }

    // Gestionar finales en funcion de los valores de los niveles de las métricas
    public AlternativeEndings(){
        if (elisaStrikes >= 2){
            // Final Elisa es despedida: 2 noticias que perjudiquen a Elisa
            ElisaFiredEnding();
        } else if (lastLevelCompleted){
            // Final completando todos los niveles: vida mediocre en el periódico
            MediocreEnding();
        }
    }
}
