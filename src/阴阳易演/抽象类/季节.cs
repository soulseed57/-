﻿namespace 阴阳易演.抽象类
{
    using System;
    using 具象类.季节;
    using 基类;
    using 容器类;
    using 枚举类;

    public abstract class 季节 : 无极
    {
        #region 构造
        static 季节()
        {
            春季 = new 春季();
            夏季 = new 夏季();
            秋季 = new 秋季();
            冬季 = new 冬季();
            长夏 = new 长夏();
        }

        #endregion

        #region 属性
        // 静态属性
        public static 春季 春季 { get; }
        public static 夏季 夏季 { get; }
        public static 秋季 秋季 { get; }
        public static 冬季 冬季 { get; }
        public static 长夏 长夏 { get; }
        // 动态属性
        public 五行 旺
        {
            get
            {
                switch (this)
                {
                    case 春季 _:
                        return 春季.旺;
                    case 夏季 _:
                        return 夏季.旺;
                    case 秋季 _:
                        return 秋季.旺;
                    case 冬季 _:
                        return 冬季.旺;
                    case 长夏 _:
                        return 长夏.旺;
                    default:
                        throw new Exception($"未知类型:{this}");
                }
            }
        }
        public 五行 相
        {
            get
            {
                switch (this)
                {
                    case 春季 _:
                        return 春季.相;
                    case 夏季 _:
                        return 夏季.相;
                    case 秋季 _:
                        return 秋季.相;
                    case 冬季 _:
                        return 冬季.相;
                    case 长夏 _:
                        return 长夏.相;
                    default:
                        throw new Exception($"未知类型:{this}");
                }
            }
        }
        public 五行 休
        {
            get
            {
                switch (this)
                {
                    case 春季 _:
                        return 春季.休;
                    case 夏季 _:
                        return 夏季.休;
                    case 秋季 _:
                        return 秋季.休;
                    case 冬季 _:
                        return 冬季.休;
                    case 长夏 _:
                        return 长夏.休;
                    default:
                        throw new Exception($"未知类型:{this}");
                }
            }
        }
        public 五行 囚
        {
            get
            {
                switch (this)
                {
                    case 春季 _:
                        return 春季.囚;
                    case 夏季 _:
                        return 夏季.囚;
                    case 秋季 _:
                        return 秋季.囚;
                    case 冬季 _:
                        return 冬季.囚;
                    case 长夏 _:
                        return 长夏.囚;
                    default:
                        throw new Exception($"未知类型:{this}");
                }
            }
        }
        public 五行 死
        {
            get
            {
                switch (this)
                {
                    case 春季 _:
                        return 春季.死;
                    case 夏季 _:
                        return 夏季.死;
                    case 秋季 _:
                        return 秋季.死;
                    case 冬季 _:
                        return 冬季.死;
                    case 长夏 _:
                        return 长夏.死;
                    default:
                        throw new Exception($"未知类型:{this}");
                }
            }
        }

        #endregion

        #region 方法
        public static 季节 季节查询(DateTime 日期)
        {
            var 节气时间 = new 节气时间(日期);
            switch (节气时间.枚举)
            {
                case 节气节令.立春:
                case 节气节令.雨水:
                case 节气节令.惊蛰:
                case 节气节令.春分:
                case 节气节令.清明:
                case 节气节令.谷雨:
                    return 春季;
                case 节气节令.立夏:
                case 节气节令.小满:
                case 节气节令.芒种:
                case 节气节令.夏至:
                case 节气节令.小暑:
                case 节气节令.大暑:
                    return 夏季;
                case 节气节令.立秋:
                case 节气节令.处暑:
                case 节气节令.白露:
                case 节气节令.秋分:
                case 节气节令.寒露:
                case 节气节令.霜降:
                    return 秋季;
                case 节气节令.立冬:
                case 节气节令.小雪:
                case 节气节令.大雪:
                case 节气节令.冬至:
                case 节气节令.小寒:
                case 节气节令.大寒:
                    return 冬季;
                default:
                    throw new Exception($"当前日期[{日期}]未查询到匹配季节");
            }
        }

        #endregion

    }
}
