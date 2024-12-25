using System;
using SqlSugar;

namespace AgvControlSyetem.Entity.Map;

[SugarTable("base_point")]
public class BasePoint
{
    [SugarColumn(IsPrimaryKey = true)]
    public string PointCode { get; set; }

    [SugarColumn(IsPrimaryKey = true)]
    public string MapCode { get; set; }

    [SugarColumn]
    public double X { get; set; }

    [SugarColumn]
    public double Y { get; set; }

    [SugarColumn]
    public double Angle { get; set; }

    [SugarColumn]
    public int PointType { get; set; }

    [SugarColumn]
    public string AgvType { get; set; }

    [SugarColumn]
    public int ShortTimeParkFlag { get; set; }

    [SugarColumn]
    public int UsedFlag { get; set; }

    [SugarColumn]
    public int IsReport { get; set; }

    [SugarColumn]
    public int Priority { get; set; }

}