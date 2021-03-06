﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADGP_125
{


    interface ICommonChrStat
    {
        string _chrClass { get; set; }
        string _chrID { get; set; }
        int _dmg { get; set; }
        int _health { get; set; }
        bool _alive { get; set; }
        int _lvl { get; set; }
        int  _exp { get; set; }


    }
    [Serializable]
    public class Unit : ICommonChrStat
    {

        public string _chrClass { get; set; }
        public string _chrID { get; set; }
        public int _dmg { get; set; }
        public int _health { get; set; }
        public int _lvl { get; set; }
        public bool _alive { get; set; }

        public int _exp { get; set; }
        public int _expCap { get; set; }

        public Unit() { }
        public Unit(string chrClass, string chrID, int health, int  exp, int dmg)
        {
            _chrClass = chrClass;
            _chrID = chrID;
            _dmg = dmg;
            _health = health;
            _alive = true;
            _lvl = 1;
            _exp = exp;
            _expCap = 50;


        }
        public void Level()
        {
            // exp - expirenced gained from the enemy killed 
            // _expCap - The max amount of expirence a player can have per level
            if (_exp >= _expCap)
            {
                _lvl += _exp / _expCap;
                while (_exp >= _expCap)
                {
                    _exp = _exp/_expCap;
                    
                }
                _exp = ( _expCap - _exp);
                _expCap += _lvl * (_expCap * 1 / 4);
                _dmg += _lvl * (_dmg * 1 / 4);
                _health += _lvl * (_health * 1 / 2);



            }
        }

        public string PlayerInfo
        {
            get
            {
                return "Name: " + _chrID + "\nHealth: " + _health + "\nAttDmg: " + _dmg + "\nLevel:" + _lvl;
            }
        }
        public void TakeDmg(Unit p)
        {
            this._health -= p._dmg;
        }

    }
}

//public class Enemy : ICommonChrStat
//{

//    public string _chrClass { get; set; }
//    public string _chrID { get; set; }
//    public int _dmg { get; set; }
//    public int _health { get; set; }

//    public double _exp { get; set; }
//    public float _expDrop;
//    public Enemy(string chrID, int health, float expDrop, int dmg)
//    {
//        _chrID = chrID;
//        _dmg = dmg;
//        _health = health;
//        _exp = 0;
//        _expDrop = expDrop;


//    }

//    public void TakeDmg(Player player)
//    {
//        _health -= player._dmg;
//    }

//}


