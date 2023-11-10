using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace CursedIsland.Level
{


    public class Crystal3D
    {
        private VertexBuffer vertexBuffer;
        private IndexBuffer indices;
        private BasicEffect effect;
        private Vector2 position;


        public Crystal3D(GraphicsDevice graphicsDevice, Vector2 position)
        {
            this.position = position;

            var vertexData = new VertexPositionColor[]
            {
                new VertexPositionColor(new Vector3(0, 0.5f, 0), Color.Red),

                new VertexPositionColor(new Vector3(0, 0, 0.25f), Color.IndianRed),
                new VertexPositionColor(new Vector3(-0.25f, 0, 0), Color.DarkRed ),
                new VertexPositionColor(new Vector3(0, 0, -0.25f), Color.IndianRed),
                new VertexPositionColor(new Vector3(0.25f, 0, 0), Color.DarkRed),

                new VertexPositionColor(new Vector3(0, -0.5f, 0), Color.Red),
            };

            // Create a vertex buffer
            vertexBuffer = new VertexBuffer(graphicsDevice, typeof(VertexPositionColor), vertexData.Length, BufferUsage.None);
            vertexBuffer.SetData(vertexData);

            var indexData = new short[]
            {
                0, 1, 2,
                0, 2, 3,
                0, 3, 4,
                0, 4, 1,

                5, 2, 1,
                5, 3, 2,
                5, 4, 3,
                5, 1, 4
            };

            indices = new IndexBuffer(
                graphicsDevice,            // The graphics device to use
                IndexElementSize.SixteenBits,   // The size of the index 
                36,                             // The count of the indices
                BufferUsage.None                // How the buffer will be used
            );
            indices.SetData<short>(indexData);

            // Create a basic effect for rendering
            effect = new BasicEffect(graphicsDevice)
            {
                VertexColorEnabled = true,
                Projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45f), graphicsDevice.Viewport.AspectRatio, 0.1f, 100f),
                View = Matrix.CreateLookAt(new Vector3(5, 0, 0), Vector3.Zero, Vector3.Up),
                World = Matrix.Identity
            };
        }

        /// <summary>
        /// Updates the Cube
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime)
        {
            float angle = (float)gameTime.TotalGameTime.TotalSeconds;
            // Look at the cube from farther away while spinning around it
            effect.View = Matrix.CreateRotationY(angle) * Matrix.CreateTranslation(new Vector3(position, 0)) * Matrix.CreateLookAt(
                new Vector3(0, 1, -10),
                Vector3.Zero,
                Vector3.Up
            );
        }

        public void Draw(GraphicsDevice graphicsDevice)
        {
            GraphicsDevice oldState = graphicsDevice;


            graphicsDevice.SetVertexBuffer(vertexBuffer);
            // set the index buffer
            graphicsDevice.Indices = indices;

            effect.CurrentTechnique.Passes[0].Apply();
            // Draw the triangles
            graphicsDevice.DrawIndexedPrimitives(
                PrimitiveType.TriangleList, // Tye type to draw
                0,                          // The first vertex to use
                0,                          // The first index to use
                8                           // the number of triangles to draw
            );

            graphicsDevice = oldState;
        }
    }

}
