using System.Collections;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public delegate void CastedFunction();
    float timeSec=0;
    bool repeat = false;
    CastedFunction func;

    public void StartTimer(float timeSec, bool repeat, CastedFunction func)
    {
        this.timeSec = timeSec;
        this.repeat = repeat;
        this.func = func;
        if (timeSec > 0 && this.isActiveAndEnabled)
            StartCoroutine(Corutine());
        else Destroy(this);
    }

    IEnumerator Corutine()
    {
        yield return new WaitForSeconds(timeSec);
        performFunction();
    }
    void performFunction()
    {
        func();
        if (isActiveAndEnabled && repeat)
        {
            StartCoroutine(Corutine());
        }
        else
        {
            StopAllCoroutines();
            Destroy(this);
        }
    }
}
