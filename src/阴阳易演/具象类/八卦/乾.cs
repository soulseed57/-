﻿namespace 阴阳易演.具象类.八卦
{
    using 抽象类;

    public class 乾 : 八卦
    {
        public 乾()
        {
            序数 = 1;
            本数 = 6;
            方位 = "西北";
            卦值 = 生成卦值("111");
            四象 = 四象.太阳;
        }
    }
}
