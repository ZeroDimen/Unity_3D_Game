using System;
using UnityEngine;
using Screen = UnityEngine.Device.Screen;

public class HPBarController : MonoBehaviour
{
    [SerializeField] private GameObject hpBarPrefab;
    
    private HpBar _hpBar;
    private Canvas _canvas;
    private Transform _hpBarRectTransform;
    private Camera _camera;
    private Vector3 _offset;

    private void Start()
    {
        _camera =  Camera.main;
        _canvas = GameManager.Instance.Canvas;
        _hpBar = Instantiate(hpBarPrefab, _canvas.transform).GetComponent<HpBar>();
        _hpBarRectTransform =  _hpBar.GetComponent<RectTransform>();
        _offset = new Vector3(0, 1.5f, 0);
    }

    public void SetHp(float hp)
    {
        _hpBar.SetHPGauge(hp);
    }

    public void LateUpdate()
    {
        var screenPostion = _camera.WorldToScreenPoint(transform.position + _offset);

        bool isVisible = screenPostion.z > 0
            && screenPostion.x > 0 && screenPostion.x < Screen.width
            && screenPostion.y > 0 && screenPostion.y < Screen.height;
        
        _hpBar.gameObject.SetActive(isVisible);

        if (isVisible)
        {
            _hpBarRectTransform.position = screenPostion;
        }
    }
}
