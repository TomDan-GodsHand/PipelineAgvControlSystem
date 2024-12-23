using System;
using SqlSugar;

namespace AgvControlSyetem.Entity.Map;
[SugarTable("base_path")]
public class BasePath
{
    [SugarColumn(IsPrimaryKey = true)]
    public string PathId { get; set; }

    [SugarColumn(IsPrimaryKey = true)]
    public string MapCode { get; set; }

    [SugarColumn]
    public string PathStartPointCode { get; set; }

    [SugarColumn]
    public string PathEndPointCode { get; set; }

    [SugarColumn]
    public int IsUseHead { get; set; }

    [SugarColumn]
    public double PathLength { set; get; }

    [SugarColumn]
    public int LaserLevel { get; set; }

    [SugarColumn]
    public int SpeedLevel { get; set; }

    [SugarColumn]
    public double ControlPoint1X { get; set; }

    [SugarColumn]
    public double ControlPoint1Y { get; set; }

    [SugarColumn]
    public double ControlPoint2X { get; set; }

    [SugarColumn]
    public double ControlPoint2Y { get; set; }

    [SugarColumn]
    public int IsArc { get; set; }

    [SugarColumn]
    public double CirClePointX { get; set; }

    [SugarColumn]
    public double CirClePointY { get; set; }

    [SugarColumn]
    public double Radius { get; set; }

    [SugarColumn]
    public int PathType { get; set; }

    [SugarColumn]
    public int NoCreateArcFlag { get; set; }

    [SugarColumn]
    public int cost { set; get; }


}
