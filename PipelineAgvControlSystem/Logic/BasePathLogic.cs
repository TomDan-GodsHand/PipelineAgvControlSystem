using System;
using AgvControlSyetem.Entity.Base;
using AgvControlSyetem.Entity.Map;
using Microsoft.Extensions.Logging;
using SqlSugar;

namespace PipelineAgvControlSystem.Logic;

public class BasePathLogic(ISqlSugarClient db, ILogger<BasePathLogic> logger) : ILogic
{

    public bool FindAll()
    {
        try
        {
            var list = db.Queryable<BasePath>().ToList();
            return list.Count > 0;
        }
        catch (Exception ex)
        {
            logger.LogError(ex.StackTrace, ex.Message);
            return false;
        }
    }


}
