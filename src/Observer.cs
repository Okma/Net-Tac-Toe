using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net_Tac_Toe {
    // Observer interface.
    //  Contains abstract method OnUpdate to be called whenever a Subject updates.
    public interface Observer {
        void OnUpdate();
        void OnClicked(object obj);
    }

    // Subject interface.
    //  Maintains list of observers that may be added or removed. Notifies all observers when changed.
    public interface Subject {
        void AddObserver(Observer o);
        void RemoveObserver(Observer o);
        void NotifyOnChanged();
    }
}
