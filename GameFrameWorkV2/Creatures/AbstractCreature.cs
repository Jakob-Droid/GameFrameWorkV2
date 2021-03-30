using GameFrameWorkV2.Helpers.Observer;
using GameFrameWorkV2.Helpers.Structs;
using GameFrameWorkV2.Items;
using GameFrameWorkV2.Items.ConcreteAttackItems;
using GameFrameWorkV2.Items.ConcreteDefenceItems;
using System;
using System.Collections.Generic;
using GameFrameWorkV2.WorldClasses;

namespace GameFrameWorkV2.Creatures
{
    public abstract class AbstractCreature : ICreature
    {
        private int _hitPoints;
        private Random rnd = new Random();
        public Position Position { get; set; }
        public int HitPoints
        {
            get { return _hitPoints; }
            set
            {
                _hitPoints = value;
                if (_hitPoints <= 0)
                {
                    DeathObserver.OnDeath(this);
                }
            }

        }
        public string Name { get; set; }
        public CompositeDefence DefencesItems { get; set; }
        public CompositeAttack AttackItems { get; set; }
        public int Strength { get; set; } = 20;

        protected AbstractCreature(int hitPoints, string name, Position position)
        {
            HitPoints = hitPoints;
            Name = name;
            Position = position;
            AttackItems = new CompositeAttack();
            DefencesItems = new CompositeDefence();

        }


        public abstract void Hit(ICreature defender);
       

        protected int CalculateDamge(int damage, ICreature defender)
        {
            var dmg = (damage - defender.DefencesItems.ReduceHitPoints);
            return dmg > 0 ? dmg : 0;
        }

        public virtual void Loot(World world, string itemName)
        {
            DisplayItemsOnGround(world, itemName);
        }

        public virtual void LootItemOnGround(IItem item)
        {
            if (item.GetType().BaseType == typeof(AttackItem))
            {
                AttackItems.AddAttackItem((AttackItem)item);
            }
            if (item.GetType().BaseType == typeof(DefenceItem))
            {
                DefencesItems.AddDefenceItem((DefenceItem)item);
            }
        }

        public virtual void DisplayItemsOnGround(World world,string itemName)
        {
            var items = world.WorldPlayGround[this.Position.X, this.Position.Y].Object;
            var counter = 1;
            foreach (var item in items)
            {
                Console.WriteLine($"{counter} {item.Name}");
            }

            PickUpItem(world, itemName);
        }

        protected virtual void PickUpItem(World world, string itemName)
        {
            var items = world.WorldPlayGround[this.Position.X, this.Position.Y].Object;
            if (items.Contains(items.Find(x => x.Name == itemName)))
            {
                var item = world.WorldPlayGround[this.Position.X, this.Position.Y].Object.Find(x => x.Name == itemName);
                world.WorldPlayGround[this.Position.X, this.Position.Y].Object.Remove(item);
                LootItemOnGround(item as IItem);
            }
        }

        public virtual void ReceiveHit(int damage)
        {
            if (DefencesItems.DefenceItems.Count != 0)
            {
                var dmg = damage - DefencesItems.ReduceHitPoints;
                //makes sure you cannot be healed by attacks, checks for minus numbers
                if (dmg > 0)
                {
                    HitPoints -= dmg;
                }
            }
            else
            {
                HitPoints -= damage;
            }
        }

        public virtual List<IItem> OnDeath()
        {
            List<IItem> droppedItems = new List<IItem>();
            if (this.AttackItems.AttackItems.Count != 0)
            {
                droppedItems.AddRange(AttackItems.AttackItems);
            }
            if (this.AttackItems.AttackItems.Count != 0)
            {
                droppedItems.AddRange(DefencesItems.DefenceItems);
            }
            else
            {
                droppedItems = null;
            }
            return droppedItems;
        }
    }
}
