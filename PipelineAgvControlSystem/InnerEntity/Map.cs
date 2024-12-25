using System;
using AgvControlSyetem.Entity.Map;

namespace PipelineAgvControlSystem.InnerEntity;

public class Map
{
    public BaseMap BaseMap { get; set; }
    /// <summary>
    /// 储存所有点的集合 Key:PointCode ; Value:BasePoint
    /// </summary>
    public Dictionary<string, BasePoint> PointDict { get; set; }
    /// <summary>
    /// 储存所有路径的集合 Key:PathCode ; Value:BasePath
    /// </summary>
    public Dictionary<string, BasePath> PathDict { get; set; }

}