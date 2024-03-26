using Cinemachine;
using UnityEngine;
using UnityEngine.UI;

public class CammeraMove : SingletonMonoBehaviour<CammeraMove>
{
    [SerializeField] private Camera cam;
    [SerializeField] private Vector3 ceterGame;

    [SerializeField] private Transform camlookat;
    [SerializeField] private CinemachineVirtualCamera virturalcam;
    //-----------Zomcam//
    public Slider slider;
    //MoveCam--------------//
    private Vector3 StartTouch;
    public bool canMoveCam = true;
    public static CammeraMove intances;
    //-----------------

    float scale => (Screen.height / (float)Screen.width) / (float)(1920 / (float)1080);
    private void Awake()
    {
        intances = this;
    }
    private void Start()
    {

        virturalcam.m_Lens.OrthographicSize = GameManager.Instance.sizeMap * scale;

        slider.onValueChanged.AddListener(OnSliderValueChanged);
        slider.value = 0;
        ceterGame = new Vector3(GameManager.Instance.sizeMap / 2, GameManager.Instance.sizeMap / 2, 0);//25,25,0
    }

    private void Update()
    {

        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            Zoom(Input.GetAxis("Mouse ScrollWheel"));
        }


        if (Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float currentMagnitude = (touchZero.position - touchOne.position).magnitude;

            float different = currentMagnitude - prevMagnitude;
            Zoom(different * 0.0005f);
        }

        //else if (Input.touchCount == 1)
        //{
        //    Debug.Log("MoveCam");
        if (Input.GetMouseButtonDown(0) && canMoveCam)
        {
            StartTouch = cam.ScreenToWorldPoint(Input.mousePosition);
        }

        if (Input.GetMouseButton(0) && canMoveCam)
        {
            Vector3 direction = StartTouch - cam.ScreenToWorldPoint(Input.mousePosition);
            //khi cam move theo thi directon tien toi vector0
            camlookat.transform.position = ClampCamera(camlookat.transform.position + direction);

        }
        if (Input.GetMouseButtonUp(0))
        {
            StartTouch = Vector3.zero;
        }

    }
    private void OnSliderValueChanged(float value)
    {
        virturalcam.m_Lens.OrthographicSize = Mathf.Lerp(GameManager.Instance.sizeMap * scale, 10, value);
        camlookat.transform.position = ClampCamera(camlookat.transform.position);
    }
    private Vector3 ClampCamera(Vector3 targerPosition)//truyen vao 1 vector3 va tra ve 1 vector3 hop ly voi Cammera
    {
        Vector3 vectorx;
        vectorx = new Vector3(targerPosition.x, targerPosition.y, targerPosition.z);
        float _camwidth = virturalcam.m_Lens.OrthographicSize * cam.aspect;
        //height

        //width
        float mixX = (ceterGame.x - GameManager.Instance.sizeMap * scale * cam.aspect) + _camwidth;
        float maxX = (ceterGame.x + GameManager.Instance.sizeMap * scale * cam.aspect) - _camwidth;

        float mixY = (ceterGame.y - GameManager.Instance.sizeMap * scale * cam.aspect) + _camwidth - 10 * (1 - slider.value);
        float maxY = (ceterGame.y + GameManager.Instance.sizeMap * scale * cam.aspect) - _camwidth - 10 * (1 - slider.value);



        float newX = Mathf.Clamp(vectorx.x, mixX, maxX);

        float newY = Mathf.Clamp(vectorx.y, mixY, maxY);

        return new Vector3(newX, newY, -10);
    }
    private void Zoom(float increment)
    {
        slider.value += increment;
        slider.value = Mathf.Clamp01(slider.value);
    }
    public void SetCamAtStart()
    {
        camlookat.transform.position = ClampCamera(camlookat.transform.position);
    }

}
