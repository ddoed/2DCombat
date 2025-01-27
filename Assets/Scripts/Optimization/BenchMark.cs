using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class BenchMark : MonoBehaviour
{
    [Range(0f, 10000000), SerializeField] float _iterations;

    private BenchMarkTest _benchMarckTest;

    private void Awake()
    {
        _benchMarckTest = GetComponent<BenchMarkTest>();
    }

    [ContextMenu("RunTest")]
    public void RunTest()
    {
        Stopwatch sw = Stopwatch.StartNew();
        sw.Start();

        for(int i=0;i<_iterations;i++)
        {
            _benchMarckTest.PerformBenchMarkTest();
        }
        sw.Stop();

        UnityEngine.Debug.Log(sw.ElapsedMilliseconds + "ms");
    }
}
