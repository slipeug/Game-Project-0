using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CursedIsland.Particles
{
    public class DirtParticleSystem : ParticleSystem
    {
        IParticleEmitter _emitter;

        public DirtParticleSystem(Game game, IParticleEmitter emitter) : base(game, 50)
        {
            _emitter = emitter;
        }

        public void LoadContent()
        {
            base.LoadContent();
        }

        protected override void InitializeConstants()
        {
            textureFilename = "spots";

            minNumParticles = 10;
            maxNumParticles = 15;

            blendState = BlendState.AlphaBlend;
            DrawOrder = AdditiveBlendDrawOrder;
        }

        protected override void InitializeParticle(ref Particle p, Vector2 where)
        {
            var velocity = _emitter.Velocity;
            var acceleration = - Vector2.UnitY * 10;
            var scale = RandomHelper.NextFloat(0.02f, 0.04f);
            var lifetime = RandomHelper.NextFloat(0.3f, 3.0f);
            var rotation = RandomHelper.NextFloat(1.0f, 3.0f);
            var angVel = RandomHelper.NextFloat(1.0f, 3.0f);
            p.Initialize(where, velocity, acceleration, Color.Bisque, scale: scale, lifetime: lifetime, rotation: rotation, angularVelocity: angVel);
        }

        public override void Update(GameTime gameTime)
        {


            base.Update(gameTime);
            if (_emitter.Velocity != new Vector2(0,0))
                AddParticles(_emitter.Position);
        }

    }
}
