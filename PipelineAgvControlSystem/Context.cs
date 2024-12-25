using System;
using System.Collections.Specialized;
using System.Net.Sockets;
using AgvControlSyetem.Entity.Base;
using AgvControlSyetem.Entity.Map;
using Microsoft.Extensions.Logging;
using PipelineAgvControlSystem.InnerEntity;
using PipelineAgvControlSystem.Logic;

namespace PipelineAgvControlSystem;

public class Context
{
    private readonly ILogger<Context> logger;
    private readonly CommonLogic commonLogic;
    private readonly MapLogic mapLogic;

    public Context(ILogger<Context> logger, CommonLogic CommonLogic, MapLogic MapLogic)
    {
        this.logger = logger;
        commonLogic = CommonLogic;
        mapLogic = MapLogic;
        InitContext();
    }

    public bool InitContext()
    {
        try
        {
            SystemConfigDict = commonLogic.GetBaseConfig();
            Map = new();
            Map.BaseMap = mapLogic.GetBaseMap();
            Map.PointDict = mapLogic.GetBasePointDict();
            Map.PathDict = mapLogic.GetBasePathDict();
            BasicAgvDict = commonLogic.GetBasicAgvDict();
            AgvSocketDict = new();
            return true;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, ex.Message);
            return false;
        }
    }

    /// <summary>
    /// 储存地图信息的类
    /// </summary>
    public Map Map { get; set; }
    /// <summary>
    /// 系统配置字典 Key:key ; Value:value
    /// </summary>
    public Dictionary<string, string> SystemConfigDict { get; set; }

    /// <summary>
    ///  储存AGV的基础数据
    /// </summary>
    public Dictionary<string, BasicAgv> BasicAgvDict { get; set; }

    /// <summary>
    /// 储存每个连接的AGV对应的SOCKET， Key:AgvCode, Value:Socket
    /// </summary>
    public Dictionary<string, Socket> AgvSocketDict { get; set; }
}
