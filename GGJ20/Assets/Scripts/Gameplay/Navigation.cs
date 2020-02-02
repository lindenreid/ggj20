using System.Collections.Generic;

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

    private LocationSO ActiveLocation;

    // this bad, idc
    public GameObject GraveLocation;
    public GameObject ForestLocation;

    // ------------------------------------------------------------------------
    // Functions
    // ------------------------------------------------------------------------
    void Start () {
        _originalSize = Camera.orthographicSize;
        _originalPos = transform.position;
    }

    // ------------------------------------------------------------------------
    void Update () {
        if(_zoomIn) {
            Camera.orthographicSize -= CameraZoomSpeed * Time.deltaTime;
            _zoomiesLeft -= Time.deltaTime;
            Camera.transform.Translate(-_moveSpeed*Time.deltaTime);

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

        // activate location stuff
        MapParent.SetActive(false);
        LocationParent.SetActive(true);
        MapReturnButton.SetActive(true);

        // i don't literally care that this is bad
        // scenes who? idk her
        switch(ActiveLocation.LocationType) {
            case LocationType.Grave :
                GraveLocation.SetActive(true);
                ForestLocation.SetActive(false);
                break;
            case LocationType.Forest : 
                GraveLocation.SetActive(false);
                ForestLocation.SetActive(true);
                break;
        }

        // zoom out
    }

    // ------------------------------------------------------------------------
    public void OpenMap () {
        MapParent.SetActive(true);
        LocationParent.SetActive(false);
        MapReturnButton.SetActive(false);
    }

    // ------------------------------------------------------------------------
    public void OpenLocation (LocationSO locationSO, Transform target) {
        Vector3 targetDistance = transform.position - target.position;
        _moveSpeed = targetDistance / CameraZoomDuration;
        _moveSpeed.z = 0;
        ActiveLocation = locationSO;
        StartCameraZoom();
    }
}