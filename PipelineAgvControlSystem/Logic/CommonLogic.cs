using System;
using AgvControlSyetem.Entity.Base;
using Microsoft.Extensions.Logging;
using SqlSugar;

namespace PipelineAgvControlSystem.Logic;

/// <summary>
/// 一些小型表，不常用的查询方法，没有必要单独封装一个类的Logic相关方法，放在这里
/// </summary>
public class CommonLogic(ISqlSugarClient db, ILogger<CommonLogic> logger) : ILogic
{
    public Dictionary<string, string> GetBaseConfig()
    {
        try
        {
            var result = new Dictionary<string, string>();
            result = db.Queryable<BaseConfig>().ToList().ToDictionary(bc => bc.Key, bc => bc.Values);
            return result;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, ex.Message);
            return null;
        }
    }
    public Dictionary<string, BasicAgv> GetBasicAgvDict()
    {
        try
        {
            var result = new Dictionary<string, BasicAgv>();
            result = db.Queryable<BasicAgv>().ToList().ToDictionary(agv => agv.agv_code, agv => agv);
            return result;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, ex.Message);
            return null;
        }
    }
}
