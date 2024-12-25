using System;

namespace AgvControlSyetem.Entity.AGV;

public class AgvInfo
{
    public string agv_num { get; set; } //agv编号 001-100
    public string online_status { get; set; }     //是否在线，（与调度中心连接上Socket）数据：Y/N
    public string work_pattern { get; set; }  // 工作模式/控制模式  自动，手动 ，维修 。数据：0:自动模式；1：手动模式。
    public int speed { get; set; }  //速度 数据：0-100(cm/s)
    public int electricity { get; set; } //电量 数据:0-100
    public string direction { get; set; }  //前进 Ahead 或者 后退 Back_off 对应 舵机轮运行方向：数据 1：前进；2：后退。
    public string headDirection { get; set; }  //车头朝向 数据 ：U上、D下、L左、R右
    public string current_Point { get; set; }//AGV当前点位置 数据：以地图为准
    public string current_route_num { get; set; }  //当前执行路径段编号:1-65535(高字节在前)，例如前一字节为0x12,后一字节为0x34，路段编号为0x1234=4660。
    public string last_route_num { get; set; } //上一路径编号
    public int remaining_routes { get; set; }  //任务剩余未完成任务路段数:AGV已收到调度任务中未完成的任务段数。数据：0-20
    public float current_point_X { get; set; }//车辆当前X轴坐标点
    public float current_point_Y { get; set; }//车辆当前Y轴坐标点
    public double agv_angle { get; set; }//agv车辆角度 数据0-360
    public string taskid { get; set; }//车辆当前的任务信息：当前任务编号 数据：对应主任务表BaseMainTask task_code字段
    public string flag_had_pallet { get; set; } //是否有货 数据：Y：无货；N：有货。
    public string flag_stop { get; set; } // 停止标记：数据 N：未暂停；Y：已暂停。
    public string flag_exception { get; set; } // 异常状态(1)：数据 N：无异常；Y：异常。
    public string flag_action_finish { get; set; } // 动作完成标记（1）数据：N未完成；Y已完成。
    public string flag_AGV_initialize { get; set; }//初始化完成：数据： N：未完成；Y：完成。(没有完成不接收任务)
    public string Mes_Exception { get; set; }//异常信息 
    public int Map_version { get; set; }//AGV车载地图版本号：1001-65535
    public string recharge_status { get; set; }//充电状态 车体反馈充电状态 数据：0：无状态 1：对接成功 2：充电中

    public int charging_plate_direction { set; get; }//充电极板相对于车身的方向：0：表示充电极板相对在身头部 1：表示充电极板相对在车身左侧 2：表示充电极板相对在车身右侧
    public string materialsInfo { get; set; }
    public BaseAgvModel agvModel { set; get; }
    public string agvType { set; get; }
    /// <summary>
    /// 货叉状态 0:静止 1:上升 2: 下降
    /// </summary>
    public int fork_status { set; get; }

    public bool task_starting { get; set; }//任务开始中，还未成功
}