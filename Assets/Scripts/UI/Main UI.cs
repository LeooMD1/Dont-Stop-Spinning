using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class MainUI : MonoBehaviour
{
    public static float Money;
    public static float Energy = 7;

    [SerializeField]
    private float sceneRNG;
    
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

    //choose if the player is going to do an in person job or an online job
    //as of now I am gong to make it random but this can change in the future if needed 
    public void JobChooser()
    {
        sceneRNG = Random.Range(0, 50);

        if (sceneRNG >= 25f)
            SceneManager.LoadScene("InPersonJob");
        else
            SceneManager.LoadScene("OnlineJob");
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
