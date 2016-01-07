using System;

using System.Linq;

using System.Drawing;
using IrrKlang;

namespace MedCitySim
{
    class CitizenMenu : GameObject
    {
        protected ISoundEngine engine;
        private Graphics dc;
        public CitizenMenu(string imagePath, Vector2D startPosition) : base(imagePath, startPosition)
        {

        }
        public override void Update(float currentFPS)
        {


            if (Keyboard.IsKeyPressed(System.Windows.Forms.Keys.P))
            {
                if (GameWorld.Food >= 1 && GameWorld.CitizenPop < GameWorld.CitizenCap && Church.priest == true)
                {
                    GameWorld.Food--;
                    GameWorld.CitizenPop++;
                    Church church = GameWorld.objs.OfType<Church>().FirstOrDefault();
                    if (church != null)
                    {
                        float spawnPointX = church.Position.X + 40;
                        float spawnPointY = church.Position.Y + 40;
                        GameWorld.ToAdd.Add(new Citizen(@"Sprites\Citizens\CitizenPriest.png", new Vector2D(spawnPointX, spawnPointY), "lars", true, Citizen.Assignment.priest));
                    }
                    GameWorld.ToRemove.Add(this);
                    GameWorld.ToAdd.Add(new Button(@"Sprites\Button.png", new Vector2D(999, 614)));
                }

                else
                {
                    CantRecruit();
                }

            }
            if (Keyboard.IsKeyPressed(System.Windows.Forms.Keys.F))
            {
                if (GameWorld.Food >= 1 && GameWorld.CitizenPop < GameWorld.CitizenCap && Farm.farmer == true)
                {
                    GameWorld.Food--;
                    GameWorld.CitizenPop++;
                    Farm farm = GameWorld.objs.OfType<Farm>().FirstOrDefault();
                    if (farm != null)
                    {
                        float spawnPointX = farm.Position.X + 40;
                        float spawnPointY = farm.Position.Y + 40;

                        GameWorld.ToAdd.Add(new Citizen(@"Sprites\Citizens\CitizenFarmer.png", new Vector2D(spawnPointX, spawnPointY), "lars", true, Citizen.Assignment.farmer));

                    }
                    GameWorld.ToRemove.Add(this);
                    GameWorld.ToAdd.Add(new Button(@"Sprites\Button.png", new Vector2D(999, 614)));
                }

                else
                {
                    CantRecruit();
                }
            }
            if (Keyboard.IsKeyPressed(System.Windows.Forms.Keys.O))
            {
                if (GameWorld.Food >= 1 && GameWorld.CitizenPop < GameWorld.CitizenCap && CivilWatch.soldier == true)
                {
                    GameWorld.Food--;
                    GameWorld.CitizenPop++;
                    CivilWatch civilWatch = GameWorld.objs.OfType<CivilWatch>().FirstOrDefault();
                    if (civilWatch != null)
                    {
                        float spawnPointX = civilWatch.Position.X + 40;
                        float spawnPointY = civilWatch.Position.Y + 40;

                        GameWorld.ToAdd.Add(new Citizen(@"Sprites\Citizens\CitizenSoldier.png", new Vector2D(spawnPointX, spawnPointY), "lars", true, Citizen.Assignment.soldier));

                    }

                    GameWorld.ToRemove.Add(this);
                    GameWorld.ToAdd.Add(new Button(@"Sprites\Button.png", new Vector2D(999, 614)));
                }

                else
                {
                    CantRecruit();
                }
            }
            if (Keyboard.IsKeyPressed(System.Windows.Forms.Keys.L))
            {
                if (GameWorld.Food >= 1 && GameWorld.CitizenPop < GameWorld.CitizenCap && Lumbermill.lumberjack == true)
                {
                    GameWorld.Food--;
                    GameWorld.CitizenPop++;
                    Lumbermill lumbermill = GameWorld.objs.OfType<Lumbermill>().FirstOrDefault();
                    if (lumbermill != null)
                    {
                        float spawnPointX = lumbermill.Position.X + 40;
                        float spawnPointY = lumbermill.Position.Y + 40;

                        GameWorld.ToAdd.Add(new Citizen(@"Sprites\Citizens\CitizenLumberjack.png", new Vector2D(spawnPointX, spawnPointY), "lars", true, Citizen.Assignment.lumberJack));

                    }
                    GameWorld.ToRemove.Add(this);
                    GameWorld.ToAdd.Add(new Button(@"Sprites\Button.png", new Vector2D(999, 614)));
                }

                else
                {
                    CantRecruit();
                }
            }
            if (Keyboard.IsKeyPressed(System.Windows.Forms.Keys.A))
            {
                if (GameWorld.Food >= 1 && GameWorld.CitizenPop < GameWorld.CitizenCap && Quarry.mason == true)
                {
                    GameWorld.Food--;
                    GameWorld.CitizenPop++;
                    Quarry quarry = GameWorld.objs.OfType<Quarry>().FirstOrDefault();
                    if (quarry != null)
                    {
                        float spawnPointX = quarry.Position.X + 40;
                        float spawnPointY = quarry.Position.Y + 40;

                        GameWorld.ToAdd.Add(new Citizen(@"Sprites\Citizens\CitizenMason.png", new Vector2D(spawnPointX, spawnPointY), "lars", true, Citizen.Assignment.mason));

                    }
                    GameWorld.ToRemove.Add(this);
                    GameWorld.ToAdd.Add(new Button(@"Sprites\Button.png", new Vector2D(999, 614)));
                }

                else
                {
                    CantRecruit();
                }
            }
            if (Keyboard.IsKeyPressed(System.Windows.Forms.Keys.S))
            {
                if (GameWorld.Food >= 1 && GameWorld.CitizenPop < GameWorld.CitizenCap && Blacksmith.blacksmith == true)
                {
                    GameWorld.Food--;
                    GameWorld.CitizenPop++;
                    Blacksmith blacksmith = GameWorld.objs.OfType<Blacksmith>().FirstOrDefault();
                    if (blacksmith != null)
                    {
                        float spawnPointX = blacksmith.Position.X + 40;
                        float spawnPointY = blacksmith.Position.Y + 40;

                        GameWorld.ToAdd.Add(new Citizen(@"Sprites\Citizens\CitizenSmith.png", new Vector2D(spawnPointX, spawnPointY), "lars", true, Citizen.Assignment.smith));

                    }
                    GameWorld.ToRemove.Add(this);
                    GameWorld.ToAdd.Add(new Button(@"Sprites\Button.png", new Vector2D(999, 614)));
                }

                else
                {
                    CantRecruit();
                }
            }
            if (Keyboard.IsKeyPressed(System.Windows.Forms.Keys.M))
            {
                if (GameWorld.Food >= 1 && GameWorld.CitizenPop < GameWorld.CitizenCap && Mine.miner == true)
                {
                    GameWorld.Food--;
                    GameWorld.CitizenPop++;
                    Mine mine = GameWorld.objs.OfType<Mine>().FirstOrDefault();
                    if (mine != null)
                    {
                        float spawnPointX = mine.Position.X + 40;
                        float spawnPointY = mine.Position.Y + 40;

                        GameWorld.ToAdd.Add(new Citizen(@"Sprites\Citizens\CitizenMiner.png", new Vector2D(spawnPointX, spawnPointY), "lars", true, Citizen.Assignment.miner));

                    }
                    GameWorld.ToRemove.Add(this);
                    GameWorld.ToAdd.Add(new Button(@"Sprites\Button.png", new Vector2D(999, 614)));
                }
                else
                {
                    CantRecruit();
                }
            }

            if (Keyboard.IsKeyPressed(System.Windows.Forms.Keys.W))
            {
                GameWorld.ToAdd.Add(new Witch(@"Sprites\Citizens\Witch.png", new Vector2D(400, 400), false, "john"));
            }
            if (Keyboard.IsKeyPressed(System.Windows.Forms.Keys.Q))
            {

                Random rnd = new Random();
                int spawnpoint = rnd.Next(0, 4);
                switch (spawnpoint)
                {
                    case 0:
                        float spawnPointX = -9;
                        float spawnPointY = 200;
                        GameWorld.ToAdd.Add(new Raider(@"Sprites\Citizens\Raider.png", new Vector2D(spawnPointX, spawnPointY)));
                        break;
                    case 1:
                        spawnPointX = 700;
                        spawnPointY = 765;
                        GameWorld.ToAdd.Add(new Raider(@"Sprites\Citizens\Raider.png", new Vector2D(spawnPointX, spawnPointY)));
                        break;
                    case 2:
                        spawnPointX = 400;
                        spawnPointY = 765;
                        GameWorld.ToAdd.Add(new Raider(@"Sprites\Citizens\Raider.png", new Vector2D(spawnPointX, spawnPointY)));
                        break;
                    case 3:
                        spawnPointX = -9;
                        spawnPointY = 500;
                        GameWorld.ToAdd.Add(new Raider(@"Sprites\Citizens\Raider.png", new Vector2D(spawnPointX, spawnPointY)));
                        break;

                }
            }
            if (Keyboard.IsKeyPressed(System.Windows.Forms.Keys.Escape))
            {
                GameWorld.ToRemove.Add(this);
                GameWorld.ToAdd.Add(new Button(@"Sprites\Button.png", new Vector2D(999, 614)));

            }
            base.Update(currentFPS);
        }

        protected void CantRecruit()
        {
            try
            {
                engine = new ISoundEngine();
                engine.Play2D("Media/efx_NO-Fabio_Farinelli-955789468.mp3", false);
            }
            catch (Exception ex) { }
        }
    }
}