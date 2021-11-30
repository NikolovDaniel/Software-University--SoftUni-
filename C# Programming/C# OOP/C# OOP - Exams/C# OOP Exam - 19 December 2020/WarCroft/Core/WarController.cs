using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using WarCroft.Constants;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;
using System.Text;

namespace WarCroft.Core
{
	public class WarController
	{
		private IList<Character> characterParty;
		private Stack<Item> itemPool;
		public WarController()
		{
			this.characterParty = new List<Character>();
			this.itemPool = new Stack<Item>();
		}

		public string JoinParty(string[] args)
		{
            switch (args[0])
            {
				case "Warrior":
					this.characterParty.Add(new Warrior(args[1]));
					break;
				case "Priest":
					this.characterParty.Add(new Priest(args[1]));
					break;
                default:
					throw new ArgumentException($"Invalid character type \"{args[0]}\"!");
            }

			return $"{args[1]} joined the party!".TrimEnd();
        }

		public string AddItemToPool(string[] args)
		{
            switch (args[0])
            {
				case "HealthPotion":
					itemPool.Push(new HealthPotion());
					break;
				case "FirePotion":
					itemPool.Push(new FirePotion());
					break;
                default:
					throw new ArgumentException($"Invalid item \"{args[0]}\"!");
            }

			return $"{args[0]} added to pool.".TrimEnd();
        }

		public string PickUpItem(string[] args)
		{
			Character character = characterParty.FirstOrDefault(x => x.Name == args[0]);

			if (character == null)
            {
				throw new ArgumentException($"Character {args[0]} not found!");
            }

			if (itemPool.Count == 0)
            {
				throw new InvalidOperationException($"No items left in pool!");
            }

			Item item = itemPool.Peek();

			if (item.Weight + character.Bag.Load > character.Bag.Capacity)
            {
				character.Bag.AddItem(item);
            }
			else
            {
				character.Bag.AddItem(itemPool.Pop());
            }

			return $"{args[0]} picked up {item.GetType().Name}!".TrimEnd();
		}

		public string UseItem(string[] args)
		{
			Character character = characterParty.FirstOrDefault(x => x.Name == args[0]);
			
			if (character == null)
            {
				throw new ArgumentException($"Character {args[0]} not found!");
            }

			Item item = character.Bag.GetItem(args[1]);

			character.UseItem(item);

			return $"{args[0]} used {item.GetType().Name}.".TrimEnd();
		}

		public string GetStats()
		{
			StringBuilder sb = new StringBuilder();

            foreach (var character in characterParty.OrderByDescending(x => x.IsAlive).ThenByDescending(x => x.Health))
            {
				string aliveOrDead = string.Empty;
				if (character.IsAlive)
                {
					aliveOrDead = "Alive";
                }
				else
                {
					aliveOrDead = "Dead";
                }
				sb.AppendLine($"{character.Name} - HP: {character.Health}/{character.BaseHealth}, AP: {character.Armor}/{character.BaseArmor}, Status: {aliveOrDead}");
            }

			return sb.ToString().TrimEnd();
		}

		public string Attack(string[] args)
		{
			Character attacker = characterParty.FirstOrDefault(x => x.Name == args[0]);
			Character defender = characterParty.FirstOrDefault(x => x.Name == args[1]);


			if (attacker == null)
            {
				throw new ArgumentException($"Character {args[0]} not found!");
            }
			else if (defender == null)
            {
				throw new ArgumentException($"Character {args[1]} not found!");
			}

			Warrior warrior = attacker as Warrior;

			if (warrior == null)
            {
				throw new ArgumentException($"{args[0]} cannot attack!");
            }

			warrior.Attack(defender);

			string output = string.Format(SuccessMessages.AttackCharacter, attacker.Name, defender.Name, attacker.AbilityPoints,
				defender.Name, defender.Health, defender.BaseHealth, defender.Armor, defender.BaseArmor);

			if (defender.Health == 0)
            {
				output += $"\n{defender.Name} is dead!";
            }

			return output;
		}

		public string Heal(string[] args)
		{
			Character healer = characterParty.FirstOrDefault(x => x.Name == args[0]);
			Character receiver = characterParty.FirstOrDefault(x => x.Name == args[1]);


			if (healer == null)
			{
				throw new ArgumentException($"Character {args[0]} not found!");
			}
			else if (receiver == null)
			{
				throw new ArgumentException($"Character {args[1]} not found!");
			}

			Priest priest = healer as Priest;

			if (priest == null)
			{
				throw new ArgumentException($"{args[0]} cannot attack!");
			}

			priest.Heal(receiver);

			string output = string.Format(SuccessMessages.HealCharacter, healer.Name, receiver.Name, healer.AbilityPoints,
				receiver.Name, receiver.Health);

			return output;
		}
	}
}
