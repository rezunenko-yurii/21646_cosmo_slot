using SlotsGame.Scripts.CellsLib;
using SlotsGame.Scripts.ChipsLib;
using SlotsGame.Scripts.ReelsLib;
using SlotsGame.Scripts.Slot;
using UnityEngine;
using Zenject;

namespace SlotsGame.Scripts.BoardLib
{
    public class BoardContainer: MonoBehaviour
    {
        [Inject]private Config _config;
        [Inject]private Reel[] _reels;
        
        private Chip[,] _chips;
        private Cell[,] _cells;
        
        private void FillCells()
        {
            _cells = new Cell[_config.gridSize.x, _config.gridSize.y];
            for (int i = 0; i < _reels.Length; i++)
            {
                for (int j = 0; j < _reels[i].mainSector.cells.Length; j++)
                {
                    _cells[j, i] = _reels[i].mainSector.cells[j];
                }
            }
        }
    }
}