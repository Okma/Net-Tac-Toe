using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Net_Tac_Toe {
    public partial class GameBoard : Form {
        public GameBoard() {
            InitializeComponent();
            InitializeBoardSquares();
        }

        // Initializes and creates label references for each board square.
        private void InitializeBoardSquares() {
            // Initialize and create GameLabels for each board cell.
            for(int i = 0; i < tableLayoutPanel1.RowCount; i++) {
                for(int j = 0; j < tableLayoutPanel1.ColumnCount; j++) {
                    tableLayoutPanel1.Controls.Add(new GameLabel(PieceType.X), j, i);
                }
            }
        }
    }
}
