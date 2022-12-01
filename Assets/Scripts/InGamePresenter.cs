using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Gauge;
using Player;
using RipCurrent;
using UnityEngine;

namespace InGame
{
    public class InGamePresenter : MonoBehaviour
    {
        [SerializeField] private RipCurrentPresenter _ripCurrent;
        [SerializeField] private PlayerPresenter _player;
        [SerializeField] private GaugePresenter _gauge;

        private void Initialized()
        {
            _ripCurrent.Initialized();
            _player.Initialized();
        }

        private void Bind()
        {
            _ripCurrent.Bind();
            _player.Bind();
            _gauge.Bind();
        }

        private void SetEvents()
        {
            _gauge.SetEvent();
        }

        private void Start()
        {
            Initialized();
        }

        private void Update()
        {
            _player.ManualUpdate();
        }

        private void FixedUpdate()
        {
            _player.ManualFixedUpdate();
        }
    }
}