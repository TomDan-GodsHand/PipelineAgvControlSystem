using System;
using AgvControlSyetem.Entity.Base;
using AgvControlSyetem.Entity.Map;
using Microsoft.Extensions.Logging;
using SqlSugar;

namespace PipelineAgvControlSystem.Logic;

/// <summary>
/// 所有地图相关的，包括BasePath ，BasePoint，BaseMap，BaseArea，BaseFunctionArea等的Logic方法，都放在这里
/// </summary>
public class MapLogic(ISqlSugarClient db, ILogger<MapLogic> logger) : ILogic
{
    public BaseMap GetBaseMap()
    {
        try
        {
            var bm = db.Queryable<BaseMap>().Single();
            return bm;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, ex.Message);
            return null;
        }
    }
    public Dictionary<string, BasePath> GetBasePathDict()
    {
        try
        {
            var pathDict = new Dictionary<string, BasePath>();
            pathDict = db.Queryable<BasePath>().ToList().ToDictionary(bp => bp.PathId, bp => bp);
            return pathDict;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, ex.Message);
            return null;
        }
    }
    public Dictionary<string, BasePoint> GetBasePointDict()
    {
        try
        {
            var pointDict = new Dictionary<string, BasePoint>();
            pointDict = db.Queryable<BasePoint>().ToList().ToDictionary(bp => bp.PointCode, bp => bp);
            return pointDict;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, ex.Message);
            return null;
        }
    }

}
