using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildDlgScript : MonoBehaviour
{
    public enum ShowState { Type1, Type2, Type3, Type4 }

    private ShowState _CurrentShowState = ShowState.Type1;

    public GameObject BuildWindowSel1; 
    public GameObject BuildWindowSel2; 
    public GameObject BuildWindowSel3; 
    public GameObject BuildWindowSel4; 

    void Start ()
    {
        CheckReferences();
        SetBuildWindow(_CurrentShowState);
    }

    private void CheckReferences()
    {
        Debug.Assert(BuildWindowSel1 != null);
        Debug.Assert(BuildWindowSel2 != null);
        Debug.Assert(BuildWindowSel3 != null);
        Debug.Assert(BuildWindowSel4 != null);
    }

    public void SetActive(bool active)
    {
        gameObject.SetActive(active);
    }
	
    public void SetWindowAdministration()
    {
        SetBuildWindow(ShowState.Type1);
    }

    public void SetWindowProduction()
    {
        SetBuildWindow(ShowState.Type2);
    }

    public void SetWindowSupport()
    {
        SetBuildWindow(ShowState.Type3);
    }

    public void SetWindowOther()
    {
        SetBuildWindow(ShowState.Type4);
    }

    private void SetBuildWindow(ShowState NewShowState)
    {
        switch(NewShowState)
        {
            case ShowState.Type1:
                BuildWindowSel1.SetActive(true);
                BuildWindowSel2.SetActive(false);
                BuildWindowSel3.SetActive(false);
                BuildWindowSel4.SetActive(false);
                break;
            case ShowState.Type2:
                BuildWindowSel1.SetActive(false);
                BuildWindowSel2.SetActive(true);
                BuildWindowSel3.SetActive(false);
                BuildWindowSel4.SetActive(false);
                break;
            case ShowState.Type3:
                BuildWindowSel1.SetActive(false);
                BuildWindowSel2.SetActive(false);
                BuildWindowSel3.SetActive(true);
                BuildWindowSel4.SetActive(false);
                break;
            case ShowState.Type4:
                BuildWindowSel1.SetActive(false);
                BuildWindowSel2.SetActive(false);
                BuildWindowSel3.SetActive(false);
                BuildWindowSel4.SetActive(true);
                break;
        }

        _CurrentShowState = NewShowState;
    }
}
