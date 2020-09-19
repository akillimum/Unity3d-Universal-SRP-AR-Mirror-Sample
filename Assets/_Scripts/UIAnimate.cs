using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UB;
using AkilliMum.SRP.Mirror;

public class UIAnimate : ExecuteOnMainThread {

    public float StartScale = 1;
    public float EndScale = 1.5f;
    public float MillisecondsToRun = 50;

    RectTransform _rectT;
    int _multiplier = 1;

	// Use this for initialization
	void Start () {
        _rectT = gameObject.GetComponent<RectTransform>();
        if(EndScale>StartScale)
        {
            _multiplier = 1;
        }
        else
        {
            _multiplier = -1;
        }
        Execute(Animate,"",MillisecondsToRun,false);
	}
	

    void Animate(){
        if (gameObject.activeSelf)
        {
            var add = MillisecondsToRun / 1000.0f * (EndScale - StartScale) * _multiplier;
            _rectT.localScale = new Vector3(
                _rectT.localScale.x + add,
                _rectT.localScale.y + add,
                _rectT.localScale.z);
            if (_rectT.localScale.x > EndScale || _rectT.localScale.x < StartScale)
            {
                _multiplier = -_multiplier;
            }
        }

        Execute(Animate, "", MillisecondsToRun, false); //run again
    }
}
