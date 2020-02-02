using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Navigation : MonoBehaviour
{
    // ------------------------------------------------------------------------
    // Variables
    // ------------------------------------------------------------------------
    public List<UIScreen> UIScreens;
    public GameObject MapParent;
    public GameObject LocationParent;
    public GameObject MapReturnButton;

    public Camera Camera;

    // this should be in its own class but i dont give a shit
    public float CameraZoomDuration;
    public float CameraZoomSpeed;
    private float _zoomiesLeft;
    private bool _zoomIn;
    private bool _zoomOut;
    private float _originalSize;
    private Vector3 _originalPos;
    private Vector3 _moveSpeed;
    float _activeSceneTime = 0.15f;
    Vector3 _graveStartingScale;
    Vector3 _graveStartingPOS;
    Vector3 _forestStartingScale;
    Vector3 _forestStartingPOS;
    
    [SerializeField]
    Transform _targetSpriteLocation;

    [SerializeField]
    GameObject _mapIconGrave;

    [SerializeField]
    GameObject _mapIconForest;
    
    float _targetSpriteSize = 1.75f;
    float _spriteMoveTime = 0.5f;
    Vector3 _targetSpriteScale;
    Transform _selectedSprite;
    

    private LocationSO ActiveLocation;

    // this bad, idc
    public GameObject GraveLocation;
    public GameObject CottageLocation;
    public GameObject ForestLocation;

    // ------------------------------------------------------------------------
    // Functions
    // ------------------------------------------------------------------------
    void Start () {
        _originalSize = Camera.orthographicSize;
        _originalPos = transform.position;
        _targetSpriteScale = new Vector3(_targetSpriteSize, _targetSpriteSize, _targetSpriteSize);

        _forestStartingScale = _mapIconForest.transform.localScale;
        _forestStartingPOS = _mapIconForest.transform.position;

        _graveStartingScale = _mapIconGrave.transform.localScale;
        _graveStartingPOS = _mapIconGrave.transform.position;
    }

    // ------------------------------------------------------------------------
    void Update () {
        if(_zoomIn) {
            Camera.orthographicSize -= CameraZoomSpeed * Time.deltaTime;
            _zoomiesLeft -= Time.deltaTime;
            Camera.transform.Translate(-_moveSpeed*Time.deltaTime);

            if(_zoomiesLeft <= _activeSceneTime)
                SetScenesActive();
            
            if(_zoomiesLeft <= 0.0f) {
                FinishCameraZoomIn();
            }
        } else if (_zoomOut) {
            Camera.orthographicSize += CameraZoomSpeed * Time.deltaTime;
            _zoomiesLeft -= Time.deltaTime;
            Camera.transform.Translate(_moveSpeed*Time.deltaTime);

            if(_zoomiesLeft <= 0.0f) {
                FinishCameraZoomOut();
            }
        }
    }

    // ------------------------------------------------------------------------
    public void StartCameraZoom () {
        _zoomiesLeft = CameraZoomDuration;
        _zoomIn = true;
    }

    // ------------------------------------------------------------------------
    private void FinishCameraZoomOut () {
        _zoomOut = false;
        Camera.orthographicSize = _originalSize;
        transform.position = _originalPos;
    }

    // ------------------------------------------------------------------------p
    private void FinishCameraZoomIn () {
        _zoomIn = false;
        _zoomOut = true;
        _zoomiesLeft = CameraZoomDuration;
        // zoom out
    }

    void SetScenesActive()
    {
        // activate location stuff
        //MapParent.SetActive(false);
        LocationParent.SetActive(true);
        MapReturnButton.SetActive(true);

        // i don't literally care that this is bad
        // scenes who? idk her
        switch(ActiveLocation.LocationType) {
            case LocationType.Grave :
                GraveLocation.SetActive(true);
                ForestLocation.SetActive(false);
                CottageLocation.SetActive(false);
                break;
            case LocationType.Forest : 
                GraveLocation.SetActive(false);
                ForestLocation.SetActive(true);
                CottageLocation.SetActive(false);
                break;
            case LocationType.Cottage : 
                GraveLocation.SetActive(false);
                ForestLocation.SetActive(false);
                CottageLocation.SetActive(true);
                break;
        }
        
        _selectedSprite.GetComponent<MapIcon>().m_MaskFade.ScaleMask();

    }

    // ------------------------------------------------------------------------
    public void OpenMap () {
        MapParent.SetActive(true);
        LocationParent.SetActive(false);
        MapReturnButton.SetActive(false);
        ResetMap();
    }

    // ------------------------------------------------------------------------
    public void OpenLocation (LocationSO locationSO, Transform target) {
        Vector3 targetDistance = transform.position - target.position;
        _moveSpeed = targetDistance / CameraZoomDuration;
        _moveSpeed.z = 0;
        ActiveLocation = locationSO;
        //StartCameraZoom();
        _selectedSprite = target;
        Debug.Log(_selectedSprite);
        ScaleAndMoveLocation();
        DisableMapIcons();
    }

    void ScaleAndMoveLocation()
    {
        _selectedSprite.DOMove(_targetSpriteLocation.position, _spriteMoveTime);
        _selectedSprite.DOScale(_targetSpriteSize, _spriteMoveTime).OnComplete(()=>SetScenesActive());
        
    }

    void DisableMapIcons()
    {
        if (_selectedSprite.name.Contains("Forest"))
        {
            _mapIconGrave.gameObject.SetActive(false);
        }
        else
        {
            _mapIconForest.gameObject.SetActive(false);
        }
    }
    
    

    void ResetMap()
    {
        _mapIconForest.SetActive(true);
        _mapIconGrave.SetActive(true);
        
        _mapIconForest.GetComponent<MapIcon>().m_MaskFade.ResetMask();
        _mapIconGrave.GetComponent<MapIcon>().m_MaskFade.ResetMask();

        _mapIconForest.transform.position = _forestStartingPOS;
        _mapIconForest.transform.localScale = _forestStartingScale;

        _mapIconGrave.transform.position = _graveStartingPOS;
        _mapIconGrave.transform.localScale = _graveStartingScale;


    }
}