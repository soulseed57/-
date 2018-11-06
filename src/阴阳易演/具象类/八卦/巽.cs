﻿namespace 阴阳易演.具象类.八卦
{
    using 抽象类;

    public class 巽 : 八卦
    {
        public 巽()
        {
            序数 = 5;
            本数 = 4;
            方位 = "东南";
            卦值 = 生成卦值("011");
            四象 = 四象.少阳;
        }
    }
}
