﻿namespace 阴阳易演.具象类.地支
{
    using 抽象类;
    using 枚举类;

    public class 巳 : 地支
    {
        public 巳()
        {
            阴阳 = 两仪.阴;
            五行 = 五行.火;
            生肖 = "蛇";
            方位 = 十六方位.南偏东;
        }
    }
}
