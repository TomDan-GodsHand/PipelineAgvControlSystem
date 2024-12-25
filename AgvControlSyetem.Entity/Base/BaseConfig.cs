using System;
using SqlSugar;

namespace AgvControlSyetem.Entity.Base;

[SugarTable("base_config")]
public class BaseConfig
{
    [SugarColumn(ColumnName = "Key", IsPrimaryKey = true)]
    public string Key { get; set; }


    [SugarColumn(ColumnName = "Values")]
    public string Values { get; set; }


    [SugarColumn(ColumnName = "Other")]
    public string Other { get; set; }
}