using System;
using System.Collections.Generic;
using System.Text;

namespace DotaAnalyst
{
    public class RootObject
    {
        public int id { get; set; }
        public string name { get; set; }
        public string localized_name { get; set; }
        public string primary_attr { get; set; }
        public string attack_type { get; set; }
        public List<string> roles { get; set; }
        public string img { get; set; }
        public string icon { get; set; }
        public int base_health { get; set; }
        public double? base_health_regen { get; set; }
        public int base_mana { get; set; }
        public double base_mana_regen { get; set; }
        public double base_armor { get; set; }
        public int base_mr { get; set; }
        public int base_attack_min { get; set; }
        public int base_attack_max { get; set; }
        public int base_str { get; set; }
        public int base_agi { get; set; }
        public int base_int { get; set; }
        public double str_gain { get; set; }
        public double agi_gain { get; set; }
        public double int_gain { get; set; }
        public int attack_range { get; set; }
        public int projectile_speed { get; set; }
        public double attack_rate { get; set; }
        public int move_speed { get; set; }
        public double turn_rate { get; set; }
        public bool cm_enabled { get; set; }
        public int legs { get; set; }
        public int pro_win { get; set; }
        public int pro_pick { get; set; }
        public int hero_id { get; set; }
        public int pro_ban { get; set; }
        public int __invalid_name__1_pick { get; set; }
        public int __invalid_name__1_win { get; set; }
        public int __invalid_name__2_pick { get; set; }
        public int __invalid_name__2_win { get; set; }
        public int __invalid_name__3_pick { get; set; }
        public int __invalid_name__3_win { get; set; }
        public int __invalid_name__4_pick { get; set; }
        public int __invalid_name__4_win { get; set; }
        public int __invalid_name__5_pick { get; set; }
        public int __invalid_name__5_win { get; set; }
        public int __invalid_name__6_pick { get; set; }
        public int __invalid_name__6_win { get; set; }
        public int __invalid_name__7_pick { get; set; }
        public int __invalid_name__7_win { get; set; }
        public int __invalid_name__8_pick { get; set; }
        public int __invalid_name__8_win { get; set; }
        public int null_pick { get; set; }
        public int null_win { get; set; }
    }
    public class RootList
    {
        public List<RootObject> roots { get;set; }
    }
}
