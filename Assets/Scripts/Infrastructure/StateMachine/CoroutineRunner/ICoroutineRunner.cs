using System.Collections;
using UnityEngine;

namespace Infrastructure.StateMachine.CoroutineRunner
{
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator routine);
    }
}