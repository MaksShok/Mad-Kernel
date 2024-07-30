using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

namespace GameInstall.Interfaces
{
    public interface ICoroutineRunner
    {
        public Coroutine StartCoroutine(IEnumerator coroutine);
    }
}