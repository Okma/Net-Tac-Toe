using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Net_Tac_Toe {
    public partial class GameBoard : Form, Observer {
        private PieceType currentPlayer = PieceType.X;

        private enum GameState {
            InProgress,
            Finished
        }
        private GameState currentState = GameState.InProgress;

        public GameBoard() {
            InitializeComponent();
            InitializeBoardSquares();
        }

        // Initializes and creates label references for each board square.
        private void InitializeBoardSquares() {
            // Initialize and create GameLabels for each board cell.
            for(int i = 0; i < grid.RowCount; i++) {
                for(int j = 0; j < grid.ColumnCount; j++) {
                    grid.Controls.Add(new GameLabel(this), j, i);
                }
            }
        }

        private void CheckGameState() {
            for (int i = 0; i < grid.RowCount; i++) {
                for (int j = 0; j < grid.ColumnCount; j++) {
                    // Check if any piece isn't assigned.
                    GameLabel label = grid.GetControlFromPosition(j, i) as GameLabel;
                    if(label != null && !label.IsPieceAssigned()) {
                        currentState = GameState.InProgress;
                        return;
                    }
                }
            }

            // All pieces assigned, game is finished.
            currentState = GameState.Finished;
        }

        public void OnUpdate() {
            CheckGameState();


        }



        // OnClick delegation occurs when Subject is clicked on.
        public void OnClicked(object obj) {
            GameLabel label = obj as GameLabel;

            if(label != null) {
                // If the GameLabel isn't already assigned, assign the current player's PieceType.
                if (!label.IsPieceAssigned()) {
                    label.SetPieceType(currentPlayer);

                    // Advance CurrentPlayer to next player.
                    currentPlayer = currentPlayer == PieceType.X ? PieceType.O : PieceType.X;
                }
            }
        }
    }
}
