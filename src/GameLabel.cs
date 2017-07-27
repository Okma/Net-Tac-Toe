using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Net_Tac_Toe {
    // Restrict label text based on which piece is in play.
    public enum PieceType {
        X,
        O
    }

    // GameLabel subclass of Label which will handle the visual representation of player moves.
    public class GameLabel : Label, Subject {
        private const float FONT_SIZE = 120.0f;
        private const string FONT_FAMILY = "Arial";

        // Has this label been assigned already?
        private bool bIsAssigned = false;
        private Observer observer;

        // PieceType constructor; assigns text based on given PieceType.
        public GameLabel(PieceType type) : this() {
            SetPieceType(type);
        }

        // Observer constructor.
        public GameLabel(Observer o) : this() {
            this.AddObserver(o);
        }

        // Default constructor for initializing display properties.
        public GameLabel() {
            this.Font = new Font(FONT_FAMILY, FONT_SIZE, FontStyle.Bold);
            this.AutoSize = false;
            this.TextAlign = ContentAlignment.MiddleCenter;
            this.Click += new EventHandler(OnClicked);
        }

        // Fires when a GameLabel is clicked on.
        private void OnClicked(object sender, EventArgs e) {
            if(observer != null) {
                observer.OnClicked(sender);
            } else {
                throw new NullReferenceException("Observer not initialized during click event!");
            }
        }

        // When parent changes, adjust bounds to parent's bounds.
        protected override void OnParentChanged(EventArgs e) {
            base.OnParentChanged(e);
            this.Height = this.Parent.Height;
            this.Width = this.Parent.Width;
        }

        public bool IsPieceAssigned() {
            return bIsAssigned;
        }

        // Assigns and renders label text bsaed on given PieceType.
        public void SetPieceType(PieceType type) {
            switch (type) {
                case PieceType.O:
                    this.Text = "O";
                    bIsAssigned = true;
                    break;
                case PieceType.X:
                    this.Text = "X";
                    bIsAssigned = true;
                    break;
                default:
                    this.Text = "";
                    break;
            }

            NotifyOnChanged();
        }

        // Assign internal Observer reference.
        public void AddObserver(Observer o) {
            observer = o;
        }

        // Clear internal Observer reference.
        public void RemoveObserver(Observer o) {
            observer = null;
        }

        // Inform Observer of a change.
        public void NotifyOnChanged() {
            if(observer != null) {
                observer.OnUpdate();
            } else {
                throw new NullReferenceException("Observer not initialized during notify!");
            }
        }
    }
}
