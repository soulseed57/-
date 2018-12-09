﻿namespace 阴阳易演.具象类.地支
{
    using 抽象类;
    using 枚举类;

    public class 辰 : 地支
    {
        public 辰()
        {
            阴阳 = 两仪.阳;
            五行 = 五行.土;
            生肖 = "龙";
            方位 = 十六方位.东偏南;
        }
    }
}
