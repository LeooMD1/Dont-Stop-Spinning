using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainUI : MonoBehaviour
{
    public static float Money;
    
    #region Scene loaders
    
    //if Not in casino
    public void CasinoLoad()
    {
        print("casinooo");
        SceneManager.LoadScene("CasinoArea");
    }

    //if In Casino
    public void SlotMachineLoad()
    {
        SceneManager.LoadScene("SlotMachine");
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
