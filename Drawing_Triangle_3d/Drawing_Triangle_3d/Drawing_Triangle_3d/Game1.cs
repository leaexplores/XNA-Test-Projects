using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Drawing_Triangle_3d
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Camera camera;
        BasicEffect effect;
        VertexBuffer vertexBuffer;

        VertexPositionColor[] vertices; // 3 Vertices pour 1 triangle.

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        private void createATriangle()
     
        {
            vertices = new VertexPositionColor[3];

            vertices[0].Position = new Vector3(-1f, -1f, 0f);
            vertices[0].Color = Color.Aqua;
            vertices[1].Position = new Vector3(0, 1f, 0f);
            vertices[1].Color = Color.Green;
            vertices[2].Position = new Vector3(1f, -1f, 0f);
            vertices[2].Color = Color.Tomato;

        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            createATriangle();

            camera = new Camera(this, new Vector3(0, 0, 5),Vector3.Zero, Vector3.Up);
            Components.Add(camera);

            // Set vertex data in VertexBuffer
            vertexBuffer = new VertexBuffer(GraphicsDevice, typeof(VertexPositionColor),
            vertices.Length, BufferUsage.None);
            vertexBuffer.SetData(vertices);

            // Initialize the BasicEffect
            effect = new BasicEffect(GraphicsDevice);

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            GraphicsDevice.SetVertexBuffer(vertexBuffer);

            //Set object and camera info
            effect.World = Matrix.Identity;
            effect.View = camera.view;
            effect.Projection = camera.projection;
            effect.VertexColorEnabled = true;

            // Begin effect and draw for each pass
            foreach (EffectPass pass in effect.CurrentTechnique.Passes)
            {
                pass.Apply();
                GraphicsDevice.DrawUserPrimitives<VertexPositionColor>
                (PrimitiveType.TriangleStrip, vertices, 0, 1);
            }
            base.Draw(gameTime);
        }
    }
}
