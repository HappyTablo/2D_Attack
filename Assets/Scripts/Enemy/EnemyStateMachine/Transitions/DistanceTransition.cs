using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceTransition : Transition
{
    [SerializeField] private float _distanceRange;
    [SerializeField] private float _rangeSpread;

    private void Start()
    {
        _distanceRange += Random.Range(-_rangeSpread, _rangeSpread);
    }
    private void Update()
    {
        if(Vector2.Distance(transform.position, Target.transform.position) < _distanceRange)
            NeedTransit = true;
    }
}
