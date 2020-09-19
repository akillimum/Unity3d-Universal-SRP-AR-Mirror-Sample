using System.Collections;
using System.Collections.Generic;
using AkilliMum.SRP.Mirror;
using UB;
using UnityEngine;

public class EffectManager : MonoBehaviour {

    public GameObject Cam;
    private int _selectedShader = -1;
    private EffectBase[] _behaviours;

	// Use this for initialization
	void Start () {
        _behaviours = Cam.GetComponents<EffectBase>();
        foreach (var behaviour in _behaviours)
        {
            Debug.Log(behaviour.name);
        }
	}
	
    public void ChangeEffect()
    {
        _selectedShader++;
        if (_selectedShader > _behaviours.Length-1)
        {
            _selectedShader = -1;
        }
        foreach (var behavior in _behaviours)
        {
            behavior.enabled = false;
        }
        if(_selectedShader>-1)
        {
            _behaviours[_selectedShader].enabled = true;
        }

        Debug.Log(_behaviours[_selectedShader].name+ " enabled!");


    }
}

