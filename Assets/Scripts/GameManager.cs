using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject[] postLevel;
    [SerializeField] GameObject[] duringLevel;




    private void Start()
    {
        EnablePostLevel(false);
       // duringLevel[2].gameObject.SetActive(false);
    }

    public void EnablePostLevel(bool enabled)
    {

        for (int i = 0; i < postLevel.Length; i++)
        {
            postLevel[i].gameObject.SetActive(enabled);

        }
        EnableDuringLevel(!enabled);
    }

    public void EnableDuringLevel(bool enabled)
    {
        for(int i = 0;i < duringLevel.Length; i++)
        {
            duringLevel[i].gameObject.SetActive(enabled);
        }
    }
}

