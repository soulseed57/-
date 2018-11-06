﻿namespace 阴阳易演.具象类.八卦
{
    using 抽象类;

    public class 坎 : 八卦
    {
        public 坎()
        {
            序数 = 6;
            本数 = 1;
            方位 = "正北";
            卦值 = 生成卦值("010");
            四象 = 四象.少阳;
        }
    }
}
