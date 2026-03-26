using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1_AI
{
    public abstract class FSMAgentState
    {
        protected FSMAgent agent;
        public FSMAgentState(FSMAgent agent)
        {
            this.agent = agent;
        }

        public virtual void Enter() { }
        public virtual void Update(GameTime gameTime) { }
        public virtual void Exit() { }
    }
}
