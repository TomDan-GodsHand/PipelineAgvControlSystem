using System;
using SqlSugar;

namespace AgvControlSyetem.Entity.Map;

[SugarTable("base_map")]
public class BaseMap
{
    [SugarColumn(IsPrimaryKey = true)]
    public string MapCode { get; set; }

    [SugarColumn]
    public string MapName { get; set; }

    [SugarColumn]
    public string MapVersion { get; set; }

    [SugarColumn]
    public string MapPath { get; set; }

    [SugarColumn]
    public int OrderCode { get; set; }

    [SugarColumn]
    public double MinPositionX { get; set; }

    [SugarColumn]
    public double MinPositionY { get; set; }

    [SugarColumn]
    public double MaxPositionX { get; set; }

    [SugarColumn]
    public double MaxPositionY { get; set; }

    [SugarColumn]
    public int OffsetX { get; set; }

    [SugarColumn]
    public int OffsetY { get; set; }

    [SugarColumn]
    public float InitRate { get; set; }

}