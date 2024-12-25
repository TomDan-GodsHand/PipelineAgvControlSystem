using System;
using SqlSugar;

namespace AgvControlSyetem.Entity.Base;

[SugarTable("t_agv_basic")]
public class BasicAgv
{
    [SugarColumn(IsPrimaryKey = true)]
    public string agv_code { get; set; }

    [SugarColumn]
    public string agv_type { get; set; }

    [SugarColumn]
    public string agv_model_code { get; set; }

    [SugarColumn]
    public string agv_ipaddress { get; set; }

    [SugarColumn]
    public int agv_port1 { get; set; }

    [SugarColumn]
    public int charging_plate_direction { get; set; }

    [SugarColumn]
    public int agv_port2 { get; set; }

    [SugarColumn]
    public DateTime t_update { get; set; }

    [SugarColumn]
    public string u_update { get; set; }

    [SugarColumn(IsIgnore = true)]
    public BaseAgvModel agvModel { get; set; }

    [SugarColumn(IsIgnore = true)]
    public string map_code { get; set; }
}