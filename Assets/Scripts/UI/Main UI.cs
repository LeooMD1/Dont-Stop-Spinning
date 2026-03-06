using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainUI : MonoBehaviour
{
    public static float Money;
    
    #region Scene loaders
    public void CasinoLoad()
    {
        print("casinooo");
        SceneManager.LoadScene("CasinoArea");
    }

    public void WorkLoad()
    {
        print("workkk");
        SceneManager.LoadScene("JobArea");
    }

    public void HomeLoad()
    {
        print("Homeee"); 
        SceneManager.LoadScene("HomeArea");
    }
    #endregion

    #region Money Things

    public void DisplayMoney()
    {
        print(Money);
    }

    public void IncreaseMoney(float amt)
    {
        Money += amt;
    }

    public void DecreaseMoney(float amt)
    {
        Money -= amt;
    }

    #endregion
}
