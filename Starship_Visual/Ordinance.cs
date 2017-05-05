/**********
 * Josh Romito
 * CP_220
 * Assignment 1
 * Starship Battle
 * March 2, 2017
 ************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Starship_Visual
{
    //ordinance class
    class Ordinance
    {
        //private field for damage
        private int _dmg;
        //virtual int property damage
        public virtual int dmg { get { return _dmg; } set { _dmg = value; } }
        //private field for ordinance name
        private string _ordName;
        //virtual string property for name
        public string ordName { get { return _ordName; } }
        
        //constructor, requiring a name
        public Ordinance(string name)
        {
            _ordName = name;
        }
    }

    //torpedo class
    class Torpedo : Ordinance
    {
        //private field for defualt damage
        private int _torpDmg = 15;
        //overriding the base class dmg, setting it to the torpedo damage
        public override int dmg { get { return base.dmg + _torpDmg; } set { base.dmg = value; } }
        //torpedo constructor, taking in a name
        public Torpedo(string name) : base(name)
        {
        }
    }

    //ion bomb class
    class IonBomb : Ordinance
    {
        //private field for default damage
        private int _ionDmg = 10;
        //overriding the base class dmg, setting it to the Ion bomb damage
        public override int dmg { get { return base.dmg + _ionDmg; } set { base.dmg = value; } }
        //ion constructor, taking in a name
        public IonBomb(string name) : base(name)
        {
        }      
    }

    class Laser : Ordinance
    {
        private int _laserDmg = 5;
        //overriding the base class dmg, setting it to the laser damage
        public override int dmg { get { return base.dmg + _laserDmg; } set { base.dmg = value; } }
        //laser constructor, taking in a name
        public Laser(string name) : base(name)
        {
        }       
    }
}
