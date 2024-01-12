using UnityEngine;

public class AppConfig : SingletonMonoBehaviour<AppConfig>
{
    #region Default Value
    [Header("PRICES")]
    public int liveRefillPrice = 900;
    [Header("CONFIG DEFAULT VALUE")]
    [Space(10)]
    public int initialInterAdLevel = 0;
    public int initialBannerAdLevel = 0;
    public int interFrequencyTime = 0;
    [SerializeField] private string _welcomeText = Const.KEY_WELCOM;
    public bool IsHyBridModel = true;
    public int BaseCoinValue;
    public string WelcomeText { get => _welcomeText; }

    private bool _isInterActive = false;
    public bool IsInterActive { get => _isInterActive; }
    [Header("Noti Event")]
    [Space(10)]
    [SerializeField] string _content;
    [SerializeField] int _idContent;
    [SerializeField] string _rewards;
    [SerializeField] string _times;
    public string Content { get => _content; }
    public int IdContent { get => _idContent; }
    public string Rewards { get => _rewards; }
    public string Times { get => _times; }
    #endregion

    #region Value Fetch
    [Header("VALUE IS FETCH")]
    [Space(10)]
    public int INITIAL_BANNER_AD_LEVEL = 0;
    public int INITIAL_INTER_AD_LEVEL = 0;
    public int INTER_FEQUENCY_TIME = 0;
    public string WELCOM_TEXT;
    public bool IS_INTER_ACTIVE;
    public bool IS_HYBRID_MODEL;
    public int BASE_COIN_VALUE;
    public string CONTENT;
    public int ID_CONTENT;
    public string REWARDS;
    public string TIMES;
    #endregion


    #region Unity Methods
    public override void Awake()
    {
        SetDefaultConfigValue();
    }

    private void Start()
    {

    }
    #endregion

    #region Private Methods
    public void SetDefaultConfigValue()
    {
        INITIAL_INTER_AD_LEVEL = initialInterAdLevel;

        INITIAL_BANNER_AD_LEVEL = initialBannerAdLevel;

        INTER_FEQUENCY_TIME = interFrequencyTime;

        //  WELCOM_TEXT = WelcomeText;

        IS_INTER_ACTIVE = _isInterActive;

        IS_HYBRID_MODEL = IsHyBridModel;

        this.BASE_COIN_VALUE = BaseCoinValue;

        //Event Noti
        this.ID_CONTENT = _idContent;
        this.CONTENT = _content;
        this.REWARDS = _rewards;
        this.TIMES = _times;
    }
    #endregion

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            ID_CONTENT = _idContent;
            //    PlayerData.Instance.IdEventCurrent = ID_CONTENT;
        }
    }
}

