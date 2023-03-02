using System;

using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
        private readonly double baseHealth;
        private readonly double baseArmor;
        protected readonly double abilityPoints;
        private double health;
        private double armor;
        private string name;
        public IBag Bag { get; }

        public double AbilityPoints { get => abilityPoints; }
        public double BaseArmor { get => baseArmor; }
        public double BaseHealth { get => baseHealth; }
        public string Name
        {
            get { return name; }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or whitespace!");
                }

                name = value;
            }
        }

        public double Health
        {
            get { return health; }
            set
            {
                if (value < 0)
                {
                    health = 0;
                }
                else if (value > baseHealth)
                {
                    health = baseHealth;
                }
                else
                {
                    health = value;
                }
            }
        }

        public double Armor
        {
            get { return armor; }
            set
            {
                if (value < 0)
                {
                    armor = 0;
                }
                else if (value > baseArmor)
                {
                    armor = baseHealth;
                }
                else
                {
                    armor = value;
                }
            }
        }

        public Character(string name, double health, double armor, double abilityPoints, IBag bag)
        {
            this.Name = name;
            this.baseHealth = health;
            this.Health = health;
            this.baseArmor = armor;
            this.Armor = armor;
            this.abilityPoints = abilityPoints;
            this.Bag = bag;
        }
        public bool IsAlive { get; set; } = true;

        public virtual void TakeDamage(double hitPoints)
        {
            this.EnsureAlive();

            double damageDone = hitPoints - Armor;
            Armor -= hitPoints;

            if (damageDone > 0)
            {
                Health -= damageDone;
            }

            if (Health == 0)
            {
                IsAlive = false;
            }
        }

        public virtual void UseItem(Item item)
        {
            this.EnsureAlive();

            item.AffectCharacter(this);
        }
        protected void EnsureAlive()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }
        }
    }
}