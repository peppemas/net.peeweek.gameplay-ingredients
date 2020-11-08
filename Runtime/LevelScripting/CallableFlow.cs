using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameplayIngredients
{
    public class CallableFlow : MonoBehaviour
    {
        [SerializeField]
        private List<Callable> callables = new List<Callable>();


        public void AddCallable<T>() where T:Callable
        {
            var callable = gameObject.AddComponent<T>();
            Callable.SetAsFlowComponent(callable, true);
        }


        private void OnDestroy()
        {
            if (callables == null)
                return;

            foreach(var callable in callables)
            {
                Destroy(callable);
            }
        }
    }
}
