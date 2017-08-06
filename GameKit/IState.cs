using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;


namespace GameKit
{
    public interface IState : IUpdateable, IDrawable 
    {
        bool IsValidNextState();
        void Entering(int prevState);
        void Entered();
        void Exiting(int nextState);
        void Exited();
    }
}
