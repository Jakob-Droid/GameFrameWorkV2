﻿using GameFrameWorkV2.Helpers.Observer;
using GameFrameWorkV2.Helpers.Structs;
using GameFrameWorkV2.Items;
using GameFrameWorkV2.Items.ConcreteAttackItems;
using GameFrameWorkV2.Items.ConcreteDefenceItems;
using System;
using System.Collections.Generic;

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


        public virtual void Loot(IItem item)
        {
            if (typeof(IItem) == typeof(AttackItem))
            {
                AttackItems.AddAttackItem((AttackItem)item);
            }
            if (typeof(IItem) == typeof(DefenceItem))
            {
                DefencesItems.AddDefenceItem((DefenceItem)item);
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
