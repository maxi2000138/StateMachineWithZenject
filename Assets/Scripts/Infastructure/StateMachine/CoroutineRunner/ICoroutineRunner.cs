using System.Collections;
using UnityEngine;

namespace Infastructure.StateMachine.CoroutineRunner
{
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator routine);
    }
}