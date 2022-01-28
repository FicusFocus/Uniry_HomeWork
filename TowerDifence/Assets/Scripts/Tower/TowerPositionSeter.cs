using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPositionSeter : MonoBehaviour
{
    private Vector3 _lastPoint;
    private bool _isMoved = false;
    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
        _isMoved = true;
    }

    private void Update()
    {
        if (_isMoved)
            transform.position = new Vector2(_camera.ScreenToWorldPoint(Input.mousePosition).x, _camera.ScreenToWorldPoint(Input.mousePosition).y);
    }

    private void OnMouseDown()
    {
        _lastPoint = transform.position;
        _isMoved = false;
    }

    //private void OnMouseUp()
    //{
    //    var hitList = Physics2D.OverlapBoxAll(transform.position, transform.lossyScale, 180f);

    //    if (hitList.Length > 1)
    //        transform.position = _lastPoint;
        
    //    _isMoved = false;
    //}
}
