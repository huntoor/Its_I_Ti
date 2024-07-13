using UnityEngine;

public class Shop : MonoBehaviour
{
    [Space]
    [Header("Interaction Area")]
    [SerializeField] private GameObject interactArea;
    [SerializeField] private GameObject shopPanel;

    [Space]
    [Header("Next Scene")]
    [SerializeField] private string nextSceneName;

    [Space]
    [Header("Skill Cost")]
    [SerializeField] private int doubleJumpCost;
    [SerializeField] private int fireBallCost;
    [SerializeField] private int swingCost;
    [SerializeField] private int swordBuffCost;

    private AudioSource myAudioSource;

    private bool playerEntered;
    private playerPlaceHolderScript player;


    private void Awake()
    {
        myAudioSource = GetComponent<AudioSource>();

        //playerPlaceHolderScript.interactPressed += OpenMenu;
        PlayerMovement.interactPressed += OpenMenu;
    }

    private void Start()
    {
        playerEntered = false;
    }

    private void OnTriggerEnter2D(Collider2D body)
    {
        if (body.CompareTag("Player"))
        {
            interactArea.SetActive(true);

            playerEntered = true;

            player = body.GetComponent<playerPlaceHolderScript>();
        }
    }

    private void OnTriggerExit2D(Collider2D body)
    {
        if (body.CompareTag("Player"))
        {
            interactArea.SetActive(false);

            shopPanel.SetActive(false);

            playerEntered = false;

            player = null;
        }
    }

    private void OpenMenu()
    {
        if (playerEntered)
        {
            if (!shopPanel.activeInHierarchy)
            {
                myAudioSource.Play();
            }

            shopPanel.SetActive(true);

        }
    }

    public void OnDoubleJumpUnlocked()
    {
        Debug.Log("Unlock Double Jump");
        if (player != null)
        {
            // playerPlaceHolderScript.BuyItem(Items.ItemType.DoubleJump);
            if (player.CanBurchase(doubleJumpCost))
            {
                
            }

        }
    }

    public void OnFireBallUnlocked()
    {
        Debug.Log("Unlock FireBall");
        //playerPlaceHolderScript.BuyItem(Items.ItemType.FireBall);
    }
    public void OnSwingUnlocked()
    {
        Debug.Log("Unlock Swing");
        //playerPlaceHolderScript.BuyItem(Items.ItemType.Swing);
    }
    public void OnSowrdBuff()
    {
        Debug.Log("Unlock Sowrd Buff");
        //playerPlaceHolderScript.BuyItem(Items.ItemType.SowrdBuff);
    }
    public void ExitShop()
    {
        shopPanel.SetActive(false);
    }
    public void GoToNextLevel()
    {
        Debug.Log("Go to Next Scene " + nextSceneName);
        // SceneManager.LoadScene(nextSceneName);
    }
}
