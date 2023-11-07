using UnityEngine;

public class DistanceTransition : Transition
{
    [SerializeField] private float _distanceRange;
    [SerializeField] private float _rangeSpread;

    private void Start()
    {
        SetDistanceRange();
    }

    private void Update()
    {
        if(Target == null)
            return;
        if(Vector2.Distance(transform.position, Target.transform.position) < _distanceRange)
            NeedTransit = true;
    }

    private void SetDistanceRange() =>
        _distanceRange += Random.Range(-_rangeSpread, _rangeSpread);
}
