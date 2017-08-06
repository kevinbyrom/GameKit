using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;


namespace GameKit
{
    public abstract class StateBase : IState
    {
        private int drawOrder;
        
        public int DrawOrder
        {
            get
            {
                return this.drawOrder;
            }
            set
            {
                if (value != this.drawOrder)
                {
                    this.drawOrder = value;
                    OnDrawOrderChanged();
                }
            }
        }


        private int updateOrder;

        public int UpdateOrder
        {
            get
            {
                return this.updateOrder;
            }
            set
            {
                if (value != this.updateOrder)
                {
                    this.updateOrder = value;
                    OnUpdateOrderChanged();
                }
            }
        }

        private bool enabled;

        public bool Enabled
        {
            get
            {
                return this.enabled;
            }
            set
            {
                if (value != this.enabled)
                {
                    this.enabled = value;
                    OnEnabledChanged();
                }
            }
        }


        private bool visible;

        public bool Visible
        {
            get
            {
                return this.visible;
            }
            set
            {
                if (value != this.visible)
                {
                    this.visible = value;
                    OnVisibleChanged();
                }
            }
        }
        
        public event EventHandler<EventArgs> DrawOrderChanged;
        public event EventHandler<EventArgs> VisibleChanged;
        public event EventHandler<EventArgs> EnabledChanged;
        public event EventHandler<EventArgs> UpdateOrderChanged;


        public abstract void Draw(GameTime gameTime);

        public abstract void Update(GameTime gameTime);


        public virtual bool IsValidNextState()
        {
            return true;
        }

        public virtual void Entering(int prevState)
        {

        }

        public virtual void Entered()
        {

        }

        public virtual void Exiting(int nextState)
        {

        }
        public virtual void Exited()
        {

        }

        #region Change Handlers

        protected virtual void OnDrawOrderChanged()
        {
            this.DrawOrderChanged?.Invoke(this, new EventArgs());
        }

        protected virtual void OnUpdateOrderChanged()
        {
            this.UpdateOrderChanged?.Invoke(this, new EventArgs());
        }

        protected virtual void OnEnabledChanged()
        {
            this.EnabledChanged?.Invoke(this, new EventArgs());
        }

        protected virtual void OnVisibleChanged()
        {
            this.VisibleChanged?.Invoke(this, new EventArgs());
        }

        #endregion

    }
}
