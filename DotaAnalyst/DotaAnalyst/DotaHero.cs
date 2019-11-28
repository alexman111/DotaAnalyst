using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace DotaAnalyst
{
    [Table("DotaHeroesTable")]
    public class DotaHero
    {
        
        private const double MANA_FOR_ONE_INTELLIGENCE = 12;
        private const double MANA_REGENERATION_FOR_ONE_INTELLIGENCE = 0.05;
        private const double MOVE_SPEED_FOR_ONE_AGILITY = 0.05;
        private const double ARMOR_FOR_ONE_AGILITY = 0.16;
        private const double HEALTH_FOR_ONE_STRENGTH = 20;
        private const double HEALTH_REGEN_FOR_ONE_STRENGTH = 0.1;
        private const int PRO_MODE = 1;
        private const int PUB_MODE = 0;

        double ParseToDouble(double? x)
        {

            double y = 0;
            if (x != null) y = x.Value;

            return y;
        }
        public DotaHero() {
            this.Level = 1;
        }
        public DotaHero(DotaHero hero)
        {
            this.Id = hero.Id;
            this.Name = hero.Name;
            this.MainAttribute = hero.MainAttribute;
            this.AttackType = hero.AttackType;
            this.BaseHealth = hero.BaseHealth;
            this.BaseHealthRegen = ParseToDouble(hero.BaseHealthRegen);
            this.BaseMana = hero.BaseMana;
            this.BaseManaRegen = hero.BaseManaRegen;
            this.BaseArmor = hero.BaseArmor;
            this.BaseAttackMin = hero.BaseAttackMin;
            this.BaseAttackMax = hero.BaseAttackMax;
            this.BaseStrength = hero.BaseStrength;
            this.BaseAgility = hero.BaseAgility;
            this.BaseIntelligence = hero.BaseIntelligence;
            this.StrengthGain = hero.StrengthGain;
            this.AgilityGain = hero.AgilityGain;
            this.IntelligenceGain = hero.IntelligenceGain;
            this.MoveSpeed = hero.MoveSpeed;
            this.ProPick = hero.ProPick;
            this.ProBan = hero.ProBan;
            this.ProWin = hero.ProWin;
            this.AllPick = hero.AllPick;
            this.AllWin = hero.AllWin;
            this.Level = 1;
            ImagePath = IconNameParser.Parse(Name);

            ProWinrate = (double)(ProWin) / (double)(ProPick) * 100.0;
            PubWinrate = (double)(AllWin) / (double)(AllPick) * 100.0;
        }
   
        [PrimaryKey, AutoIncrement, Column("_id")]


        public int Id { get; set; }
        public string Name { get; set; }
        public string MainAttribute { get; set; }

        public string AttackType { get; set; }
       
        public double BaseHealth { get; set; }

        public double BaseHealthRegen { get; set; }

        public double BaseMana { get; set; }

        public double BaseManaRegen { get; set; }

        public double BaseArmor { get; set; }
        public double BaseAttackMin { get; set; }
        public double BaseAttackMax { get; set; }

        public double BaseStrength { get; set; }
        public double BaseAgility { get; set; }

        public double BaseIntelligence { get; set; }
        public double StrengthGain { get; set; }
        public double AgilityGain { get; set; }
        public double IntelligenceGain { get; set; }
        public double MoveSpeed { get; set; }

        public int Level { get; set; }
        public int ProPick { get; set; }
        public int ProBan { get; set; }
        public int ProWin { get; set; }
        public int AllPick { get; set; }
        public int AllWin { get; set; }
        public string ImagePath { get; set; }
        public double ProWinrate { get; set; }
        public double PubWinrate { get; set; }

        public double GetCurrentStrength()
        {
            return BaseStrength + (Level - 1) * StrengthGain;
        }
        public double GetCurrentAgility()
        {
            return BaseAgility + (Level - 1) * AgilityGain;
        }
        public double GetWinrate(int mode)
        {
            double winrate;
            if (mode == PUB_MODE)
            {
                winrate = PubWinrate;
            }else
            {
                winrate = ProWinrate;
            }
            return winrate;
        }
        public double GetCurrentIntelligence()
        {
            return BaseIntelligence + (Level - 1) * IntelligenceGain;
        }

        public double GetHealthRegeneration()
        {
            return (double)BaseHealthRegen + GetCurrentStrength() * HEALTH_REGEN_FOR_ONE_STRENGTH;
        }
        public double GetHealth()
        {
            return BaseHealth + GetCurrentStrength() * HEALTH_FOR_ONE_STRENGTH;
        }

        public double GetArmor()
        {
            return BaseArmor + ARMOR_FOR_ONE_AGILITY * GetCurrentAgility(); 
        }

        public double GetMoveSpeed()
        {
            return Math.Min(MoveSpeed + GetCurrentAgility() * MOVE_SPEED_FOR_ONE_AGILITY, 550); 
        }

        public double GetMana()
        {
            return BaseMana + GetCurrentIntelligence() * MANA_FOR_ONE_INTELLIGENCE;
        }
        public double GetManaRegeneration()
        {
            return BaseManaRegen + GetCurrentIntelligence() * MANA_REGENERATION_FOR_ONE_INTELLIGENCE;
        }

        public double GetMinDamage()
        {
            double bonus = 0;

            if (MainAttribute == "agi") bonus = GetCurrentAgility();
            else if (MainAttribute == "int") bonus = GetCurrentIntelligence();
            else bonus = GetCurrentStrength();

            return BaseAttackMin + bonus;
        }

        public double GetMaxDamage()
        {
            double bonus = 0;

            if (MainAttribute == "agi") bonus = GetCurrentAgility();
            else if (MainAttribute == "int") bonus = GetCurrentIntelligence();
            else bonus = GetCurrentStrength();

            return BaseAttackMax + bonus;
        }
    }
}
