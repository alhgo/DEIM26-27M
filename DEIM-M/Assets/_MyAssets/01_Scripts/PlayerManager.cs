using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] int ciclos = 200;

    [SerializeField] float limits = 10f;

    float moveX;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartGame();

    }
    // Update is called once per frame
    void Update()
    {
        moveX = Input.GetAxis("Horizontal");
        //CheckPosition(5);
        bool estoyEnElLiminte = CheckPosition(limits);
        if (estoyEnElLiminte == true)
        {
            MovePlayer();
        }
    }

    void StartGame()
    {
        int n = 0;
        while (n < 10)
        {
            n++;
            //print(n);
        }

        for (int i = 0; i < ciclos; i++)
        {
            print(i);
        }
    }



    bool CheckPosition(float myLimit)
    {
        bool inLimit;

        float posX = transform.position.x;
        //print(posX);

        if (posX > myLimit && moveX > 0)
        {
            transform.position = new Vector3(myLimit, 0, 0);
            inLimit = false;
        }
        else if (posX < -myLimit && moveX < 0)
        {
            transform.position = new Vector3(-myLimit, 0, 0);
            inLimit = false;
        }
        else
        {
            //(posX);
            inLimit = true;
        }

        return inLimit;
        
    }

    void MovePlayer()
    {

    }
}
