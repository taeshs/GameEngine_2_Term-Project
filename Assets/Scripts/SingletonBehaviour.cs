using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Script
{
public class SingletonBehaviour<T> : MonoBehaviour where T : MonoBehaviour // 제너릭으로 만들기 위해 <>를 사용함
{
        private static T _instance; //명시적이지 않게 추상화 함

        public static T Instance // 최초로 생성된 인스턴스만 존재 , 접근자방법                            
        {
            // 싱글턴 인스턴스가 가지고 있는 필드와 프로퍼티는 기본적으로 public
            get
            {
                _instance = FindObjectOfType<T>(); // 오브젝트형(혹은 컴포넌트의 형)으로 검색해서 가장 처음 나타난 오브젝트를 반환한다.
                if (_instance == null)
                {
                    var go = new GameObject(typeof(T).Name); // nameof(T)에서 바꿔줌
                    _instance = go.AddComponent<T>();
                }
                return _instance;
            }
        }
    }

}
