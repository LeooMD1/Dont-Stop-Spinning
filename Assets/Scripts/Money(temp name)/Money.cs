using UnityEngine;

public class Money : MonoBehaviour
{
    [Header("--------VARIABLES--------")]
    public static float money = 10;
    


    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoneyGenerator()
    {
        money = money + 1;
        print(money);
    }
}
