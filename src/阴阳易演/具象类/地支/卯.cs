﻿namespace 阴阳易演.具象类.地支
{
    using 抽象类;
    using 枚举类;

    public class 卯 : 地支
    {
        public 卯()
        {
            阴阳 = 两仪.阴;
            五行 = 五行.木;
            生肖 = "兔";
            方位 = 十六方位.正东;
        }
    }
}
