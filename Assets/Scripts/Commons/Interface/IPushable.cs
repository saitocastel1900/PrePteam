using System;
using UnityEngine;

namespace Player
{
    public interface IPushable
    {
        public void Push(Action OnCallBack);
    }
}