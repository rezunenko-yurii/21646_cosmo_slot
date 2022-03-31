using System.Collections.Generic;
using SlotsGame.Scripts.Animation;
using SlotsGame.Scripts.CellsLib;
using SlotsGame.Scripts.Slot;
using UnityEngine;
using Zenject;

namespace SlotsGame.Scripts.ReelsLib
{
    public class Reels : MonoBehaviour
    {
        [Inject] private Config _config;
        [Inject] private DiContainer _container;
        
        private RectTransform _parent;
        
        private Reel[] _reels;
        private ReelsBuilder _reelsBuilder;

        [Inject] private Cells _cells;
        
        public void Init(RectTransform parent)
        {
            _parent = parent;
            
            _reelsBuilder = new ReelsBuilder();
            _reelsBuilder.Build(_config.reelsBlueprint.reelPrefab, _config.gridSize.y, _parent, _container);
            _reels = _reelsBuilder.Reels();
            
            _cells.Init(Cells());
        }
        
        private Cell[,] Cells()
        {
            var cells = new Cell[_config.gridSize.x, _config.gridSize.y];
            
            for (int i = 0; i < _reels.Length; i++)
            {
                for (int j = 0; j < _reels[i].mainSector.cells.Length; j++)
                {
                    cells[j, i] = _reels[i].mainSector.cells[j];
                }
            }

            return cells;
        }

        public List<SlotAnimController> Controllers()
        {
            List<SlotAnimController> list = new List<SlotAnimController>();

            foreach (var reel in _reels)
            {
                list.Add(reel.controller);
            }

            return list;
        }

        public void Prepare()
        {
            _cells.Prepare();
        }

        public void Appear()
        {
            _cells.Appear();
        }

        public void ShowCombinations()
        {
            _cells.ShowCombinations();
        }
        
        public void HideCombinations()
        {
            _cells.HideCombinations();
        }
    }
}