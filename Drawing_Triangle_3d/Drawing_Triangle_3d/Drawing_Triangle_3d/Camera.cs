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
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class Camera : Microsoft.Xna.Framework.GameComponent
    {
        public Camera(Game game, Vector3 pos, Vector3 target, Vector3 up)
            : base(game)
        {
            view = Matrix.CreateLookAt(pos, target, up);
            projection = Matrix.CreatePerspectiveFieldOfView(
            MathHelper.PiOver4,
            (float)Game.Window.ClientBounds.Width /
            (float)Game.Window.ClientBounds.Height,
            1, 100);
        }

        public Matrix view { get; protected set; }
        public Matrix projection { get; protected set; }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            // TODO: Add your initialization code here

            base.Initialize();
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            // TODO: Add your update code here

            base.Update(gameTime);
        }
    }
}
