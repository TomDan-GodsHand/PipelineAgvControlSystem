using System;
using System.Collections.Specialized;

namespace PipelineAgvControlSystem;

public class Context
{
    /// <summary>
    /// 系统配置字典 Key:key ; Value:value
    /// </summary>
    public Dictionary<string, string> SystemConfigDict { get; set; }

    #region  Map相关
    public string MapName { get; set; }
    /// <summary>
    /// 储存所有点的集合 Key:PointCode ; Value:BasePoint
    /// </summary>
    public Dictionary<string, string> PointDict { get; set; }
    /// <summary>
    /// 储存所有路径的集合 Key:PathCode ; Value:BasePath
    /// </summary>
    public Dictionary<string, string> PathDict { get; set; }
    #endregion
}
