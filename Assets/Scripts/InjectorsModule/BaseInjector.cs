using System;
using System.Linq;
using System.Reflection;
using TypeReferences;
using UnityEngine;

namespace DefaultNamespace.InjectorsModule
{
    public class BaseInjector : MonoBehaviour
    {
        [SerializeField] private bool injectOnAwake = true;
        [SerializeField] [ClassImplements(typeof(IInjector))] private ClassTypeReference attributeTarget;
        [SerializeField] private ScriptableObject injectableObject;
        protected virtual void Awake()
        {
            if (injectOnAwake)
            {
                Inject();
            }
        }

        public void Inject()
        {
            var a = transform.GetComponentsInChildren<MonoBehaviour>();
            foreach (var aa in a)
            {
                var type = aa.GetType();
                
                InjectProperties(aa, type);
                InjectFields(aa, type);
                
            }
        }

        private void InjectProperties(object obj, Type type)
        {
            var properties = type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(prop => prop.IsDefined(attributeTarget.Type, true));
            
            foreach (var property in properties)
            {
                property.SetValue(obj,injectableObject);
            }
        }
        
        private void InjectFields(object obj, Type type)
        {
            var fields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(field => field.IsDefined(attributeTarget.Type, true));
            
            foreach (var field in fields)
            {
                field.SetValue(obj,injectableObject);
            }
        }
    }
}