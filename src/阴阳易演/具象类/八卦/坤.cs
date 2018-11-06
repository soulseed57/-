﻿namespace 阴阳易演.具象类.八卦
{
    using 抽象类;

    public class 坤 : 八卦
    {
        public 坤()
        {
            序数 = 8;
            本数 = 2;
            方位 = "西南";
            卦值 = 生成卦值("000");
            四象 = 四象.太阴;
        }
    }
}
