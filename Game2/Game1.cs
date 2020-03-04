using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Game2
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //player stuff
        Texture2D playerText;
        Rectangle playerRect;

        bool isJumping = false;

        //Added for animation
        Rectangle animateRect;
        int animateCount = 0;
        int animateSpeed = 10;
        int animateNumPics = 3;
        Texture2D player1;
        Texture2D player2;
        Texture2D player3;
        Texture2D player4;
        Texture2D player5;
        Texture2D fplayer1;
        Texture2D fplayer2;
        Texture2D fplayer3;
        Texture2D fplayer4;
        Texture2D fplayer5;

        //enemy stuff
        Texture2D chef1Text;
        Rectangle chef1Rect;

        //enemy animation
        Texture2D animatechef1;
        Rectangle animateChef1Rect;
        int animateChef1Count = 0;
        int animateChef1Speed = 10;
        int animateChef1NumPics = 3;
        Texture2D chef1;
        Texture2D chef1a;

        //enemy 2 stuff
        Texture2D enemyText;
        Rectangle enemyRect;

        //enemy 2 animation
        Texture2D animateenemy;
        Rectangle animateenemyRect;
        int animateenemyCount = 0;
        int animateenemySpeed = 10;
        int animateenemyNumPics = 3;
        Texture2D enemy1;
        Texture2D enemy2;

        //platform stuff
        Texture2D floorText;
        Rectangle floorRect;
        Rectangle platform;

        Texture2D blockText;
        Rectangle blockRect;

        //variables
        int state = 0;
        int lives;
        int speed;
        int speedJ;
        int maxHeight;
        int jumpHeight;
        int gravSpeed;
        int enemyspeed;

        Rectangle[] blocks;

        //states
        Texture2D startText;
        Rectangle startRect;
        Texture2D winText;
        Rectangle winRect;
        Texture2D loseText;
        Rectangle loseRect;

        //Keyboard thing
        KeyboardState kb;
        KeyboardState oldKB;

        //hitboxes
        Texture2D BodyHit;
        Rectangle BodyRect;
        Texture2D feetRect;
        Rectangle feetfloor;

        SpriteFont test;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            //window
            this.graphics.PreferredBackBufferWidth = 1200;
            this.graphics.PreferredBackBufferHeight = 800;
            this.graphics.ApplyChanges();

            //states
            startRect = new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
            winRect = new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
            loseRect = new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
            
            //player stuff 
            playerRect = new Rectangle(0, 500, 50, 50);

            //animateRect = new Rectangle(100, 300, 24, 59);
            animateSpeed = 20;
            animateNumPics = 3;
            animateCount = 0;

            //enemy stuff 
            chef1Rect = new Rectangle(300, 450, 50, 75);
            animateChef1Count = 0;
            animateChef1Speed = 20;
            animateChef1NumPics = 3;

            //variables
            speed = 3;
            speedJ = 3;
            lives = 3;
            state = 1;
            maxHeight = 100;
            jumpHeight = maxHeight;
            gravSpeed = 4;
            enemyspeed = 3;

            //enemy 2 stuff
            enemyRect = new Rectangle(600, 450, 50, 75);
            animateenemyCount = 0;
            animateenemySpeed = 20;
            animateenemyNumPics = 3;

            //platform stuff
            floorRect = new Rectangle(000, 500, 1200, 350);
            platform = new Rectangle(000, 540, 1200, 350);

            blocks = new Rectangle[18];

            //Hitboxes
            
            //rightSide = new Rectangle(playerRect.X + 50, playerRect.Y, 3, playerRect.Height);
            //BodyRect = new Rectangle(playerRect.X, playerRect.Y, playerRect.Width, 3);

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

            test = Content.Load<SpriteFont>("File2");
            
            //state stuff
            startText = Content.Load<Texture2D>("Meme5");
            winText = Content.Load<Texture2D>("Meme4");
            loseText = Content.Load<Texture2D>("house-house");

            //player stuff
            
            player1 = Content.Load<Texture2D>("pizzasteve1");
            player2 = Content.Load<Texture2D>("pizzasteve2");
            player3 = Content.Load<Texture2D>("pizzasteve3");
            player4 = Content.Load<Texture2D>("pizzasteve4");
            player5 = Content.Load<Texture2D>("pizzasteve5");
            fplayer1 = Content.Load<Texture2D>("fpizzasteve1");
            fplayer2 = Content.Load<Texture2D>("fpizzasteve2");
            fplayer3 = Content.Load<Texture2D>("fpizzasteve3");
            fplayer4 = Content.Load<Texture2D>("fpizzasteve4");
            fplayer5 = Content.Load<Texture2D>("fpizzasteve5");

            playerText = player1;
            //hitbox
            BodyHit = Content.Load<Texture2D>("block");
            feetRect = Content.Load<Texture2D>("block");

            //enemy stuff 
            chef1 = Content.Load<Texture2D>("chef1");
            chef1a = Content.Load<Texture2D>("fchef1");

            chef1Text = chef1;

            //enemy 2 stuff
            enemy1 = Content.Load<Texture2D>("chef2");
            enemy2 = Content.Load<Texture2D>("fchef2");

            enemyText = enemy1;

            //platform stuff
            floorText = Content.Load<Texture2D>("Floor");
            blockText = Content.Load<Texture2D>("block");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (state == 1)
            {
                KeyboardState kb = Keyboard.GetState();
                if (kb.IsKeyDown(Keys.Space) && oldKB.IsKeyUp(Keys.Space))
                {
                    state = 2;
                }
            }
            if (state == 2)
            {
                makeWalls1();
                checkKeys();
                chef1movement();
                checkCollisions();
                checkLives();
                updatePlatform();
                updateWalls();
                wallCollisions();
            }
            if (state == 3)
            {
                makeWalls2();
                checkKeys();
                enemymovement();
                checkCollisions();
                checkLives();
                updatePlatform();
                updateWalls();
                wallCollisions();
                
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            if (state == 1)
            {
                spriteBatch.Draw(startText, startRect, Color.White);
            }
            if (state == 2)
            {
                spriteBatch.Draw(floorText, floorRect, Color.White);
                
                //walls
                spriteBatch.Draw(blockText, blocks[0], Color.White);
                spriteBatch.Draw(blockText, blocks[1], Color.White);
                spriteBatch.Draw(blockText, blocks[2], Color.White);
                spriteBatch.Draw(blockText, blocks[3], Color.White);
                spriteBatch.Draw(blockText, blocks[4], Color.White);
                spriteBatch.Draw(blockText, blocks[5], Color.White);
                spriteBatch.Draw(blockText, blocks[6], Color.White);
                spriteBatch.Draw(blockText, blocks[7], Color.White);
                spriteBatch.Draw(blockText, blocks[8], Color.White);
                spriteBatch.Draw(blockText, blocks[9], Color.White);

                //end walls
                spriteBatch.Draw(playerText, playerRect, Color.White);
                spriteBatch.Draw(feetRect, feetfloor, Color.White);
                spriteBatch.Draw(chef1Text, chef1Rect, Color.White);
            }
            if (state == 3)
            {
                spriteBatch.Draw(floorText, floorRect, Color.White);
                //walls
                spriteBatch.Draw(blockText, blocks[0], Color.White);
                spriteBatch.Draw(blockText, blocks[1], Color.White);
                spriteBatch.Draw(blockText, blocks[2], Color.White);
                spriteBatch.Draw(blockText, blocks[3], Color.White);
                spriteBatch.Draw(blockText, blocks[4], Color.White);
                spriteBatch.Draw(blockText, blocks[5], Color.White);
                spriteBatch.Draw(blockText, blocks[6], Color.White);
                spriteBatch.Draw(blockText, blocks[7], Color.White);
                spriteBatch.Draw(blockText, blocks[8], Color.White);
                spriteBatch.Draw(blockText, blocks[9], Color.White);
                spriteBatch.Draw(blockText, blocks[10], Color.White);
                spriteBatch.Draw(blockText, blocks[11], Color.White);
                spriteBatch.Draw(blockText, blocks[12], Color.White);
                spriteBatch.Draw(blockText, blocks[13], Color.White);
                spriteBatch.Draw(blockText, blocks[14], Color.White);
                spriteBatch.Draw(blockText, blocks[15], Color.White);
                spriteBatch.Draw(blockText, blocks[16], Color.White);
                spriteBatch.Draw(blockText, blocks[17], Color.White);

                spriteBatch.Draw(playerText, playerRect, Color.White);
                spriteBatch.Draw(enemyText, enemyRect, Color.White);
            }
            if (state == 4)
            {
                spriteBatch.Draw(winText, winRect, Color.White);
            }
            if (state == 5)
            {
                spriteBatch.Draw(loseText, loseRect, Color.White);
            }

            spriteBatch.DrawString(test, "" + jumpHeight + " " + state + " " + onWalls(), new Vector2(50, 50), Color.Red);
            spriteBatch.End();

            base.Draw(gameTime);
        }
        private void checkKeys()
        {
            //Game controls
            KeyboardState kb = Keyboard.GetState();
            if (kb.IsKeyDown(Keys.A))
            {
                playerRect.X -= 5;
                Lanimatecode();
            }

            if (kb.IsKeyDown(Keys.D))
            {
                playerRect.X += 5;
                Ranimatecode();
            }

        }
        private void Ranimatecode()
        {
            animateCount++;
            if (animateCount < animateSpeed)
            {
                playerText = player1;
            }
            else if (animateCount < animateSpeed * 1.2)
            {
                playerText = player3;
            }
            else if (animateCount < animateSpeed * 1.4)
            {
                playerText = player2;
            }
            else if (animateCount < animateSpeed * 1.6)
            {
                playerText = player3;
            }
            else if (animateCount < animateSpeed * 1.8)
            {
                playerText = player4;
            }
            else if (animateCount < animateSpeed * 2)
            {
                playerText = player5;
            }
            else if (animateCount < animateSpeed * 2.2)
            {
                playerText = player4;
            }
            else
            {
                animateCount = 0;
            }
        }
        private void Lanimatecode()
        {
            animateCount++;
            if (animateCount < animateSpeed)
            {
                playerText = fplayer1;
            }
            else if (animateCount < animateSpeed * 1.2)
            {
                playerText = fplayer3;
            }
            else if (animateCount < animateSpeed * 1.4)
            {
                playerText = fplayer2;
            }
            else if (animateCount < animateSpeed * 1.6)
            {
                playerText = fplayer3;
            }
            else if (animateCount < animateSpeed * 1.8)
            {
                playerText = fplayer4;
            }
            else if (animateCount < animateSpeed * 2)
            {
                playerText = fplayer5;
            }
            else if (animateCount < animateSpeed * 2.2)
            {
                playerText = fplayer4;
            }
            else
            {
                animateCount = 0;
            }
        }
        private void checkCollisions()
        {
            if (playerRect.Intersects(chef1Rect))
            {
                playerRect.Location = new Point(0, 500);
                lives -= 1;
            }
            if (playerRect.Intersects(enemyRect))
            {
                playerRect.Location = new Point(0, 500);
                lives -= 1;
            }
            if (playerRect.X > 1200 && state == 2)
            {
                playerRect.Location = new Point(0, 500);
                state = 3;
            }
            if (playerRect.X > 1200 && state == 3)
            {
                state = 4;
            }
        }
        private void chef1movement()
        {
            chef1Rect.X += speed;
            if (chef1Rect.X > 1050)
            {
                speed *= -1;
                chef1Text = chef1a;

            }
            if (chef1Rect.X < 300)
            {
                speed *= -1;
                chef1Text = chef1;
            }
        }
        private void enemymovement()
        {
            enemyRect.X += enemyspeed;
            if (enemyRect.X > 975)
            {
                enemyspeed *= -1;
                enemyText = enemy2;
            }
            if (enemyRect.X < 200)
            {
                enemyspeed *= -1;
                enemyText = enemy1;
            }
        }
        private void checkLives()
        {
            if (lives < 0)
            {
                state = 5;
            }
        }
        private void updatePlatform()
        {
            kb = Keyboard.GetState();
            if (onFloor() && kb.IsKeyDown(Keys.Space))
            {
                isJumping = true;
                jump();
            }
            if (!onFloor() && isJumping == false)
            {
                fall();
            }
            if (!onFloor() && isJumping == true)
            {
                jump();
            }
        }
        private void updateWalls()
        {
            kb = Keyboard.GetState();
            if (onWalls() && kb.IsKeyDown(Keys.Space))
            {
                isJumping = true;
                jump();
            }
            if (!onWalls() && isJumping == false)
            {
                fall();
            }
            if (!onWalls() && isJumping == true)
            {
                jump();
            }
        }
        private bool onFloor()
        {
            Rectangle testfloor = new Rectangle(playerRect.X + 10, playerRect.Y + playerRect.Height, playerRect.Width - 10, 3);
            
            if (testfloor.Intersects(platform))
            {
                isJumping = false;
                jumpHeight = maxHeight;
                playerRect.Y = platform.Y - playerRect.Height;
                return true;
            }
            return false;
        }
        private bool onWalls()
        {
            Rectangle feetfloor = new Rectangle(playerRect.X, playerRect.Y + 50, playerRect.Width - 10, 3);

            if (feetfloor.Intersects(blocks[0]))
            {
                isJumping = false;
                jumpHeight = maxHeight;
                playerRect.Y = blocks[0].Y - playerRect.Height;
                //playerRect.X = blocks[0].X - 50;
                return true;
            }
            if (feetfloor.Intersects(blocks[1]))
            {
                isJumping = false;
                jumpHeight = maxHeight;
                playerRect.Y = blocks[1].Y - playerRect.Height;
                return true;
            }
            if (feetfloor.Intersects(blocks[2]))
            {
                isJumping = false;
                jumpHeight = maxHeight;
                playerRect.Y = blocks[2].Y - playerRect.Height;
                return true;
            }
            if (feetfloor.Intersects(blocks[3]))
            {
                isJumping = false;
                jumpHeight = maxHeight;
                playerRect.Y = blocks[3].Y - playerRect.Height;
                return true;
            }
            if (feetfloor.Intersects(blocks[4]))
            {
                isJumping = false;
                jumpHeight = maxHeight;
                playerRect.Y = blocks[4].Y - playerRect.Height;
                return true;
            }
            if (feetfloor.Intersects(blocks[5]))
            {
                isJumping = false;
                jumpHeight = maxHeight;
                playerRect.Y = blocks[5].Y - playerRect.Height;
                return true;
            }
            if (feetfloor.Intersects(blocks[6]))
            {
                isJumping = false;
                jumpHeight = maxHeight;
                playerRect.Y = blocks[6].Y - playerRect.Height;
                return true;
            }
            if (feetfloor.Intersects(blocks[7]))
            {
                isJumping = false;
                jumpHeight = maxHeight;
                playerRect.Y = blocks[7].Y - playerRect.Height;
                return true;
            }
            if (feetfloor.Intersects(blocks[8]))
            {
                isJumping = false;
                jumpHeight = maxHeight;
                playerRect.Y = blocks[8].Y - playerRect.Height;
                return true;
            }
            if (feetfloor.Intersects(blocks[9]))
            {
                isJumping = false;
                jumpHeight = maxHeight;
                playerRect.Y = blocks[9].Y - playerRect.Height;
                return true;
            }
            if (feetfloor.Intersects(blocks[10]))
            {
                isJumping = false;
                jumpHeight = maxHeight;
                playerRect.Y = blocks[10].Y - playerRect.Height;
                return true;
            }
            if (feetfloor.Intersects(blocks[11]))
            {
                isJumping = false;
                jumpHeight = maxHeight;
                playerRect.Y = blocks[11].Y - playerRect.Height;
                return true;
            }
            if (feetfloor.Intersects(blocks[12]))
            {
                isJumping = false;
                jumpHeight = maxHeight;
                playerRect.Y = blocks[12].Y - playerRect.Height;
                return true;
            }
            if (feetfloor.Intersects(blocks[13]))
            {
                isJumping = false;
                jumpHeight = maxHeight;
                playerRect.Y = blocks[13].Y - playerRect.Height;
                return true;
            }
            if (feetfloor.Intersects(blocks[14]))
            {
                isJumping = false;
                jumpHeight = maxHeight;
                playerRect.Y = blocks[14].Y - playerRect.Height;
                return true;
            }
            if (feetfloor.Intersects(blocks[15]))
            {
                isJumping = false;
                jumpHeight = maxHeight;
                playerRect.Y = blocks[15].Y - playerRect.Height;
                return true;
            }
            if (feetfloor.Intersects(blocks[16]))
            {
                isJumping = false;
                jumpHeight = maxHeight;
                playerRect.Y = blocks[16].Y - playerRect.Height;
                return true;
            }
            if (feetfloor.Intersects(blocks[17]))
            {
                isJumping = false;
                jumpHeight = maxHeight;
                playerRect.Y = blocks[71].Y - playerRect.Height;
                return true;
            }
         
            return false;
        }
        private void fall()
        {
            playerRect.Y += gravSpeed;
        }
        private void jump()
        {
            if (jumpHeight > 0)
            {
                jumpHeight -= gravSpeed;
                playerRect.Y -= gravSpeed;
                isJumping = true;
            }
            else
            {
                isJumping = false;
            }
        }
        private void makeWalls1()
        {
            blocks[0] = new Rectangle(250, 500, 50, 50);
            blocks[1] = new Rectangle(250, 450, 50, 50);
            blocks[2] = new Rectangle(400, 400, 50, 50);
            blocks[3] = new Rectangle(500, 300, 50, 50);
            blocks[4] = new Rectangle(700, 300, 50, 50);
            blocks[5] = new Rectangle(900, 300, 50, 50);
            blocks[6] = new Rectangle(1100, 350, 50, 50);
            blocks[7] = new Rectangle(1100, 400, 50, 50);
            blocks[8] = new Rectangle(1100, 450, 50, 50);
            blocks[9] = new Rectangle(1100, 500, 50, 50); 
        }
        private void makeWalls2()
        {
            blocks[0] = new Rectangle(150, 500, 50, 50);
            blocks[1] = new Rectangle(150, 450, 50, 50);
            blocks[2] = new Rectangle(275, 350, 50, 50);
            blocks[3] = new Rectangle(325, 350, 50, 50);
            blocks[4] = new Rectangle(375, 350, 50, 50);
            blocks[5] = new Rectangle(525, 300, 50, 50);
            blocks[6] = new Rectangle(575, 300, 50, 50);
            blocks[7] = new Rectangle(625, 300, 50, 50);
            blocks[8] = new Rectangle(775, 350, 50, 50);
            blocks[9] = new Rectangle(825, 350, 50, 50);
            blocks[10] = new Rectangle(875, 350, 50, 50);
            blocks[11] = new Rectangle(1025, 300, 50, 50);
            blocks[12] = new Rectangle(1025, 350, 50, 50);
            blocks[13] = new Rectangle(1025, 400, 50, 50);
            blocks[14] = new Rectangle(1025, 450, 50, 50);
            blocks[15] = new Rectangle(1025, 500, 50, 50);
            blocks[16] = new Rectangle(575, 350, 50, 50);
            blocks[17] = new Rectangle(575, 400, 50, 50);
            
        }
        private void wallCollisions()
        {
            //Rectangle BodyRect = new Rectangle(playerRect.X, playerRect.Y , playerRect.Width, 3);
            BodyRect = new Rectangle(playerRect.X, playerRect.Y, playerRect.Width, playerRect.Height - 5);

            if (BodyRect.Intersects(blocks[0]))
            {
                isJumping = false;
                jumpHeight = 0;
                playerRect.X = blocks[0].Left - 50;

            }
            if (BodyRect.Intersects(blocks[1]))
            {
                isJumping = false;
                jumpHeight = 0;
                playerRect.X = blocks[1].Left - 50;
            }
            if (BodyRect.Intersects(blocks[2]))
            {
                isJumping = false;
                jumpHeight = 0;
                playerRect.X = blocks[2].Left - 50;
            }
            if (BodyRect.Intersects(blocks[3]))
            {
                isJumping = false;
                jumpHeight = 0;
                playerRect.X = blocks[3].Left - 50;
            }
            if (BodyRect.Intersects(blocks[4]))
            {
                isJumping = false;
                jumpHeight = 0;
                playerRect.X = blocks[4].Left - 50;
            }
            if (BodyRect.Intersects(blocks[5]))
            {
                isJumping = false;
                jumpHeight = 0;
                playerRect.X = blocks[5].Left - 50;
            }
            if (BodyRect.Intersects(blocks[6]))
            {
                isJumping = false;
                jumpHeight = 0;
                playerRect.X = blocks[6].Left - 50;
            }
            if (BodyRect.Intersects(blocks[7]))
            {
                isJumping = false;
                jumpHeight = 0;
                playerRect.X = blocks[7].Left - 50;
            }
            if (BodyRect.Intersects(blocks[8]))
            {
                isJumping = false;
                jumpHeight = 0;
                playerRect.X = blocks[8].Left - 50;
            }
            if (BodyRect.Intersects(blocks[9]))
            {
                isJumping = false;
                jumpHeight = 0;
                playerRect.X = blocks[9].Left - 50;
            }
            if (BodyRect.Intersects(blocks[10]))
            {
                isJumping = false;
                jumpHeight = 0;
                playerRect.X = blocks[10].Left - 50;
            }
            if (BodyRect.Intersects(blocks[11]))
            {
                isJumping = false;
                jumpHeight = 0;
                playerRect.X = blocks[11].Left - 50;
            }
            if (BodyRect.Intersects(blocks[12]))
            {
                isJumping = false;
                jumpHeight = 0;
                playerRect.X = blocks[12].Left - 50;
            }
            if (BodyRect.Intersects(blocks[13]))
            {
                isJumping = false;
                jumpHeight = 0;
                playerRect.X = blocks[13].Left - 50;
            }
            if (BodyRect.Intersects(blocks[14]))
            {
                isJumping = false;
                jumpHeight = 0;
                playerRect.X = blocks[14].Left - 50;
            }
            if (BodyRect.Intersects(blocks[15]))
            {
                isJumping = false;
                jumpHeight = 0;
                playerRect.X = blocks[15].Left - 50;
            }
            if (BodyRect.Intersects(blocks[16]))
            {
                isJumping = false;
                jumpHeight = 0;
                playerRect.X = blocks[16].Left - 50;
            }
            if (BodyRect.Intersects(blocks[17]))
            {
                isJumping = false;
                jumpHeight = 0;
                playerRect.X = blocks[17].Left - 50;
            }
        }
    }
}
