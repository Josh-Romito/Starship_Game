/************
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
using System.Windows.Forms;

namespace Starship_Visual
{
    abstract class Starship
    {
        //private field for the default dmg -
        //it is used to override the default the _firingDamage each time we load - with a defined value for the different ships
        private int _defaultFiringDmg;
        public virtual int defaultFiringDmg { get { return _defaultFiringDmg; } set { _defaultFiringDmg = value; } }

        //private field for firing damage
        private int _firingDamage;
        //read only property was created so we can show how much damage each ship is being attacked with
        public int FiringDamage { get { return _firingDamage; } } 

        //private field for ordinance
        private int _ordinance = 0;
        //read only property was created so we can create conditions based on the ordinance level in the main program
        public int ordinance { get { return _ordinance; } } 

        //private int for max health
        private int _maxHealth = 0;
        //read only property
        public int maxHealth { get { return _maxHealth; } } 

        //private backing field for ship name
        private string _shipName;
        //read only property
        public string shipName { get { return _shipName; } }

        //private backing field for ship type
        private string _shipType;
        public string shipType { get { return _shipType; } set { _shipType = value; } } // get/set for backing field

        //public int for max shield health
        public static int _maxShieldHealth = 25;
        //read only property
        public int maxShieldHealth { get { return _maxShieldHealth; } }

        //private backing field for shield level set to max shield health
        private int _shieldLevel = _maxShieldHealth;
        //read only property
        public int shieldLevel { get { return _shieldLevel; } }

        //private field for health
        private int _health;
        //read only property
        public int health { get { return _health; } }

        //private field for condition with default of Pristine
        private string _condition = "Pristine";
        public string condition { get { return _condition; } } // get/set for backing field

        //class constructor, taking in a string name, int for max health
        public Starship(string name, int inMaxHealth)
        {
            _shipName = name;
            _maxHealth = inMaxHealth;
            _health += _maxHealth;
        }

        //class constructor taking in a name only
        public Starship(string name)
        {
            _shipName = name;
        }

        //fire method, takin in a starship target object
        public bool Fire(Starship target)
        {
            //if we still have ammo, fire away! (remove single ordinance and call takehit method passing it a fire damage and starship target object)
            if (_ordinance > 0 && target._condition != "Destroyed")
            {
                _ordinance -= 1;
                TakeHit(_firingDamage, target);
                return true;
            }
            //if condition is destroyed, we cannot fire..... 
            else if (target._condition == "Destroyed")
            {
                MessageBox.Show(shipName.ToString() + " cannot fire! It is destroyed!!!!");
                return false;
            }            
            else
                return false;
        }

        //take hit method, taking in an int for damage, and starship object for the target
        public void TakeHit(int dmg, Starship target)
        {
            //if shield level is greater than 0,, we subtract the damage from the shield
            if (target._shieldLevel > 0)
            {
                target._shieldLevel -= dmg;
                //if shield level is less than 0, we subtract the dmg from the health - 
                //in addition, we subtract any damage that went beyond the sheild threshold from the health
                //then reset shield level to 0
                if (target._shieldLevel < 0)
                {
                    target._health -= -target._shieldLevel;
                    target._shieldLevel = 0;
                }
            }
            //if sheild level is 0, we subtract from the health
            else if (target._shieldLevel == 0)
            {
                target._health -= dmg;
            }

            //setting the vehicle condition based on health
            if (target._health <= 0)
            {
                target._condition = "Destroyed";
                target._health = 0;
            }
            else if (target._health > 0 && target._health < target._maxHealth)
                target._condition = "Damaged";
            else if (target._health == target._maxHealth)
                target._condition = "Pristine";
            
            //if the condition is destroyed we let you know.
            if (target._condition == "Destroyed")
            {
                MessageBox.Show("The ship: " + target.shipName.ToString() + ", was destroyed");
            }
        }

        //load method, taking in an ordinance type to set new damage.
        public void Load(Ordinance type)
        {
            //resetting ordinance to zero each time we load
            //this ensures that we are applying the ordinance damage mods to each ordinance that is loaded
            _ordinance = 0;
            //reseting the firing damage to default - 
            //to prevent the damage from being added each time a new ordinance type is loaded         
            _firingDamage = defaultFiringDmg;

            //adding the ordinance damage modifier to the firing damage
            _firingDamage += type.dmg;

            //increasing ordinace count by 2
            _ordinance += 2;
        }
    }

    //cruiser class, inherited from starship
    class Cruiser : Starship
    {
        //public static variable for the default cruiser health
        public static int cruiserHealth = 100;
        //private variable for the default damage
        private int cruiserDmg = 10;

        //cruiser constructor
        public Cruiser(string name, int inMaxHealth) : base(name, cruiserHealth)
        {
            this.shipType = "Cruiser";
        }

        //override for default damage
        public override int defaultFiringDmg { get { return base.defaultFiringDmg + cruiserDmg; } set { base.defaultFiringDmg = value; } }
    }

    //destroyer class, inherited from starship
    class Destroyer : Starship
    {
        //public static variable for the default destroyer health
        public static int destroyerHealth = 75;

        //private variable for default damage
        private int destroyerDmg = 20;

        //destroyer constructor
        public Destroyer(string name, int inMaxHealth) : base(name, destroyerHealth)
        {
            this.shipType = "Destroyer";
        }

        //override for the default damage
        public override int defaultFiringDmg { get { return base.defaultFiringDmg + destroyerDmg; } set { base.defaultFiringDmg = value; } }
    }
}
