using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameFrameWorkV2.Helpers.Enums;
using GameFrameWorkV2.Helpers.Structs;
using GameFrameWorkV2.Items;
using GameFrameWorkV2.WorldClasses;

namespace GameFrameWorkV2.Creatures.ConcreteCreatures
{
    public class PlayerCreature : Creature
    {
        private World _world;
        public List<IItem> Inventory { get; set; }
        public PlayerCreature(int hitPoints, string name, Position position, World world) : base(hitPoints, name, position)
        {
            _world = world;
        }

        public override void Loot()
        {
            var @object = _world.WorldPlayGround[this.Position.X, this.Position.Y].Object;
            if (@object.IsLootable)
            {
                Inventory.Add(@object.Item);
            }
        }
    }
}
