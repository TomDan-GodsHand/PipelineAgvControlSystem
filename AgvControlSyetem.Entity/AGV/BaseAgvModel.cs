using System;
using SqlSugar;

namespace AgvControlSyetem.Entity.AGV;

[SugarTable("t_agv_model")]
public class BaseAgvModel
{
    /// <summary>
    /// Desc:
    /// Default:
    /// Nullable:False
    /// </summary>           
    [SugarColumn(IsPrimaryKey = true)]
    public string agv_model_code { get; set; }

    /// <summary>
    /// Desc:
    /// Default:
    /// Nullable:True
    /// </summary>           
    [SugarColumn]
    public double agv_shape { get; set; }  //根据AGV模型计算

    #region 对于矩形车体来说,静态情况

    /// <summary>
    /// Desc:
    /// Default:
    /// Nullable:True
    /// </summary>           
    [SugarColumn]
    public double agv_width { get; set; }

    [SugarColumn]
    public double head_length { get; set; } //旋转中心到头部的距离

    [SugarColumn]
    public double tail_length { get; set; }

    #endregion

    #region 对于矩形车体来说,动态情况

    /// <summary>
    /// Desc:
    /// Default:
    /// Nullable:True
    /// </summary>           
    [SugarColumn]
    public double runing_agv_width { get; set; }

    [SugarColumn]
    public double runing_head_length { get; set; } //旋转中心到头部的距离

    [SugarColumn]
    public double runing_tail_length { get; set; }

    #endregion

    #region 对于圆形车体来说，静态情况
    [SugarColumn]
    public double circle_radius { set; get; }
    #endregion

    #region 对于圆形车体来说，动态情况
    [SugarColumn]
    public double runing_circle_radius { set; get; }
    #endregion

}