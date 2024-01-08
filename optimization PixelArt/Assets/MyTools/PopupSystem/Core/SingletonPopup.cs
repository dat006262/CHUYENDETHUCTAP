//using System.Collections.Generic;
//using UnityEngine;

//namespace PopupSystem
//{
//    /// <summary>
//    /// Singleton pattern.
//    /// </summary>
//    public class SingletonPopup<T> : BasePopup where T : BasePopup
//    {
//        protected static T instance;

//        /// <summary>
//        /// Singleton using for Popup Group only!
//        /// </summary>
//        /// <value>The instance.</value>
//        public static T Instance
//        {
//            get
//            {
//                if (instance == null)
//                {
//                    instance = FindObjectOfType<T>();
//                    if (instance == null) instance = PopupManager.Instance.CheckInstancePopupPrebab<T>();
//                }

//                return instance;
//            }
//        }

//        public override void Awake()
//        {
//            base.Awake();
//        }
//    }

//}